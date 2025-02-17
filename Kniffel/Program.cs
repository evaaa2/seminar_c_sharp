using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kniffel
{
    internal class Program
    {
        static void Intro()
        {
            Console.WriteLine("WELCOME TO KNIFFEL!");
            Console.WriteLine("(Also known as Yatzy)");
            Console.WriteLine();
            Console.ReadKey();
            bool wrongInput = true;
            while (wrongInput)
            {
                Console.WriteLine("Do you know the rules of this game? (Write yes or no)");
                string answer = Console.ReadLine();
                if (answer == "yes" || answer == "Yes" || answer == "YES")
                {
                    Console.WriteLine("Alright then, let's start the game!");
                    wrongInput = false;
                }

                else if (answer == "no" || answer == "No" || answer == "NO")
                {
                    ExplainTheRules();
                    wrongInput = false;
                }

                else Console.WriteLine("Wrong input!");
                Console.WriteLine();
            }
        }

        static void ExplainTheRules()
        {
            //will be done later on
            Console.WriteLine("Well, then look them up on the internet!");
        }

        static void Dice()
        {
            Console.WriteLine("Your dice:");
            Console.WriteLine("  +++");
            Console.WriteLine("  +?+");
            Console.WriteLine("  +++");

            Console.WriteLine("To throw the dice, press any key.");
            Console.ReadKey();




        }

        

        static void Main(string[] args)
        {
            Dice classic = new Dice();

            Intro();
            Console.ReadKey();

            Console.Clear();
            Dice();

            

            Console.ReadKey();
        }
    }
}
