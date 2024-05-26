using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Spider : Enemy
    {
        public Spider(string name = "Spider", int health = 0, int attackPower = 0) :
        base(name, health, attackPower)
        {
            base.Name = name;
            base.Health = health + random.Next(10, 30);
            base.AttackPower = attackPower + random.Next(2, 10);

        }
    }
}