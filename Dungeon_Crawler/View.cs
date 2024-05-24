using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dungeon_Crawler
{
    public class View
    {
        public void YouCanot(string sorry)
        {
            Console.WriteLine("You can't" + sorry);
        }

        //Faz um ciclo para imprimir v�rios enters ou apagar o terminal
        public void Enter_Delete(int a)
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
        public string Welcome()
        {
            string a = "";
            Console.WriteLine("Welcome to the internet");
            Console.WriteLine("What is your name?");
            a = Console.ReadLine();
            Console.WriteLine("have a look around");
            return a;
        }
        //Jo�o altera isto! 
        public void Goodbye()
        {
            Console.WriteLine("See ya");
        }
    }
}