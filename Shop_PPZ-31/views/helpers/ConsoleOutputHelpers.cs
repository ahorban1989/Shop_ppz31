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
            Console.WriteLine("id: " + e.EmployeeV.Id + ",\t name: " + e.EmployeeV.Name +" " + e.EmployeeV.Surname
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
                $", quantity: {po.ProuctOrderV.ProductCount}, price: {po.ProuctOrderV.ProductPrice}" +
                $", sum: {po.ProuctOrderV.ProductCount*po.ProuctOrderV.ProductPrice}");
        }

        public static void OutputOrderView(OrderView o)
        {
            Console.WriteLine($"id: {o.OrderV.Id}, customer id: {o.CustosumerV.Id}, customer name: {o.CustosumerV.Name}" +
                $", employee name: {o.EmployeeV.Name}");

            int sum = 0;
            foreach (ProductOrderView po in o.ProductsOrderViewsV)
            {
                Console.Write("\t");
                OutputProductOrderView(po);
                //Console.WriteLine($"\tid: {po.ProuctOrderV.Id}, product name: {po.ProductV.Name}" +
                //    $", quantity: {po.ProuctOrderV.ProductCount}, price: {po.ProuctOrderV.ProductPrice}" +
                //    $", sum: {po.ProuctOrderV.ProductCount * po.ProuctOrderV.ProductPrice}");
            }

            Console.WriteLine($"total: {sum}");
        }

        public static void OutputEmployeeView (EmployeeView e)
        {
            Console.WriteLine($"id: {e.EmployeeV.Id}, name: {e.EmployeeV.Name}, surname: {e.EmployeeV.Surname}" +
                $", position: {e.EmployeeV.Position} ,boss: {e.ChiefV.Name}");
            Console.WriteLine("\t\tOrders:");
            foreach (SimpleOrderView o in e.SimpleOrderViewsV)
            {
                Console.Write("\t\t");
                OutputSimpleOrderView(o);
            }
        }


        public static void OutputCusomerView(CustumerView c)
        {
            Console.WriteLine($"id: {c.CustomerV.Id}, name: {c.CustomerV.Name}, surname: {c.CustomerV.Surname}");
            Console.WriteLine("\tOrdrs:");
            foreach(SimpleOrderView o in c.SimpleOrderViewsV)
            {
                Console.Write("\t");
                OutputSimpleOrderView(o);
            }
        }

    }


}
