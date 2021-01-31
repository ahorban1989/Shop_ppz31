using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_server.Models.ViewModels
{
    public class EmployeeView
    {
        public SimpleEmployeeView Employee { get; set; }
        public List<SimpleOrderView> Orders { get; set; }
    }
}
