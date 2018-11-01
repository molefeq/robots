using System.Collections.Generic;

namespace ABSAProject.Console
{
    public class RobotGridState
    {
        public RobotGridState()
        {
            XPoint = 0;
            YPoint = 0;
            PreviuosStep = null;
            StepCount = 0;
            RightTurnCount = 0;
            UniqueStepsTaken = new Dictionary<string, string>();
        }

        public int StepCount { get; set; }
        public string PreviuosStep { get; set; }
        public int XPoint { get; set; }
        public int YPoint { get; set; }
        public int RightTurnCount { get; set; }
        public Dictionary<string, string> UniqueStepsTaken { get; set; }
    }
}
