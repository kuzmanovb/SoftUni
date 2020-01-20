using System;
using System.Linq;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] piratShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();
            int[] warShip = Console.ReadLine().Split('>').Select(int.Parse).ToArray();

            int maxHealth = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while (input != "Retire")
            {
                string[] inputArray = input.Split();

                if (inputArray[0] == "Fire")
                {
                    int index = int.Parse(inputArray[1]);
                    int damage = int.Parse(inputArray[2]);

                    if (index >= 0 && index < warShip.Length)
                    {
                        int healthShip = warShip[index];
                        healthShip -= damage;
                        warShip[index] = healthShip;

                        if (healthShip <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }
                else if (inputArray[0] == "Defend")
                {
                    int startIndex = int.Parse(inputArray[1]);
                    int endIndex = int.Parse(inputArray[2]);
                    int damage = int.Parse(inputArray[3]);

                    if (startIndex >= 0 && startIndex < piratShip.Length
                        && endIndex >= 0 && endIndex < piratShip.Length)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            int healthShip = piratShip[i];
                            healthShip -= damage;
                            piratShip[i] = healthShip;
                           
                            if (healthShip <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }
                else if (inputArray[0] == "Repair")
                {
                    int index = int.Parse(inputArray[1]);
                    int healthAdd = int.Parse(inputArray[2]);

                    if (index >= 0 && index < piratShip.Length)
                    {
                        int healthShip = piratShip[index];
                        healthShip += healthAdd;

                        if (healthShip > maxHealth)
                        {
                            healthShip = maxHealth;
                        }
                        piratShip[index] = healthShip;
                    }
                }
                else if (inputArray[0] == "Status")
                {
                    double minHealth = maxHealth * 0.2;

                    int count = 0;

                    foreach (var ship in piratShip)
                    {
                        if (ship < minHealth)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }

                input = Console.ReadLine();
            }

           
                Console.WriteLine($"Pirate ship status: {piratShip.Sum()}");
                Console.WriteLine($"Warship status: {warShip.Sum()}");
        }
    }
}
