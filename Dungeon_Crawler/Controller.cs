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
            if(model.map[model.playerLocation[0]-1][model.playerLocation[1]] 
            != '|')
            {
                model.playerLocation[0] -= 2;
            }
            else{
                view.YouCanot(" move up!");
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
                view.YouCanot(" move down!");
            }
        }

        //Lembrar: X come�a � esquerda e � a segunda lista
        public void MoveRight()
        {
            if (model.map[model.playerLocation[0]][model.playerLocation[1] + 1]
            != '|')
            {
                model.playerLocation[1] += 2;
            }
            else
            {
                view.YouCanot(" move right!");
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
                view.YouCanot(" move left!");
            }            
        }

        public void verifyfight(){
            if(model.map[model.playerLocation[0]][model.playerLocation[1]] == '/'){
                model.map[model.playerLocation[0]][model.playerLocation[1]] = '+';
                fight();
            }
        }
        public void fight(){
            int h = model.random.Next(50,71);
            int a = model.random.Next(10,16);
            model.enemy1 = new Enemy("random Enemy",h,a);
            Console.WriteLine("You found a " + model.enemy1);
            while(true){
                Console.WriteLine("What do you wanna do?(attack or heal)");
                Console.WriteLine($"hp: {model.player.Health}");
                switch (Console.ReadLine())
                {
                    case "heal":
                        model.player.Heal(10);
                        break;
                    case "attack":
                        model.player.Attack(model.enemy1);
                        break;
                    default:
                        Console.WriteLine("Unknown move");
                        break;
                }
            }
        }
        public void VerifyItem(){
            if(model.map[model.playerLocation[0]][model.playerLocation[1]] == '+'){
                PickItem();
            }
        }

        public void PickItem(){
            int h = model.random.Next(1,7);
            bool hasitem = false;
            switch (h){
                case 1:
                    Jewlery o = new Ring();
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
                    Jewlery i = new Necklace();
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
                    Jewlery j = new Necklace();
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
                verifyfight();
                VerifyItem();
                Console.WriteLine(model.player.Health + " " + model.player.AttackPower);
                Console.WriteLine(model.map[model.playerLocation[0]][model.playerLocation[1]]);
            }
            
        }

        
    }
}