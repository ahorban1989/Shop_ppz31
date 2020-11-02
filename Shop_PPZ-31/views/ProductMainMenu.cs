using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.Controllers;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.views
{
    class ProductMainMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
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
                    //TODO Add
                    Console.Write("Please input product's name: ");
                    string name = views.helpers.ConsoleImputHelpers.ImputName();
                    Console.Write("Please input product's price: ");
                    decimal price = views.helpers.ConsoleImputHelpers.ImputDecimalNumber();
                    Product product = new Product(name, price);
                    ProductManager.CreateProduct(product);
                    //Console.Write("Please input product id in it's descripion: ");
                    //int productId = views.helpers.ConsoleImputHelpers.ImputIntNumber();
                    int productId = product.Id;
                    Console.Write("Please input info about product in it's descripion: ");
                    string productInfo = views.helpers.ConsoleImputHelpers.ImputName();
                    Description description = new Description(productId, productInfo);
                    ProductManager.CreateProductDescription(description);
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
