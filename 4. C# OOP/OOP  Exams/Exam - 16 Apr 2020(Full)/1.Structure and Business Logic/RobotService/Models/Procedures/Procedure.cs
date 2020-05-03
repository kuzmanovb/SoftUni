using System.Text;
using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            Robots = new List<IRobot>();
        }

        protected List<IRobot> Robots { get; private set; }
       

        public string History()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetType().Name);
            foreach (var robot in Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IRobot robot, int procedureTime);

    }
}
