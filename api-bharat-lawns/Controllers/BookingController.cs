using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bharat_lawns.Data;
using api_bharat_lawns.DTO;
using api_bharat_lawns.Helper;
using api_bharat_lawns.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_bharat_lawns.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles.SuperUser)]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int pageLength = 10)
        {
            int skip = page > 1 ? (page - 1) * pageLength : 0;
            // var bookings = _context.Bookings.Include(x => x.BookingInvoices).Include(x => x.FunctionTypes).
            //     Skip(skip).
            //     Take(pageLength).
            //     OrderBy(x => x.FunctionDate);
            // return Ok(bookings);
            return Ok();
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
        public async Task<IActionResult> Post(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
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
