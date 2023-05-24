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
    [Authorize(Roles.SuperUser)]
    public class FunctionTypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FunctionTypeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(Pager<FunctionType> pager)
        {
            var functionTypesQ = _context.FunctionTypes.AsQueryable();
            var functionType = await pager.Paginate(functionTypesQ).ToListAsync();
            return Ok(new ResponseData<FunctionType>(functionType, pager));
        }
        // GET: api/FunctionType/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var functionType = await _context.FunctionTypes.FindAsync(id);
            if (functionType == null)
            {
                return NotFound();
            }
            return Ok(functionType);
        }

        // POST: api/FunctionType
        [HttpPost]
        public async Task<IActionResult> Create(FunctionType functionType)
        {
            _context.FunctionTypes.Add(functionType);
            await _context.SaveChangesAsync();
            return Ok(functionType);
        }

        // Delete: api/FunctionType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var functionType = await _context.FunctionTypes.FindAsync(id);
            if (functionType == null)
            {
                return NotFound();
            }

            _context.FunctionTypes.Remove(functionType);
            await _context.SaveChangesAsync();
            return Ok(functionType);
        }

        // PUT: api/FunctionType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, FunctionType functionType)
        {
            if (id != functionType.Id)
            {
                return BadRequest();
            }
            _context.Entry(functionType).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(functionType);
        }

    }
}
