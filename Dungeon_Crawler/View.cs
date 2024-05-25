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
            Console.WriteLine("You can't" + sorry);
        }

        //Faz um ciclo para imprimir vários enters ou apagar o terminal
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

        //João altera isto!
        public void Welcome()
        {
            Console.WriteLine("Welcome to the internet, have a look around");
        }
        //João altera isto! 
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
    }
}