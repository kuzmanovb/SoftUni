using System;
using System.Collections.Generic;

namespace Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> allVenicle = new List<Car>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArr = input.Split();

                if (inputArr[0] == "car")
                {
                    var newCar = new Car();

                    newCar.Type = "Car";
                    newCar.Model = inputArr[1];
                    newCar.Color = inputArr[2];
                    newCar.Horsepower = int.Parse(inputArr[3]);

                    allVenicle.Add(newCar);
                }
                else if (inputArr[0] == "truck")
                {
                    var newTruck = new Car();

                    newTruck.Type = "Truck";
                    newTruck.Model = inputArr[1];
                    newTruck.Color = inputArr[2];
                    newTruck.Horsepower = int.Parse(inputArr[3]);

                    allVenicle.Add(newTruck);
                }

                input = Console.ReadLine();
            }

            string getInfo = Console.ReadLine();

            while (getInfo != "Close the Catalogue")
            {
                foreach (var venickle in allVenicle)
                {

                    if (venickle.Model == getInfo)
                    {
                        Console.WriteLine($"Type: {venickle.Type}");
                        Console.WriteLine($"Model: {venickle.Model}");
                        Console.WriteLine($"Color: {venickle.Color}");
                        Console.WriteLine($"Horsepower: {venickle.Horsepower}");
                    }

                }
                getInfo = Console.ReadLine();
            }

            double hourseCar = 0;
            double countCar = 0;
            double hourseTruck = 0;
            double countTruck = 0;

            foreach (var item in allVenicle)
            {
                if (item.Type == "Car")
                {
                    hourseCar += item.Horsepower;
                    countCar++;
                }
                else if (item.Type == "Truck")
                {
                    hourseTruck += item.Horsepower;
                    countTruck++;
                }
            }

            if (countCar > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(hourseCar * 1.0 / countCar):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: 0.00.");
            }
            
            if (countTruck > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(hourseTruck * 1.0 / countTruck):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: 0.00.");
            }
        }
    }
    class Car
    {
        public Car()
        {
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }

    }
}
