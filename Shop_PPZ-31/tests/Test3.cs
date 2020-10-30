using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using Shop_PPZ_31.Controllers;

namespace Shop_PPZ_31.tests
{
    class Test3
    {
        public void RunTetst()
        {
            Console.WriteLine("<----TEST3---->");
            //Get Emloyee
            EmployeeView employeeView = HrManager.GetById(1);
            Console.WriteLine($"id: {employeeView.EmployeeV.Id}, name: {employeeView.EmployeeV.Name}, " +
                $"chief: {employeeView.EmployeeV.Id}, " +
                $"number of orders: {employeeView.SimpleOrderViewsV.Count}");

            foreach(var o in employeeView.SimpleOrderViewsV)
            {
                Console.WriteLine($"\trder id: {o.OrderV.Id}, costumerId: {o.OrderV.CustomerId}, sum: {o.Sum}");
            }
            //
            Console.WriteLine("<------------------>");
        }
    }
}
