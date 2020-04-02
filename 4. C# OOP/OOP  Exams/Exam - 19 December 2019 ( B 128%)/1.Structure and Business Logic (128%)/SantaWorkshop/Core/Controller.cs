using System;
using System.Linq;
using System.Text;

using SantaWorkshop.Repositories;
using SantaWorkshop.Models.Dwarfs;
using SantaWorkshop.Core.Contracts;
using SantaWorkshop.Models.Presents;
using SantaWorkshop.Models.Workshops;
using SantaWorkshop.Models.Instruments;
using SantaWorkshop.Utilities.Messages;
using SantaWorkshop.Models.Dwarfs.Contracts;

namespace SantaWorkshop.Core
{
    public class Controller : IController
    {
        private DwarfRepository dwarfs;
        private PresentRepository presents;
        private Workshop workshop;
        public Controller()
        {
            this.dwarfs = new DwarfRepository();
            this.presents = new PresentRepository();
            this.workshop = new Workshop();
        }

        public string AddDwarf(string dwarfType, string dwarfName)
        {
            IDwarf currentDwarf = null;
            if (dwarfType != "SleepyDwarf" && dwarfType != "HappyDwarf")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDwarfType);
            }
            if (dwarfType == "SleepyDwarf")
            {
                currentDwarf = new SleepyDwarf(dwarfName);
            }
            else if (dwarfType == "HappyDwarf")
            {
                currentDwarf = new HappyDwarf(dwarfName);
            }
            dwarfs.Add(currentDwarf);

            return string.Format(OutputMessages.DwarfAdded, dwarfType, dwarfName);
        }

        public string AddInstrumentToDwarf(string dwarfName, int power)
        {
            if (dwarfs.FindByName(dwarfName) == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentDwarf);
            }

            var currentInstrument = new Instrument(power);
            dwarfs.FindByName(dwarfName).AddInstrument(currentInstrument);

            return string.Format(OutputMessages.InstrumentAdded, power, dwarfName);

        }

        public string AddPresent(string presentName, int energyRequired)
        {
            var currentPresant = new Present(presentName, energyRequired);
            presents.Add(currentPresant);
            return string.Format(OutputMessages.PresentAdded, presentName);
        }

        public string CraftPresent(string presentName)
        {
            IDwarf bestDwarf = FindBestDwarf();
            var curentPresent = presents.FindByName(presentName);
            if (bestDwarf.Energy < 50)
            {
                throw new InvalidOperationException(ExceptionMessages.DwarfsNotReady);
            }
            workshop.Craft(curentPresent, bestDwarf);

            if (bestDwarf.Energy <= 0)
            {
                dwarfs.Remove(bestDwarf);
            }
            if (curentPresent.IsDone())
            {
                return string.Format(OutputMessages.PresentIsDone, presentName);
            }
            else
            {
                return string.Format(OutputMessages.PresentIsNotDone, presentName);
            }
        }
        public string Report()
        {
            var sb = new StringBuilder();
            var presantDone = presents.Models.Where(p => p.IsDone()).Count();
            //sb.AppendLine($"{presantDone} presents are done!")
              //.AppendLine("Dwarfs info:");
           
            sb.Append($"{presantDone} presents are done!"
                + Environment.NewLine +
                "Dwarfs info:"
                + Environment.NewLine);

            foreach (var dwarf in dwarfs.Models)
            {
                var notBrokenInstruments = dwarf.Instruments.Where(i => !i.IsBroken()).Count();

                //sb.AppendLine($"Name: {dwarf.Name}")
                //  .AppendLine($"Energy: {dwarf.Energy}")
                //   .AppendLine($"Instruments: {notBrokenInstruments} not broken left");
                  

                sb.Append($"Name: {dwarf.Name}"
                    + Environment.NewLine +
                    $"Energy: {dwarf.Energy}"
                    + Environment.NewLine +
                    $"Instruments: {notBrokenInstruments} not broken left");
            }


            return sb.ToString().TrimEnd();



        }
        private IDwarf FindBestDwarf()
        {
            IDwarf bestDwarf = null;
            var bestSum = 0;
            foreach (var dwarf in dwarfs.Models)
            {
                var sum = dwarf.Energy + dwarf.Instruments.Sum(x => x.Power);
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestDwarf = dwarf;
                }
            }

            return bestDwarf;
        }
    }
}
