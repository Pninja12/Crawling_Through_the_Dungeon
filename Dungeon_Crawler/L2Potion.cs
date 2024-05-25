using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class L2Potion : PotionsLevel
    {

        public L2Potion(){
            Name = "Rare Potion";
            Value = 10;
            Level = 1;
            description = "This item restores you 40 hp";
        }
    }
}