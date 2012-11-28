using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Rover
    {
        public Coordinate Location { get; private set; }
        public Direction Direction { get; private set; }
        public Boolean IsObstructed { get; set; }

        private Grid grid;

        public Rover(Coordinate startingLocation, Direction direction, Grid grid)
        {
            Location = startingLocation;
            Direction = direction;
            this.grid = grid;
        }

        public void TakeCommands(string commandString)
        {
            foreach (char command in commandString.ToLower().ToCharArray())
            {
                if (command == Command.Forward)
                    MoveForward();
                else if (command == Command.Backward)
                    MoveBackward();
                else if (command == Command.Right)
                    TurnRight();
                else if (command == Command.Left)
                    TurnLeft();
                else throw new System.InvalidOperationException("Not a valid command");
            }
        }

        public void MoveForward()
        {

            var nextLocation = grid.GetSpaceInFront(Location, Direction);

            if (grid.IsObstacle(nextLocation))
                IsObstructed = true;
            else
            {
                Location = nextLocation;
                IsObstructed = false;
            }
        }

        public void MoveBackward()
        {
            var nextLocation = grid.GetSpaceBehind(Location, Direction);

            if (grid.IsObstacle(nextLocation))
                IsObstructed = true;
            else
            {
                Location = nextLocation;
                IsObstructed = false;
            }
        }

        public void TurnRight()
        {
            if (Direction == Direction.North)
                Direction = Direction.East;
            else if (Direction == Direction.East)
                Direction = Direction.South;
            else if (Direction == Direction.South)
                Direction = Direction.West;
            else
                Direction = Direction.North;
        }

        public void TurnLeft()
        {
            if (Direction == Direction.North)
                Direction = Direction.West;
            else if (Direction == Direction.West)
                Direction = Direction.South;
            else if (Direction == Direction.South)
                Direction = Direction.East;
            else Direction = Direction.North;
        }

    }
}

