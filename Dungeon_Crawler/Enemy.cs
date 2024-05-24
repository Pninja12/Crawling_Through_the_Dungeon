using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Enemy : Character
    {
        public Enemy(string name){
            Name = name;
            Health = 100; 
            AttackPower = 33;
        }

        
    }
}