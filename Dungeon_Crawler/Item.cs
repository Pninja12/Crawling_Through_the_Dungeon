using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public abstract class Item
    {
        public string Name{ get; set; }
        public virtual int Value{ get; set; }
        public string description;
        
    }
}