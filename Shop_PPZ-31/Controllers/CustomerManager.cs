using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using System.Linq;

namespace Shop_PPZ_31.controllers
{
    static class CustomerManager
    {
        static DBItem<Employee> dbEmployees = DBItem<Employee>.DBInstance();
        static DBItem<Order> dbOrders = DBItem<Order>.DBInstance();
        static DBItem<Customer> dbCustomers = DBItem<Customer>.DBInstance();
        static DBItem<ProductOrder> dbProductOrders = DBItem<ProductOrder>.DBInstance();
        static DBItem<Product> dbProducts = DBItem<Product>.DBInstance();

        #region CUSTOMER CRUD
        public static Customer CreateCostumer(Customer customer)
        {
            return dbCustomers.AddItem(customer);
        }

        public static List<SimpleCustumerView> GetAll()
        {
            List<SimpleCustumerView> simpleCustumerViews = new List<SimpleCustumerView>();

            List<Customer> customers = dbCustomers.Items;
            foreach (Customer customer in customers)
            {
                SimpleCustumerView simpleCustumerView = new SimpleCustumerView();
                simpleCustumerView.CustomerV = customer;

                var selectOrder = from o in dbOrders.Items
                                  where o.CustomerId == customer.Id
                                  select o;

                simpleCustumerView.OrderCountV = selectOrder.Count();
                simpleCustumerViews.Add(simpleCustumerView);
            }

            return simpleCustumerViews;
        }

        public static CustumerView GetById(int id)
        {

            CustumerView custumerView = new CustumerView();
            custumerView.SimpleOrderViewsV = new List<SimpleOrderView>();
            Customer customer = dbCustomers.FindById(id);

            custumerView.CustomerV = customer;

            List<Order> orders = dbOrders.Items;


            var selectOrders = from order in orders
                               where order.EmployeeId == customer.Id
                               select order;

            foreach (var order in selectOrders)
            {

                var selectProductOrders = from p in dbProductOrders.Items
                                          where p.OrderId == order.Id
                                          select p;

                decimal sum = selectProductOrders.Sum(n => n.ProductPrice);
                SimpleOrderView simpleOrderView = new SimpleOrderView();
                simpleOrderView.OrderV = order;
                simpleOrderView.Sum = sum;
                custumerView.SimpleOrderViewsV.Add(simpleOrderView);
            }

            return custumerView;

        }

        public static void CustomerUpdate(Customer customer)
        {
            try
            {
                dbCustomers.Update(customer);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        public static void DeleteCostumer(int id)
        {
            foreach (Order order in dbOrders.Items)
            {
                if (order.CustomerId == id)
                {
                    foreach (ProductOrder productOrder in dbProductOrders.Items)
                    {
                        if (productOrder.ProductId == order.Id) dbProductOrders.Delete(productOrder.Id);
                    }
                    dbOrders.Delete(order.Id);
                }

            }
            dbCustomers.Delete(id);
        }
        #endregion

        #region CRUD ORDER
        
        public static Order CreateOrder(Order order)
        {
            try
            {
                return dbOrders.AddItem(order);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        public static ProductOrder AddProducOrderToOrder(ProductOrder productOrder, Order order)
        {
            productOrder.OrderId = order.Id;

            try
            {
                return dbProductOrders.AddItem(productOrder);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        public static OrderView GetOrderById(int id)
        {
            Console.WriteLine("getting started");
            OrderView orderView = new OrderView();
            orderView.ProductsOrderViewsV = new List<ProductOrderView>();
            orderView.OrderV = dbOrders.FindById(id);
            orderView.EmployeeV = dbEmployees.FindById(orderView.OrderV.EmployeeId);
            orderView.CustosumerV = dbCustomers.FindById(orderView.OrderV.CustomerId);


            var selectProductsOrder = from po in dbProductOrders.Items
                                      where po.OrderId == orderView.OrderV.Id
                                      select po;
            foreach(ProductOrder po in selectProductsOrder)
            {
                ProductOrderView productOrderView = new ProductOrderView();
                productOrderView.ProuctOrderV = po;
                productOrderView.ProductV = dbProducts.FindById(po.ProductId);
                Console.WriteLine("po added");
                orderView.ProductsOrderViewsV.Add(productOrderView);
            }

            return orderView;
        }

        public static void UpdateOrder (Order order)
        {
            try
            {
                dbOrders.Update(order);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        public static void UpdateProductOrder (ProductOrder productOrder)
        {
            try
            {
                dbProductOrders.Update(productOrder);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        public static void DeleteOrder(int id)
        {
            Order order;
            try
            {
                order = dbOrders.FindById(id);

                foreach (ProductOrder product in dbProductOrders.Items)
                {
                    if (product.OrderId == order.Id) dbProductOrders.Delete(product.Id);
                }

                dbOrders.Delete(id);
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e);
                throw;
            }

        }

        public static void DeleteProductOrder(ProductOrder productOrder)
        {
            try
            {
                dbProductOrders.Delete(productOrder.Id);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        public static void DeleteProductOrder(int productOrder)
        {
            try
            {
                dbProductOrders.Delete(productOrder);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}
