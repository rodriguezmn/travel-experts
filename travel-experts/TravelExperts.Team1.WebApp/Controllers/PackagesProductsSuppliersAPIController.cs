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
    public class PackagesProductsSuppliersAPIController : ControllerBase
    {
        private readonly TravelExpertsContext _context;

        public PackagesProductsSuppliersAPIController(TravelExpertsContext context)
        {
            _context = context;
        }

        // GET: api/PackagesProductsSuppliersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackagesProductsSuppliers>>> GetPackagesProductsSuppliers()
        {
            return await _context.PackagesProductsSuppliers.ToListAsync();
        }

        // GET: api/PackagesProductsSuppliersAPI/5
        [HttpGet("{id1},{id2}")]
        public async Task<ActionResult<PackagesProductsSuppliers>> GetPackagesProductsSuppliers(int id1, int id2)
        {
            var packagesProductsSuppliers = await _context.PackagesProductsSuppliers.FindAsync(id1, id2);

            if (packagesProductsSuppliers == null)
            {
                return NotFound();
            }

            return packagesProductsSuppliers;
        }

        // PUT: api/PackagesProductsSuppliersAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id1},{id2}")]
        public async Task<IActionResult> PutPackagesProductsSuppliers(int id1, int id2, PackagesProductsSuppliers packagesProductsSuppliers)
        {
            if (id1 != packagesProductsSuppliers.PackageId)
            {
                return BadRequest();
            }

            _context.Entry(packagesProductsSuppliers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackagesProductsSuppliersExists(id1, id2))
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

        // POST: api/PackagesProductsSuppliersAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PackagesProductsSuppliers>> PostPackagesProductsSuppliers(PackagesProductsSuppliers packagesProductsSuppliers)
        {
            _context.PackagesProductsSuppliers.Add(packagesProductsSuppliers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PackagesProductsSuppliersExists(packagesProductsSuppliers.PackageId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPackagesProductsSuppliers", new { id = packagesProductsSuppliers.PackageId }, packagesProductsSuppliers);
        }

        // DELETE: api/PackagesProductsSuppliersAPI/5
        [HttpDelete("{id1},{id2}")]
        public async Task<ActionResult<PackagesProductsSuppliers>> DeletePackagesProductsSuppliers(int id1, int id2)
        {
            var packagesProductsSuppliers = await _context.PackagesProductsSuppliers.FindAsync(id1, id2);
            if (packagesProductsSuppliers == null)
            {
                return NotFound();
            }

            _context.PackagesProductsSuppliers.Remove(packagesProductsSuppliers);
            await _context.SaveChangesAsync();

            return packagesProductsSuppliers;
        }

        private bool PackagesProductsSuppliersExists(int id)
        {
            return _context.PackagesProductsSuppliers.Any(e => e.PackageId == id);
        }
        private bool PackagesProductsSuppliersExists(int id1, int id2)
        {
            return _context.PackagesProductsSuppliers.Any(e => e.PackageId == id1 && e.ProductSupplierId == id2);
        }
    }
}
