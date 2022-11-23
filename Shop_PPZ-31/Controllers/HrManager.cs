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
    static class HrManager
    {
        //static DBItem<Employee> dbEmployees = DBItem<Employee>.DBInstance();

        static HttpClientHandler clientHandler = new HttpClientHandler();
        static HttpClient client = new HttpClient(clientHandler);
        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        static HrManager()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client.BaseAddress = new Uri("https://localhost:5001/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region CRUD

        //**Create
        public static Employee CreateEmployee(Employee employee)
        {
            Shop_server.Models.Employee newEmployee = new Shop_server.Models.Employee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Position = employee.Position,
                ChiefId = employee.ChiefId,
            };

            var employeeJson = new StringContent(
                JsonSerializer.Serialize(newEmployee),
                Encoding.UTF8,
                "application/json");

            var response = client.PostAsync("Hr", employeeJson).Result.Content;
            var responceJson = response.ReadAsStringAsync().Result;

            newEmployee = JsonSerializer.Deserialize<Shop_server.Models.Employee>(responceJson, jsonOptions);
            return new Employee(newEmployee.Name, newEmployee.Surname, newEmployee.Position, newEmployee.ChiefId.GetValueOrDefault())
            {
                Id = newEmployee.Id
            };
        }
        //**READ ALL
        public static List<SimpleEmployeeView> GetAll()
        {
            var response = client.GetAsync("Hr").Result.Content;
            var responseJson = response.ReadAsStringAsync().Result;

            List<Shop_server.Models.Employee> employees = JsonSerializer
                .Deserialize<List<Shop_server.Models.Employee>>(responseJson, jsonOptions);

            List<SimpleEmployeeView> simpleEmployeeViews = employees.Select(e => new SimpleEmployeeView
            { 
                EmployeeV = new Employee (e.Name, e.Surname, e.Position, e.ChiefId.GetValueOrDefault())
                {
                    Id = e.Id
                },
                ChiefV = new Employee ((e.Chief == null) ? "" : e.Chief.Name, (e.Chief == null) ? "" : e.Chief.Name,
                    (e.Chief == null) ? "" : e.Chief.Position, (e.Chief == null) ? 0 : e.Chief.ChiefId.GetValueOrDefault())
                {
                    Id = (e.Chief == null) ? 0 : e.Chief.Id
                }
            }).ToList();
            return simpleEmployeeViews;
        }

        //**READ 1
        public static EmployeeView GetById(int id)
        {
            var response = client.GetAsync($"Hr/{id}").Result;
            var responseJson = response.Content.ReadAsStringAsync().Result;

            Shop_server.Models.Employee employee = JsonSerializer
                .Deserialize<Shop_server.Models.Employee>(responseJson, jsonOptions);

            EmployeeView employeeView = new EmployeeView
            {
                EmployeeV = new Employee(employee.Name, employee.Surname,
                    employee.Position, employee.ChiefId.GetValueOrDefault())
                {
                    Id = employee.Id
                },
                ChiefV = new Employee((employee.Chief == null) ? "" : employee.Chief.Name, (employee.Chief == null) ? "" : employee.Chief.Surname,
                    (employee.Chief == null) ? "" : employee.Chief.Position, (employee.Chief == null) ? 0 : employee.Chief.ChiefId.GetValueOrDefault())
                {
                    Id = (employee.Chief == null) ? 0 : employee.Chief.Id
                },
                SimpleOrderViewsV = employee.Orders.Select(o => new SimpleOrderView 
                {
                    OrderV = new Order (o.CustomerId, o.EmployeeId)
                    {
                        Id = o.Id,
                    },
                    Sum = o.ProductOrders.Sum(p => p.ProductCount*p.ProductPrice)
                }).ToList()
            };
            return employeeView;
        }
        //**UPDATE
        public static bool Update(Employee employee)
        {
            Shop_server.Models.Employee newEmployee = new Shop_server.Models.Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Surname = employee.Surname,
                Position = employee.Position,
                ChiefId = employee.ChiefId
            };

            var employeeJson = new StringContent(
                JsonSerializer.Serialize(newEmployee),
                Encoding.UTF8,
                "application/json");

            var response = client.PutAsync($"Hr/{employee.Id}", employeeJson).Result;

            return response.IsSuccessStatusCode;
        }

        //**DELETE
        public static Employee Delete(int id)
        {
            var response = client.DeleteAsync($"Hr/{id}").Result.Content;
            var responseString = response.ReadAsStringAsync().Result;

            Shop_server.Models.Employee employee = JsonSerializer
                .Deserialize<Shop_server.Models.Employee>(responseString, jsonOptions);

            return new Employee(employee.Name, employee.Surname, employee.Position, employee.ChiefId.GetValueOrDefault()) { Id = employee.Id };
        }

        #endregion
    }
}
