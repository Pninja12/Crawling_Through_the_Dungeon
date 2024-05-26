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

        //Faz um ciclo para imprimir v�rios enters ou apagar o terminal
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
        //Jo�o altera isto! 
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

        public void Tutorial()
        {
            Enter_Delete();
            Console.Write("Description:\nThis is a single player game.\n");
            Console.Write("You play as an adventurer that is exploring");
            Console.Write(" a dungeon trying to loot any treasure he finds.\n");
            Console.WriteLine("There's 4 types of different rooms:");
            Console.WriteLine("-entrance/exit");
            Console.WriteLine("-enemy room");
            Console.WriteLine("-treasure room");
            Console.WriteLine("-empty room\n");
            ReadProof();
            Enter_Delete();
            Console.Write("Objective:\nThe objective");
            Console.Write(" is to kill the most enemies before returning");
            Console.WriteLine(" to the starting room to exit the dungeon.\n");
            ReadProof();
            Enter_Delete();
            Console.Write("How to Play:\nThe game starts with the player in ");
            Console.Write("the entrance room.\nYou can input the following ");
            Console.WriteLine("commands in any room:");
            Console.WriteLine("-\"up\", to go to the room above;");
            Console.WriteLine("-\"down\", to go to the room below;");
            Console.WriteLine("-\"left\", to go to the room to the left;");
            Console.WriteLine("-\"right\", to go to the room to the right;\n");
            Console.Write("If there is a door in the direction you chose");
            Console.WriteLine(", you move to that room.\n");
            Console.Write("If you enter a enemy room, the battle begins and ");
            Console.WriteLine("you can input the following commands:");
            Console.WriteLine("-\"attack\", to attack the enemy");
            Console.WriteLine("-\"heal\", to use one of the heal potions\n");
            ReadProof();
            Enter_Delete();
        }

        public void Memories(bool verdade = false)
        {
            if (verdade)
                Console.WriteLine("The room is empty.");
            else
                Console.WriteLine("You have already been to this room...");
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
            Console.WriteLine("What do you want to do?(attack or heal)");
            Console.WriteLine($"HP: {player.Health}");

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
            Console.WriteLine("Choose which enemy to attack:");
            for(int i = 0; i < enemies.Count; i++)
            {
                Console.Write($"[{i}]{enemies[i].Name}: {enemies[i].Health}\n");
            }
        }
        public void ShowInventory(Player player)
        {
            Console.WriteLine("Choose which item to consume:");
            for(int i = 0; i < player.inventory.Count; i++)
            {
                Console.WriteLine($"[{i}]{player.inventory[i].Name}: " +
                $"restores {player.inventory[i].Value}Hp");
            }
            
        }

        public void Healed(int value)
        {
            Console.WriteLine($"You healed {value} HP");
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
            {
                Console.Write("Want to exit the dungeon ");
                Console.WriteLine("and end your adventure?(yes/no)");
            }             

            else      
            {
                Console.Write("Here's your score:\nEnemies killed: ");
                Console.WriteLine(points);
                ReadProof();
            }         
                
        }

        public void Continue()
        {
            Console.Write("Do you want to restart your adventure?(yes/no)\n");
        }

        public void Menu()
        {
            Enter_Delete();
            Console.WriteLine("Welcome to the Dungeon Crawling Experience!\n");
            Console.Write("Choose and option(play, tutorial, exit):");
            Enter_Delete(1);
        }
        
    }
}