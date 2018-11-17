using System;

namespace flarebattleship
{
    class BattleshipPlayer: IPlayer
    {
        public BattleshipPlayer(string name, Board board)
        {
            this.Name = name;
            this.Board = board;
        }

        public string Name {get; private set;}
        public Board Board {get; private set;}
    }
}