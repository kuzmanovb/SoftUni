using System;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }

            robot.ProcedureTime -= procedureTime;

            robot.Happiness -= 3;
            robot.Energy += 10;
            Robots.Add(robot);
        }
    }
}
