using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class Controller
    {
        View view = new View();
        Model model = new Model();
        public void MapGiver()
        {
            
            //Vai escolher aleatùriamente um mapa
            model.mapName = "Maps/Map" + model.random.Next(1,2) + ".txt";
            
            using StreamReader sr = new StreamReader(model.mapName);
            model.map = new List<List<char>>();
            List<char> temp = new List<char>();
            model.playerLocation = new int []{0,0};

            //variùveis de suporte
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
                //apaga os conteudos da lista temporùria
                temp = new List<char>();
                y += 1;
                x = 0;
            }
        }

        //Lembrar: Y comeùa em cima e ù a primeira lista
        public void MoveUp()
        {
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

        //Lembrar: X comeùa ù esquerda e ù a segunda lista
        public void MoveRight()
        {
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
            if(model.map[model.playerLocation[0]][model.playerLocation[1]] == '/')
            {
                model.map[model.playerLocation[0]][model.playerLocation[1]] = '-';
                Fight();
            }
            if(model.map[model.playerLocation[0]][model.playerLocation[1]] == '*')
            {
                model.map[model.playerLocation[0]][model.playerLocation[1]] = '-';
                PickItem();
            }
            if(model.map[model.playerLocation[0]][model.playerLocation[1]] == '+')
            {
                model.map[model.playerLocation[0]][model.playerLocation[1]] = '-';
                view.Memories();
            }
        }
        public void Fight(){
            ChooseEnemy();
            foreach(Enemy enemy in model.enemies)
            {
                view.FindingEnemy(enemy.Name);
            }
            view.ReadProof();
            while(true){
                model.answer = view.BattleMenu(model.player);
                switch (model.answer)
                {
                    case "heal":
                        if (model.player.inventory != null)
                        {
                            ChooseHealing();
                            break;
                        }
                        else{
                            view.YouCanot("open your inventory");
                            break;
                        }
                    case "attack":
                        model.player.Attack(model.enemy1);
                        break;
                    default:
                        Console.WriteLine("Unknown move");
                        break;
                }
                if (model.enemy1.Health <= 0){
                    Console.WriteLine("Matou o inimigo");
                    break;
                }
                
            }
        }
        public void ChooseHealing()
        {
            while(true)
            {
                model.player.ShowInventory();
                model.answer = view.Answer();
                if (int.Parse(model.answer) < model.player.inventory.Count)
                {
                    model.player.Heal(
                        model.player.inventory[int.Parse(model.answer)].Value);
                    model.player.inventory.RemoveAt(int.Parse(model.answer));
                    break;
                }
                else
                {
                    view.YouCanot("use that number, try a new one.");
                }
                view.Enter_Delete();
            }

        }

        public void PickItem(){
            int h = model.random.Next(1,7);
            bool hasitem = false;
            switch (h){
                case 1:
                    Jewelry o = new Ring();
                    Console.WriteLine($"u just got a {o.Name} {o.description}");
                    if(model.player.Hasbuff()){
                        hasitem = true;
                        Console.WriteLine($"u currently have a {model.player.Whatbuff().Name} {o.description}");
                    }
                    Console.WriteLine($"Would you like to use your new item?(yes or no)");
                    switch(Console.ReadLine()){
                        case "yes":
                            if (hasitem){
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
                        hasitem = true;
                        Console.WriteLine($"u currently have a {model.player.Whatbuff().Name} {i.description}");
                    }
                    Console.WriteLine($"Would you like to use your new item?(yes or no)");
                    switch(Console.ReadLine()){
                        case "yes":
                            if (hasitem){
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
                        hasitem = true;
                        Console.WriteLine($"u currently have a {model.player.Whatbuff().Name} {j.description}");
                    }
                    Console.WriteLine($"Would you like to use your new item?(yes or no)");
                    switch(Console.ReadLine()){
                        case "yes":
                            if (hasitem){
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

        public void ChooseEnemy()
        {
            int number = model.random.Next(1, 7);
            if(number == 1)
            {
                model.enemies.Add(new Spider("Spider1"));
                model.enemies.Add(new Spider("Spider2"));
                model.enemies.Add(new Spider("Spider3"));
            }
            if(number == 2)
            {
                model.enemies.Add(new Spider("Spider1"));
                model.enemies.Add(new Spider("Spider2"));
                model.enemies.Add(new Spider("Spider3"));
                model.enemies.Add(new Spider("Spider4"));
                model.enemies.Add(new Spider("Spider5"));
            }
            if(number == 3)
            {
                model.enemies.Add(new Skeleton());
            }
            if(number == 4)
            {
                model.enemies.Add(new Skeleton("Skeleton1"));
                model.enemies.Add(new Skeleton("Skeleton2"));
            }
            if(number == 5)
            {
                model.enemies.Add(new Zombie());
            }
            if(number == 6)
            {
                model.enemies.Add(new Zombie("Zombie1"));
                model.enemies.Add(new Zombie("Zombie2"));
            }
        }
        
        public void Game()
        {
            string n;
            n = view.Welcome();
            MapGiver();
            model.player = new Player(n);

            model.player.Heal(10);
            
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
                    default:
                        Console.WriteLine("Unknown move");
                        break;
                }
                VerifyPlace();
                Console.WriteLine(model.player.Health + " " + model.player.AttackPower);
                Console.WriteLine(model.map[model.playerLocation[0]][model.playerLocation[1]]);
            }
            
        }

        
    }
}