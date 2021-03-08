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
    public class HrController : ControllerBase
    {
        private readonly ShopContext _context;

        public HrController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/Hr
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = _context.Employees.Include(e => e.Orders).Select(e =>
            
            new Employee
            {
                Id = e.Id,
                Name = e.Name,
                Surname = e.Surname,
                Position = e.Position,
                ChiefId = e.ChiefId,
                Chief = (e.Chief == null)? null:
                    new Employee
                    {
                        Id = e.Chief.Id,
                        Name = e.Chief.Name,
                        Surname = e.Chief.Position,
                        ChiefId = e.Chief.ChiefId,
                        Chief = null
                    },
                Orders = e.Orders
            }) ;
            return await employees.ToListAsync();
        }

        // GET: api/Hr/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees.Include(e => e.Orders)
                .ThenInclude(o => o.ProductOrders)
                .ThenInclude(p => p.Product)
                .Select(e =>
                    new Employee
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Surname = e.Surname,
                        Position = e.Position,
                        ChiefId = e.ChiefId,
                        Chief = (e.Chief == null) ? null :
                            new Employee
                            {
                                Id = e.Chief.Id,
                                Name = e.Chief.Name,
                                Surname = e.Chief.Position,
                                ChiefId = e.Chief.ChiefId,
                                Chief = null,
                                Orders = null
                            },
                        Orders = e.Orders.Select(o =>
                            new Order
                            {
                                Id = o.Id,
                                CustomerId = o.Id,
                                EmployeeId = o.EmployeeId,
                                Customer = new Customer 
                                { 
                                    Id = o.Customer.Id,
                                    Name = o.Customer.Name,
                                    Surname = o.Customer.Surname,
                                    Orders = null
                                },
                                ProductOrders = o.ProductOrders.Select(p =>
                                        new ProductOrder
                                        {
                                            Id = p.Id,
                                            ProductId = p.ProductId,
                                            ProductPrice = p.ProductPrice,
                                            OrderId = p.OrderId,
                                            Order = null,
                                            ProductCount = p.ProductCount,
                                            Product = p.Product
                                        }
                                    ).ToList()
                            }
                        ).ToList()
                    }
                ).FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;

        }

        // PUT: api/Hr/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Hr
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Hr/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
