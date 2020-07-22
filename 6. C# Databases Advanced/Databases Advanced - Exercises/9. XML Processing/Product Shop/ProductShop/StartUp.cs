using System;
using System.Linq;
using System.Collections.Generic;

using ProductShop.Data;
using ProductShop.Models;
using ProductShop.XMLHelper;
using ProductShop.Dtos.Import;
using ProductShop.Dtos.Export;
using System.IO;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            using (var context = new ProductShopContext())
            {
                DeleteAndCreateDatabase(context);

                // Task 1. Import Users
                var inputUsers = File.ReadAllText(@"../../../Datasets/users.xml");
                Console.WriteLine(ImportUsers(context, inputUsers));

                // Task 2. Import Products
                var inputProducts = File.ReadAllText(@"../../../Datasets/products.xml");
                Console.WriteLine(ImportProducts(context, inputProducts));

                // Task 3. Import Categories
                var inputCategories = File.ReadAllText(@"../../../Datasets/categories.xml");
                Console.WriteLine(ImportCategories(context, inputCategories));

                // Task 4. Import Categories and Products
                var inputCategoryProducts = File.ReadAllText(@"../../../Datasets/categories-products.xml");
                Console.WriteLine(ImportCategoryProducts(context, inputCategoryProducts));

                // Task 5. Products In Range
                Console.WriteLine(GetProductsInRange(context));

                // Task 6. Sold Products
                Console.WriteLine(GetSoldProducts(context));

                // Task 7. Categories By Products Count
                Console.WriteLine(GetCategoriesByProductsCount(context));

                // Task 8.Users and Products
                Console.WriteLine(GetUsersWithProducts(context));

            }

        }

        private static void DeleteAndCreateDatabase(ProductShopContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("delete");
            context.Database.EnsureCreated();
            Console.WriteLine("create");
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersFromXML = XMLConverter.Deserializer<UsersDTO>(inputXml, "Users");

            var users = usersFromXML
                        .Select(u => new User
                        {
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                            Age = u.Age
                        })
                        .ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var productsFromXML = XMLConverter.Deserializer<ProductDTO>(inputXml, "Products");

            var products = productsFromXML
                           .Select(p => new Product
                           {
                               Name = p.Name,
                               Price = p.Price,
                               SellerId = p.SellerId,
                               BuyerId = p.BuyerId
                           })
                           .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {

            var categoriesFromXML = XMLConverter.Deserializer<CategoryDTO>(inputXml, "Categories");

            var categories = categoriesFromXML
                             .Where(c => c.Name != null)
                             .Select(c => new Category
                             {
                                 Name = c.Name

                             })
                             .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var catProFromXML = XMLConverter.Deserializer<CategoryProductDTO>(inputXml, "CategoryProducts");

            var productsId = context.Products.Select(i => i.Id).ToList();
            var categoiesId = context.Categories.Select(c => c.Id).ToList();

            var categoryProducts = new List<CategoryProduct>();

            foreach (var item in catProFromXML)
            {
                if (productsId.Contains(item.ProductId) && categoiesId.Contains(item.CategoryId))
                {
                    var newCatPro = new CategoryProduct
                    {
                        CategoryId = item.CategoryId,
                        ProductId = item.ProductId
                    };

                    categoryProducts.Add(newCatPro);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {

            var products = context.Products
                           .Where(p => p.Price >= 500 && p.Price <= 1000)
                           .OrderBy(p => p.Price)
                           .Select(p => new ProductsRangeDTO
                           {
                               Name = p.Name,
                               Price = p.Price,
                               Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                           })
                           .Take(10)
                           .ToList();

            var productsRange = XMLConverter.Serialize(products, "Products");

            return productsRange;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var products = context.Users
                                .Where(p => p.ProductsSold.Any())
                                .OrderBy(n => n.LastName)
                                .ThenBy(n => n.FirstName)
                                .Select(p => new UserSoldProductsDTO
                                {
                                    FirstName = p.FirstName,
                                    LastName = p.LastName,
                                    SoldProducts = p.ProductsSold
                                                   .Select(x => new SoldProduct
                                                   {
                                                       Name = x.Name,
                                                       Price = x.Price
                                                   })
                                                   .ToList()
                                })
                                .Take(5)
                                .ToList();

            var soldProducts = XMLConverter.Serialize(products, "Users");

            return soldProducts;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var category = context.Categories
                           .Select(c => new ProductsCountDTO
                           {
                               Name = c.Name,
                               Count = c.CategoryProducts.Count(),
                               AveragePrice = c.CategoryProducts.Average(x => x.Product.Price),
                               TotalRevenue = c.CategoryProducts.Sum(y => y.Product.Price)
                           })
                           .OrderByDescending(c => c.Count)
                           .ThenBy(t => t.TotalRevenue)
                           .ToList();

            var categoryByProducts = XMLConverter.Serialize(category, "Categories");

            return categoryByProducts;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var usersProduct = context.Users
                               //.ToList() // Uncoment ToList for Judge
                               .Where(u => u.ProductsSold.Any())
                               .OrderByDescending(p => p.ProductsSold.Count)
                               .Select(u => new UserProductsDTO
                               {
                                   FirstName = u.FirstName,
                                   LastName = u.LastName,
                                   Age = u.Age,
                                   SoldProducts = new ProductsWithCountDTO
                                   {
                                       Count = u.ProductsSold.Count,
                                       Products = u.ProductsSold
                                                  .Select(x => new ProductToDTO
                                                  {
                                                      Name = x.Name,
                                                      Price = x.Price
                                                  })
                                                  .OrderByDescending(y => y.Price)
                                                  .ToList()
                                   }
                               })
                               .Take(10)
                               .ToList();

            var userProductWithCount = new UserProductWithCount
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                Users = usersProduct

            };

            var userProductsExport = XMLConverter.Serialize(userProductWithCount, "Users");

            return userProductsExport;
        }

    }
}