using System;
using System.Collections.Generic;
using System.Linq;

namespace flarebattleship
{
    class Board: IBoard
    {
        public Board(int width, int height)
        {
            this.battleships = new List<IBattleship>();

            this.Width = width;
            this.Height = height;
        }

        public void Add(IBattleship battleship)
        {
            this.battleships.Add(battleship);
        }

        public IEnumerable<IHitResult> GotHitAt(IPosition position)
        {
            var results = new List<IHitResult>();

            foreach (var battleship in battleships)
            {
                var result = battleship.GotHitAt(position);
                //yield result;
                results.Add(result);
            }

            return results;
        }

        public bool HasLost => battleships.All(battleship => battleship.IsSunk);
        
        List<IBattleship> battleships;

        public int Width {get; private set;}

        public int Height {get; private set;}
    }
}