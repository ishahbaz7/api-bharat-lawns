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
    [Authorize(Roles = Roles.SuperUser)]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(Pager<Booking> pager)
        {
            var bookingsQ = _context.Bookings.
                Include(x => x.Features).
                Include(x => x.FunctionTypes).
                Include(x => x.ProgramTypes).
                AsQueryable();
            var q = pager.Query;
            if (!string.IsNullOrEmpty(q))
            {
                bookingsQ = bookingsQ.Where(x => x.Name.Contains(q) || x.MobileNo.Contains(q));
            }
            var bookings = await pager.Paginate(bookingsQ).ToListAsync();
            return Ok(new ResponseData<Booking>(bookings, pager));
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
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
        public async Task<IActionResult> Post(BookingDTO modal)
        {
            if (modal.MealType != MealType.NonVeg && modal.MealType != MealType.Veg)
            {
                ModelState.AddModelError("MealType", "Please Select Meal Type");
                return BadRequest(new ResponseErrors(ModelState.ToSerializedDictionary()));
            }
            var user = await AuthHelper.GetUser(User, _context);
            if (user == null)
                return Unauthorized();
            var booking = MapperConfig.Map<BookingDTO, Booking>(modal);
            booking.CreatedById = user.Id;
            booking.Status = Status.Active;
            if (modal.FeatureIds?.Length > 0)
            {
                var features = await _context.Features.Where(x => modal.FeatureIds.Contains(x.Id)).ToListAsync();
                booking.Features = features;
            }
            var invoice = new Invoice
            {
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
            return Ok(booking);
        }

        [HttpPut("{id}")]
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
    }

}
