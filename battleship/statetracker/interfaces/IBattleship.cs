using System;

namespace flarebattleship
{
    interface IBattleship
    {
        IHitResult GotHitAt(IPosition position);
        bool IsSunk {get;}
    }
}