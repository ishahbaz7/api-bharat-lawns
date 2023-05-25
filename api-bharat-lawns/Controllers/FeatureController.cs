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
    [Authorize(Roles = Roles.SuperUser)]
    public class FeatureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeatureController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/Feature
        [HttpPost("get-all")]
        public async Task<IActionResult> GetAll(Pager<Feature> pager)
        {
            var featuresQ = _context.Features.AsQueryable();
            var q = pager.Query?.Trim();
            if (!string.IsNullOrEmpty(q))
            {
                featuresQ = featuresQ.Where(x => x.Name.Contains(q));
            }
            var feature = await pager.Paginate(featuresQ).ToListAsync();
            return Ok(new ResponseData<Feature>(feature, pager));
        }
        // GET: api/Feature/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }
        // POST: api/Feature
        [HttpPost]
        public async Task<IActionResult> Create(Feature feature)
        {
            _context.Features.Add(feature);
            await _context.SaveChangesAsync();
            return Ok(feature);
        }
        // Delete: api/Feature/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // PUT: api/Feature/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Feature feature)
        {
            if (id != feature.Id)
            {
                return BadRequest();
            }
            _context.Entry(feature).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
