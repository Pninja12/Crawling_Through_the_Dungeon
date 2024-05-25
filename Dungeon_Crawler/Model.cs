using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Model
    {
        public List<List<char>> map;
        public Random random = new Random();
        public String mapName = "";
        public int[] playerLocation;
        public Character enemy1;
        public Player player;

        
    }
}