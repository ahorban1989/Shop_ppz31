using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class OrderAddProductMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.DarkMagenta;
        ConsoleColor colorDefoult;

        List<ProductView> productViews;
        OrderView orderView;

        public OrderAddProductMenu(OrderView ov)
        {
            orderView = ov;
        }


        protected override void Idle()
        {
            productViews = ProductManager.GetAll();
            List<SimpleEmployeeView> simpleEmployeeViews = HrManager.GetAll();
            Console.Clear();
            Console.Title = "Add product to Order";
            Console.WriteLine("\t\t\tAdd product to Order\n");

            Console.WriteLine(SEPARATOR);
            foreach (ProductView p in productViews)
            {
                helpers.ConsoleOutputHelpers.OutputProductView(p);
            }
            Console.WriteLine(SEPARATOR);
            Console.Write("Enter product id: ");
            int id = views.helpers.ConsoleImputHelpers.ImputIntNumber();
            ProductView product;
            try
            {
                product = ProductManager.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
            Console.Write("Enter count: ");
            int count = views.helpers.ConsoleImputHelpers.ImputIntNumber();
            
            Console.WriteLine("\nSelect action: \n\n1. Confirm\n2. Cencel");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    ProductOrder productOrder = new ProductOrder(product.ProductV.Id, product.ProductV.Price, orderView.OrderV.Id, count);
                    CustomerManager.AddProducOrderToOrder(productOrder, orderView.OrderV);
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
