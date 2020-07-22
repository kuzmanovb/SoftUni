using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Globalization;
using System.Collections.Generic;

using CarDealer.DTO;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var context = new CarDealerContext())
            {
                DeleteAndCreateDatabase(context);

                // Task 9. Import Suppliers
                var inputSupplier = File.ReadAllText(@"../../../Datasets/suppliers.json");
                Console.WriteLine(ImportSuppliers(context, inputSupplier));

                // Task 10.Import Parts
                var inputParts = File.ReadAllText(@"../../../Datasets/parts.json");
                Console.WriteLine(ImportParts(context, inputParts));

                // Task 11. Import Cars
                var inputCars = File.ReadAllText(@"../../../Datasets/cars.json");
                Console.WriteLine(ImportCars(context, inputCars));

                // Task 12. Import Customers
                var inputCustomers = File.ReadAllText(@"../../../Datasets/customers.json");
                Console.WriteLine(ImportCustomers(context, inputCustomers));

                // Task 13. Import Sales
                var inputSales = File.ReadAllText(@"../../../Datasets/sales.json");
                Console.WriteLine(ImportSales(context, inputSales));

                // Task 14. Export Ordered Customers
                Console.WriteLine(GetOrderedCustomers(context));

                // Task 15. Export Cars from Make Toyota
                Console.WriteLine(GetCarsFromMakeToyota(context));

                // Task 16. Export Local Suppliers
                Console.WriteLine(GetLocalSuppliers(context));

                // Task 17. Export Cars with Their List of Parts
                Console.WriteLine(GetCarsWithTheirListOfParts(context));

                // Task 18. Export Total Sales by Customer
                Console.WriteLine(GetTotalSalesByCustomer(context));

                // Task 19. Export Sales with Applied Discount
                Console.WriteLine(GetSalesWithAppliedDiscount(context));

            };




        }
        private static void DeleteAndCreateDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("deleted");
            context.Database.EnsureCreated();
            Console.WriteLine("created");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

            var count = 0;

            foreach (var p in parts.Where(p => p.SupplierId <= context.Suppliers.Count()))
            {
                context.Parts.Add(p);
                count++;
            }

            context.SaveChanges();

            return $"Successfully imported {count}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);

            foreach (var car in cars)
            {
                var newCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                context.Cars.Add(newCar);

                foreach (var part in car.PartsId.Distinct())
                {
                    var newPartCar = new PartCar
                    {
                        PartId = part,
                        Car = newCar
                    };

                    context.PartCars.Add(newPartCar);
                }
            }

            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                            .AsEnumerable()
                            .OrderBy(y => y.BirthDate)
                            .ThenBy(d => d.IsYoungDriver)
                            .Select(c => new
                            {
                                c.Name,
                                BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                c.IsYoungDriver
                            })
                            .ToList();

            var customerToJSON = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customerToJSON;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromToyota = context.Cars
                                 .Where(c => c.Make == "Toyota")
                                 .Select(c => new
                                 {
                                     c.Id,
                                     c.Make,
                                     c.Model,
                                     c.TravelledDistance
                                 })
                                 .OrderBy(m => m.Model)
                                 .ThenByDescending(d => d.TravelledDistance)
                                 .ToList();

            var carsToJSON = JsonConvert.SerializeObject(carsFromToyota, Formatting.Indented);

            return carsToJSON;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                            .Where(s => s.IsImporter == false)
                            .Select(p => new
                            {
                                p.Id,
                                p.Name,
                                PartsCount = p.Parts.Where(q => q.Quantity > 0).Count()
                            })
                            .ToList();

            var suppliersToJSON = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersToJSON;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                       .Select(c => new
                       {
                           car = new
                           {
                               c.Make,
                               c.Model,
                               c.TravelledDistance
                           },
                           parts = c.PartCars
                                   .Select(p => new
                                   {
                                       p.Part.Name,
                                       Price = p.Part.Price.ToString("F2")
                                   })
                       })
                       .ToList();

            var carsToJSON = JsonConvert.SerializeObject(cars, Formatting.Indented);


            return carsToJSON;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            //Local work but in judge 50/100
            var customers = context.Cars
                            .Where(c => c.Sales.Count() > 0)
                            .Select(c => new
                            {
                                fullName = c.Sales.Select(t => t.Customer.Name).First(),
                                boughtCars = c.Sales.Count(),
                                spentMoney = c.PartCars.Sum(y => y.Part.Price)
                            })
                            .OrderByDescending(m => m.spentMoney)
                            .ThenByDescending(t => t.boughtCars)
                            .ToList();

            var customersToJSON = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customersToJSON;

            // Local gives error but in judge 100/100
            //var customers = context.Customers
            //              .Where(c => c.Sales.Count() > 0)
            //              .Select(c => new
            //              {
            //                  fullName = c.Sales.Select(t => t.Customer.Name).First(),
            //                  boughtCars = c.Sales.Count(),
            //                  spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(x => x.Part.Price))
            //              })
            //              .OrderByDescending(m => m.spentMoney)
            //              .ThenByDescending(t => t.boughtCars)
            //              .ToList();

            //var customersToJSON = JsonConvert.SerializeObject(customers, Formatting.Indented);

            //return customersToJSON;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                        .Select(s => new
                        {
                            car = new { s.Car.Make, s.Car.Model, s.Car.TravelledDistance },
                            customerName = s.Customer.Name,
                            Discount = s.Discount.ToString("F2"),
                            price = s.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                            priceWithDiscount = $"{s.Car.PartCars.Sum(x => x.Part.Price) * (1 - s.Discount / 100):F2}",
                        })
                        .Take(10)
                        .ToList();

            var salesToJSON = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return salesToJSON;
        }




    }
}