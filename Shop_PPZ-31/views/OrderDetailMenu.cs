using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.models;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class OrderDetailMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkMagenta;
        ConsoleColor colorDefoult;

        OrderView orderView;

        public OrderDetailMenu(OrderView o)
        {
            orderView = o;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Order Menu";
            Console.WriteLine($"\t\t\tORDER MENU\n\t\tDetail about Order");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputOrderView(orderView);
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Add product\n2. Delete Product from Order\n3. Delete Order\n4. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    OrderAddProductMenu orderAddProductMenu = new OrderAddProductMenu(orderView);
                    orderAddProductMenu.Run();
                    orderView = CustomerManager.GetOrderById(orderView.OrderV.Id);
                    break;
                case "2":
                    Console.WriteLine("Enter product order id: ");
                    int poId = helpers.ConsoleImputHelpers.ImputIntNumber();
                    Console.Write("Enter yes to comfirm delete: ");
                    string confirm1 = Console.ReadLine();
                    if (confirm1.ToUpper() == "YES") CustomerManager.DeleteProductOrder(poId);
                    orderView = CustomerManager.GetOrderById(orderView.OrderV.Id);
                    break;
                case "3":
                    Console.Write("Enter yes to comfirm delete: ");
                    string confirm = Console.ReadLine();
                    if (confirm.ToUpper() == "YES") CustomerManager.DeleteOrder(orderView.OrderV.Id);
                    SetDone();
                    break;
                case "4":
                    SetDone();
                    break;
            }


        }

        protected override void Init()
        {
            colorDefoult = Console.ForegroundColor;

            Console.ForegroundColor = conColorlor;
        }

        protected override void CleanUp()
        {
            Console.ForegroundColor = colorDefoult;
        }
    }
}
