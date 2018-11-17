using System;

namespace flarebattleship
{
    class Player: IPlayer
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name {get; private set;}
    }
}