using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDemon = new List<Demon>();

            var paternChar = new Regex(@"[^\d\.+\-\*\/]");
            var paternDigit = new Regex(@"[-]?\d+\.?\d*");
            var paternMultiOrDivi = new Regex(@"[\*\/]");

            string[] input = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                var matchChar = paternChar.Matches(input[i]);
                var matchDigit = paternDigit.Matches(input[i]);
                var matchMultiOrDivi = paternMultiOrDivi.Matches(input[i]);

                var allChar = string.Join("", matchChar).ToCharArray();
                int curentHealth = 0;
                foreach (var item in allChar)
                {

                    curentHealth += (int)item;
                }

                double curentDamage = 0;
                foreach (Match item in matchDigit)
                {
                    curentDamage += double.Parse(item.Value);
                }
                foreach (Match item in matchMultiOrDivi)
                {
                    if (item.Value == "*")
                    {
                        curentDamage *= 2;

                    }
                    else if (item.Value == "/")
                    {
                        curentDamage /= 2;

                    }
                }

                allDemon.Add(new Demon(input[i], curentHealth, curentDamage));

            }

            foreach (var demon in allDemon.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
            }


        }
    }
    public class Demon
    {
        public Demon(string name, int health, double damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
        public string Name { get; set; }
        public int Health { get; set; }
        public double Damage { get; set; }
    }
}
