using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTest
{
    [TestClass]
    public class RoverUnitTest
    {
        [TestMethod]
        public void Constructor()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(2, 2), Direction.North, grid);

            Assert.AreEqual(new Coordinate(2, 2), rover.Location);
        }

        [TestMethod]
        public void MovingForward_ChangesPosition()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.North, grid);
            rover.MoveForward();

            Assert.AreEqual(0, rover.Location.X);
            Assert.AreEqual(1, rover.Location.Y);
        }

        [TestMethod]
        public void MovingBackward_ChangesPosition()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 1), Direction.North, grid);
            rover.MoveBackward();

            Assert.AreEqual(0, rover.Location.X);
            Assert.AreEqual(0, rover.Location.Y);
        }

        [TestMethod]
        public void WhenFacingNorth_TurnRight_AssertFacingEast()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.North, grid);
            rover.TurnRight();

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingEast_TurnRight_AssertFacingSouth()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.East, grid);
            rover.TurnRight();

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingSouth_TurnRight_AssertFacingWest()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.South, grid);
            rover.TurnRight();

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingWest_TurnRight_AssertFacingNorth()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.West, grid);
            rover.TurnRight();

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingNorth_TurnLeft_AssertFacingWest()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.North, grid);
            rover.TurnLeft();

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingWest_TurnLeft_AssertFacingSouth()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.West, grid);
            rover.TurnLeft();

            Assert.AreEqual(Direction.South, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingSouth_TurnLeft_AssertFacingEast()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.South, grid);
            rover.TurnLeft();

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void WhenFacingEast_TurnLeft_AssertFacingNorth()
        {
            var grid = new Grid(10, 10);
            var rover = new Rover(new Coordinate(0, 0), Direction.East, grid);
            rover.TurnLeft();

            Assert.AreEqual(Direction.North, rover.Direction);
        }

        [TestMethod]
        public void DoesNotMoveIntoAnObstacle()
        {
            var grid = new Grid(3, 3, new[] { new Coordinate(0, 1) });
            var rover = new Rover(new Coordinate(0, 0), Direction.North, grid);
            rover.MoveForward();

            Assert.AreEqual(new Coordinate(0, 0), rover.Location);
        }

        [TestMethod]
        public void WhenMovingIntoAnObstacle_BecomesObstructed()
        {
            var grid = new Grid(3, 3, new[] { new Coordinate(0, 1) });
            var rover = new Rover(new Coordinate(0, 0), Direction.North, grid);
            rover.MoveForward();

            Assert.IsTrue(rover.IsObstructed);
        }

        [TestMethod]
        public void TakeCommand_Forward()
        {
            var grid = new Grid(3, 3);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("f");

            Assert.AreEqual(1, rover.Location.X);
            Assert.AreEqual(2, rover.Location.Y);
        }

        [TestMethod]
        public void TakeCommand_Backward()
        {
            var grid = new Grid(3, 3);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("b");

            Assert.AreEqual(1, rover.Location.X);
            Assert.AreEqual(0, rover.Location.Y);
        }

        [TestMethod]
        public void TakeCommand_TurnRight()
        {
            var grid = new Grid(3, 3);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("r");

            Assert.AreEqual(Direction.East, rover.Direction);
        }

        [TestMethod]
        public void TakeCommand_TurnLeft()
        {
            var grid = new Grid(3, 3);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("l");

            Assert.AreEqual(Direction.West, rover.Direction);
        }

        [TestMethod]
        public void TakeCommand_MoveForawardTwoSpaces()
        {
            var grid = new Grid(4, 4);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("ff");

            Assert.AreEqual(1, rover.Location.X);
            Assert.AreEqual(3, rover.Location.Y);
        }

        [TestMethod]
        public void TakeCommand_MoveForawardOneSpaceBackwardOneSpace()
        {
            var grid = new Grid(4, 4);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("fb");

            Assert.AreEqual(1, rover.Location.X);
            Assert.AreEqual(1, rover.Location.Y);
        }

        [TestMethod, ExpectedException(typeof(InvalidOperationException))]
        public void TakeCommand_InvalidCommand()
        {
            var grid = new Grid(4, 4);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("x");   
        }

        [TestMethod]
        public void TakeCommand_UpperCaseCommand()
        {
            var grid = new Grid(4, 4);
            var rover = new Rover(new Coordinate(1, 1), Direction.North, grid);
            rover.TakeCommands("F");

            Assert.AreEqual(1, rover.Location.X);
            Assert.AreEqual(2, rover.Location.Y);
        }
    }
}
