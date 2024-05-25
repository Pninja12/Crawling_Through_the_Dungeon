using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class L1Potion : PotionsLevel
    {

        public L1Potion(){
            Name = "Common Potion";
            Value = 10;
            Level = 1;
            description = "This item restores you 20 hp";
        }
    }
}