using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new ProductShopContext())
            {

                // Task 1. Import Users
                var data = File.ReadAllText(@"..\..\..\Datasets\users.json");
                Console.WriteLine(ImportUsers(context, data));

                // Task 2. Import Products 
                var products = File.ReadAllText(@"..\..\..\Datasets\products.json");
                Console.WriteLine(ImportProducts(context, products));

                // Task 3. Import Categories
                var categories = File.ReadAllText(@"..\..\..\Datasets\categories.json");
                Console.WriteLine(ImportCategories(context, categories));

                // Task 4. Import Categories and Products
                var categoryProducts = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");
                Console.WriteLine(ImportCategoryProducts(context, categoryProducts));

                // Task 5. Export Products in Range
                Console.WriteLine(GetProductsInRange(context));

                // Task 6. Export Successfully Sold Products
                Console.WriteLine(GetSoldProducts(context));

                // Task 7. Export Categories by Products Count
                Console.WriteLine(GetCategoriesByProductsCount(context));

                //Task 8.Export Users and Products
                Console.WriteLine(GetUsersWithProducts(context));


            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var newUsers = JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(newUsers);

            context.SaveChanges();

            return $"Successfully imported {newUsers.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            var newProducts = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(newProducts);

            context.SaveChanges();

            return $"Successfully imported {newProducts.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var newcategories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            var count = 0;

            foreach (var category in newcategories)
            {
                if (category.Name != null)
                {
                    context.Categories.Add(category);
                    count++;
                }
            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var newCategoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoryProducts.AddRange(newCategoryProducts);

            context.SaveChanges();

            return $"Successfully imported {newCategoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                           .Where(p => p.Price >= 500 && p.Price <= 1000)
                           .Select(p => new
                           {
                               name = p.Name,
                               price = p.Price,
                               seller = p.Seller.FirstName + " " + p.Seller.LastName
                           })
                           .OrderBy(p => p.price)
                           .ToList();

            var productsToJSON = JsonConvert.SerializeObject(products, Formatting.Indented);

            return productsToJSON;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                        .Where(s => s.ProductsSold.Any(p => p.Buyer != null))
                        .Select(b => new
                        {
                            firstName = b.FirstName,
                            lastName = b.LastName,
                            soldProducts = b.ProductsSold
                                             .Where(p => p.Buyer != null)
                                             .Select(p => new
                                             {
                                                 name = p.Name,
                                                 price = p.Price,
                                                 buyerFirstName = p.Buyer.FirstName,
                                                 buyerLastName = p.Buyer.LastName
                                             })
                        })
                        .OrderBy(n => n.lastName)
                        .ThenBy(n => n.firstName)
                        .ToList();

            var usersToJSON = JsonConvert.SerializeObject(users, Formatting.Indented);

            return usersToJSON;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            var categuries = context.Categories
                             .Select(c => new
                             {
                                 category = c.Name,
                                 productsCount = c.CategoryProducts
                                                  .Select(x => x.Product)
                                                  .Count(),
                                 averagePrice = c.CategoryProducts
                                                 .Average(x => x.Product.Price)
                                                 .ToString("F2"),
                                 totalRevenue = ((c.CategoryProducts
                                                  .Select(x => x.Product)
                                                  .Count())
                                              *
                                                (c.CategoryProducts
                                                  .Average(x => x.Product.Price)))
                                                .ToString("F2")
                             })
                             .OrderByDescending(p => p.productsCount)
                             .ToList();

            var categoriesToJSON = JsonConvert.SerializeObject(categuries, Formatting.Indented);

            return categoriesToJSON;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var curentUsers = context.Users
                             .AsEnumerable()
                             .Where(p => p.ProductsSold.Any(b => b.Buyer != null))
                             .OrderByDescending(p => p.ProductsSold.Count(c => c.Buyer != null))
                             .Select(c => new
                             {
                                 firstName = c.FirstName,
                                 lastName = c.LastName,
                                 age = c.Age,
                                 soldProducts = new
                                 {
                                     count = c.ProductsSold.Count(b => b.Buyer != null),
                                     products = c.ProductsSold
                                                 .Where(x => x.Buyer != null)
                                                 .Select(y => new
                                                 {
                                                     name = y.Name,
                                                     price = y.Price
                                                 })
                                                 .ToList()
                                 }
                             })
                             .ToList();

            var usersWithCoiunt = new
            {
                usersCount = curentUsers.Count,
                users = curentUsers
            };

            var setingJSON = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            var usersToJSON = JsonConvert.SerializeObject(usersWithCoiunt, setingJSON);

            return usersToJSON;

        }


    }
}