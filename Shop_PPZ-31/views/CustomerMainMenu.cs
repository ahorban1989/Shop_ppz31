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
        ConsoleColor conColorlor = ConsoleColor.Cyan;
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
                    //TODO Add
                    Console.Write("Please input customer's name: ");
                    string name = views.helpers.ConsoleImputHelpers.ImputName();
                    Console.Write("Please input customer's surname: ");
                    string surname = views.helpers.ConsoleImputHelpers.ImputName();
                    Customer customer = new Customer(name, surname);
                    CustomerManager.CreateCostumer(customer);
                    break;
                case "2":
                    //TODO detail
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
