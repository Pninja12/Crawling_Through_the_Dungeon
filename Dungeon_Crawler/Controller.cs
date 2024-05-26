using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Controller
    {
        View view = new View();
        Model model = new Model();
        public void MapGiver()
        {
            
            //Vai escolher aleat�riamente um mapa
            model.mapName = "Maps/Map" + model.random.Next(1,2) + ".txt";
            
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

        //Lembrar: Y come�a em cima e � a primeira lista
        public void MoveUp()
        {
            //verifica se o jogador pode mexer-se
            if(model.map[model.playerLocation[0]-1][model.playerLocation[1]] 
            != '|')
            {
                model.playerLocation[0] -= 2;
            }
            else{
                view.YouCanot("move up!");
            }
        }

        public void MoveDown()
        {
            //verifica se o jogador pode mexer-se
            if (model.map[model.playerLocation[0] + 1][model.playerLocation[1]]
            != '|')
            {
                model.playerLocation[0] += 2;
            }
            else
            {
                view.YouCanot("move down!");
            }
        }

        //Lembrar: X come�a � esquerda e � a segunda lista
        public void MoveRight()
        {
            //verifica se o jogador pode mexer-se
            if (model.map[model.playerLocation[0]][model.playerLocation[1] + 1]
            != '|')
            {
                model.playerLocation[1] += 2;
            }
            else
            {
                view.YouCanot("move right!");
            }
        }

        public void MoveLeft()
        {
            //verifica se o jogador pode mexer-se
            if (model.map[model.playerLocation[0]][model.playerLocation[1] - 1]
            != '|')
            {
                model.playerLocation[1] -= 2;
            }
            else
            {
                view.YouCanot("move left!");
            }            
        }


        public void VerifyPlace()
        {
            view.Enter_Delete();
            //troca locais por locais j� visitados
            if (model.map[model.playerLocation[0]]
            [model.playerLocation[1]] == '/')
            {
                model.map[model.playerLocation[0]]
                [model.playerLocation[1]] = '-';
                model.gameOver = Fight();
            }
            else if (model.map[model.playerLocation[0]]
            [model.playerLocation[1]] == '*')
            {
                model.map[model.playerLocation[0]]
                [model.playerLocation[1]] = '-';
                PickItem();
            }
            else if (model.map[model.playerLocation[0]]
            [model.playerLocation[1]] == '+')
            {
                model.map[model.playerLocation[0]]
                [model.playerLocation[1]] = '-';
                view.Memories(true);
            }
            else if (model.map[model.playerLocation[0]]
            [model.playerLocation[1]] == '-')
            {
                view.Memories();
            }
            else if (model.map[model.playerLocation[0]]
            [model.playerLocation[1]] == '.')
            {
                view.End(false);
                model.answer = view.Answer();
                if (model.answer == "yes")
                {
                    view.End(true,model.enemiesKilled);
                    model.gameOver = true;
                }
            }
        }
        public bool Fight()
        {
            //cria os inimigos
            WhichEnemy();
            view.FindingEnemy(model.enemies);

            view.ReadProof();
            while(model.enemies.Count > 0)
            {
                while(true)
                {
                    model.answer = view.BattleMenu(model.player);
                    
                    if(model.answer == "heal")
                    {
                        if (model.player.inventory.Count > 0)
                        {
                            ChooseHealing();
                            break;
                        }
                        else{
                            view.YouCanot("open your inventory because " +
                            "it's empty");
                            view.ReadProof();
                        }
                    }
                    else if(model.answer == "attack")
                    {
                        ChooseAttack();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Unknown move");
                        view.ReadProof();
                    }
                    
                    view.Enter_Delete();
                }
                //verifica se inimigo est� morto
                model.enemiesToKill = new List<Character>{};
                for(int i = 0; i < model.enemies.Count; i++)
                {
                    if (model.enemies[i].Health <= 0)
                    {
                        view.EnemyKilled(model.enemies[i].Name);
                        model.enemiesToKill.Add(model.enemies[i]);
                    }
                }
                //apaga inimigos
                for(int i = 0; i < model.enemiesToKill.Count; i++)
                {
                    model.enemies.Remove(model.enemiesToKill[i]);
                    model.enemiesKilled++;
                }
                //turno de ataque dos inimigos
                for(int i = 0; i < model.enemies.Count; i++)
                {
                    view.EnemyTurn(model.enemies[i].Name,
                     model.enemies[i].AttackPower);
                    model.player.Health -= model.enemies[i].AttackPower;
                }
                //se o jogador morrer

                if(model.player.Health <= 0)
                {
                    view.YouLost("the game");
                    return true;
                }
                
        
            }
            view.YouWin("the battle");
            return false;
        }
        public void ChooseHealing()
        {
            while(true)
            {
                //mostra inventario
                view.ShowInventory(model.player);
                model.answer = view.Answer();
                if (int.Parse(model.answer) < model.player.inventory.Count)
                {
                    model.player.Heal(
                        model.player.inventory[int.Parse(model.answer)].Value);
                    view.Healed(
                        model.player.inventory[int.Parse(model.answer)].Value);
                    model.player.inventory.RemoveAt(int.Parse(model.answer));
                    
                    break;
                }
                else
                {
                    view.YouCanot("use that number, try a new one.");
                    view.ReadProof();
                }
                view.Enter_Delete();
            }
        }
        public void ChooseAttack()
        {
            while(true)
            {
                //mostra inimigos
                view.ShowEnemies(model.enemies);
                model.answer = view.Answer();
                if (int.Parse(model.answer) < model.enemies.Count)
                {
                    model.enemies[int.Parse(model.answer)].Health
                    -= model.player.AttackPower;
                    break;
                }
                else
                {
                    view.YouCanot("use that number, try a new one.");
                    view.ReadProof();
                }
                view.Enter_Delete();
            }
        }

        public void PickItem(){
            int h = model.random.Next(1,7);
            model.hasItem = false;
            switch (h){
                case 1:
                    Jewelry o = new Ring();
                    Console.WriteLine($"u just got a {o.Name} {o.description}");
                    if(model.player.Hasbuff()){
                        model.hasItem = true;
                        Console.WriteLine($"u currently have a {model.player.Whatbuff().Name} {o.description}");
                    }
                    Console.WriteLine($"Would you like to use your new item?(yes or no)");
                    switch(Console.ReadLine()){
                        case "yes":
                            if (model.hasItem){
                                model.player.RemoveBuff(model.player.Whatbuff());
                            }                  
                            model.player.AddBuff(o);
                            break;
                    }
                    
                    break;
                case 2:
                    Jewelry i = new Necklace();
                    Console.WriteLine($"u just got a {i.Name} {i.description}");
                    if(model.player.Hasbuff()){
                        model.hasItem = true;
                        Console.WriteLine($"u currently have a {model.player.Whatbuff().Name} {i.description}");
                    }
                    Console.WriteLine($"Would you like to use your new item?(yes or no)");
                    switch(Console.ReadLine()){
                        case "yes":
                            if (model.hasItem){
                                model.player.RemoveBuff(model.player.Whatbuff());
                            }                  
                            model.player.AddBuff(i);
                            break;
                    }
                    break;
                case 3:
                    Jewelry j = new Necklace();
                    Console.WriteLine($"u just got a {j.Name} {j.description}");
                    if(model.player.Hasbuff()){
                        model.hasItem = true;
                        Console.WriteLine($"u currently have a {model.player.Whatbuff().Name} {j.description}");
                    }
                    Console.WriteLine($"Would you like to use your new item?(yes or no)");
                    switch(Console.ReadLine()){
                        case "yes":
                            if (model.hasItem){
                                model.player.RemoveBuff(model.player.Whatbuff());
                            }                  
                            model.player.AddBuff(j);
                            break;
                    }
                    break;
                case 4:
                    PotionsLevel k = new L1Potion();
                    Console.WriteLine($"u just got a {k.Name} {k.description}");
                    model.player.PickUpItem(k);
                    break;
                case 5:
                    PotionsLevel p = new L2Potion();
                    Console.WriteLine($"u just got a {p.Name} {p.description}");
                    model.player.PickUpItem(p);
                    break;
                case 6:
                    PotionsLevel b = new L3Potion();
                    Console.WriteLine($"u just got a {b.Name} {b.description}");
                    model.player.PickUpItem(b);
                    break;


            }
            Console.WriteLine();
        }

        public void WhichEnemy()
        {
            model.enemies = new List<Character>();
            int number = model.random.Next(1, 7);
            if(number == 1)
            {
                model.enemies.Add(new Spider("Spider1",
                model.random.Next(10, 30),model.random.Next(2, 10)));
                model.enemies.Add(new Spider("Spider2",
                model.random.Next(10, 30),model.random.Next(2, 10)));
                model.enemies.Add(new Spider("Spider3",
                model.random.Next(10, 30),model.random.Next(2, 10)));
            }
            if(number == 2)
            {
                model.enemies.Add(new Spider("Spider1",
                model.random.Next(10, 30),model.random.Next(2, 10)));
                model.enemies.Add(new Spider("Spider2",
                model.random.Next(10, 30),model.random.Next(2, 10)));
                model.enemies.Add(new Spider("Spider3",
                model.random.Next(10, 30),model.random.Next(2, 10)));
                model.enemies.Add(new Spider("Spider4",
                model.random.Next(10, 30),model.random.Next(2, 10)));
                model.enemies.Add(new Spider("Spider5",
                model.random.Next(10, 30),model.random.Next(2, 10)));
            }
            if(number == 3)
            {
                model.enemies.Add(new Skeleton("Skeleton",
                model.random.Next(20, 50),model.random.Next(10, 29)));
            }
            if(number == 4)
            {
                model.enemies.Add(new Skeleton("Skeleton1",
                model.random.Next(20, 50),model.random.Next(10, 29)));
                model.enemies.Add(new Skeleton("Skeleton2",
                model.random.Next(20, 50),model.random.Next(10, 29)));
            }
            if(number == 5)
            {
                model.enemies.Add(new Zombie("Zombie",model.random.Next(60, 80)
                ,model.random.Next(3, 12)));
            }
            if(number == 6)
            {
                model.enemies.Add(new Zombie("Zombie1",model.random.Next(60, 80)
                ,model.random.Next(3, 12)));
                model.enemies.Add(new Zombie("Zombie2",model.random.Next(60, 80)
                ,model.random.Next(3, 12)));
            }
        }

        public void Menu()
        {
            while(true)
            {
                view.Menu();
                model.answer = view.Answer();
                if(model.answer == "tutorial")
                {
                    view.Tutorial();
                }
                else if(model.answer == "exit")
                {
                    model.gameOver = true;
                    break;
                }
                else if(model.answer == "play")
                {
                    break;
                }
            }
        }
        
        public void Game()
        {
            Menu();
            
            model.player = new Player();
            while (!model.gameOver)
            {
                MapGiver();
                
                model.player.Heal(1000000);

                while (true)
                {
                    Console.WriteLine("Where do you wanna move?");
                    switch (Console.ReadLine())
                    {
                        case "up":
                            MoveUp();
                            break;
                        case "down":
                            MoveDown();
                            break;
                        case "left":
                            MoveLeft();
                            break;
                        case "right":
                            MoveRight();
                            break;
                        case "heal":
                            if (model.player.inventory.Count > 0)
                            {
                                ChooseHealing();
                            }
                            else
                            {
                                view.YouCanot("open your inventory because " +
                                "it's empty");
                                view.ReadProof();
                            }
                            break;
                        default:
                            Console.WriteLine("Unknown move");
                            break;
                    }
                    VerifyPlace();
                    if (model.gameOver)
                    {

                        break;
                    }
                }
                view.Continue();
                model.answer = view.Answer();
                if(model.answer == "yes")
                {
                    model.gameOver = false;
                }
            }
        }
    }
}