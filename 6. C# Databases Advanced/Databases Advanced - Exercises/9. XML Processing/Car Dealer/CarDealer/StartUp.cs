using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using CarDealer.Data;
using CarDealer.Models;
using CarDealer.XMLHelper;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            DeleteAndCreateDatabase(context);


            // Task 9. Import Suppliers
            var inputSuppliers = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(context, inputSuppliers));

            // Task 10. Import Parts
            var inputParts = File.ReadAllText(@"../../../Datasets/parts.xml");
            Console.WriteLine(ImportParts(context, inputParts));

            // Task 11. Import Cars
            var inputCars = File.ReadAllText(@"../../../Datasets/cars.xml");
            Console.WriteLine(ImportCars(context, inputCars));

            // Task 12.Import Customers
            var inputCustomer = File.ReadAllText(@"../../../Datasets/customers.xml");
            Console.WriteLine(ImportCustomers(context, inputCustomer));

            // Task 13. Import Sales
            var inputSales = File.ReadAllText(@"../../../Datasets/sales.xml");
            Console.WriteLine(ImportSales(context, inputSales));

            // Task 14. Cars With Distance
            Console.WriteLine(GetCarsWithDistance(context));

            // Task 15. Cars from make BMW
            Console.WriteLine(GetCarsFromMakeBmw(context));

            // Task 16. Local Suppliers
            Console.WriteLine(GetLocalSuppliers(context));

            // Task 17. Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            // Task 18.Total Sales by Customer
            Console.WriteLine(GetTotalSalesByCustomer(context));

            //Query 19. Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        private static void DeleteAndCreateDatabase(CarDealerContext context)
        {
            context.Database.EnsureDeleted();
            Console.WriteLine("deleted");
            context.Database.EnsureCreated();
            Console.WriteLine("created");
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var suppliersXML = XMLConverter.Deserializer<SupplierDTO>(inputXml, "Suppliers");

            var suppliers = suppliersXML
                            .Select(s => new Supplier
                            {
                                Name = s.Name,
                                IsImporter = s.IsImporter
                            })
                            .ToList();

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var partsXML = XMLConverter.Deserializer<PartDTO>(inputXml, "Parts");

            var suppliersId = context.Suppliers.Select(p => p.Id).ToList();

            var parts = partsXML
                        .Select(p =>
                        new Part
                        {
                            Name = p.Name,
                            Price = p.Price,
                            Quantity = p.Quantity,
                            SupplierId = p.SupplierId

                        })
                        .ToList()
                        .Where(p => suppliersId.Contains(p.SupplierId))
                        .ToList();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var carsXML = XMLConverter.Deserializer<CarDTO>(inputXml, "Cars");

            var count = 0;

            var partsId = context.Parts.Select(p => p.Id).ToList();

            foreach (var car in carsXML)
            {

                var newCasr = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TraveledDistance
                };

                count++;

                context.Cars.Add(newCasr);

                var uniqueParts = car.Parts.Select(p => p.Id).Distinct();

                foreach (var part in uniqueParts)
                {

                    if (partsId.Contains(part))
                    {
                        var newPartCar = new PartCar
                        {
                            PartId = part,
                            Car = newCasr
                        };

                        context.PartCars.Add(newPartCar);
                    }
                };

            }

            context.SaveChanges();

            return $"Successfully imported {count}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customersXML = XMLConverter.Deserializer<CustomerDTO>(inputXml, "Customers");

            var customers = customersXML
                            .Select(c => new Customer
                            {
                                Name = c.Name,
                                BirthDate = DateTime.Parse(c.BirthDate),
                                IsYoungDriver = c.IsYoungDriver
                            })
                            .ToList();

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var salesXML = XMLConverter.Deserializer<SaleDTO>(inputXml, "Sales");

            var carsId = context.Cars.Select(c => c.Id).ToList();

            var sales = salesXML
                        .Select(s => new Sale
                        {
                            Discount = s.Discount,
                            CarId = s.CarId,
                            CustomerId = s.CustomerId
                        })
                        .ToArray()
                        .Where(s => carsId.Contains(s.CarId))
                        .ToList();

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carWithDistance = context.Cars
                                  .Where(c => c.TravelledDistance > 2000000)
                                  .Select(c => new CarWithDistanceDTO
                                  {
                                      Make = c.Make,
                                      Model = c.Model,
                                      TravelledDistance = c.TravelledDistance
                                  })
                                  .OrderBy(c => c.Make)
                                  .ThenBy(c => c.Model)
                                  .Take(10)
                                  .ToList();

            var carToXML = XMLConverter.Serialize(carWithDistance, "cars");

            return carToXML;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsBMW = context.Cars
                          .Where(c => c.Make == "BMW")
                          .Select(c => new CarsBMWDTO
                          {
                              Id = c.Id,
                              Model = c.Model,
                              TravelledDistance = c.TravelledDistance
                          })
                          .OrderBy(c => c.Model)
                          .ThenByDescending(c => c.TravelledDistance)
                          .ToList();

            var carToXML = XMLConverter.Serialize(carsBMW, "cars");

            return carToXML;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                            .Where(s => s.IsImporter == false)
                            .Select(s => new LocalSuppliersDTO
                            {
                                Id = s.Id,
                                Name = s.Name,
                                PartsCount = s.Parts.Count()
                            })
                            .ToList();

            var suppliersXML = XMLConverter.Serialize(suppliers, "suppliers");

            return suppliersXML;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsParts = context.Cars
                           .Select(c => new CarsWithPartsDTO
                           {
                               Make = c.Make,
                               Model = c.Model,
                               TravelledDistance = c.TravelledDistance,
                               Parts = c.PartCars
                                       .Select(p => new PartsOfCarDTO
                                       {
                                           Name = p.Part.Name,
                                           Price = p.Part.Price
                                       })
                                       .OrderByDescending(x => x.Price)
                                       .ToList()
                           })
                           .OrderByDescending(c => c.TravelledDistance)
                           .ThenBy(c => c.Model)
                           .Take(5)
                           .ToList();

            var carsPartsXML = XMLConverter.Serialize(carsParts, "cars");

            return carsPartsXML;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Cars
                            .Where(c => c.Sales.Any(s => s.Customer.Sales.Any()))
                            .Select(c => new SalesCustomerDTO
                            {
                                Name = c.Sales.Select(n => n.Customer.Name).First(),
                                BoughtCars = c.Sales.Count,
                                SpentMoney = c.PartCars.Sum(p => p.Part.Price)

                            })
                            .OrderByDescending(s => s.SpentMoney)
                            .ToList();

            var customerXML = XMLConverter.Serialize(customers, "customers");

            return customerXML;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var info = context.Sales
                       .Select(c => new SaleWithDiscountDTO
                       {
                           Car2 = new Car2DTO
                           {
                               Make = c.Car.Make,
                               Model = c.Car.Model,
                               TravelledDistance = c.Car.TravelledDistance
                           },
                           Discount = c.Discount,
                           Name = c.Customer.Name,
                           Price = c.Car.PartCars.Sum(p => p.Part.Price),
                           PriceWithDiscount = c.Car.PartCars.Sum(p => p.Part.Price) -
                                               c.Car.PartCars.Sum(p => p.Part.Price) * c.Discount / 100
                       })
                       .ToList();

            var infoToXML = XMLConverter.Serialize(info, "sales");

            return infoToXML;
        }

    }
}