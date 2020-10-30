using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.models
{
    class DBInitializer
    {
        public DBInitializer()
        {
            DBItem<Product> dbProduct = DBItem<Product>.DBInstance();
            Product product1 = new Product("Product1", 10);
            dbProduct.AddItem(product1);
            Product product2 = new Product("Product2", 20);
            dbProduct.AddItem(product2);

            DBItem<Description> dbDescription = DBItem<Description>.DBInstance();
            Description description1 = new Description(1, "Product1 info1");
            dbDescription.AddItem(description1);
            Description description2 = new Description(2, "Product2 info2");
            dbDescription.AddItem(description2);

            DBItem<Customer> dbCustomer = DBItem<Customer>.DBInstance();
            Customer customer1 = new Customer("Customer1Name", "Customer1Surname");
            dbCustomer.AddItem(customer1);
            Customer customer2 = new Customer("Customer2Name", "Customer2Surname");
            dbCustomer.AddItem(customer2);

            DBItem<Employee> dbEmployee = DBItem<Employee>.DBInstance();
            Employee employee1 = new Employee("Employee1Name", "Employee1Surname", "Employee1Position", 1);
            dbEmployee.AddItem(employee1);
            Employee employee2 = new Employee("Employee2Name", "Employee2Surname", "Employee2Position", 1);
            dbEmployee.AddItem(employee2);

            DBItem<Order> dbOrder = DBItem<Order>.DBInstance();
            Order order1 = new Order(1, 1);
            dbOrder.AddItem(order1);
            Order order2 = new Order(2, 2);
            dbOrder.AddItem(order2);

            DBItem<ProductOrder> dbProductOrder = DBItem<ProductOrder>.DBInstance();
            ProductOrder productOrder1 = new ProductOrder(1,10, 1, 1);
            dbProductOrder.AddItem(productOrder1);
            ProductOrder productOrder2 = new ProductOrder(2,20, 2, 2);
            dbProductOrder.AddItem(productOrder2);
        }
    }
}
