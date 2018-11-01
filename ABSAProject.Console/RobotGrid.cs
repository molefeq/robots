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

        public RobotGridState MoveRobot()
        {
            RobotGridState robotGridState = new RobotGridState();
            List<string> steps = GetRobotSteps();

            if (steps.Count == 0)
            {
                return robotGridState;
            }

            foreach (string step in steps)
            {
                if (IsStartingPoint(robotGridState))
                {
                    Move(robotGridState, step);
                    continue;
                }

                MoveUp(robotGridState, step);
                MoveDown(robotGridState, step);
                MoveLeft(robotGridState, step);
                MoveRight(robotGridState, step);
            }

            return robotGridState;
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
        
        private void MoveUp(RobotGridState robotGridState, string step)
        {
            if (IsStartingPoint(robotGridState) || step != "N")
            {
                return;
            }

            robotGridState.YPoint = robotGridState.YPoint + 1;
            Move(robotGridState, step);
        }

        private void MoveDown(RobotGridState robotGridState, string step)
        {
            if (IsStartingPoint(robotGridState) || step != "S")
            {
                return;
            }

            robotGridState.YPoint = robotGridState.YPoint - 1;
            Move(robotGridState, step);
        }

        private void MoveLeft(RobotGridState robotGridState, string step)
        {
            if (IsStartingPoint(robotGridState) || step != "W")
            {
                return;
            }

            robotGridState.XPoint = robotGridState.XPoint - 1;
            Move(robotGridState, step);
        }

        private void MoveRight(RobotGridState robotGridState, string step)
        {
            if (IsStartingPoint(robotGridState) || step != "E")
            {
                return;
            }

            robotGridState.XPoint = robotGridState.XPoint + 1;
            Move(robotGridState, step);
        }

        private void Move(RobotGridState robotGridState, string step)
        {
            robotGridState.RightTurnCount = IsRightTurn(step, robotGridState.PreviuosStep) ? robotGridState.RightTurnCount + 1 : robotGridState.RightTurnCount;

            if (robotGridState.UniqueStepsTaken.ContainsKey($"x{robotGridState.XPoint}_y{robotGridState.YPoint}"))
            {
                return;
            }

            robotGridState.UniqueStepsTaken.Add($"x{robotGridState.XPoint}_y{robotGridState.YPoint}", step);
            robotGridState.StepCount = robotGridState.StepCount + 1;
            robotGridState.PreviuosStep = step;
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

        private bool IsStartingPoint(RobotGridState robotGridState)
        {
            return robotGridState.StepCount == 0 && robotGridState.XPoint == X_ORIGIN && robotGridState.YPoint == Y_ORIGIN;
        }
    }
}
