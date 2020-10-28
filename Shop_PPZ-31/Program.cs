using System;

namespace Shop_PPZ_31
{
    class Program
    {
        static void Main(string[] args)
        {
            DBItem<Product> dbProduct = new DBItem<Product>();
            Product product1 = new Product("Product1", 10);
            dbProduct.AddItem(product1);
            Product product2 = new Product("Product2", 20);
            dbProduct.AddItem(product2);

            DBItem<Description> dbDescription = new DBItem<Description>();
            Description description1 = new Description(1, "Product1 info1");
            dbDescription.AddItem(description1);
            Description description2 = new Description(2, "Product2 info2");
            dbDescription.AddItem(description2);

            DBItem<Customer> dbCustomer = new DBItem<Customer>();
            Customer customer1 = new Customer("Customer1Name", "Customer1Surname");
            dbCustomer.AddItem(customer1);
            Customer customer2 = new Customer("Customer2Name", "Customer2Surname");
            dbCustomer.AddItem(customer2);

            DBItem<Employee> dbEmployee = new DBItem<Employee>();
            Employee employee1 = new Employee("Employee1Name", "Employee1Surname", "Employee1Position", 1);
            dbEmployee.AddItem(employee1);
            Employee employee2 = new Employee("Employee2Name", "Employee2Surname", "Employee2Position", 1);
            dbEmployee.AddItem(employee2);

            DBItem<Order> dbOrder = new DBItem<Order>();
            Order order1 = new Order(1, 1, "Order1");
            dbOrder.AddItem(order1);
            Order order2 = new Order(2, 2, "Order2");
            dbOrder.AddItem(order2);

            DBItem<ProductOrder> dbProductOrder = new DBItem<ProductOrder>();
            ProductOrder productOrder1 = new ProductOrder(1, 1, 1);
            dbProductOrder.AddItem(productOrder1);
            ProductOrder productOrder2 = new ProductOrder(2, 2, 2);
            dbProductOrder.AddItem(productOrder2);

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
            Console.ReadLine();
        }
    }
}
