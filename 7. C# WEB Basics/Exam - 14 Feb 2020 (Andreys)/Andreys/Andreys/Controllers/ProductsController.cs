using Andreys.Services;
using Andreys.ViewModels;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();

        }

        [HttpPost]
        public HttpResponse Add(AddViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("The name should be between 4 and 20 characters");
            }

            if (input.Description.Length > 10)
            {
                return this.Error("The description should be to 20 characters");
            }

            this.productsService.AddProduct(input);

            return this.Redirect("/");

        }

        public HttpResponse Details(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var curentProduct = this.productsService.GetCurentProduct(id);

            return this.View(curentProduct);

        }

        public HttpResponse Delete(int id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.productsService.DeleteProduct(id);

            return this.Redirect("/");
        }

    }
}
