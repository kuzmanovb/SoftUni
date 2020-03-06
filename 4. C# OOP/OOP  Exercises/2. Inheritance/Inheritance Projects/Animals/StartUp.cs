using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allAnimals = new List<Animal>();

            var type = Console.ReadLine();

            while (type != "Beast!")
            {
                var typeInfo = Console.ReadLine().Split();
                var name = typeInfo[0];
                var age = int.Parse(typeInfo[1]);

                switch (type)
                {
                    case "Dog":
                        var newDog = new Dog(name, age, typeInfo[2]);
                        allAnimals.Add(newDog);
                        break;
                    case "Cat":
                        var newCat = new Cat(name, age, typeInfo[2]);
                        allAnimals.Add(newCat);
                        break;
                    case "Frog":
                        var newFrog = new Frog(name, age, typeInfo[2]);
                        allAnimals.Add(newFrog);
                        break;
                    case "Kitten":
                        var newKittens = new Kitten(name, age);
                        allAnimals.Add(newKittens);
                        break;
                    case "Tomcat":
                        var newTomcat = new Tomcat(name, age);
                        allAnimals.Add(newTomcat);
                        break;
                }

                type = Console.ReadLine();
            }

            foreach (var animal in allAnimals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
