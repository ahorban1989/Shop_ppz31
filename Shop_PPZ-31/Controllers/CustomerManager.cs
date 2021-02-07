using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Shop_PPZ_31.controllers
{
    static class CustomerManager
    {
        static DBItem<Employee> dbEmployees = DBItem<Employee>.DBInstance();
        static DBItem<Order> dbOrders = DBItem<Order>.DBInstance();
        static DBItem<Customer> dbCustomers = DBItem<Customer>.DBInstance();
        static DBItem<ProductOrder> dbProductOrders = DBItem<ProductOrder>.DBInstance();
        static DBItem<Product> dbProducts = DBItem<Product>.DBInstance();

        static HttpClientHandler clientHandler = new HttpClientHandler();


        static HttpClient client = new HttpClient(clientHandler);

        static CustomerManager()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };


            client.BaseAddress = new Uri("https://localhost:5001/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        #region CUSTOMER CRUD
        public static Customer CreateCostumer(Customer customer)
        {
            Shop_server.Models.Customer newCusomer = new Shop_server.Models.Customer
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Orders = null
            };

            var clienJson = new StringContent(
                JsonSerializer.Serialize(newCusomer),
                Encoding.UTF8,
                "application/json"
                );

            var response = client.PostAsync("Cm", clienJson).Result.Content;

            var resString = response.ReadAsStringAsync().Result;
            newCusomer = JsonSerializer.Deserialize<Shop_server.Models.Customer>(resString, new JsonSerializerOptions
            { PropertyNameCaseInsensitive = true });
            return new Customer(newCusomer.Name, newCusomer.Surname)
            {
                Id = newCusomer.Id
            };
        }

        public static List<SimpleCustumerView> GetAll()
        {

            var response = client.GetAsync("Cm").Result.Content;

            var resSttring = response.ReadAsStringAsync().Result;


            List<Shop_server.Models.Customer> customers = JsonSerializer
                .Deserialize<List<Shop_server.Models.Customer>>(resSttring, new JsonSerializerOptions 
                {PropertyNameCaseInsensitive = true });


            List<SimpleCustumerView> simpleCustumerViews = customers.Select(c => new SimpleCustumerView
                {
                    CustomerV = new Customer(c.Name, c.Surname)
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Surname = c.Surname
                    },
                    OrderCountV = (c.Orders == null)?0 : c.Orders.Count
                }).ToList();


            return simpleCustumerViews;
        }

        public static CustumerView GetById(int id)
        {

            var response = client.GetAsync($"Cm/{id}").Result.Content;
            var resSring = response.ReadAsStringAsync().Result;
            
            Shop_server.Models.Customer customer  = JsonSerializer
                .Deserialize<Shop_server.Models.Customer>(resSring, new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true });

            CustumerView custumerView = new CustumerView
            {
                CustomerV = new Customer(customer.Name, customer.Surname)
                {
                    Id = customer.Id
                },
                SimpleOrderViewsV = (customer.Orders == null) ? null :
                    customer.Orders.Select(o => new SimpleOrderView
                    {
                        OrderV = new Order(o.CustomerId, o.EmployeeId)
                        {
                            Id = o.Id
                        },
                        Sum = o.ProductOrders.Sum(po => po.ProductCount*po.ProductPrice)
                    }).ToList()
            };

            return custumerView;

        }

        public static bool CustomerUpdate(Customer customer)
        {
            Shop_server.Models.Customer updatingCustomer = new Shop_server.Models.Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname = customer.Surname,
                Orders = null
                
            };

            var customerJson = new StringContent(
                 JsonSerializer.Serialize(updatingCustomer),
                 Encoding.UTF8,
                 "application/json");

            var response = client.PutAsync($"Cm/{customer.Id}", customerJson).Result.IsSuccessStatusCode;

            return response;
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
