namespace MortalEngines.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly List<IPilot> pilotsRepo;
        private readonly List<IMachine> machineRepo;
        public MachinesManager()
        {
            this.pilotsRepo = new List<IPilot>();
            this.machineRepo = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            string massage = null;
            var checkPilot = pilotsRepo.FirstOrDefault(p => p.Name == name);
            if (checkPilot != null)
            {
                massage = string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                var pilot = new Pilot(name);
                pilotsRepo.Add(pilot);
                massage = string.Format(OutputMessages.PilotHired, name);
            }

            return massage;
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            string massage = null;

            var checkMachine = machineRepo.FirstOrDefault(m => m.Name == name);

            if (checkMachine != null)
            {
                massage = string.Format(OutputMessages.MachineExists, name);

            }
            else
            {
                var tank = new Tank(name, attackPoints, defensePoints);
                tank.ToggleDefenseMode();
                machineRepo.Add(tank);
                massage = string.Format(OutputMessages.TankManufactured, name, tank.AttackPoints, tank.DefensePoints);
            }

            return massage;
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            string massage = null;

            var checkMachine = machineRepo.FirstOrDefault(m => m.Name == name);

            if (checkMachine != null)
            {
                massage = string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var fighter = new Fighter(name, attackPoints, defensePoints);
                fighter.ToggleAggressiveMode();
                machineRepo.Add(fighter);

                massage = string.Format(OutputMessages.FighterManufactured, name, fighter.AttackPoints, fighter.DefensePoints, "ON");
            }

            return massage;
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            string massage = null;

            var pilot = pilotsRepo.FirstOrDefault(p => p.Name == selectedPilotName);
            var machine = machineRepo.FirstOrDefault(m => m.Name == selectedMachineName);

            if (pilot == null)
            {
                massage = string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (machine == null)
            {
                massage = string.Format(OutputMessages.MachineNotFound, selectedMachineName);

            }
            else if (machine.Pilot != null)
            {
                massage = string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                machine.Pilot = pilot;
                massage = string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }

            return massage;
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            string massage = null;
            var attacker = machineRepo.FirstOrDefault(a => a.Name == attackingMachineName);
            var defender = machineRepo.FirstOrDefault(d => d.Name == defendingMachineName);
            if (attacker == null)
            {
                massage = string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defender == null)
            {
                massage = string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attacker.HealthPoints == 0)
            {
                massage = string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defender.HealthPoints == 0)
            {
                massage = string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            else
            {
                attacker.Attack(defender);

                massage = string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, defender.HealthPoints);
            }

            return massage;
        }

        public string PilotReport(string pilotReporting)
        {
            var pilotForReport = pilotsRepo.FirstOrDefault(p => p.Name == pilotReporting);

            return pilotForReport.Report();
        }

        public string MachineReport(string machineName)
        {
            var machineForReport = machineRepo.FirstOrDefault(m => m.Name == machineName);

            return machineForReport.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            string massage = null;

            Fighter checkMachine = (Fighter)machineRepo.FirstOrDefault(m => m.Name == fighterName && m.GetType().Name == "Fighter");
            if (checkMachine != null)
            {
                if (checkMachine.AggressiveMode == true)
                {
                    checkMachine.AggressiveMode = false;
                }
                else
                {
                    checkMachine.AggressiveMode = true;
                }

                checkMachine.ToggleAggressiveMode();

                massage = string.Format(OutputMessages.FighterOperationSuccessful, fighterName);

            }
            else
            {
                massage = string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            return massage;
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            string massage = null;

            Tank checkMachine = (Tank)machineRepo.FirstOrDefault(m => m.Name == tankName && m.GetType().Name == "Tank");
            if (checkMachine != null)
            {
                if (checkMachine.DefenseMode == true)
                {
                    checkMachine.DefenseMode = false;
                }
                else
                {
                    checkMachine.DefenseMode = true;
                }
                checkMachine.ToggleDefenseMode();

                massage = string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
            else
            {
                massage = string.Format(OutputMessages.MachineNotFound, tankName);
            }

            return massage;
        }
    }
}