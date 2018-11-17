using System.Collections.Generic;
using System.Linq;
using System;

namespace flarebattleship
{
    class PlayerConfiguration
    {
        public string Name;
        public IEnumerable<BattleshipConfiguration> BattleshipConfigurations;
    }
}