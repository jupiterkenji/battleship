using System;
using System.Collections.Generic;
using System.Linq;

namespace flarebattleship
{
    class XYBattleship: IBattleship
    {
        public XYBattleship(IEnumerable<IOccupiedPosition> occupiedPositions)
        {
            this.occupiedPositions = new List<IOccupiedPosition>();

            foreach (var occupiedPosition in occupiedPositions)
            {
                this.occupiedPositions.Add(occupiedPosition);
            }
        }

        public IHitResult GotHitAt(IPosition position)
        {
            foreach(var occupiedPosition in occupiedPositions)
            {
                if (position.Equals(occupiedPosition.Position))
                {
                    occupiedPosition.Damage = true;
                    return new HitResult("1");
                }
            }

            return new NullHitResult();
        }

        public bool IsSunk => occupiedPositions.All(occupiedPosition => occupiedPosition.Damage == true);

        protected void CloneFrom(XYBattleship battleship)
        {
            this.occupiedPositions = battleship.occupiedPositions;
        }

        protected List<IOccupiedPosition> occupiedPositions;
    }
}