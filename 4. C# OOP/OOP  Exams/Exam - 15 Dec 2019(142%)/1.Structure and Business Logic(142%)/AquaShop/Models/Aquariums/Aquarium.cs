using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AquaShop.Utilities.Messages;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fishes;

        public Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.decorations = new List<IDecoration>();
            this.fishes = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public int Comfort
        {
            get => decorations.Sum(c => c.Comfort);

        }

        public ICollection<IDecoration> Decorations => this.decorations.AsReadOnly();

        public ICollection<IFish> Fish => this.fishes.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {

            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (decorations.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            fishes.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {


            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (fishes.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {

                var fishesName = Fish.Select(f => f.Name).ToArray();

                sb.AppendLine("Fish: " + string.Join(", ", fishesName));
            }

            sb.AppendLine($"Decorations: {decorations.Count}")
            .AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return fishes.Remove(fish);
        }
    }
}
