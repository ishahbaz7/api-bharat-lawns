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
            var booking = _context.Bookings.FirstOrDefault(i => i.Id == id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookingDTO modal)
        {
            var user = await AuthHelper.GetUser(User, _context);
            if (user == null)
                return Unauthorized();
            var booking = MapperConfig.Map<BookingDTO, Booking>(modal);
            booking.CreatedById = user.Id;
            var features = await _context.Features.Where(x => modal.FeatureIds.Contains(x.Id)).ToListAsync();
            booking.Features = features;
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
        public async Task<IActionResult> Put(int id, Booking updatedBooking)
        {
            if (id != updatedBooking.Id)
                return BadRequest();
            var booking = _context.Bookings.
                Include(x => x.FunctionTypes).
                FirstOrDefault(x => x.Id == id);

            if (booking == null)
                return NotFound();

            // booking.Name = updatedBooking.Name;
            // booking.FunctionDate = updatedBooking.FunctionDate;
            // booking.MobileNo = updatedBooking.MobileNo;
            // booking.StageDecoration = updatedBooking.StageDecoration;
            // booking.Anjuman = updatedBooking.Anjuman;
            // booking.Mandap = updatedBooking.Mandap;
            // booking.Entry = updatedBooking.Entry;
            // booking.Chowrie = updatedBooking.Chowrie;
            // booking.CateringService = updatedBooking.CateringService;
            // booking.OtherFeatures = updatedBooking.OtherFeatures;
            // booking.ProgramTimings = updatedBooking.ProgramTimings;
            // booking.MealType = updatedBooking.MealType;
            // booking.FunctionTypeId = updatedBooking.FunctionTypes.Id;
            await _context.SaveChangesAsync();
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

        [HttpPut("cancel-booking/{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            if (id == 0)
                return NotFound();

            var booking = _context.Bookings.FirstOrDefault(i => i.Id == id);
            if (booking == null)
                return NotFound();
            booking.Status = Status.Cancelled;
            await _context.SaveChangesAsync();

            return Ok("ok");
        }
    }

}
