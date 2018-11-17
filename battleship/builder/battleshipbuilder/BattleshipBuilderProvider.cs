using System;
using System.Collections.Generic;

namespace flarebattleship
{
    static class BattleshipBuilderProvider
    {
        static public BattleshipBuilder GetBuilder(Orientation orientation)
        {
            switch(orientation)
            {
                case Orientation.Horizontal:
                    return new HorizontalBattleshipBuilder();
                case Orientation.Vertical:
                    return new VerticalBattleshipBuilder();
                default:
                    throw new Exception($"Invaild orientation {orientation.ToString()}");
            }
        }
    }
}