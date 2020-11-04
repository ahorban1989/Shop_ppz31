using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.controllers;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.views
{
    class CustomerMainMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkMagenta;
        ConsoleColor colorDefoult;

        List<SimpleCustumerView> simpleCustomerViews;

        public CustomerMainMenu(List<SimpleCustumerView> sc)
        {
            simpleCustomerViews = sc;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Customer Menu";
            Console.WriteLine("\t\t\tCustomer MENU\n\t\tCustomers list");
            Console.WriteLine(SEPARATOR);
            List<SimpleCustumerView> simpleCustomerViews = CustomerManager.GetAll();
            foreach(SimpleCustumerView sc in simpleCustomerViews)
            {
                helpers.ConsoleOutputHelpers.OutputSimpleCustomerView(sc);
            }
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Add customer\n2. Detail about customer\n3. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    CustomerAddMenu customerAddMenu = new CustomerAddMenu();
                    customerAddMenu.Run();

                    simpleCustomerViews = CustomerManager.GetAll();
                    break;
                case "2":
                    Console.Write("Enter Costumer id:");
                    int id = helpers.ConsoleImputHelpers.ImputIntNumber();
                    CustomerDetailMenu customerDetailMenu;
                    try
                    {
                        customerDetailMenu = new CustomerDetailMenu(CustomerManager.GetById(id));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("did not find Object with this id!!!");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("pres any key to continue");
                        Console.ReadKey();
                        break;
                    }

                    customerDetailMenu.Run();
                    break;
                case "3":
                    //TODO exit
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
