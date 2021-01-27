using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_server.Models.ViewModels
{
    public class SimpleEmployeeView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Position { get; set; }
        
        public SimpleEmployeeView Chief { get; set; }
    }
}
