using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    class Product : IItem
    {
        private static int count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Product(string Name, decimal Price)
        {
            this.Id = count++;
            this.Name = Name;
            this.Price = Price;
        }
        public override string ToString()
        {
            return string.Format($"id: {Id}, name: {Name}, price: {Price}");
        }
    }
}
