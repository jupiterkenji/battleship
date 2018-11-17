using System;
using System.Collections.Generic;
using System.Linq;

namespace flarebattleship
{
    class Game
    {
        public Game()
        {
            IsFinish = false;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to Battleship Game !");

            var gameConfiguration = GameConfigurationUI.Run();
            stateTracker = GameBuilder.Build(gameConfiguration);

            do
            {
                var hitPosition = GetHitPosition();

                var results = stateTracker.Process(hitPosition);
                var resultsAsString = string.Join(
                    ", ",
                    results
                        .Where(result => !(result is NullHitResult))
                        .Select(result => result.Result == "1" ? "Hit" : "Missed")
                ).Trim(',');
                Console.WriteLine($"Result: {resultsAsString}");

                IsFinish = stateTracker.IsFinish;
            } while (!IsFinish);

            Finish();
        }

        IPosition GetHitPosition()
        {
            while(true)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine($"{(stateTracker.CurrentPlayer.Name)}, please enter your move i.e. 'x,y' or 'quit': ");
                var input = Console.ReadLine().ToLower();

                if (input == "quit")
                {
                    IsFinish = true;
                    return null;
                }
                else
                {
                    string message;
                    if (!stateTracker.Validate(input, out message))
                    {
                        Console.WriteLine($"> Error input: {message}");
                    }
                    else
                    {
                        return Helper.Convert(input);
                    }
                }
            }
        }

        void Finish()
        {
            var winners = stateTracker
                .Players
                .Where(player => !player.Board.HasLost)
                .Select(player => player.Name);

            Console.WriteLine($"Winner/s: {(string.Join(", ", winners))}");
            Console.WriteLine("Thank you for playing!");
        }

        public bool IsFinish {get; private set;}

        public IEnumerable<string> Result => null;

        public const int BoardWidth = 20;
        public const int BoardHeight = 20;
        public const int TotalPlayers = 2;

        public const int TotalBattleShips = 2;

        StateTracker stateTracker;
    }
}