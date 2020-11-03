using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.views
{
    class HrDetailMenu : AbstractMenu
    {
        ConsoleColor conColorlor = ConsoleColor.Cyan;
        ConsoleColor colorDefoult;

        EmployeeView employeeView = new EmployeeView();

        public HrDetailMenu(EmployeeView e)
        {
            employeeView = e;
        }

        protected override void Idle()
        {
            Console.Clear();
            Console.Title = "Employee Menu";
            Console.WriteLine($"\t\t\tHR MENU\n\t\tDetail about employee");
            Console.WriteLine(SEPARATOR);
            helpers.ConsoleOutputHelpers.OutputEmployeeView(employeeView);
            Console.WriteLine(SEPARATOR);
            Console.WriteLine("\nSelect action: \n\n1. Edit\n2. Delete\n3. Back");
            string switchMenu = Console.ReadLine();

            switch (switchMenu)
            {
                case "1":
                    //TODO Edit
                    break;
                case "2":
                    Console.Write("Enter yes to comfirm delete: ");
                    string confirm = Console.ReadLine();
                    if (confirm.ToUpper() == "YES") HrManager.Delete(employeeView.EmployeeV.Id);
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
