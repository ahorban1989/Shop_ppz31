using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.controllers;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.views
{
    class ProductMainMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkYellow;
        ConsoleColor colorDefoult;

        List<ProductView> productViews;

        public ProductMainMenu (List<ProductView> pv)
        {
            productViews = pv;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Product Menu";
            Console.WriteLine("\t\t\tProduct MENU\n\t\tProducts list");
            Console.WriteLine(SEPARATOR);
            productViews = ProductManager.GetAll();
            foreach (ProductView pv in productViews)
            {
                helpers.ConsoleOutputHelpers.OutputProductView(pv);
            }
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Add product\n2. Detail about product\n3. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    ProductAddMenu productAddMenu = new ProductAddMenu();
                    productAddMenu.Run();
                    productViews = ProductManager.GetAll();
                    break;
                case "2":
                    Console.Write("Enter product id:");
                    int id = helpers.ConsoleImputHelpers.ImputIntNumber();
                    ProductDetailMenu productDetailMenu;
                    try
                    {
                        productDetailMenu = new ProductDetailMenu(ProductManager.GetById(id));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("did not find Object with this id!!!");
                        Console.WriteLine(e.Message);
                        Console.WriteLine("pres any key to continue");
                        Console.ReadKey();
                        break;
                    }

                    productDetailMenu.Run();
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
