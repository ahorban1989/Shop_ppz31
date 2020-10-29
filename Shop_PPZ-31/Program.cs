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

            foreach (Customer customer in dbCustomer.Items) 
            {
                Console.WriteLine(customer);

                foreach (Order order in dbOrder.Items)
                {
                    if (order.CustomerId == customer.Id)
                    {
                        Console.WriteLine("\t" + order);

                        foreach (Employee employee in dbEmployee.Items)
                        {
                            if (employee.Id == order.EmployeeId)
                            {
                                Console.WriteLine("\t\t" + employee);
                            }
                        }
                        foreach (ProductOrder productOrder in dbProductOrder.Items)
                        {
                            if (productOrder.OrderId == order.Id)
                            {
                                Console.WriteLine("\t\t\t" + productOrder);

                                foreach (Product product in dbProduct.Items)
                                {
                                    if(product.Id == productOrder.ProductId)
                                    {
                                        Console.WriteLine("\t\t\t\t" + product);

                                        foreach (Description description in dbDescription.Items)
                                        {
                                            if(description.ProductId == product.Id)
                                            {
                                                Console.WriteLine("\t\t\t\t\t" + description);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            MainMenu mainMenu = new MainMenu();
            mainMenu.Run();
            Console.ReadLine();
        }
    }
}
