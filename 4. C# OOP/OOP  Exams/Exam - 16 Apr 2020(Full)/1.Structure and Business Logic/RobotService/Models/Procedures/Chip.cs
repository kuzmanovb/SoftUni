using System;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }

            robot.ProcedureTime -= procedureTime;

            if (robot.IsChipped)
            {
                throw new ArgumentException($"{robot.Name} is already chipped");
            }


            robot.IsChipped = true;
            robot.Happiness -= 5;
            Robots.Add(robot);
        }
    }
}
