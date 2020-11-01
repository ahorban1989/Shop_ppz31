using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.views
{
    class CustomerManagerMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Green;
        ConsoleColor colorDefoult;

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Customer Manager Menu";
            //Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. HR menu\n2. Product Manager Menu\n3. Costumer Manager Menu\n4. Exit");
            Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. Register Customer\n2. Delete Customer\n3. Create Order\n4. Delete Order\n5. Process Order\n6. Accept Payment\n7. Exit");
            string switchMenu = Console.ReadLine();
            // Таблица с Заказами. Просмотр Клиента. Детальнее о Заказе. Когда добавляем Заказ, показать табл. с Продуктами, и запрос ид Продукта, кол-ва, и ещё или закончить. Если Закончить, то введите ид Заказчика, или добавить нового.
            // Далее выбираем Исполнителя Заказа. Enter, и Заказ ушёл в Таблицу.

            switch (switchMenu)
            {
                case "1":
                    //TODO Register Customer
                    break;
                case "2":
                    //TODO Delete Customer
                    break;
                case "3":
                    //TODO Create Order
                    break;
                case "4":
                    //TODO Delete Order
                    break;
                case "5":
                    //TODO Process Order
                    break;
                case "6":
                    //TODO Accept Payment
                    break;
                case "7":
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
