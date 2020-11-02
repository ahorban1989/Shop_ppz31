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
            Console.WriteLine("id: " + c.CustomerV.Id + ", name: " + c.CustomerV.Name + ", surname: "
                               + c.CustomerV.Surname + ", Number of orders: " + c.OrderCountV);
        }

        public static void OutputSimpleEmployyeeView(SimpleEmployeeView e)
        {
            Console.WriteLine("id: " + e.EmployeeV.Id + ",\t name: " + e.EmployeeV.Name
                               + ", \t chief name: " + e.ChiefV.Name);
        }

        public static void OutputProductView(ProductView p)
        {
            Console.WriteLine($"id: {p.ProductV.Id}, product name: {p.ProductV.Name}" +
                $", poroduct price: {p.ProductV.Price}, description: {p.DescriptionV.Info}");
        }

        public static void OutputProductOrderView(ProductOrderView po)
        {
            Console.WriteLine($"id: {po.ProuctOrderV.Id}, product: {po.ProductV.Name}" +
                $", quantity: {po.ProuctOrderV.ProductCount}, price for 1: {po.ProuctOrderV.ProductPrice}" +
                $", sum: {po.ProuctOrderV.ProductCount*po.ProuctOrderV.ProductPrice}");
        }


    }


}
