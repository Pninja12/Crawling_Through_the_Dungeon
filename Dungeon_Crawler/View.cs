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

        public void Memories(bool verdade = false)
        {
            if (verdade)
                Console.WriteLine("A sala está vazia");
            else
                Console.WriteLine("This place looks familiar...");
        }

        public void FindingEnemy(List<Character> enemies)
        {
            for(int i = 0; i < enemies.Count; i++)
            {
                Console.WriteLine($"You found a {enemies[i].Name}");
            }
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

        public void EnemyTurn(string name, int damage)
        {
            Console.WriteLine($"It's {name}'s turn");
            Console.WriteLine($"\n{name} deals {damage} of damage");
        }

        public string Answer()
        {
            Console.Write("\n-->");
            return Console.ReadLine();
        }

        public void ShowEnemies(List<Character> enemies)
        {
            Console.WriteLine("Choose which to attack:");
            for(int i = 0; i < enemies.Count; i++)
            {
                Console.Write($"[{i}]{enemies[i].Name}: {enemies[i].Health}\n");
            }
        }
        public void ShowInventory(Player player)
        {
            Console.WriteLine("Choose which to consume:");
            for(int i = 0; i < player.inventory.Count; i++)
            {
                Console.WriteLine($"[{i}]{player.inventory[i].Name}: " +
                $"restores {player.inventory[i].Value}Hp");
            }
            
        }

        public void Healed(int value)
        {
            Console.WriteLine($"You healed {value}");
        }

        public void EnemyKilled(string name)
        {
            Console.WriteLine($"You killed {name}");
        }

        public void YouWin(string rest)
        {
            Console.WriteLine($"Congratulations! You win " + rest);
        }

        public void YouLost(string rest)
        {
            Console.WriteLine($"You lost " + rest);
        }

        public void End(bool answer,int points = 0)
        {
            if(!answer)                
                Console.WriteLine("Want to end your adventure?(yes/no)");

            else      
            {
                Console.Write("Here's your score\nEnemies killed: ");
                Console.WriteLine(points);
                ReadProof();
            }         
                
        }

        public void Continue()
        {
            Console.Write("Do you want to continue your adventures?(yes/no)\n");
        }

        public void Menu()
        {
            Console.WriteLine("Welcome to the Dungeon Crawling Experience");
            Console.Write("Choose and option(play,tutorial,exit):");
            Enter_Delete(3);
        }
        
    }
}