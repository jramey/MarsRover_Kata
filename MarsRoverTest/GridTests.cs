using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRoverTest
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void Constructor()
        {
            var grid = new Grid(100, 100);
        }

        [TestMethod]
        public void ConstructorWithObstacles()
        {            
            var obstacles = Enumerable.Empty<Coordinate>();
            var grid = new Grid(100, 100, obstacles);
        }

        [TestMethod]
        public void GetNextSpace_North()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(0, 0), Direction.North);
            Assert.AreEqual(new Coordinate(0, 1), nextSpace);
        }

        [TestMethod]
        public void GetNextSpace_East()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(0, 0), Direction.East);
            Assert.AreEqual(new Coordinate(1, 0), nextSpace);
        }

        [TestMethod]
        public void GetNextSpace_South()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(1, 1), Direction.South);
            Assert.AreEqual(new Coordinate(1, 0), nextSpace);
        }

        [TestMethod]
        public void GetNextSpace_West()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(1, 1), Direction.West);
            Assert.AreEqual(new Coordinate(0, 1), nextSpace);
        }

        [TestMethod]
        public void WrapNorth()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(0, 2), Direction.North);
            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }

        [TestMethod]
        public void WrapEast()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(2, 0), Direction.East);
            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }

        [TestMethod]
        public void WrapSouth()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(0, 0), Direction.South);
            Assert.AreEqual(new Coordinate(0, 2), nextSpace);
        }

        [TestMethod]
        public void WrapWest()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceInFront(new Coordinate(0, 0), Direction.West);
            Assert.AreEqual(new Coordinate(2, 0), nextSpace);
        }

        [TestMethod]
        public void GetNextSpace_North_ReturnsCurrentSpaceWhenObstructed()
        {
            var grid = new Grid(3, 3, new[] { new Coordinate(0, 1) });
            var isObstacle = grid.IsObstacle(new Coordinate(0, 1));
            Assert.IsTrue(isObstacle);
        }

        [TestMethod]
        public void GetSpaceBehindCurrentSpaceWhenObstructed()
        {
            var grid = new Grid(3, 3, new[] { new Coordinate(0, 1) });
            var nextLocation = grid.GetSpaceBehind(new Coordinate(0, 1), Direction.North);
            var isObstacle = grid.IsObstacle(new Coordinate(0, 1));
            Assert.IsTrue(isObstacle);
            Assert.AreEqual(nextLocation, new Coordinate(0,0));
        }

        [TestMethod]
        public void WrapEastBackwards()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceBehind(new Coordinate(0, 0), Direction.East);
            Assert.AreEqual(new Coordinate(2, 0), nextSpace);
        }

        [TestMethod]
        public void WrapWestBackwards()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceBehind(new Coordinate(2, 0), Direction.West);
            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }


        [TestMethod]
        public void WrapNorthBackwards()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceBehind(new Coordinate(0, 0), Direction.North);
            Assert.AreEqual(new Coordinate(0, 2), nextSpace);
        }

        [TestMethod]
        public void WrapSouthBackwards()
        {
            var grid = new Grid(3, 3);
            var nextSpace = grid.GetSpaceBehind(new Coordinate(0, 2), Direction.South);
            Assert.AreEqual(new Coordinate(0, 0), nextSpace);
        }
    }
}
