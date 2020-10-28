using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31
{
    class ProductOrder
    {
        private static int count = 1;
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductCount { get; set; }
        public ProductOrder(int ProductId, int OrderId, int ProductCount)
        {
            this.Id = count++;
            this.ProductId = ProductId;
            this.OrderId = OrderId;
            this.ProductCount = ProductCount;
        }
        public override string ToString()
        {
            return string.Format($"{Id} {ProductId} {OrderId} {ProductCount}");
        }
    }
}
