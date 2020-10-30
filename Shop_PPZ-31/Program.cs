using System;
using Shop_PPZ_31.models;
using Shop_PPZ_31.views;

namespace Shop_PPZ_31
{
    class Program
    {
        static void Main(string[] args)
        {
            DBItem<Product> dbProduct = DBItem<Product>.DBInstance();
            DBItem<Description> dbDescription = DBItem<Description>.DBInstance();
            DBItem<Customer> dbCustomer = DBItem<Customer>.DBInstance();
            DBItem<Employee> dbEmployee = DBItem<Employee>.DBInstance();
            DBItem<Order> dbOrder = DBItem<Order>.DBInstance();
            DBItem<ProductOrder> dbProductOrder = DBItem<ProductOrder>.DBInstance();

            DBInitializer dbInit = new DBInitializer();

            tests.Test2 test2 = new tests.Test2();
            test2.RunTetst();

            tests.Test3 test3 = new tests.Test3();
            test3.RunTetst();

            Console.ReadLine();
        }
    }
}
