namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Core.ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            // Item
            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.CategoryId));

            // Employees

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position));

            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.PositionName));

            // Categories

            this.CreateMap<Category, CategoryAllViewModel>();

            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            // Order

            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(s => DateTime.UtcNow))
                .ForMember(x => x.Type, y => y.MapFrom(s => OrderType.ToGo));

            this.CreateMap<CreateOrderInputModel, OrderItem>();


            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name));

        }
    }
}
