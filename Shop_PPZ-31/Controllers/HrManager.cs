using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using System.Linq;

namespace Shop_PPZ_31.Controllers
{
    static class HrManager
    {
        static DBItem<Employee> dbEmployees = DBItem<Employee>.DBInstance();
        static DBItem<Order> dbOrders = DBItem<Order>.DBInstance();
        static DBItem<Customer> dbCustomers = DBItem<Customer>.DBInstance();
        static DBItem<ProductOrder> dbProductOrders = DBItem<ProductOrder>.DBInstance();

        #region CRUD

        //**Create
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
        //**READ ALL
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

        //**READ 1
        public static EmployeeView GetById(int id)
        {
            EmployeeView employeeView = new EmployeeView();
            employeeView.SimpleOrderViewsV = new List<SimpleOrderView>();
            Employee employee = dbEmployees.FindById(id);
            
            employeeView.EmployeeV = employee;
            
            List<Employee> employees = dbEmployees.Items;
            Employee chief = null;
            foreach (Employee chiefC in employees)
            {
                if (chiefC.Id == employee.ChiefId)
                {
                    chief = chiefC;
                    break;
                }
            }

            employeeView.ChiefV = chief;

            List<Order> orders = dbOrders.Items;
            

            var selectOrders = from order in orders
                               where order.EmployeeId == employee.Id
                               select order;

            foreach (var order in selectOrders)
            {

                var selectProductOrders = from p in dbProductOrders.Items
                                          where p.OrderId == order.Id select p;

                decimal sum = selectProductOrders.Sum(n => n.ProductPrice);
                SimpleOrderView simpleOrderView = new SimpleOrderView();
                simpleOrderView.OrderV = order;
                simpleOrderView.Sum = sum;
                employeeView.SimpleOrderViewsV.Add(simpleOrderView);
            }

            return employeeView;
        }
        //**UPDATE
        public static void Update(Employee employee)
        {
            try
            {
                dbEmployees.Update(employee);
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e);
            }
        }

        //**DELETE
        public static void Delete(int id)
        {
            try
            {
                dbEmployees.Delete(id);
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e);
            }
        }

        #endregion
    }
}
