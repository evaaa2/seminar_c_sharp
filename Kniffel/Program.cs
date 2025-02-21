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
        static Dice classic1 = new Dice(3, 2);
        static Dice classic2 = new Dice(10, 2);
        static Dice classic3 = new Dice(17, 2);
        static Dice classic4 = new Dice(24, 2);
        static Dice classic5 = new Dice(31, 2);

        static bool classic1Active = true;
        static bool classic2Active = true;
        static bool classic3Active = true;
        static bool classic4Active = true;
        static bool classic5Active = true;

        static int number1;
        static int number2;
        static int number3;
        static int number4;
        static int number5;

        static int thisDice;
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


        static void DisplayDice()
        {
            
            Console.WriteLine("Your dice:");
            for (int i = 0; i < 5; i++) Console.Write("  ***  ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) Console.Write("  *?*  ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) Console.Write("  ***  ");
        }
        
        static void ThrowDice()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(0, 7);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true to not show key press
                while (keyInfo.Key != ConsoleKey.Spacebar)
                {
                    Console.WriteLine("To throw, press Spacebar.");
                    keyInfo = Console.ReadKey(true);
                }
                
                //for (int j = 0; j < 8; j++)
                {
                    if(classic1Active)classic1.Throw();
                    if(classic2Active) classic2.Throw();
                    if(classic3Active) classic3.Throw();
                    if (classic4Active) classic4.Throw();
                    if (classic5Active) classic5.Throw();
                    //Console.Beep(300 + j * 20, 100);
                    //Thread.Sleep(j * j * 4);
                }
                SelectDice();
            }
        }

        static void GetNumbers()
        {
            number1 = classic1.ThrownNumber();
            number2 = classic2.ThrownNumber();
            number3 = classic3.ThrownNumber();
            number4 = classic4.ThrownNumber();
            number5 = classic5.ThrownNumber();
        }

        static void SelectDice()
        {
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("Select by arrows those dice, that you want to put on side. To confirm putting a certain dice on side, press Arrow up.");
            thisDice = 1;
            Console.SetCursorPosition(classic1.positionLeft, classic1.positionTop + 3);
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true to not show key press
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        ChangeCursorPosition(0, -1);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("↑");
                        Console.ForegroundColor = ConsoleColor.White;
                        ChangeCursorPosition(-1, 1);
                        break;
                    case ConsoleKey.DownArrow:
                        ChangeCursorPosition(0, -1);
                        Console.Write(" ");
                        ChangeCursorPosition(-1, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (thisDice > 1)
                        {
                            ChangeCursorPosition(-7, 0);
                            thisDice--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (thisDice < 5)
                        {
                            ChangeCursorPosition(7, 0);
                            thisDice++;
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Exiting...");
                        return; 
                }
            }
        }

        static void ChangeCursorPosition(int addToLeft, int addToTop)
        {
            if (addToLeft < 0) Console.CursorLeft -= Math.Abs(addToLeft);
            else Console.CursorLeft += addToLeft;

            if (addToTop < 0) Console.CursorTop -= Math.Abs(addToTop);
            else Console.CursorTop += addToTop;

        }
        static void Main(string[] args)
        {
            //Intro();
            //Console.ReadKey();
           


            Console.Clear();
            DisplayDice();
            ThrowDice();
            
            

            Console.ReadKey();
        }
    }
}
