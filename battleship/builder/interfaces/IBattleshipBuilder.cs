using System;

namespace flarebattleship
{
    interface IBattleshipBuilder
    {
        IBattleship Build(IPosition position, Orientation orientation, int size);
    }
}