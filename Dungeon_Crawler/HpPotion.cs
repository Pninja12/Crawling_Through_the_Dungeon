using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class HpPotion : Item
    {

        public HpPotion(string name, int value){
            Name = name;
            Value = value;
        }
    }
}