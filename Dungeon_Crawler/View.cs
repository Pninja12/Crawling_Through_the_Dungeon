using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class View
    {
        public void YouCanot(string sorry)
        {
            Console.WriteLine("You can't " + sorry);
        }

        //Faz um ciclo para imprimir vï¿½rios enters ou apagar o terminal
        public void Enter_Delete(int a = 0)
        {
            if(a != 0)
            {
                for(int i = 0; i < a; i++)
                {
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.Clear();
            }
        }



        //Joï¿½o altera isto!
        public string Welcome()
        {
            string a = "";
            Console.WriteLine("Welcome to the Dungeon Crawling Experience");
            Console.WriteLine("What is your name?");
            a = Console.ReadLine();
            Console.WriteLine("have a look around");
            return a;
        }
        //Joï¿½o altera isto! 
        public void Goodbye()
        {
            Console.WriteLine("See ya");
        }

        public string Do(string action = "")
        {
            if (action == "")
            {
                Console.WriteLine(action);
            }
            else
            {
                Console.WriteLine("What do you want to do next?\n-->");
            }
            return Console.ReadLine();
                
        }
        //João altera isto!
        public void Tutorial()
        {

        }

        public void Memories()
        {
            Console.WriteLine("This place looks familiar...");
        }

        public void FindingEnemy(string enemy)
        {
            Console.WriteLine("You found a", enemy);
        }

        public void StartBattle()
        {
            Console.WriteLine("The battle starts, here are your opponents:");
        }
        public string BattleMenu(Player player)
        {
            Console.WriteLine($"It's your turn");
            Console.WriteLine("What do you wanna do?(attack or heal)");
            Console.WriteLine($"hp: {player.Health}");

            return Answer();
        }

        public void ReadProof()
        {
            Console.WriteLine("Click ENTER to proceed...");
            Console.ReadLine();
        }

        public void EnemyTurn(string name)
        {
            Console.WriteLine($"It's {name}'s turn");
        }

        public string Answer()
        {
            Console.WriteLine("\n-->");
            return Console.ReadLine();
        }
    }
}