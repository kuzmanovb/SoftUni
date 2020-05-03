using System;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {

            if (robot.ProcedureTime - procedureTime < 0)
            {
                throw new ArgumentException("Robot doesn't have enough procedure time");
            }

            robot.ProcedureTime -= procedureTime;

           
            robot.Energy -= 8;
            if (robot.IsChecked)
            {
                robot.Energy -= 8;
            }
            Robots.Add(robot);
        }
    }
}
