using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop_server.Models;
using Microsoft.EntityFrameworkCore;

namespace Shop_server.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
    }
}
