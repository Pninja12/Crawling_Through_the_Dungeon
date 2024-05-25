using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Capacete : Jewlery
    {

        public Capacete(){
            Name = "capacete";
            Value = 5;
            Type = 2;
            description = "This item gives you 5 hp and 5 Attack Power";
        }
    }
}