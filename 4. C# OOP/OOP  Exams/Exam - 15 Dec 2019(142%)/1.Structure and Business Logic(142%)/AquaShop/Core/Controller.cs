using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using AquaShop.Models.Fish;
using AquaShop.Repositories;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Utilities.Messages;
using AquaShop.Models.Decorations;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium currentAquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                currentAquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                currentAquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            aquariums.Add(currentAquarium);

            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration curentDecoration;

            if (decorationType == "Ornament")
            {
                curentDecoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                curentDecoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            decorations.Add(curentDecoration);

            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            string massageForReturn = string.Empty;
            var currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (fishType == "FreshwaterFish")
            {
                if (currentAquarium.GetType().Name != "FreshwaterAquarium")
                {
                    massageForReturn = OutputMessages.UnsuitableWater;
                }
                else
                {
                    var currentFish = new FreshwaterFish(fishName, fishSpecies, price);

                    currentAquarium.AddFish(currentFish);

                    massageForReturn = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);

                }
            }
            else if (fishType == "SaltwaterFish")
            {
                if (currentAquarium.GetType().Name != "SaltwaterAquarium")
                {
                    massageForReturn = OutputMessages.UnsuitableWater;
                }
                else
                {
                    var currentFish = new SaltwaterFish(fishName, fishSpecies, price);
                    currentAquarium.AddFish(currentFish);
                    massageForReturn = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            return massageForReturn;
        }

        public string CalculateValue(string aquariumName)
        {
            var valueDecorations = aquariums.FirstOrDefault(a => a.Name == aquariumName).Decorations.Sum(d => d.Price);
            var valueFishes = aquariums.FirstOrDefault(a => a.Name == aquariumName).Fish.Sum(f => f.Price);

            var value = valueDecorations + valueFishes;

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string FeedFish(string aquariumName)
        {
            var currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            currentAquarium.Feed();
            var countFishes = currentAquarium.Fish.Count();

            return string.Format(OutputMessages.FishFed, countFishes);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {

            var currentDecoracion = decorations.FindByType(decorationType);
            if (currentDecoracion == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            
            var currentAquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            currentAquarium.AddDecoration(currentDecoracion);
            decorations.Remove(currentDecoracion);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);

        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
