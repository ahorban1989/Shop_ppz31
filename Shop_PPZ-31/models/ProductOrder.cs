using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    class ProductOrder : IItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public int OrderId { get; set; }
        public int ProductCount { get; set; }
        public ProductOrder(int productId, decimal productPrice, int orderId, int productCount)
        {
            this.ProductId = productId;
            this.ProductPrice = productPrice;
            this.OrderId = orderId;
            this.ProductCount = productCount;
        }
        public override string ToString()
        {
            return string.Format($"id: {Id}, ProductId: {ProductId}, OrderId: {OrderId}, Count: {ProductCount}");
        }
    }
}
