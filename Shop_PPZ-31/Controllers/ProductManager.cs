using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using System.Text.Json;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.controllers
{
    static class ProductManager
    {
        static DBItem<Product> dbProducts = DBItem<Product>.DBInstance();
        static DBItem<Description> dbDescriptions = DBItem<Description>.DBInstance();

        static HttpClientHandler clientHandler = new HttpClientHandler();
        static HttpClient client = new HttpClient(clientHandler);
        static JsonSerializerOptions jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        static ProductManager()
        {
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client.BaseAddress = new Uri("https://localhost:5001/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        #region Product CRUD
        //**CREATE
        public static Product CreateProduct(Product product)
        {
            Shop_server.Models.Product newProduct = new Shop_server.Models.Product
            {
                Name = product.Name,
                Price = product.Price
            };

            var productJson = new StringContent(
                JsonSerializer.Serialize(newProduct),
                Encoding.UTF8,
                "application/json");

            var response = client.PostAsync("Pm", productJson).Result.Content;
            var responceJson = response.ReadAsStringAsync().Result;

            newProduct = JsonSerializer.Deserialize<Shop_server.Models.Product>(responceJson, jsonOptions);
            return new Product(newProduct.Name, newProduct.Price)
            {
                Id = newProduct.Id
            };
        }
        public static Description CreateProductDescription(Description productDescription)
        {
            Shop_server.Models.Description newDescription = new Shop_server.Models.Description
            {
                ProductId = productDescription.ProductId,
                Info = productDescription.Info
            };

            var productDescriptionJson = new StringContent(
                JsonSerializer.Serialize(newDescription),
                Encoding.UTF8,
                "application/json");

            var response = client.PostAsync("Pm", productDescriptionJson).Result.Content;
            var responceJson = response.ReadAsStringAsync().Result;

            newDescription = JsonSerializer.Deserialize<Shop_server.Models.Description>(responceJson, jsonOptions);
            return new Description(newDescription.ProductId, newDescription.Info)
            {
                Id = newDescription.Id
            };
        }

        //**READ ALL
        public static List<ProductView> GetAll ()
        {
            var response = client.GetAsync("Pm").Result.Content;
            var responseJson = response.ReadAsStringAsync().Result;

            List<Shop_server.Models.Product> products = JsonSerializer
                .Deserialize<List<Shop_server.Models.Product>>(responseJson, jsonOptions);

            List<Shop_server.Models.Description> descriptions = JsonSerializer
                .Deserialize<List<Shop_server.Models.Description>>(responseJson, jsonOptions);

            List<ProductView> productViews = new List<ProductView>();

            foreach (var (product, description, productView) in from Product product in products
                                                                from Description description in descriptions
                                                                where description.ProductId == product.Id
                                                                let productView = new ProductView()
                                                                select (product, description, productView))
            {
                productView.ProductV = product;
                productView.DescriptionV = description;
                productViews.Add(productView);
                break;
            }

            return productViews;
        }

        //**READ 1
        public static ProductView GetById(int id)
        {
            var response = client.GetAsync($"Pm/{id}").Result.Content;
            var responseJson = response.ReadAsStringAsync().Result;

            Shop_server.Models.Product product = JsonSerializer
                .Deserialize<Shop_server.Models.Product>(responseJson, jsonOptions);

            Shop_server.Models.Description description = JsonSerializer
                .Deserialize<Shop_server.Models.Description>(responseJson, jsonOptions);

            ProductView productView = new ProductView
            {
                ProductV = new Product(product.Name, product.Price),
                DescriptionV = new Description(description.ProductId, description.Info)
            };
            
            return productView;
        }

        //**UPDATE PRODUCT
        public static bool ProductUpdate (Product product)
        {
            Shop_server.Models.Product newProduct = new Shop_server.Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            var productJson = new StringContent(
                JsonSerializer.Serialize(newProduct),
                Encoding.UTF8,
                "application/json");

            var response = client.PutAsync($"Pm/{product.Id}", productJson).Result;

            return response.IsSuccessStatusCode;
        }
        //**UPDATE PRODUCT DESCRIPTION
        public static bool DescriptionUpdate (Description description)
        {
            var productResponse = client.GetAsync($"Pm/{description.ProductId}").Result.Content;
            var responseJson = productResponse.ReadAsStringAsync().Result;

            Shop_server.Models.Product product = JsonSerializer
                .Deserialize<Shop_server.Models.Product>(responseJson, jsonOptions);

            Shop_server.Models.Description newDescription = new Shop_server.Models.Description
            {
                Id = description.Id,
                ProductId = description.ProductId,
                Info = description.Info
            };

            product.Description = newDescription;

            var productJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                "application/json");

            var response = client.PutAsync($"Pm/{description.ProductId}", productJson).Result;

            return response.IsSuccessStatusCode;
        }

        //DELETE
        /*public static void Delete(int id)
        {
            Product product;
            try
            {
                product = dbProducts.FindById(id);

                foreach (Description description in dbDescriptions.Items)
                {
                    if (description.ProductId == product.Id) dbDescriptions.Delete(description.Id);
                }

                dbProducts.Delete(id);
            }
            catch (Exception e)
            {

                Console.Error.WriteLine(e);
            }
        }*/

        //DELETE
        public static Product Delete(int id)
        {
            var response = client.DeleteAsync($"Pm/{id}").Result.Content;
            var responseString = response.ReadAsStringAsync().Result;

            Shop_server.Models.Product product = JsonSerializer
                .Deserialize<Shop_server.Models.Product>(responseString, jsonOptions);

            return new Product(product.Name, product.Price) { Id = product.Id };
        }

        #endregion
    }
}
