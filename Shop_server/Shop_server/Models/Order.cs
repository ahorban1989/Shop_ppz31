using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Shop_server.interfaces;

namespace Shop_server.Models
{
    public class Order : IItem
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }

        //navigation properties
        public List<ProductOrder> ProductOrders { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
