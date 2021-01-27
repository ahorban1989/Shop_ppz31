using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_server.Models.ViewModels
{
    public class OrderView
    {
        public int Id { get; set; }
        public List<ProductOrderView> PproductOrderViews { get; set; }
    }
}
