using System.Linq;

using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Craft(IPresent present, IDwarf dwarf)
        {
            var curentInstrument = dwarf.Instruments.FirstOrDefault(i => !i.IsBroken());

            while (dwarf.Energy > 0 && curentInstrument != null)
            {
                present.GetCrafted();
                dwarf.Work();
                curentInstrument.Use();
                if (present.IsDone())
                {
                    break;
                }
                if (curentInstrument.IsBroken())
                {
                    curentInstrument = dwarf.Instruments.FirstOrDefault(i => !i.IsBroken());
                }
            }
        }
    }
}
