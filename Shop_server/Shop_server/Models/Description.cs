using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop_server.interfaces;

namespace Shop_server.Models
{
    public class Description : IItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Info { get; set; }

        //navigation properties
        public Product Product { get; set; }
    }
}
