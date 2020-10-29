using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    class Employee : IItem
    {
        private static int count = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int ChiefId { get; set; }
        public Employee(string Name, string Surname, string Position, int ChiefId)
        {
            this.Id = count++;
            this.Name = Name;
            this.Surname = Surname;
            this.Position = Position;
            this.ChiefId = ChiefId;
        }
        public override string ToString()
        {
            return string.Format($"id: {Id}, name: {Name}, Surname: {Surname}, position: {Position}, chiefId: {ChiefId}");
        }
    }
}
