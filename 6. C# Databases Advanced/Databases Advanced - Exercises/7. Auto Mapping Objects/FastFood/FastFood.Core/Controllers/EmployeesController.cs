namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using ViewModels.Employees;

    public class EmployeesController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public EmployeesController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Register()
        {
            var registerView = context.Positions
                 .ProjectTo<RegisterEmployeeViewModel>(mapper.ConfigurationProvider)
                 .ToList();

            return this.View(registerView);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                this.RedirectToAction("Error", "Home");
            }

            var register = this.mapper.Map<Employee>(model);
            context.Employees.Add(register);
            context.SaveChanges();

            return this.RedirectToAction("All", "Employees");
        }

        public IActionResult All()
        {
            var allEmployees = context.Employees
                .ProjectTo<EmployeesAllViewModel>(mapper.ConfigurationProvider)
                .ToList();

            return this.View(allEmployees);
        }
    }
}
