using System;
using System.Collections.Generic;

namespace flarebattleship
{
    class GameBuilder
    {
        public static StateTracker Build(GameConfiguration gameConfiguration)
        {
            var players = new List<BattleshipPlayer>();

            foreach(var playerConfiguration in gameConfiguration.PlayerConfigurations)
            {
                var board = new Board(gameConfiguration.Width, gameConfiguration.Height);

                foreach (var battleShipConfiguration in playerConfiguration.BattleshipConfigurations)
                {
                    var battleShip = BattleshipBuilderProvider
                        .GetBuilder(battleShipConfiguration.Orientation)
                        .Build(
                            battleShipConfiguration.Position,
                            battleShipConfiguration.Size
                        );

                    board.Add(battleShip);
                }

                players.Add(new BattleshipPlayer(playerConfiguration.Name, board));
            }

            return new StateTracker(players);
        }
    }
}