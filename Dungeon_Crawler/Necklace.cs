using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Necklace : Jewlery
    {
        public Necklace(){
            Name = "Necklace";
            Value = 10;
            Type = 1;
            description = "This item gives you 10 hp";
        }

    }
}