using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Player : Character
    {
        public List<Item> inventory = new List<Item>{};
        List<Jewelry> Currentbuff = new List<Jewelry>{};
        public Player(string name){
            Name = name;
            Health = 100; 
            MaxHealth = 100;
            AttackPower = 23;
        }

        public override void Heal(int h) { 
            base.Heal(h);
            if (Health > MaxHealth){
                Health = MaxHealth;
            }
        }

        public void PickUpItem(Item i) { 
            inventory.Add(i);     
        }

        public void ShowInventory()
        {
            int contagem = new int();
            foreach(Item item in inventory)
            {   
                Console.WriteLine($"[{contagem}]{item.Name}: restores {item.Value}Hp");
                contagem++;
            }
        }

        public bool Hasbuff(){ 
            if (Currentbuff.Count > 0) return true;
            else return false;

        }
        public Jewelry Whatbuff(){ 
            return Currentbuff.First();
        }

        public void AddBuff(Jewelry i) { 
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

        public void RemoveBuff(Jewelry i) { 
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