using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Zombie : Enemy
    {

        public Zombie(string name = "Zombie", int health = 0, int attackPower = 0) :
        base(name, health, attackPower)
        {
            base.Name = name;
            base.Health = health + random.Next(60, 80);
            base.AttackPower = attackPower + random.Next(3, 12);

        }
    }
}