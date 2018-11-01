using ABSAProject.Console;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace ABSAProject.Test
{
    [TestClass]
    public class RobotGridTest
    {
        [TestMethod]
        public void MoveRobot_Should_Do_11_Unique_Moves_For_N4_E2_S2_W4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4,E2,S2,W4");

            // Act
            var robotGridState = robotGrid.MoveRobot();

            //Assert
            Assert.AreEqual(robotGridState.StepCount, 11);
        }

        [TestMethod]
        public void MoveRobot_Should_Do_3_Right_Turns_For_N4_E2_S2_W4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4,E2,S2,W4");

            // Act
            var robotGridState = robotGrid.MoveRobot();

            //Assert
            Assert.AreEqual(robotGridState.RightTurnCount, 3);
        }

        [TestMethod]
        public void MoveRobot_Should_Do_4_Unique_Moves_For_N4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4");

            // Act
            var robotGridState = robotGrid.MoveRobot();

            //Assert
            Assert.AreEqual(robotGridState.StepCount, 4);
        }

        [TestMethod]
        public void MoveRobot_Should_Have_No_Right_Turns_For_N4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4");

            // Act
            var robotGridState = robotGrid.MoveRobot();

            //Assert
            Assert.AreEqual(robotGridState.RightTurnCount, 0);
        }

        [TestMethod]
        public void MoveRobot_Should_Have_0_Unique_Moves_For_Empty_Instructions()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("");

            // Act
            var robotGridState = robotGrid.MoveRobot();

            //Assert
            Assert.AreEqual(robotGridState.StepCount, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MoveRobot_Should_Throw_Null_Exception_When_Instructions_Are_Null()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid(null);

            // Act
            var robotGridState = robotGrid.MoveRobot();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "R format is not correct expcted formated is N4.")]
        public void MoveRobot_Should_Throw_ArgumentException_When_Instruction_Is_Not_Valid()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("R");

            // Act
            var robotGridState = robotGrid.MoveRobot();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "R is not allowed option, allowed options are N, S, E or W.")]
        public void MoveRobot_Should_Throw_ArgumentOutOfRangeException_When_Instruction_Is_Not_Valid_Direction()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("RR");

            // Act
            var robotGridState = robotGrid.MoveRobot();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "R is expected to be number please check the format.")]
        public void MoveRobot_Should_Throw_ArgumentOutOfRangeException_When_Instruction_Is_Not_Valid_Step_Count()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("NR");

            // Act
            var robotGridState = robotGrid.MoveRobot();
        }
    }
}
