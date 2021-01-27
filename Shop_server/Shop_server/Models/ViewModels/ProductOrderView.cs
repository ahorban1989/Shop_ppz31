using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop_server.Models;

namespace Shop_server.Models.ViewModels
{
    public class ProductOrderView
    {
        public int Id { get; set; }
        public ProductView Product { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
