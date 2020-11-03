using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.controllers;


namespace Shop_PPZ_31.views
{
    class ProductDetailMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkYellow;
        ConsoleColor colorDefoult;

        ProductView productView;

        public ProductDetailMenu(ProductView p)
        {
            productView = p;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Product Menu";
            Console.WriteLine($"\t\t\tPRODUCT MENU\n\t\tDetail about product");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputProductView(productView);
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Edit\n2. Delete\n3. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    //SimpleEmployeeView se = new SimpleEmployeeView();
                    //se.EmployeeV = employeeView.EmployeeV;
                    //se.ChiefV = employeeView.ChiefV;
                   // HrUpdateMenu hrUpdateMenu = new HrUpdateMenu(se);
                    //hrUpdateMenu.Run();
                    break;
                case "2":
                    Console.Write("Enter yes to comfirm delete: ");
                    string confirm = Console.ReadLine();
                    if (confirm.ToUpper() == "YES") ProductManager.Delete(productView.ProductV.Id);
                    SetDone();
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
