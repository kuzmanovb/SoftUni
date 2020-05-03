using System;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
   public class Charge : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }

            robot.ProcedureTime -= procedureTime;

            robot.Happiness += 12;
            robot.Energy += 10;
            Robots.Add(robot);
        }
    }
}
