using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.views
{
    class ProductManagerMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Green;
        ConsoleColor colorDefoult;

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Product Manager Menu";
            //Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. HR menu\n2. Product Manager Menu\n3. Costumer Manager Menu\n4. Exit");
            Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. Register Product\n2. Delete Product\n3. Update Product\n4. Process Order\n5. Exit");
            // Список всех Продуктов, а детальнее: 1)) Редактировать Продукт, 2)) Редактировать Описание, 3)) Удалить Продукт
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    //TODO Register Product
                    break;
                case "2":
                    //TODO Delete Product
                    break;
                case "3":
                    //TODO Update Product
                    break;
                case "4":
                    //TODO Process Order
                    break;
                case "5":
                    //TODO Exit
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
