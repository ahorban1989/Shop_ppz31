using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31
{
    class Customer
    {
        private static int count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Customer(string Name, string Surname)
        {
            this.Id = count++;
            this.Name = Name;
            this.Surname = Surname;
        }
        public override string ToString()
        {
            return string.Format($"{Id} {Name} {Surname}");
        }
    }
}
