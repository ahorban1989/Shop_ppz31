using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.views.helpers
{
    static class ConsoleOutputHelpers
    {
        public static void OutputSimpleOrderView(SimpleOrderView o)
        {
            Console.WriteLine($"order id: {o.OrderV.Id}, customerId: {o.OrderV.CustomerId}, sum: {o.Sum}");
        }

        public static void OutputSimpleCustomerView(SimpleCustumerView c)
        {
            // TODO!!!!!!!!
        }
    }


}
