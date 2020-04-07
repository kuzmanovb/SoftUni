using System;
using System.Linq;
using System.Text;

using SpaceStation.Models;
using SpaceStation.Repositories;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astroRepo;
        private PlanetRepository planetRepo;
        private Mission mission;
        private int countPlanetsExplored = 0;
        public Controller()
        {
            this.astroRepo = new AstronautRepository();
            this.planetRepo = new PlanetRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut newAstro = null;

            if (type == "Biologist")
            {
                newAstro = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                newAstro = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                newAstro = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astroRepo.Add(newAstro);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var newPlanet = new Planet(planetName);
            foreach (var item in items)
            {
                newPlanet.Items.Add(item);
            }

            planetRepo.Add(newPlanet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var currentPlanet = planetRepo.Models.FirstOrDefault(p => p.Name == planetName);

            var astronautsWithOxygen = astroRepo.Models.Where(a => a.Oxygen >= 60).ToList();

            if (astronautsWithOxygen.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            countPlanetsExplored++;
            mission.Explore(currentPlanet, astronautsWithOxygen);

            var deadAstro = astronautsWithOxygen.Where(a => !a.CanBreath).Count();

            return string.Format(OutputMessages.PlanetExplored,planetName, deadAstro);

        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{countPlanetsExplored} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astro in astroRepo.Models)
            {
                var bag = astro.Bag.Items.Count == 0 ? "none" : string.Join(", ", astro.Bag.Items);
                    sb.AppendLine($"Name: {astro.Name}")
                    .AppendLine($"Oxygen: {astro.Oxygen}")
                    .AppendLine($"Bag items: {bag}");
            }

            return sb.ToString().TrimEnd();

        }

        public string RetireAstronaut(string astronautName)
        {
            var currentAstro = astroRepo.Models.FirstOrDefault(a => a.Name == astronautName);
            if (currentAstro == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astroRepo.Remove(currentAstro);

            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
