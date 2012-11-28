using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Grid
    {
        public int numOfRows { get; private set; }
        public int numOfCols { get; private set; }
        public IEnumerable<Coordinate> obstacles;

        public Grid(Int32 numOfRows, Int32 numOfCols) : this(numOfRows, numOfCols, Enumerable.Empty<Coordinate>())
        { }

        public Grid(Int32 numOfRows, Int32 numOfCols, IEnumerable<Coordinate> obstacles)
        {
            this.numOfRows = numOfRows;
            this.numOfCols = numOfCols;
            this.obstacles = obstacles;
        }

        public Coordinate GetSpaceInFront(Coordinate space, Direction direction)
        {
            if (direction == Direction.North)
            {
                if (space.Y + 1 >= numOfRows)
                    return new Coordinate(space.X, 0);

                return new Coordinate(space.X, space.Y + 1);
            }
            else if (direction == Direction.East)
            {
                if (space.X + 1 >= numOfCols)
                    return new Coordinate(0, space.Y);

                return new Coordinate(space.X + 1, space.Y);
            }
            else if (direction == Direction.West)
            {
                if (space.X - 1 < 0)
                    return new Coordinate(numOfCols - 1, space.Y);

                return new Coordinate(space.X - 1, space.Y);
            }
            else
            {
                if (space.Y - 1 < 0)
                    return new Coordinate(space.X, numOfRows - 1);

                return new Coordinate(space.X, space.Y - 1);
            }
        }

        public Coordinate GetSpaceBehind(Coordinate space, Direction direction)
        {
            if (direction == Direction.North)
            {
                if (space.Y - 1 < 0)
                    return new Coordinate(space.X, numOfRows - 1);

                return new Coordinate(space.X, space.Y - 1);
            }
            else if (direction == Direction.East)
            {
                if (space.X - 1 < 0)
                    return new Coordinate(numOfCols - 1, space.Y);

                return new Coordinate(space.X - 1, space.Y);
            }
            else if (direction == Direction.West)
            {
                if (space.X + 1 >= numOfCols)
                    return new Coordinate(0, space.Y);

                return new Coordinate(space.X + 1, space.Y);
            }
            else
            {
                if (space.Y + 1 >= numOfRows)
                    return new Coordinate(space.X, 0);

                return new Coordinate(space.X, space.Y + 1);
            }
        }

        public Boolean IsObstacle(Coordinate coordinate)
        {
            return obstacles.Contains(coordinate);
        }

        public IEnumerable<Coordinate> GetObsstacles()
        { 
            return obstacles;
        }
    }
}
