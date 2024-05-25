using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        List<Item> inventory = new List<Item>{};
        public Player(string name){
            Name = name;
            Health = 100; 
            MaxHealth = 100;
            AttackPower = 33;
        }

        public override void Heal(int h) { 
            base.Heal(10);
            if (Health > MaxHealth){
                Health = MaxHealth;
            }
        }

        public void PickUpItem(Item i) { 
            inventory.Add(i);     
        }

        
    }
}