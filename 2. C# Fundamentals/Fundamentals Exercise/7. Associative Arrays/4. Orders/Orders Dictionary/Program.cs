using System;
using System.Collections.Generic;

namespace Orders_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var productList = new Dictionary<string, Product>();

            string input = Console.ReadLine();

            while (input != "buy")
            {
                string[] inputArr = input.Split();

                string productName = inputArr[0];
                double price = double.Parse(inputArr[1]);
                double quantity = double.Parse(inputArr[2]);

                if (!productList.ContainsKey(productName))
                {
                    var newProduct = new Product(price, quantity);

                    productList.Add(productName, newProduct);
                }
                else
                {
                    productList[productName].Price = price;
                    productList[productName].Quantity += quantity;
                }
                
                input = Console.ReadLine();
            }

            foreach (var item in productList)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Sum():f2}");
            }

        }
    }

    public class Product
    {
        public Product(double price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public double Sum()
        {
            double sum = Quantity * Price;
            return sum;
        }
    }
}
