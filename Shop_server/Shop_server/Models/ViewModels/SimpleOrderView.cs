using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_server.Models.ViewModels
{
    public class SimpleOrderView
    {
        public int Id { get; set; }
        public int ProductsCount { get; set; }
        public decimal Sum { get; set; }

    }
}
