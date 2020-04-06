using System;

using MortalEngines.Entities.Contracts;


namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, 100)
        {
        }

        public bool DefenseMode { get; internal set; } = true;
       
        public void ToggleDefenseMode()
        {
            if (DefenseMode == true)
            {
                this.AttackPoints -= 40;
                this.DefensePoints += 30;
            }
            else
            {
                this.AttackPoints += 40;
                this.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            string defenseModeType;
            if (DefenseMode == true)
            {
                defenseModeType = "ON";
            }
            else
            {
                defenseModeType = "OFF";
            }

            return base.ToString()
                + Environment.NewLine +
                $" *Defense: {defenseModeType}";
        }
    }
}
