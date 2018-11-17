using System;

namespace flarebattleship
{
    class BattleshipPlayer: IPlayer
    {
        public BattleshipPlayer(string name, Board board)
        {
            Name = name;
            Board = Board;
        }

        public string Name {get; private set;}
        public Board Board {get; private set;}
    }
}