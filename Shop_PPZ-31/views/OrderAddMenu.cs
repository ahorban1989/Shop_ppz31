using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.controllers;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.models;

namespace Shop_PPZ_31.views
{
    class OrderAddMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkMagenta;
        ConsoleColor colorDefoult;

        SimpleCustumerView simpleCustumer;

        public OrderAddMenu (SimpleCustumerView sc)
        {
            simpleCustumer = sc;
        }


        protected override void Idle()
        {
            List<SimpleEmployeeView> simpleEmployeeViews = HrManager.GetAll();
            Console.Clear();
            Console.Title = "Add Order";
            Console.WriteLine("\t\t\tAdd Order\n");

            Console.WriteLine(SEPARATOR);
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                helpers.ConsoleOutputHelpers.OutputSimpleEmployyeeView(simpleEmployeeView);
            }
            Console.WriteLine(SEPARATOR);
            Console.Write("Enter employee id: ");
            int EmployeeId = views.helpers.ConsoleImputHelpers.ImputIntNumber();

            Console.WriteLine("\nSelect action: \n\n1. Confirm\n2. Cencel");
            string switchMenu = Console.ReadLine();
            
            switch (switchMenu)
            {
                case "1":
                    Order order = new Order(simpleCustumer.CustomerV.Id, EmployeeId);
                    order = CustomerManager.CreateOrder(order);
                    OrderDetailMenu orderDetailMenu = new OrderDetailMenu(CustomerManager.GetOrderById(order.Id));
                    orderDetailMenu.Run();
                    break;
                case "2":
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
