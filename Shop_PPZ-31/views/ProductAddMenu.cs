using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class ProductAddMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
        ConsoleColor colorDefoult;


        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Add product";
            Console.WriteLine("\t\t\tAdd product\n");


            Console.Write("Please input product's name: ");
            string name = views.helpers.ConsoleImputHelpers.ImputName();
            Console.Write("Please input product's price: ");
            decimal price = views.helpers.ConsoleImputHelpers.ImputDecimalNumber();
            Product product = new Product(name, price);
            ProductManager.CreateProduct(product);
            int productId = product.Id;
            Console.Write("Please input info about product in it's descripion: ");
            string productInfo = views.helpers.ConsoleImputHelpers.ImputName();
            Description description = new Description(productId, productInfo);
            ProductManager.CreateProductDescription(description);

            SetDone();
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
