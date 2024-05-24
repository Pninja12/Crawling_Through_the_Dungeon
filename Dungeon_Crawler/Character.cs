using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health;
        public int MaxHealth;
        public int AttackPower;

        public void Attack(Character u) {
            u.Health -= AttackPower;
        }
        public virtual void Heal(int h) {           
            Health += h;
        }
    }
}