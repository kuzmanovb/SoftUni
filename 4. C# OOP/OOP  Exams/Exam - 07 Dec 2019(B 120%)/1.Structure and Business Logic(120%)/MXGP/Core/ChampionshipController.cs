using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using MXGP.Models;
using MXGP.Models.Races;
using MXGP.Repositories;
using MXGP.Models.Riders;
using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Utilities.Messages;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private MotorcycleRepository motoRepo;
        private RaceRepository raceRepo;
        private RiderRepository riderRepo;
        public ChampionshipController()
        {
            this.motoRepo = new MotorcycleRepository();
            this.raceRepo = new RaceRepository();
            this.riderRepo = new RiderRepository();
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            if (riderRepo.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motoRepo.GetByName(motorcycleModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            var currentRider = riderRepo.GetByName(riderName);
            var currentMotocycle = motoRepo.GetByName(motorcycleModel);
            currentRider.AddMotorcycle(currentMotocycle);

            return string.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            if (raceRepo.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            if (riderRepo.GetByName(riderName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RiderNotFound, riderName));

            }

            var currentRider = riderRepo.GetByName(riderName);
            var curentRace = raceRepo.GetByName(raceName);

            curentRace.AddRider(currentRider);

            return string.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {

            IMotorcycle newMotor = null;

            if (type == "Speed")
            {
                newMotor = new SpeedMotorcycle(model, horsePower);
            }
            if (type == "Power")
            {
                newMotor = new PowerMotorcycle(model, horsePower);
            }

            if (motoRepo.GetByName(model) == newMotor)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MotorcycleExists, model));
            }

            motoRepo.Add(newMotor);

            return string.Format(OutputMessages.MotorcycleCreated, newMotor.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            var currentRace = new Race(name, laps);
            if (raceRepo.GetByName(name) == currentRace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            raceRepo.Add(currentRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var newRider = new Rider(riderName);

            if (riderRepo.GetByName(riderName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            }

            riderRepo.Add(newRider);

            return string.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var currentRace = raceRepo.GetByName(raceName);

            if (currentRace == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var allRiderInRace = currentRace.Riders;

            if (allRiderInRace.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var riders = new Dictionary<string, double>();

            foreach (var item in allRiderInRace)
            {
                var laps = currentRace.Laps;
                var rasePoind = item.Motorcycle.CalculateRacePoints(laps);

                riders.Add(item.Name, rasePoind);
            }

            List<KeyValuePair<string, double>> ridersOrder = riders.OrderByDescending(d => d.Value).ToList();

            var sb = new StringBuilder();

            if (ridersOrder.Count > 0)
            {
                sb.AppendLine(string.Format(OutputMessages.RiderFirstPosition, ridersOrder[0].Key, raceName));
            }
            if (ridersOrder.Count > 1)
            {
                sb.AppendLine(string.Format(OutputMessages.RiderSecondPosition, ridersOrder[1].Key, raceName));

            }
            if (ridersOrder.Count > 2)
            {
                sb.AppendLine(string.Format(OutputMessages.RiderThirdPosition, ridersOrder[2].Key, raceName));

            }
            
            raceRepo.Remove(currentRace);

            return sb.ToString().TrimEnd();
        }
    }
}
