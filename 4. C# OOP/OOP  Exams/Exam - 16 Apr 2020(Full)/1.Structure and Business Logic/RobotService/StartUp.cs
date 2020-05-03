using RobotService.Core.Contracts;

namespace RobotService
{
    using Core;
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();

        }
    }
}
