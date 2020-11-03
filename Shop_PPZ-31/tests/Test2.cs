using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.controllers;

namespace Shop_PPZ_31.tests
{
    class Test2
    {
        public void RunTetst()
        {
            Console.WriteLine("<----TEST2---->");
            //GetAll Emloyees
            List<SimpleEmployeeView> simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                Console.WriteLine("id: " + simpleEmployeeView.EmployeeV.Id + ",\t name: " + simpleEmployeeView.EmployeeV.Name + ", \t chief name: "+simpleEmployeeView.ChiefV.Name);
            }
            //
            Console.WriteLine("<------------------>");
            //Add Employees
            Employee employee1 = new Employee("John", "Smith", "HrManager", 1);
            HrManager.CreateEmployee(employee1);
            //
            simpleEmployeeViews = HrManager.GetAll();
            foreach (SimpleEmployeeView simpleEmployeeView in simpleEmployeeViews)
            {
                Console.WriteLine("id: " + simpleEmployeeView.EmployeeV.Id + ",\t name: " + simpleEmployeeView.EmployeeV.Name + ", \t chief name: " + simpleEmployeeView.ChiefV.Name);
            }
        }
    }
}
