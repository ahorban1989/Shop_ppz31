using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_server.Data;
using Shop_server.Models;
using Shop_server.Models.ViewModels;

namespace Shop_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PmController : ControllerBase
    {
        private readonly ShopContext _context;

        public PmController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Pm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductView>>> GetProducts()
        {
            return await _context.Products.Include(p => p.Description).Select(p =>
                            new ProductView
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                Description = (p.Description == null)? null: p.Description.Info
                            }).ToListAsync();
        }

        // GET: api/Pm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductView>> GetProduct(int id)
        {
            var product = await _context.Products.Include(p => p.Description)
                                                 .SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            ProductView productView = new ProductView
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = (product.Description == null) ? null :
                               product.Description.Info

            };

            return productView;
        }

        // PUT: api/Pm/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product, string description)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var nevDescription = await _context.Descriptions.SingleOrDefaultAsync(d => d.ProductId == id);

            if (nevDescription != null)
            {
                nevDescription.Info = description;
                _context.Descriptions.Update(nevDescription);
            }
            else
            {
                nevDescription = new Description { Info = description, ProductId = id };
                _context.Descriptions.Add(nevDescription);
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Pm
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Pm/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var descriptions = await _context.Descriptions.Where(d => d.ProductId == id).ToListAsync();
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.Descriptions.RemoveRange(descriptions);
            await _context.SaveChangesAsync();

            return product;
        }



        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
