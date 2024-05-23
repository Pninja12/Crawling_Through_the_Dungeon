using System;
using System.Collections.Generic;
using System.IO;

namespace Dungeon_Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string s;

            using StreamReader sr = new StreamReader("Map1.txt");
            List<List<char>> map = new List<List<char>>();
            List<char> temp = new List<char>();
            int x = 0;
            int y = 0;
            int[] PlayerLocation = new int []{ y, x };

            while ((s = sr.ReadLine()) != null)
            {
                foreach (char c in s)
                {
                    temp.Add(c);
                    if (c == '.')
                    {
                        PlayerLocation[0] = y;
                        PlayerLocation[1] = x;
                    }
                    x += 1;
                    
                    
                }
                map.Add(temp);
                temp = new List<char>();
                y += 1;
                x = 0;
            }

            y = PlayerLocation[0];
            x = PlayerLocation[1];

            Console.WriteLine($"{y},{x}");

            if (map[(y - 1)][x] != '|')
            {
                Console.WriteLine($"moveu-se cima, {map[(y - 1)][x]}");
                PlayerLocation[0] = y - 2;
            }
            if (map[y][x + 1] != '|')
            {
                Console.WriteLine($"moveu-se lado,{map[y][x + 1]}");
                PlayerLocation[1] = x + 2;
            }
            y = PlayerLocation[0];
            x = PlayerLocation[1];
            Console.WriteLine($"moveu-se lado,{map[y][x]}");
            Console.WriteLine($"{y},{x}");
            
            
        }
    }
}
