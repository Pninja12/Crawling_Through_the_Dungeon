using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Controller
    {
        View view;
        Model model;
        public void MapGiver()
        {
            
            //Vai escolher aleat�riamente um mapa
            model.mapName = "Map" + model.random.Next(1,3) + ".txt";
            

            using StreamReader sr = new StreamReader(model.mapName);
            model.map = new List<List<char>>();
            List<char> temp = new List<char>();
            model.playerLocation = new int []{0,0};

            //vari�veis de suporte
            int x = 0;
            int y = 0;
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                foreach (char c in s)
                {
                    //Adiciona cada charater a uma lista na vertical (x)
                    temp.Add(c);
                    if (c == '.')
                    {
                        model.playerLocation[0] = y;
                        model.playerLocation[1] = x;
                    }
                    x += 1;
                    
                    
                }
                //Adiciona cada lista a uma lista na horizontal (y)
                model.map.Add(temp);
                //apaga os conteudos da lista tempor�ria
                temp = new List<char>();
                y += 1;
                x = 0;
            }
        }

        public void MoveUp()
        {
            if(model.map[model.playerLocation[0]][model.playerLocation[1] + 1] 
            != '|')
            {
                model.playerLocation[1] += 2;
            }
            else{
                view.YouCanot("move up!");
            }
        }

        public void MoveDown()
        {
            if(model.map[model.playerLocation[0]][model.playerLocation[1] - 1] 
            != '|')
            {
                model.playerLocation[1] += 2;
            }
            else{
                view.YouCanot("move down!");
            }
    }
}