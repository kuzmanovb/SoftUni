using Andreys.Data;
using Andreys.Models;
using Andreys.ViewModels;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Andreys.Services
{
    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(AddViewModel input)
        {
            var newProduct = new Product
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Price = decimal.Parse(input.Price),
                Category = (Category)Enum.Parse(typeof(Category), input.Category),
                Gender = (Gender)Enum.Parse(typeof(Gender), input.Gender),
            };

            this.db.Products.Add(newProduct);
            this.db.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var curentProduct = this.db.Products.FirstOrDefault(p => p.Id == id);

            this.db.Remove(curentProduct);
            this.db.SaveChanges();
        }

        public ProductViewModel GetCurentProduct(int id)
        {
            return this.db.Products
                .Where(p => p.Id == id)
                .Select(x => new ProductViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Category = x.Category.ToString(),
                    Gender = x.Gender.ToString()
                })
                .FirstOrDefault();
                
        }

        ICollection<ProductViewModel> IProductsService.GetAllProducts()
        {
            var allProducts = this.db.Products
                .Select(x => new ProductViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Description = x.Description,
                     ImageUrl = x.ImageUrl,
                     Price = x.Price,
                     Category = x.Category.ToString(),
                     Gender = x.Gender.ToString()
                 })
                .ToArray();

            return allProducts;
        }
    }
}
