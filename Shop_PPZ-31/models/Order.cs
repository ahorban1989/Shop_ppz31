using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    class Order : IItem
    {
        private static int count = 1;
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public Order(int CustomerId, int EmployeeId)
        {
            this.Id = count++;
            this.CustomerId = CustomerId;
            this.EmployeeId = EmployeeId;
        }
        public override string ToString()
        {
            return string.Format($"id: {Id}, cjstunerId: {CustomerId}, employeeId: {EmployeeId}");
        }
    }
}
