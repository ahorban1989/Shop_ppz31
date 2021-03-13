using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Shop_server.interfaces;

namespace Shop_server.Models
{
    public class Product : IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        //navigation properties
        public Description Description { get; set; }
    }
}
