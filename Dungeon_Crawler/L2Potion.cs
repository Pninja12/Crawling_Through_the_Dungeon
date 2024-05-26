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
            Value = 40;
            Level = 2;
            description = "This item restores you 40 hp";
        }
    }
}