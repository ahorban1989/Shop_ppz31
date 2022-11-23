using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.views
{
    class MainMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Green;
        ConsoleColor colorDefoult;


        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Shop Main Menu";
            Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. HR menu\n2. Product Manager Menu\n3. Costumer Manager Menu\n4. Exit");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    // HR menu
                    views.HrMainMenu hrMainMenu = new HrMainMenu(controllers.HrManager.GetAll());
                    hrMainMenu.Run();
                    break;
                case "2":
                    // PR menu
                    views.ProductMainMenu productMainMenu = new ProductMainMenu(controllers.ProductManager.GetAll());
                    productMainMenu.Run();
                    break;
                case "3":
                    // CM menu
                    views.CustomerMainMenu customerMainMenu = new CustomerMainMenu(controllers.CustomerManager.GetAll());
                    customerMainMenu.Run();
                    break;
                case "4":
                    // exit
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
