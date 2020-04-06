using System;

using MortalEngines.Entities.Contracts;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {

        public Fighter(string name, double attackPoints, double defensePoints) : base(name, attackPoints, defensePoints, 200)
        {
            
        }

        public bool AggressiveMode { get; internal set; } = true;
        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == true)
            {
                this.AttackPoints += 50;
                this.DefensePoints -= 25;
            }
            else
            {
                this.AttackPoints -= 50;
                this.DefensePoints += 25;
            }
        }

        public override string ToString()
        {
            string agressiveModeType;
            if (AggressiveMode == true)
            {
                agressiveModeType = "ON";
            }
            else
            {
                agressiveModeType = "OFF";
            }

            return base.ToString() 
                + Environment.NewLine+
                $" *Aggressive: {agressiveModeType}";
        }
    }
}
