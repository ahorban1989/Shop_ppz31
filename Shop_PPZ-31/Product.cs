using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31
{
    class Product
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
            return string.Format($"{Id} {Name} {Price}");
        }
    }
}
