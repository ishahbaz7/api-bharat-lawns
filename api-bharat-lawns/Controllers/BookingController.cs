using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bharat_lawns.Data;
using api_bharat_lawns.DTO;
using api_bharat_lawns.Helper;
using api_bharat_lawns.Model;
using api_bharat_lawns.Response;
using api_bharat_lawns.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_bharat_lawns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("get-all")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}, {Roles.ReportsRole}")]
        public async Task<IActionResult> GetAll(Pager<Booking> pager, DateTime? month, bool? pending)
        {
            var bookingsQ = _context.Bookings.
                Include(x => x.Features).
                Include(x => x.FunctionTypes).
                Include(x => x.ProgramTypes).
                AsQueryable();
            if (month != null)
            {
                var firstDay = new DateTime(month.Value.Year, month.Value.Month, 1);
                var lastDay = firstDay.AddMonths(1).AddDays(-1);
                bookingsQ = bookingsQ.Where(x =>
                x.FunctionDate.Date >= firstDay &&
                x.FunctionDate.Date <= lastDay);
            }
            else if (pending == true)
            {
                bookingsQ = bookingsQ.Where(x => x.Balance > 0 && x.Status != Status.Cancelled);
            }
            var q = pager.Query.Trim();
            if (!string.IsNullOrEmpty(q))
            {
                bookingsQ = bookingsQ.Where(x => x.Name.Contains(q) || x.MobileNo.Contains(q));
            }
            var bookings = await pager.Paginate(bookingsQ).ToListAsync();
            return Ok(new ResponseData<Booking>(bookings, pager));
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> Get(int id)
        {
            var booking = _context.Bookings.
            Include(x => x.Features).
            Include(x => x.FunctionTypes).
            Include(x => x.ProgramTypes).
            FirstOrDefault(i => i.Id == id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> Post(BookingDTO modal)
        {
            var user = await AuthHelper.GetUser(User, _context);
            if (user == null)
                return Unauthorized();

            if (modal.MealType != MealType.NonVeg && modal.MealType != MealType.Veg)
                ModelState.AddModelError("MealType", "Please Select Meal Type");
            var programType = await _context.ProgramTypes.FindAsync(modal.ProgramTypeId);
            var isBookings = await _context.Bookings.Where(x => x.FunctionDate.Date == modal.FunctionDate.Date).Include(x => x.ProgramTypes).ToListAsync();

            if (isBookings != null && isBookings.Count > 0)
            {
                if (isBookings.Count >= 2)
                    ModelState.AddModelError("FunctionDate", "Booking already exist for this date");
                else
                {
                    var isBooking = isBookings.FirstOrDefault();
                    if (isBooking.ProgramTypes.Name.ToLower() == "full day" ||
                        programType.Name.ToLower() == "full day")
                        ModelState.AddModelError("FunctionDate", "Booking already exist for this date");
                    if (isBooking.ProgramTypes.Id == modal.ProgramTypeId)
                        ModelState.AddModelError("ProgramTypeId", "Booking already exist for this slot");
                }
            }

            if (modal.Balance > modal.Amount)
                ModelState.AddModelError("Balance", "Balance cannot be greater than amount");

            if (!ModelState.IsValid)
                return BadRequest(new ResponseErrors(ModelState.ToSerializedDictionary()));

            var invNo = 1;
            var lastInv = await _context.Invoices.OrderByDescending(x => x.InvoiceNo).FirstOrDefaultAsync();
            if (lastInv != null && lastInv.InvoiceNo != null)
                invNo = (int)lastInv.InvoiceNo + 1;
            var booking = MapperConfig.Map<BookingDTO, Booking>(modal);
            booking.CreatedById = user.Id;
            booking.Status = Status.Active;
            booking.InvoiceNo = invNo;
            if (modal.FeatureIds?.Length > 0)
            {
                var features = await _context.Features.Where(x => modal.FeatureIds.Contains(x.Id)).ToListAsync();
                booking.Features = features;
            }


            var invoice = new Invoice
            {
                InvoiceNo = invNo,
                Booking = booking,
                TotalAmount = booking.Amount,
                Balance = booking.Balance,
                Advance = modal.Advance,
                Status = modal.Balance == 0 ? InvoiceStatus.Paid : modal.Advance > 0 ? InvoiceStatus.Partial : InvoiceStatus.UnPaid,
                CreatedById = user.Id
            };
            var receipt = new PaymentReceipt
            {
                Invoice = invoice,
                Amount = modal.Advance,
                PaymentMode = PaymentMode.Cash,
                PaymentType = PaymentType.Advance,
                CreatedById = user.Id
            };
            await _context.PaymentReceipts.AddAsync(receipt);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { booking, receipt });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> Put(int id, BookingDTO modal)
        {
            var user = await AuthHelper.GetUser(User, _context);
            if (user == null)
                return Unauthorized();

            var features = await _context.Features.Where(x => modal.FeatureIds.Contains(x.Id)).ToListAsync();
            if (id != modal.Id)
                return BadRequest();
            var booking = _context.Bookings.
                Include(x => x.Features).
                FirstOrDefault(x => x.Id == id);
            if (booking == null)
                return NotFound();
            booking.Features.RemoveAll(x => booking.Features.Any(y => y.Id == x.Id));
            booking.Features = features;
            booking.FunctionTypeId = modal.FunctionTypeId;
            booking.ProgramTypeId = modal.ProgramTypeId;
            booking.MealType = modal.MealType;
            booking.Name = modal.Name;
            booking.MobileNo = modal.MobileNo;
            booking.FunctionDate = modal.FunctionDate;
            booking.UpdatedById = user.Id;
            booking.UpdatedAt = DateTime.Now;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            var programType = await _context.ProgramTypes.Where(x => x.Id == booking.ProgramTypeId).FirstOrDefaultAsync();
            var functionType = await _context.FunctionTypes.Where(x => x.Id == booking.FunctionTypeId).FirstOrDefaultAsync();
            booking.ProgramTypes = programType;
            booking.FunctionTypes = booking.FunctionTypes;
            return Ok(booking);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(x => x.Id == id);

            if (booking == null)
                return NotFound();

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return Ok(booking);
        }

        [HttpPut("cancel/{id}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(i => i.Id == id);
            if (booking == null)
                return NotFound();
            booking.Status = Status.Cancelled;
            booking.CancellationDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok("ok");
        }

        [HttpGet("get-events/{date}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> GetEventsByMonth(DateTime date)
        {
            var start = new DateTime(date.Year, date.Month, 1).AddDays(-7);
            var end = start.AddMonths(1).AddDays(14);
            var bookings = await _context.Bookings.Where(x =>
                x.FunctionDate.Date > start &&
                x.FunctionDate.Date < end &&
                x.Status != Status.Cancelled).
                Include(x => x.ProgramTypes).
                Select(x => new EventDto
                {
                    Id = x.Id,
                    Title = x.ProgramTypes.Name,
                    Start = x.FunctionDate,
                    End = x.FunctionDate,
                    Status = x.Status
                }).OrderBy(x => x.Start).ToListAsync();
            return Ok(bookings);
        }

        [HttpPost("pending-balance/{id}/{amount}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<ActionResult> CollectPendingBalance(int id, decimal amount)
        {
            var booking = await _context.Bookings.Where(x => x.Id == id).Include(x => x.Invoice).FirstOrDefaultAsync();
            if (amount > booking.Balance || amount <= 0)
                ModelState.AddModelError("amount", "Amount cannot be greater than balance or less than 0");
            if (booking.Status == Status.Cancelled)
                ModelState.AddModelError("amount", "This booking was cancelled");

            if (!ModelState.IsValid)
                return BadRequest(new ResponseErrors(ModelState.ToSerializedDictionary()));
            var user = await AuthHelper.GetUser(User, _context);
            var receipt = new PaymentReceipt
            {
                Amount = amount,
                CreatedAt = DateTime.Now,
                CreatedById = user.Id,
                InvoiceId = booking.Invoice.Id,
                PaymentType = PaymentType.Partial
            };
            booking.Balance -= amount;
            booking.Invoice.Balance -= amount;
            try
            {
                await _context.PaymentReceipts.AddAsync(receipt);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(receipt);
        }

        [HttpGet("get-receipts/{bookingId}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<IActionResult> GetReciepts(int bookingId)
        {
            var receipts = await _context.PaymentReceipts.OrderByDescending(x => x.CreatedAt).Where(x => x.Invoice.Booking.Id == bookingId).
            Select(x => new
            {
                Id = x.Id,
                Date = x.CreatedAt,
                Amount = x.Amount,
                BookingName = x.Invoice.Booking.Name,
                InvoiceNo = x.Invoice.InvoiceNo,
                BookingId = x.Invoice.Booking.Id,
            })
            .ToListAsync();

            return Ok(receipts);
        }

        [HttpGet("print-receipt/{receiptId}")]
        [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
        public async Task<ActionResult> PrintReceipt(int receiptId)
        {
            var receipt = await _context.PaymentReceipts.Where(x => x.Id == receiptId).
                Select(a => new
                {
                    ReceiptDate = a.CreatedAt,
                    Name = a.Invoice.Booking.Name,
                    MobileNo = a.Invoice.Booking.MobileNo,
                    FunctionDate = a.Invoice.Booking.FunctionDate,
                    ProgramTiming = a.Invoice.Booking.ProgramTypes.Name,
                    InvoiceNo = a.Invoice.InvoiceNo,
                    ReceiptNo = a.Id,
                    Features = a.Invoice.Booking.Features,
                    OtherFeatures = a.Invoice.Booking.OtherFeatures,
                    Amount = a.Amount,
                    PaymentType = a.PaymentType

                }).FirstOrDefaultAsync();
            return Ok(receipt);
        }
    }

}
