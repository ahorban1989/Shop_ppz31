using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.views
{
    class HrManagerMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Green;
        ConsoleColor colorDefoult;


        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "HR Manager Menu";
            //Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. HR menu\n2. Product Manager Menu\n3. Costumer Manager Menu\n4. Exit");
            Console.WriteLine("\t\t\t\tMenu\n\nSelect menu: \n\n1. Create Employee\n2. Delete Employee\n3. Update Employee\n4. Exit");
            // Показываем список Работников, 
            // 1) Детальнее о Работнике, 1)) Редактировать Работника, 2)) Удалить Работника, 2) Add Empoyee
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    //TODO Create Employee
                    break;
                case "2":
                    //TODO Delete Employee
                    break;
                case "3":
                    //TODO Update Employee
                    break;
                case "4":
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
