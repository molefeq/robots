using System;
using System.Collections.Generic;
using System.Linq;

namespace ABSAProject.Console
{
    public class RobotGrid
    {
        private static readonly int X_ORIGIN = 0;
        private static readonly int Y_ORIGIN = 0;

        public RobotGrid(string robotMoves)
        {
            this.RobotMoves = robotMoves;
        }

        public string RobotMoves { get; }
        
        public int CalculateRobotUniqueMoves(out int rightCount)
        {
            int stepCount = 0;
            List<string> steps = GetRobotSteps();

            rightCount = 0;

            if (steps.Count == 0)
            {
                return stepCount;
            }

            int xPoint = X_ORIGIN;
            int yPoint = Y_ORIGIN;
            string previuosStep = null;

            Dictionary<string, string> uniqueStepsTaken = new Dictionary<string, string>();

            foreach (string step in steps)
            {
                if (stepCount == 0 && xPoint == X_ORIGIN && yPoint == Y_ORIGIN)
                {
                    uniqueStepsTaken.Add($"x{xPoint}_y{yPoint}", step);
                    stepCount = stepCount + 1;
                    previuosStep = step;
                    continue;
                }

                if (step == "N")
                {
                    yPoint = yPoint + 1;
                }

                if (step == "S")
                {
                    yPoint = yPoint - 1;
                }

                if (step == "E")
                {
                    xPoint = xPoint + 1;
                }

                if (step == "W")
                {
                    xPoint = xPoint - 1;
                }

                if (!uniqueStepsTaken.ContainsKey($"x{xPoint}_y{yPoint}"))
                {
                    uniqueStepsTaken.Add($"x{xPoint}_y{yPoint}", step);
                    stepCount = stepCount + 1;
                }

                rightCount = IsRightTurn(step, previuosStep) ? rightCount + 1 : rightCount;

                previuosStep = step;
            }

            return stepCount;
        }

        private List<string> GetRobotSteps()
        {
            List<string> steps = new List<string>();
            string[] instructions = RobotMoves.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string instruction in instructions)
            {
                CheckInstruction(instruction);
                steps.AddRange(Enumerable.Repeat<String>(instruction.Substring(0, 1), Convert.ToInt32(instruction.Substring(1).Trim())).ToList<String>());
            }

            return steps;
        }

        private void CheckInstruction(string instruction)
        {
            if (instruction.Length < 2)
            {
                throw new ArgumentException($"{instruction} format is not correct expcted formated is N4.");
            }

            var direction = instruction.Substring(0, 1);
            int stepCount;

            if (direction != "N" && direction != "S" && direction != "E" && direction != "W")
            {
                throw new ArgumentOutOfRangeException($"{direction} is not allowed option, allowed options are N, S, E or W.");
            }

            if (!Int32.TryParse(instruction.Substring(1).Trim(), out stepCount))
            {
                throw new ArgumentOutOfRangeException($"{instruction.Substring(1).Trim()} is expected to be number please check the format.");
            }
        }

        private bool IsRightTurn(string currentStep, string previuosStep)
        {
            return (previuosStep == "N" && currentStep == "E") ||
                   (previuosStep == "E" && currentStep == "S") ||
                   (previuosStep == "S" && currentStep == "W") ||
                   (previuosStep == "W" && currentStep == "N");
        }

    }
}
