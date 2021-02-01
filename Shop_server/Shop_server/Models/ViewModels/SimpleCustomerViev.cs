using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_server.Models.ViewModels
{
    public class SimpleCustomerViev
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<SimpleOrderView> Orders { get; set; }
    }
}
