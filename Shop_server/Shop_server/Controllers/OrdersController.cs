using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop_server.Data;
using Shop_server.Models;

namespace Shop_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ShopContext _context;

        public OrdersController(ShopContext context)
        {
            _context = context;
        }


        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.Include(c => c.Employee)
                .Include(c => c.Customer)
                .Include(c => c.ProductOrders)
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p.Description)
                .Select(o => new Order 
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        EmployeeId = o.EmployeeId,
                        Customer = new Customer
                        {
                            Id = o.Customer.Id,
                            Name = o.Customer.Name,
                            Surname = o.Customer.Surname,
                            Orders = null
                        },
                        Employee = new Employee
                        {
                            Id = o.Employee.Id,
                            Name = o.Employee.Name,
                            Surname = o.Employee.Surname,
                            Position = o.Employee.Position,
                            ChiefId = o.Employee.ChiefId,
                            Chief = null,
                            Orders = null
                        },
                        ProductOrders = o.ProductOrders.Select(p => new ProductOrder
                        {
                            Id = p.Id,
                            OrderId = p.OrderId,
                            ProductId = p.ProductId,
                            ProductCount = p.ProductCount,
                            Product = p.Product,
                            Order = null

                        }).ToList()
                    })
                .SingleOrDefaultAsync(o => o.Id == id);
                

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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


        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        // POST: api/Orders/5/addProduct/1/
        [HttpPost("{id}/addProduct/{productId}/{count}")]
        public async Task<ActionResult<ProductOrder>> AddProduct(int id, int productId, int count)
        {
            var order = await _context.Orders.FindAsync(id);
            var product = await _context.Products.FindAsync(productId);
            if (order == null || product == null)
            {
                return BadRequest();
            }

            var newProduct = new ProductOrder
            {
                OrderId = id,
                ProductId = productId,
                ProductCount = count,
                ProductPrice = product.Price

            };

            _context.ProductOrders.Add(newProduct);
            await _context.SaveChangesAsync();

            return newProduct;

        }

        // DELETE: api/Orders/5/deleteProduct/1/
        [HttpDelete("{id}/deleteProduct/{productId}")]
        public async Task<ActionResult<ProductOrder>> deleteProduct (int id, int productId)
        {
            var product = await _context.ProductOrders.FindAsync(productId);

            if(product == null || product.OrderId != id)
            {
                return BadRequest();
            }

            _context.ProductOrders.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }


        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
