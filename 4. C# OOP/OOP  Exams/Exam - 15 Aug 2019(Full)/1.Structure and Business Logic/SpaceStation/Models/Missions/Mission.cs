using System.Linq;
using System.Collections.Generic;

using SpaceStation.Models.Planets;
using SpaceStation.Models.Astronauts.Contracts;


namespace SpaceStation.Models
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {

            while (true)
            {
                var currentAstro = astronauts.FirstOrDefault(a => a.CanBreath);

                if (planet.Items.Count == 0)
                {
                    return;
                }

                if (currentAstro == null)
                {
                    return;
                }

                string currentItem = null;
                foreach (var item in planet.Items)
                {
                    currentItem = item;
                    break;
                }

                planet.Items.Remove(currentItem);

                currentAstro.Breath();
                currentAstro.Bag.Items.Add(currentItem);


            }


        }
    }
}
