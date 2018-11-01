namespace ABSAProject.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a set of instructions.");
                System.Console.WriteLine("For Example: N4,E2,S2,W4");
                return;
            }

            RobotGrid robotGrid = new RobotGrid(args[0]);
            RobotGridState robotGridState =  robotGrid.MoveRobot();
            
            System.Console.WriteLine($"Number Of Steps: {robotGridState.StepCount}");
            System.Console.WriteLine($"Number Of Right Turns: {robotGridState.RightTurnCount}");

            System.Console.ReadLine();
        }
    }
}
