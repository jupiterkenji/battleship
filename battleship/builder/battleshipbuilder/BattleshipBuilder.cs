using System;
using System.Collections.Generic;

namespace flarebattleship
{
    abstract class BattleshipBuilder
    {
        abstract public XYBattleship Build(XYPosition position, int size);
    }
}