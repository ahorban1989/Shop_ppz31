using System;
using System.Collections.Generic;
using System.Text;
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
            foreach(SimpleEmployeeView se in simpleEmployeeViews)
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
                    break;
                case "2":
                    //TODO detail
                    break;
                case "3":
                    //TODO exit
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
