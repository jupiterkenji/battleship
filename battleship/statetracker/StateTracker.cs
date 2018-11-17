using System;
using System.Linq;
using System.Collections.Generic;

namespace flarebattleship
{
    class StateTracker
    {
        public StateTracker(IEnumerable<IPlayer> players)
        {
            this.Players = players.Cast<BattleshipPlayer>().ToArray();
        }

        public IEnumerable<IHitResult> Process(IPosition hitPosition)
        {
            var result = CurrentPlayer.Board.GotHitAt(hitPosition);

            currentPlayerIndex = (currentPlayerIndex + 1) % Players.Length;

            return result;
        }

        public BattleshipPlayer[] Players {get; private set;}

        int currentPlayerIndex = 0;

        public BattleshipPlayer CurrentPlayer => Players[currentPlayerIndex];

        public bool Validate(string input, out string message)
        {
            var position = Helper.Convert(input);

            var validation = new BoardValidation(CurrentPlayer.Board, position);
            return validation.Validate(out message);
        }

        public bool IsFinish => Players.Any(player => player.Board.HasLost);
    }
}