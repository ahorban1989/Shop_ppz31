using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Shop_server.interfaces;

namespace Shop_server.Models
{
    public class ProductOrder : IItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductCount { get; set; }

        //navigation properties
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
