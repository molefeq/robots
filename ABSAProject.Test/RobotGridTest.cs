using ABSAProject.Console;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace ABSAProject.Test
{
    [TestClass]
    public class RobotGridTest
    {        
        [TestMethod]
        public void CalculateRobotUniqueMoves_Should_Return_11_For_N4_E2_S2_W4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4,E2,S2,W4");
            int rightMovesCount;

            // Act
           var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);

            //Assert
            Assert.AreEqual(stepsCount, 11);
        }

        [TestMethod]
        public void CalculateRobotUniqueMoves_Should_Do_3_Right_Turns_For_N4_E2_S2_W4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4,E2,S2,W4");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);

            //Assert
            Assert.AreEqual(rightMovesCount, 3);
        }

        [TestMethod]
        public void CalculateRobotUniqueMoves_Should_Return_4_For_N4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);

            //Assert
            Assert.AreEqual(stepsCount, 4);
        }

        [TestMethod]
        public void CalculateRobotUniqueMoves_Should_Return_Have_No_Right_Turns_For_N4()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("N4");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);

            //Assert
            Assert.AreEqual(rightMovesCount, 0);
        }

        [TestMethod]
        public void CalculateRobotUniqueMoves_Should_Return_0_For_Empty_Instructions()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);

            //Assert
            Assert.AreEqual(stepsCount, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CalculateRobotUniqueMoves_Should_Throw_Null_Exception_When_Instructions_Are_Null()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid(null);
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "R format is not correct expcted formated is N4.")]
        public void CalculateRobotUniqueMoves_Should_Throw_ArgumentException_When_Instruction_Is_Not_Valid()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("R");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "R is not allowed option, allowed options are N, S, E or W.")]
        public void CalculateRobotUniqueMoves_Should_Throw_ArgumentOutOfRangeException_When_Instruction_Is_Not_Valid_Direction()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("RR");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "R is expected to be number please check the format.")]
        public void CalculateRobotUniqueMoves_Should_Throw_ArgumentOutOfRangeException_When_Instruction_Is_Not_Valid_Step_Count()
        {
            // Arrange
            RobotGrid robotGrid = new RobotGrid("NR");
            int rightMovesCount;

            // Act
            var stepsCount = robotGrid.CalculateRobotUniqueMoves(out rightMovesCount);
        }
        
    }
}
