using System.Collections.Generic;
using System.Linq;
using System;

namespace flarebattleship
{
    class BattleshipConfiguration
    {
        public BattleshipConfiguration(string configurationAsString)
        {
            var configurationAsArray = configurationAsString
                .Split(",")
                .Select(configuration => configuration.Trim())
                .ToArray();

            Position = new XYPosition(
                x: int.Parse(configurationAsArray[0]),
                y: int.Parse(configurationAsArray[1])
            );

            switch (configurationAsArray[2])
            {
                case "h":
                    Orientation = Orientation.Horizontal;
                    break;
                case "v":
                    Orientation = Orientation.Vertical;
                    break;
                default:
                    throw new ArgumentException("Invalid orientation");
            }

            Size = int.Parse(configurationAsArray[3]);
        }

        public XYPosition Position {get; private set;}

        public Orientation Orientation {get; private set;}

        public int Size {get; private set;}
    }
}