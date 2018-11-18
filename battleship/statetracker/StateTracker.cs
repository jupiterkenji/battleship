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
            var results = new List<IHitResult>();

            var otherPlayers = Players.Except(new[] {CurrentPlayer});

            foreach (var otherPlayer in otherPlayers)
            {
                var playerResults = otherPlayer.Board.GotHitAt(hitPosition);
                results.AddRange(playerResults);
            }

            currentPlayerIndex = (currentPlayerIndex + 1) % Players.Length;

            return results;
        }

        public BattleshipPlayer[] Players {get; private set;}

        int currentPlayerIndex = 0;

        public BattleshipPlayer CurrentPlayer => Players[currentPlayerIndex];

        public bool ValidateHitPosition(string input, out string message)
        {
            try
            {
                var position = Helper.Convert(input);

                var validation = new BoardPositionValidation(CurrentPlayer.Board.Width, CurrentPlayer.Board.Height, position);
                return validation.Validate(out message);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public bool IsFinish => Players.Any(player => player.Board.HasLost);
    }
}