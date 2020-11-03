using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.models;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class HrUpdateMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
        ConsoleColor colorDefoult;

        SimpleEmployeeView simpleEmployeeView;

        public HrUpdateMenu(SimpleEmployeeView e)
        {
            simpleEmployeeView = e;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Employee Menu";
            Console.WriteLine($"\t\t\tHR MENU\n\t\tDetail about employee");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputSimpleEmployyeeView(simpleEmployeeView);
            Console.WriteLine(SEPARATOR);
            Console.Write("Enter new name: ");
            string name = helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Enter new surname: ");
            string surname = helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Enter new position: ");
            string position = helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Enter new chief id: ");
            int chiefId = helpers.ConsoleImputHelpers.ImputIntNumber();
            Console.WriteLine("\nSelect action: \n\n1. confirm\n2. cencel");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    simpleEmployeeView.EmployeeV.Name = name;
                    simpleEmployeeView.EmployeeV.Surname = surname;
                    simpleEmployeeView.EmployeeV.Position = position;
                    simpleEmployeeView.EmployeeV.ChiefId = chiefId;
                    HrManager.Update(simpleEmployeeView.EmployeeV);
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
