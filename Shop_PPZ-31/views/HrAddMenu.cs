using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class HrAddMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
        ConsoleColor colorDefoult;


        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Add employee";
            Console.WriteLine("\t\t\tAdd employee\n");


            Console.Write("Please input employee's name: ");
            string name = views.helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Please input employee's surname: ");
            string surname = views.helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Please input employee's position: ");
            string position = views.helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Please input employee's chiefId: ");
            int chiefId = views.helpers.ConsoleImputHelpers.ImputIntNumber();
            Employee employee = new Employee(name, surname, position, chiefId);
            HrManager.CreateEmployee(employee);

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
