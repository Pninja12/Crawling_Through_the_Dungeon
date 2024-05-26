using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class L3Potion : PotionsLevel
    {

        public L3Potion(){
            Name = "Mythic Potion";
            Value = 60;
            Level = 1;
            description = "This item restores you 60 hp";
        }
    }
}