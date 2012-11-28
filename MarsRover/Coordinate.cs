using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    public class Coordinate
    {
        public Int32 X { get; private set; }
        public Int32 Y { get; private set; }

        public Coordinate(Int32 x, Int32 y)
        {
            X = x;
            Y = y;
        }

        public override Int32 GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override Boolean Equals(Object obj)
        {
            if (obj is Coordinate == false)
                return false;

            var otherCoordinate = obj as Coordinate;

            if (this.GetHashCode() != otherCoordinate.GetHashCode())
                return false;

            if (this.X != otherCoordinate.X || this.Y != otherCoordinate.Y)
                return false;

            return true;
        }

        public override String ToString()
        {
            return String.Format("({0}, {1})", X, Y);
        }
    }
}
