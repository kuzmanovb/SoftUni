using Andreys.ViewModels;
using Andreys.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Services
{
    public interface IProductsService
    {
         void AddProduct(AddViewModel input);

         ICollection<ProductViewModel> GetAllProducts();

         ProductViewModel GetCurentProduct(int Id);

         void DeleteProduct(int Id);



    }
}
