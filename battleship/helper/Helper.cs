using System;
using System.Linq;
using System.Collections.Generic;

namespace flarebattleship
{
    static class Helper
    {
        public static IPosition Convert(string positionAsString)
        {
            var positionAsArray = positionAsString
                .Split(",")
                .Select(configuration => configuration.Trim())
                .ToArray();

            var position = new XYPosition(
                x: int.Parse(positionAsArray[0]),
                y: int.Parse(positionAsArray[1])
            );

            return position;
        }
    }
}