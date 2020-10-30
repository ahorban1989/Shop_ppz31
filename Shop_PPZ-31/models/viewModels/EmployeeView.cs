using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.models.viewModels
{
    class EmployeeView
    {
        Employee EmployeeV { get; set; }
        Employee ChiefV { get; set; }
        List<OrderView> OrderViewsV { get; set; }
    }
}
