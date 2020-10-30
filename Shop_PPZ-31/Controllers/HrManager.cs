using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.Controllers
{
    static class HrManager
    {
        static DBItem<Employee> dbEmployees = DBItem<Employee>.DBInstance();
        static DBItem<Order> dbOrders = DBItem<Order>.DBInstance();
        static DBItem<Customer> dbCustomers = DBItem<Customer>.DBInstance();
        static DBItem<ProductOrder> dbProductOrders = DBItem<ProductOrder>.DBInstance();

        #region CRUD

        public static void CreateEmployee(Employee employee)
        {
            try
            {
                dbEmployees.AddItem(employee);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
            
        }

        public static List<SimpleEmployeeView> GetAll()
        {
            List<SimpleEmployeeView> simpleEmployeeViews = new List<SimpleEmployeeView>();
            List<Employee> employees = dbEmployees.Items;
            foreach(Employee employee in employees)
            {
                SimpleEmployeeView employeeView = new SimpleEmployeeView();
                employeeView.EmployeeV = employee;
                Employee chief = null;
                foreach(Employee chiefC in employees)
                {
                    if(chiefC.Id == employee.ChiefId)
                    {
                        chief = chiefC;
                        break;
                    }
                }
                employeeView.ChiefV = chief;
                simpleEmployeeViews.Add(employeeView);
            }
            return simpleEmployeeViews;
        }

        public static EmployeeView GetById(int id)
        {
            EmployeeView employeeView = new EmployeeView();


            return employeeView;
        }

        #endregion
    }
}
