using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.Controllers;

namespace Shop_PPZ_31.tests
{
    class TestHrManager
    {
        public void RunTest()
        {
            Console.WriteLine("<----TEST HR---->");
            /////
            List<SimpleEmployeeView> simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                Console.WriteLine("id: " + simpleEmployeeView.EmployeeV.Id + ",\t name: " + simpleEmployeeView.EmployeeV.Name + ", \t chief name: " + simpleEmployeeView.ChiefV.Name);
            }
            /////
            Console.WriteLine("<ADD>");
            Employee employee = new Employee("Bob", "Marley", "Hr", 1);
            employee = HrManager.CreateEmployee(employee);

            simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                Console.WriteLine("id: " + simpleEmployeeView.EmployeeV.Id + ",\t name: " + simpleEmployeeView.EmployeeV.Name + ", \t chief name: " + simpleEmployeeView.ChiefV.Name);
            }
            ////
            Console.WriteLine("<UPDATE>");
            employee.Name = "Борис";
            employee.Surname = "Марля";
            HrManager.Update(employee);

            simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                Console.WriteLine("id: " + simpleEmployeeView.EmployeeV.Id + ",\t name: " + simpleEmployeeView.EmployeeV.Name + ", \t chief name: " + simpleEmployeeView.ChiefV.Name);
            }

            ////
            Console.WriteLine("<READ1>");
            EmployeeView employeeView = HrManager.GetById(1);

            Console.WriteLine($"id: {employeeView.EmployeeV.Id}, name: {employeeView.EmployeeV.Name}, surname: {employeeView.EmployeeV.Surname}, position: {employeeView.EmployeeV.Position} ,boss: {employeeView.ChiefV.Name}");
            Console.WriteLine("Orders:");
            foreach ( SimpleOrderView simpleOrderView in employeeView.SimpleOrderViewsV )
            {
                Console.WriteLine($"\t\tid: {simpleOrderView.OrderV.Id}, employeeId: {simpleOrderView.OrderV.EmployeeId}, sum: {simpleOrderView.Sum}");
            }
            /////
            Console.WriteLine("<DELETE>");
            //Console.WriteLine(employee.Id);
            HrManager.Delete(employee.Id);

            simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                Console.WriteLine("id: " + simpleEmployeeView.EmployeeV.Id + ",\t name: " + simpleEmployeeView.EmployeeV.Name + ", \t chief name: " + simpleEmployeeView.ChiefV.Name);
            }
        }

    }
}
