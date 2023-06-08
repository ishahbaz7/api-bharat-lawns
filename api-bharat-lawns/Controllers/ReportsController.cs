using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bharat_lawns.Data;
using api_bharat_lawns.DTO;
using api_bharat_lawns.Helper;
using api_bharat_lawns.Model;
using api_bharat_lawns.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_bharat_lawns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = $"{Roles.ReportsRole}, {Roles.SuperUser}")]
    public class ReportsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("month/{month}")]
        public async Task<ActionResult<IEnumerable>> GetReportsByMonth(DateTime month, Pager<Booking> pager)
        {
            var user = await AuthHelper.GetUser(User, _context);
            var firstDay = new DateTime(month.Year, month.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);
            var bookings = pager.Paginate(_context.Bookings.AsQueryable());
            var reports = await bookings.Where(x =>
                    x.CreatedAt.Date >= firstDay &&
                    x.CreatedAt.Date <= lastDay).
                    GroupBy(x => new { x.CreatedAt.Date }).OrderBy(x => x.Key.Date)
                    .Select(x => new Reports
                    {

                        BookingsValue = x.Sum(i => i.Amount),
                        Bookings = x.Count(),
                        PendingAmount = x.Sum(i => i.Balance),
                        Morning = x.Count(i => i.ProgramTypes.Name == "Morning"),
                        Evening = x.Count(i => i.ProgramTypes.Name == "Evening"),
                        FullDay = x.Count(i => i.ProgramTypes.Name == "Full Day"),
                        Date = x.Key.Date,
                        Collection = _context.PaymentReceipts.Where(i => x.Select(i => i.InvoiceId).Contains(i.InvoiceId)).Sum(i => i.Amount),
                    }).ToListAsync();
            return Ok(new ResponseData<Reports>(reports, pager));

        }

        [HttpGet("year/{year}")]
        public async Task<ActionResult<IEnumerable>> GetReportsByYear(int year)
        {
            var user = await AuthHelper.GetUser(User, _context);
            var firstDay = new DateTime(year, 1, 1);
            var lastDay = firstDay.AddYears(1).AddDays(-1);
            var coll = _context.Bookings.Where(x =>
                    x.CreatedAt.Date >= firstDay &&
                    x.CreatedAt.Date <= lastDay).
                    GroupBy(x => new { x.CreatedAt.Year, x.CreatedAt.Month }).
                    OrderBy(x => x.Key.Month)
                    .Select(x => new Reports
                    {
                        Collection = _context.PaymentReceipts.Where(i => x.Select(i => i.InvoiceId).Contains(i.InvoiceId)).Sum(i => i.Amount),
                        BookingsValue = x.Sum(i => i.Amount),
                        PendingAmount = x.Sum(i => i.Balance),
                        Bookings = x.Count(),
                        Morning = x.Count(i => i.ProgramTypes.Name == "Morning"),
                        Evening = x.Count(i => i.ProgramTypes.Name == "Evening"),
                        FullDay = x.Count(i => i.ProgramTypes.Name == "Full Day"),
                        Date = new DateTime(x.Key.Year, x.Key.Month, 1)

                    });

            return Ok(coll);
        }

    }
}
