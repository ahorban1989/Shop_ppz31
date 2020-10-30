using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;

namespace Shop_PPZ_31.Controllers
{
    class ProductManager
    {
        public void CreateProduct()
        {
            Console.Write("Product name: ");
            string name = Console.ReadLine();
            Console.Write("Product price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Product product = new Product(name, price);
        }
    }
}
