using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31
{
    class Description
    {
        private static int count = 1;
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Info { get; set; }
        public Description(int ProductId, string Info)
        {
            this.Id = count++;
            this.ProductId = ProductId;
            this.Info = Info;
        }
        public override string ToString()
        {
            return string.Format($"{Id} {ProductId} {Info}");
        }
    }
}
