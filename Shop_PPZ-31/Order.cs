using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31
{
    class Order
    {
        private static int count = 1;
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string OrderName { get; set; }
        public Order(int CustomerId, int EmployeeId, string OrderName)
        {
            this.Id = count++;
            this.CustomerId = CustomerId;
            this.EmployeeId = EmployeeId;
            this.OrderName = OrderName;
        }
        public override string ToString()
        {
            return string.Format($"{Id} {CustomerId} {EmployeeId} {OrderName}");
        }
    }
}
