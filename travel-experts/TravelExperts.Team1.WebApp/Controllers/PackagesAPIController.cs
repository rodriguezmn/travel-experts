using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelExperts.Team1.WebApp.Models;

namespace TravelExperts.Team1.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesAPIController : ControllerBase
    {
        private readonly TravelExpertsContext _context;

        public PackagesAPIController(TravelExpertsContext context)
        {
            _context = context;
        }

        // GET: api/PackagesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Packages>>> GetPackages()
        {
            return await _context.Packages.ToListAsync();
        }

        // GET: api/PackagesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Packages>> GetPackages(int id)
        {
            var packages = await _context.Packages.FindAsync(id);

            if (packages == null)
            {
                return NotFound();
            }

            return packages;
        }

        // PUT: api/PackagesAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackages(int id, Packages packages)
        {
            if (id != packages.PackageId)
            {
                return BadRequest();
            }

            _context.Entry(packages).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackagesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PackagesAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Packages>> PostPackages(Packages packages)
        {
            _context.Packages.Add(packages);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackages", new { id = packages.PackageId }, packages);
        }

        // DELETE: api/PackagesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Packages>> DeletePackages(int id)
        {
            var packages = await _context.Packages.FindAsync(id);
            if (packages == null)
            {
                return NotFound();
            }

            _context.Packages.Remove(packages);
            await _context.SaveChangesAsync();

            return packages;
        }

        private bool PackagesExists(int id)
        {
            return _context.Packages.Any(e => e.PackageId == id);
        }
    }
}
