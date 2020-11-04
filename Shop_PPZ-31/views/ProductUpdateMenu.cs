using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.models;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class ProductUpdateMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkYellow;
        ConsoleColor colorDefoult;

        ProductView productView;

        public ProductUpdateMenu(ProductView p)
        {
            productView = p;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Employee Menu";
            Console.WriteLine($"\t\t\tHR MENU\n\t\tDetail about employee");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputProductView(productView);
            Console.WriteLine(SEPARATOR);
            Console.Write("Enter new product name: ");
            string name = helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Enter new price: ");
            decimal price = helpers.ConsoleImputHelpers.ImputDecimalNumber();
            Console.Write("Enter new description: ");
            string description = helpers.ConsoleImputHelpers.ImputName();
            Console.WriteLine("\nSelect action: \n\n1. confirm\n2. cencel");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    productView.ProductV.Name = name;
                    productView.ProductV.Price = price;
                    productView.DescriptionV.Info = description;

                    ProductManager.ProductUpdate(productView.ProductV);
                    ProductManager.DescriptionUpdate(productView.DescriptionV);

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
