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
    public class ProductsSuppliersAPIController : ControllerBase
    {
        private readonly TravelExpertsContext _context;

        public ProductsSuppliersAPIController(TravelExpertsContext context)
        {
            _context = context;
        }

        // GET: api/ProductsSuppliersAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsSuppliers>>> GetProductsSuppliers()
        {
            return await _context.ProductsSuppliers.ToListAsync();
        }

        // GET: api/ProductsSuppliersAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsSuppliers>> GetProductsSuppliers(int id)
        {
            var productsSuppliers = await _context.ProductsSuppliers.FindAsync(id);

            if (productsSuppliers == null)
            {
                return NotFound();
            }

            return productsSuppliers;
        }

        // PUT: api/ProductsSuppliersAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductsSuppliers(int id, ProductsSuppliers productsSuppliers)
        {
            if (id != productsSuppliers.ProductSupplierId)
            {
                return BadRequest();
            }

            _context.Entry(productsSuppliers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsSuppliersExists(id))
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

        // POST: api/ProductsSuppliersAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductsSuppliers>> PostProductsSuppliers(ProductsSuppliers productsSuppliers)
        {
            _context.ProductsSuppliers.Add(productsSuppliers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductsSuppliers", new { id = productsSuppliers.ProductSupplierId }, productsSuppliers);
        }

        // DELETE: api/ProductsSuppliersAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductsSuppliers>> DeleteProductsSuppliers(int id)
        {
            var productsSuppliers = await _context.ProductsSuppliers.FindAsync(id);
            if (productsSuppliers == null)
            {
                return NotFound();
            }

            _context.ProductsSuppliers.Remove(productsSuppliers);
            await _context.SaveChangesAsync();

            return productsSuppliers;
        }

        private bool ProductsSuppliersExists(int id)
        {
            return _context.ProductsSuppliers.Any(e => e.ProductSupplierId == id);
        }
    }
}
