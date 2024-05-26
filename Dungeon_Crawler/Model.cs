using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Model
    {
        public List<List<char>> map;
        public Random random= new Random();
        public string mapName = "";
        public int[] playerLocation;
        public List<Character> enemies;
        public Player player;
        public string answer = "";
        public bool hasItem;
        public bool gameOver = false;
        public int enemiesKilled = 0;

        //suporte
        public List<Character> enemiesToKill;
        
    }
}