using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.controllers;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.models;

namespace Shop_PPZ_31.views
{
    class CustomerAddMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkMagenta;
        ConsoleColor colorDefoult;


        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Add Cistomer";
            Console.WriteLine("\t\t\tAdd Customer\n");


            Console.Write("Please input customer's name: ");
            string name = views.helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Please input customer's surname: ");
            string surname = views.helpers.ConsoleImputHelpers.ImputName();
            Customer customer = new Customer(name, surname);
            CustomerManager.CreateCostumer(customer);

            SetDone();
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
