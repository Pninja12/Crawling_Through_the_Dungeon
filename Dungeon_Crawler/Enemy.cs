using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Enemy : Character
    {
        public Enemy(string name, int health, int attackPower){
            Name = name;
            Health = health; 
            AttackPower = attackPower;
        }

        
    }
}