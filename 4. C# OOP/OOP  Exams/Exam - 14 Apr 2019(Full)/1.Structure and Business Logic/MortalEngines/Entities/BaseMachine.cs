using System;
using System.Text;
using System.Collections.Generic;

using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IPilot pilot;

        private readonly List<string> targets;

        public BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public IPilot Pilot
        {
            get => this.pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }
        public double HealthPoints {
            get => this.healthPoints;
            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints 
        { 
            get => this.attackPoints;
            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        { get => this.defensePoints;
            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets => this.targets;

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            target.HealthPoints -= Math.Abs(this.AttackPoints - target.DefensePoints);

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            Targets.Add(target.Name);
        }

        public override string ToString()
        {
            string targets;
            if (Targets.Count == 0)
            {
                targets = "None";
            }
            else
            {
                targets = string.Join(",", Targets);
            }
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}")
                .AppendLine($" *Type: {this.GetType().Name}")
                .AppendLine($" *Health: {this.HealthPoints:f2}")
                .AppendLine($" *Attack: {this.AttackPoints:f2}")
                .AppendLine($" *Defense: {this.DefensePoints:f2}")
                .AppendLine($" *Targets: {targets}");

            return sb.ToString().TrimEnd();
        }
    }
}
