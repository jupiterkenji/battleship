using System.Collections.Generic;
using System.Linq;
using System;

namespace flarebattleship
{
    class GameConfiguration
    {
        public GameConfiguration(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public IEnumerable<PlayerConfiguration> PlayerConfigurations;
        public int Width {get; private set;}

        public int Height {get; private set;}

    }
}