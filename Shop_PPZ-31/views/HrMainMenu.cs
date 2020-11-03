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
                    HrAddMenu hrAddMenu = new HrAddMenu();
                    hrAddMenu.Run();
                    simpleEmployeeViews = HrManager.GetAll();
                    break;
                case "2":
                    Console.Write("Enter Employee id:");
                    int id = helpers.ConsoleImputHelpers.ImputIntNumber();
                    HrDetailMenu hrDetailMenu;
                    try
                    {
                        hrDetailMenu = new HrDetailMenu(HrManager.GetById(id));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("did not find Object with this id!!!");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("pres any key to continue");
                        Console.ReadKey();
                        break;
                    }
                    
                    hrDetailMenu.Run();
                    break;
                case "3":
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
