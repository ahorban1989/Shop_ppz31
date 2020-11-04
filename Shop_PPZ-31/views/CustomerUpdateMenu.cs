using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class CustomerUpdateMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
        ConsoleColor colorDefoult;

        SimpleCustumerView simpleCustumerView;

        public CustomerUpdateMenu(SimpleCustumerView c)
        {
            simpleCustumerView = c;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Customer Menu";
            Console.WriteLine($"\t\t\tCUSTOMER MENU\n\t\tEdit customer");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputSimpleCustomerView(simpleCustumerView);
            Console.WriteLine(SEPARATOR);
            Console.Write("Enter new name: ");
            string name = helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Enter new surname: ");
            string surname = helpers.ConsoleImputHelpers.ImputName();
            Console.WriteLine("\nSelect action: \n\n1. confirm\n2. cencel");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    simpleCustumerView.CustomerV.Name = name;
                    simpleCustumerView.CustomerV.Surname = surname;
                    CustomerManager.CustomerUpdate(simpleCustumerView.CustomerV);
                    SetDone();
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
