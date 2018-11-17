using System;
using System.Collections.Generic;

namespace flarebattleship
{
    interface IBoard
    {
        void Add(IBattleship battleship);
        
        IEnumerable<IHitResult> GotHitAt(IPosition position);
        
        bool HasLost { get; }
    }
}