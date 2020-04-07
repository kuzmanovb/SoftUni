using System.Collections.Generic;

using SpaceStation.Models.Bags;

namespace SpaceStation.Models
{
    public class Backpack : IBag
    {
        private readonly List<string> bag;
        public Backpack()
        {
            this.bag = new List<string>();
        }

        public ICollection<string> Items => this.bag;
    }
}
