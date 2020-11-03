using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.controllers;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.views
{
    class HrMainMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
        ConsoleColor colorDefoult;

        List<SimpleEmployeeView> simpleEmployeeViews;

        public HrMainMenu (List<SimpleEmployeeView> se)
        {
            simpleEmployeeViews = se;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Employee Menu";
            Console.WriteLine("\t\t\tHR MENU\n\t\tEmployees list");
            Console.WriteLine(SEPARATOR);
            simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView se in simpleEmployeeViews)
            {
                helpers.ConsoleOutputHelpers.OutputSimpleEmployyeeView(se);
            }
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Add employee\n2. Detail about employee\n3. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    //TODO Add
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
