using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_bharat_lawns.Data;
using api_bharat_lawns.DTO;
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
    [Authorize(Roles = $"{Roles.BookingRole}, {Roles.SuperUser}")]
    public class ProgramTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProgramTypeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(Pager<ProgramType> pager)
        {
            var programTypesQ = _context.ProgramTypes.AsQueryable();
            var q = pager.Query?.Trim();
            if (!string.IsNullOrEmpty(q))
            {
                programTypesQ = programTypesQ.Where(x => x.Name.Contains(q));
            }
            var programType = await pager.Paginate(programTypesQ).ToListAsync();
            return Ok(new ResponseData<ProgramType>(programType, pager));
        }

        // GET: api/ProgramType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var programType = await _context.ProgramTypes.FindAsync(id);
            if (programType == null)
            {
                return NotFound();
            }
            return Ok(programType);
        }

        // POST: api/ProgramType
        [HttpPost]
        public async Task<IActionResult> Create(ProgramType programType)
        {
            _context.ProgramTypes.Add(programType);
            await _context.SaveChangesAsync();
            return Ok(programType);
        }

        // Delete: api/ProgramType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var programType = await _context.ProgramTypes.FindAsync(id);
            if (programType == null)
            {
                return NotFound();
            }
            _context.ProgramTypes.Remove(programType);
            await _context.SaveChangesAsync();
            return Ok(programType);
        }

        // PUT: api/ProgramType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProgramType programType)
        {
            if (id != programType.Id)
            {
                return BadRequest();
            }
            _context.Entry(programType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(programType);
        }

    }
}
