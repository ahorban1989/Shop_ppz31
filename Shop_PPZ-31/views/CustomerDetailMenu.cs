using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.controllers;


namespace Shop_PPZ_31.views
{
    class CustomerDetailMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkMagenta;
        ConsoleColor colorDefoult;

        CustumerView custumerView;

        public CustomerDetailMenu(CustumerView c)
        {
            custumerView = c;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Customer Menu";
            Console.WriteLine($"\t\t\tCUSTOMER MENU\n\t\tDetail about Customer");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputCusomerView(custumerView);
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Edit\n2. Delete\n3. Add order\n4. Order detail\n5. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    SimpleCustumerView sc = new SimpleCustumerView();
                    sc.CustomerV = custumerView.CustomerV;
                    sc.OrderCountV = custumerView.SimpleOrderViewsV.Count;
                    CustomerUpdateMenu customerUpdateMenu = new CustomerUpdateMenu(sc);
                    customerUpdateMenu.Run();
                    break;
                case "2":
                    Console.Write("Enter yes to comfirm delete: ");
                    string confirm = Console.ReadLine();
                    if (confirm.ToUpper() == "YES") CustomerManager.DeleteCostumer(custumerView.CustomerV.Id);
                    SetDone();
                    break;
                case "3":
                    //TODO add order
                    break;
                case "4":
                    //TODO Order detail
                    break;
                case "5":
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
