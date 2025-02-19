using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Random rnd = new Random();
            Dice classic1 = new Dice(3, 2);
            Dice classic2 = new Dice(10, 2);
            Dice classic3 = new Dice(17, 2);
            Dice classic4 = new Dice(24, 2);
            Dice classic5 = new Dice(31, 2);
            Console.WriteLine("Your dice:");
            for (int i = 0; i < 5; i++) Console.Write("  ***  ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) Console.Write("  *?*  ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) Console.Write("  ***  ");

            Console.WriteLine("\nTo throw the dice, press any key.");
            Console.ReadKey();

            classic1.Throw();
            classic2.Throw();



        }




    



        static void Main(string[] args)
        {
            //Intro();
            //Console.ReadKey();

            Console.Clear();
            Dice();

            

            Console.ReadKey();
        }
    }
}
