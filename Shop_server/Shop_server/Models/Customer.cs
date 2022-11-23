using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Shop_server.interfaces;

namespace Shop_server.Models
{
    public class Customer : IItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        //navigation properties
        [JsonPropertyName("orders")]
        public List<Order> Orders { get; set; }

    }
}
