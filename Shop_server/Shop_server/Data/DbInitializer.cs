using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Shop_server.Models;

namespace Shop_server.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            //add products
            var products = new Product[]
            {
                new Product{Name = "Prodyct1", Price = 10},
                new Product{Name = "Product2", Price = 20},
                new Product{Name = "Product3", Price = 15}
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            //add descriptions
            var descriptions = new Description[]
            {
                new Description{Info = "description for product 1", ProductId =  1},
                new Description{Info = "description for product 2", ProductId = 2},
                new Description{Info = "description for product 3", ProductId = 3}
            };
            foreach (Description d in descriptions)
            {
                context.Descriptions.Add(d);
            }
            context.SaveChanges();

            //add employees
            var employees = new Employee[]
            {
                new Employee{Name = "Ivan", Surname = "Popov", Position = "boos"},
                new Employee{Name = "Pavel", Surname = "katkov", Position = "Manager", ChiefId = 1 },
                new Employee{Name = "oleg", Surname = "Ivanov", Position = "Manager", ChiefId = 1}
            };
            foreach (Employee e in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            //add clients
            var customers = new Customer[]
{
                new Customer{Name = "Igor", Surname = "Volkov"},
                new Customer{Name = "Maxim", Surname = "Katkov"},
                new Customer{Name = "Andrey", Surname = "Samosvalov"}
};
            foreach (Customer c in customers)
            {
                context.Customers.Add(c);
            }
            context.SaveChanges();
        }
    }
}
