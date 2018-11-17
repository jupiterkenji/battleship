using System;

namespace flarebattleship
{
    class XYOccupiedPosition: IOccupiedPosition
    {
        public XYOccupiedPosition(XYPosition position)
        {
            this.Position = position;
        }

        public IPosition Position {get; private set;}
        public bool Damage {get;set;}
    }
}