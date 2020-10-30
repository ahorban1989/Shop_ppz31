using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    class Customer : IItem
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
            return string.Format($"id: {Id}, name: {Name}, surname: {Surname}");
        }
    }
}
