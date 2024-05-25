using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Ring : Jewlery
    {

        public Ring(){
            Name = "Ring";
            Value = 10;
            Type = 0;
            description = "This item gives you 10 Attack Power";
        }

    }
}