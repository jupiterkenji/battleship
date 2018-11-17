using System;

namespace flarebattleship
{
    class  XYPosition: IPosition
    {
        public XYPosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X {get; private set;}
        public int Y {get; private set;}

        public bool Equals(IPosition other)
        {
            if (other is XYPosition otherAsXY)
            {
                return this.X == otherAsXY.X && this.Y == otherAsXY.Y;
            }

            return false;
        }
    }
}