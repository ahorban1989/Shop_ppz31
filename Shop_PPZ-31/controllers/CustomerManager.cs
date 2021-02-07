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

        static HttpClientHandler clientHandler = new HttpClientHandler();


        static HttpClient client = new HttpClient(clientHandler);
        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions{ PropertyNameCaseInsensitive = true };

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
            newCusomer = JsonSerializer.Deserialize<Shop_server.Models.Customer>(resString, jsonOptions);
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
                .Deserialize<List<Shop_server.Models.Customer>>(resSttring, jsonOptions);


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
                .Deserialize<Shop_server.Models.Customer>(resSring, jsonOptions);

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

        public static Customer DeleteCostumer(int id)
        {
            var response = client.DeleteAsync($"Cm/{id}").Result.Content;
            var responseString = response.ReadAsStringAsync().Result;

            Shop_server.Models.Customer customer = JsonSerializer
                .Deserialize<Shop_server.Models.Customer>(responseString, jsonOptions);

            return new Customer(customer.Name, customer.Surname) { Id = customer.Id };
        }
        #endregion

        #region CRUD ORDER
        
        public static Order CreateOrder(Order order)
        {
            Shop_server.Models.Order newOrder = new Shop_server.Models.Order
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId
            };

            var orderJson = new StringContent(
                JsonSerializer.Serialize(newOrder),
                Encoding.UTF8,
                "application/json");

            var response = client.PostAsync($"Cm/{order.CustomerId}/addorder", orderJson).Result.Content;
            var responseJsong = response.ReadAsStringAsync().Result;

            newOrder = JsonSerializer.Deserialize<Shop_server.Models.Order>(responseJsong, jsonOptions);
            return new Order(newOrder.CustomerId, newOrder.EmployeeId){ Id = newOrder.Id };
        }

        public static ProductOrder AddProducOrderToOrder(ProductOrder productOrder, Order order)
        {
            // TODO write a method that adds the product to order
            throw new NotImplementedException();
        }

        public static OrderView GetOrderById(int id)
        {
            var response = client.GetAsync($"Orders/{id}").Result.Content;
            var responseJson = response.ReadAsStringAsync().Result;

            Shop_server.Models.Order order = JsonSerializer.Deserialize<Shop_server.Models.Order>(responseJson, jsonOptions);

            return new OrderView
            {
                OrderV = new Order(order.CustomerId, order.EmployeeId)
                {
                    Id = order.Id
                },
                EmployeeV = new Employee(order.Employee.Name, order.Employee.Surname,
                    order.Employee.Position,
                    (order.Employee.ChiefId != null) ? order.Employee.ChiefId.Value : 0)
                {
                    Id = order.Employee.Id
                },
                CustosumerV = new Customer(order.Customer.Name, order.Customer.Surname)
                {
                    Id = order.Employee.Id
                },
                ProductsOrderViewsV = order.ProductOrders.Select(p =>
                    new ProductOrderView
                    {
                        ProductV = new Product (p.Product.Name, p.Product.Price)
                        {
                            Id = p.Product.Id
                        },
                        ProuctOrderV = new ProductOrder (p.ProductId, p.ProductPrice, p.OrderId, p.ProductCount)
                        {
                            Id = p.Id
                        }
                    }).ToList()
            };
        }

        public static bool UpdateOrder (Order order)
        {
            Shop_server.Models.Order updatedOrder = new Shop_server.Models.Order
            {
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId
            };

            var orderJson = new StringContent(
                JsonSerializer.Serialize(updatedOrder),
                Encoding.UTF8,
                "application/json");

            var response = client.PutAsync($"Orders/{order.Id}", orderJson).Result.IsSuccessStatusCode;
            return response;
        }

        public static void UpdateProductOrder (ProductOrder productOrder)
        {
            // TODO Write a method that updates producOrder in order
            throw new NotImplementedException();
        }

        public static Order DeleteOrder(int id)
        {
            var response = client.DeleteAsync($"Orders/{id}").Result.Content;
            var responseJson = response.ReadAsStringAsync().Result;

            Shop_server.Models.Order deletedOrder = JsonSerializer.Deserialize<Shop_server.Models.Order>(responseJson, jsonOptions);
            return new Order(deletedOrder.CustomerId, deletedOrder.EmployeeId) { Id = deletedOrder.Id };
        }

        public static void DeleteProductOrder(ProductOrder productOrder)
        {
            // TODO
            throw new NotImplementedException();
        }

        public static void DeleteProductOrder(int productOrder)
        {
            // TODO
            throw new NotImplementedException();
        }

        #endregion
    }
}
