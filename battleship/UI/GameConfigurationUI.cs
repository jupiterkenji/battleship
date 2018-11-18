using System;
using System.Collections.Generic;

namespace flarebattleship
{
    class GameConfigurationUI
    {
        public static GameConfiguration Run()
        {
            var playerConfigurations = new List<PlayerConfiguration>();

            for (var playerIndex = 1; playerIndex <= Game.TotalPlayers; playerIndex++)
            {
                Console.WriteLine($"=================== Setup for Player #{playerIndex} ===================");
                Console.WriteLine($"Please enter player #{playerIndex} Name: ");
                var playerName = Console.ReadLine();

                var battleshipConfigurations = new List<BattleshipConfiguration>();

                for (var battleShipIndex = 0; battleShipIndex < Game.TotalBattleShips; battleShipIndex++)
                {
                    Console.WriteLine($"=================== Setup for Player {playerIndex} ({playerName})- Battleship #{battleShipIndex}/{Game.TotalBattleShips} ===================");
                    var battleshipConfiguration = GetBattleShipConfiguration(battleShipIndex, existingBattleshipConfigurations: battleshipConfigurations);
                    battleshipConfigurations.Add(battleshipConfiguration);
                }

                var playerConfiguration = new PlayerConfiguration() { Name = playerName, BattleshipConfigurations = battleshipConfigurations};
                playerConfigurations.Add(playerConfiguration);
            }

            return new GameConfiguration(Game.BoardWidth, Game.BoardHeight) {PlayerConfigurations = playerConfigurations};
        }

        static BattleshipConfiguration GetBattleShipConfiguration(int battleShipIndex, IEnumerable<BattleshipConfiguration> existingBattleshipConfigurations)
        {
            Console.WriteLine($"Note board size: {Game.BoardWidth}x{Game.BoardHeight}");

            while(true)
            {
                BattleshipConfiguration configuration = null;
                try
                {
                    Console.WriteLine($"Please enter battleship #{battleShipIndex} x,y,orientation(h/v),size i.e 10,10,h,10: ");
                    configuration = new BattleshipConfiguration(Console.ReadLine());

                    var validation = new BoardConfigurationValidation(Game.BoardWidth, Game.BoardHeight, configuration.Position, configuration.Orientation, configuration.Size, existingBattleshipConfigurations);
                    string  message;
                    if (!validation.Validate(out message))
                    {
                        throw new Exception(message);
                    }

                    return configuration;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                }
            }
        }
    }
}