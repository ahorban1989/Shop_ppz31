using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.interfaces;

namespace Shop_PPZ_31.models
{
    class Description : IItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Info { get; set; }
        public Description(int ProductId, string Info)
        {
            this.ProductId = ProductId;
            this.Info = Info;
        }
        public override string ToString()
        {
            return string.Format($"id:{Id}, productId:{ProductId}, info:{Info}");
        }
    }
}
