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
    public class CmController : ControllerBase
    {
        private readonly ShopContext _context;

        public CmController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Cm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.Include(c => c.Orders).Select(c =>
                new Customer
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Orders = c.Orders
                }
            ).ToListAsync();
        }

        // GET: api/Cm/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.ProductOrders)
                    .ThenInclude(po => po.Product)
                    .Include(c => c.Orders)
                    .ThenInclude(o => o.Employee)
                    .Select(c =>
                        new Customer
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Surname = c.Surname,
                            Orders = c.Orders.Select(o =>
                                new Order
                                {
                                    Id = o.Id,
                                    CustomerId = o.CustomerId,
                                    EmployeeId = o.EmployeeId,
                                    Customer = null,
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
                                    ProductOrders = o.ProductOrders.Select(po => 
                                        new ProductOrder
                                        {
                                            Id = po.Id,
                                            ProductId = po.ProductId,
                                            ProductPrice = po.ProductPrice,
                                            OrderId = po.OrderId,
                                            ProductCount = po.ProductCount,
                                            Product = po.Product
                                        }
                                    ).ToList()
                                }
                            ).ToList()
                        }

                    ).SingleOrDefaultAsync(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Cm/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Cm
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Cm/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        // POST: api/Cm/5/addorder
        [HttpPost("{id}/addorder")]
        public async Task<ActionResult<Order>> PostOrder(int id, Order order)
        {
            if (order.CustomerId != id)
            {
                return BadRequest();
            }

            order.Employee = null;
            order.Customer = null;
            order.ProductOrders = null;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;

            
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
