using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.models.viewModels
{
    class OrderView
    {
        public Order OrderV { get; set; }
        public Employee EmployeeV { get; set; }
        public Customer CustosumerV { get; set; }
        public List<ProductOrderView> ProductsOrderViewsV { get; set; }
    }
}
