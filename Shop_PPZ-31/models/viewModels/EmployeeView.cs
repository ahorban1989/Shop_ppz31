using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.models.viewModels
{
    class EmployeeView
    {
        public Employee EmployeeV { get; set; }
        public Employee ChiefV { get; set; }
        public List<SimpleOrderView> SimpleOrderViewsV { get; set; }
    }
}
