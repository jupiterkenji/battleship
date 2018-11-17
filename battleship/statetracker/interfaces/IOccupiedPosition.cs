using System;

namespace flarebattleship
{
    interface IOccupiedPosition
    {
        IPosition Position {get;}
        bool Damage {get;set;}
    }
}