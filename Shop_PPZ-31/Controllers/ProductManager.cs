using System;
using System.Collections.Generic;
using System.Text;
using Shop_PPZ_31.models;
using Shop_PPZ_31.models.viewModels;

namespace Shop_PPZ_31.Controllers
{
    static class ProductManager
    {
        static DBItem<Product> dbProducts = DBItem<Product>.DBInstance();
        static DBItem<Description> dbDescriptions = DBItem<Description>.DBInstance();

        #region Product CRUD
        //**CREATE
        public static void CreateProduct(Product product)
        {
            try
            {
                dbProducts.AddItem(product);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                throw;
            }
        }

        //**READ ALL
        public static List<ProductView> GetAll ()
        {
            List <ProductView> productViews = new List<ProductView>();
            var products = dbProducts.Items;
            var descriptions = dbDescriptions.Items;
            
            foreach (Product product in products)
            {
                foreach (Description description in descriptions)
                {
                    if(description.ProductId == product.Id)
                    {
                        ProductView productView = new ProductView();
                        productView.ProductV = product;
                        productView.DescriptionV = description;

                        productViews.Add(productView);

                        break;
                    }
                }
            }

            return productViews;
        }

        //**READ 1
        public static ProductView GetById(int id)
        {
            ProductView productView = new ProductView();
            //TODO**********
            
            return productView;
        }

        #endregion
    }
}
