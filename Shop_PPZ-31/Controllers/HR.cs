using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using System.Linq;

namespace Shop_PPZ_31.Controllers

{
    class HR
    {
        DBItem<Employee> dbEmloyees = DBItem<Employee>.DBInstance();
        DBItem<Order> dbOrders = DBItem<Order>.DBInstance();
        public void AddEmployee(Employee employee)
        {
            dbEmloyees.AddItem(employee);
        }
        
        public Employee GetEmployeeByID(int id)
        {
            Employee employee = null;
            try
            {
                employee = dbEmloyees.FindById(id);
                if (employee == null) throw new ArgumentException("did not find employee with this Id", "num");
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
            return employee;

        }

        public List<Employee> GetAllEmployees()
        {
            return dbEmloyees.Items;
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                dbEmloyees.Update(employee);
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e);
            }

        }

        public List<Order> GetAllEmployeeOrdersById(int id)
        {
            //LINQ selection from dbOrders
            List<Order> orders = dbOrders.Items;
            
            var selectOrders = from order in orders
                               where order.EmployeeId == id
                               select order;
            
            return selectOrders.ToList();
        }
    }
}
