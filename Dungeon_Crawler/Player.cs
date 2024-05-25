using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        List<Item> inventory = new List<Item>{};
        List<Jewlery> Currentbuff = new List<Jewlery>{};
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
        public bool Hasbuff(){ 
            if (Currentbuff.Count > 0) return true;
            else return false;

        }
        public Jewlery Whatbuff(){ 
            return Currentbuff.First();
        }

        public void AddBuff(Jewlery i) { 
            Currentbuff.Add(i);
            switch (i.Type) {
                case 0:
                    AttackPower += i.Value;
                    break;
                case 1:
                    MaxHealth += i.Value;
                    Health += i.Value;
                    break;                 
                case 2:
                    Health += i.Value / 2;
                    MaxHealth += i.Value / 2;
                    AttackPower += i.Value / 2;
                    break;
            }
        }

        public void RemoveBuff(Jewlery i) { 
            switch (i.Type) {
                case 0:
                    AttackPower -= i.Value;
                    break;
                case 1:
                    MaxHealth -= i.Value;
                    Health -= i.Value;
                    break;                 
                case 2:
                    Health -= i.Value / 2;
                    MaxHealth -= i.Value / 2;
                    AttackPower -= i.Value / 2;
                    break;
            }
            Currentbuff.Remove(i);
        }

        
    }
}