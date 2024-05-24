using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        Item[] inventory = new Item[9];
        public Player(string name){
            Name = name;
            Health = 100; 
            MaxHealth = 100;
            AttackPower = 33;
        }

        public override void Heal(int h) { 
            base.Heal(h);
            if (Health > MaxHealth){
                Health = MaxHealth;
            }
        }

        public void PickUpItem(Item i) { 
            for (int j = 0; j < 9; j++) {
                if (inventory[j] == null){
                    inventory[j] = i;
                }
            }
            
        }

        
    }
}