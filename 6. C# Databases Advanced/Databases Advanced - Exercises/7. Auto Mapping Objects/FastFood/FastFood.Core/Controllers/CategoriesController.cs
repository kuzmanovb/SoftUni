﻿namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            if (!ModelState.IsValid)
            {
                this.RedirectToAction("Error", "Home");
            }

            var category = this.mapper.Map<Category>(model);
            context.Categories.Add(category);
            context.SaveChanges();

            return this.RedirectToAction("All", "Categories");
        }

        public IActionResult All()
        {
            var allCategries = context.Categories
                .ProjectTo<CategoryAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(allCategries);
        }
    }
}