using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Kniffel
{
    internal class Program
    {
        
        static int diceFromTop = 18;
        static Dice classic1 = new Dice(3, diceFromTop);
        static Dice classic2 = new Dice(10, diceFromTop);
        static Dice classic3 = new Dice(17, diceFromTop);
        static Dice classic4 = new Dice(24, diceFromTop);
        static Dice classic5 = new Dice(31, diceFromTop);
        

        static int combinationsFromTop = 1;
        static int combinationsFromLeft = 14;
        static int combArrowFromLeft = combinationsFromLeft + 5;
        static Numbers ones = new Numbers(combinationsFromLeft, combinationsFromTop + 1, 1);
        static Numbers twos = new Numbers(combinationsFromLeft, combinationsFromTop + 2, 2);
        static Numbers threes = new Numbers(combinationsFromLeft, combinationsFromTop + 3, 3);
        static Numbers fours = new Numbers(combinationsFromLeft, combinationsFromTop + 4, 4);
        static Numbers fives = new Numbers(combinationsFromLeft, combinationsFromTop + 5, 5);
        static Numbers sixs = new Numbers(combinationsFromLeft, combinationsFromTop + 6, 6);

        static Multi triplet = new Multi(combinationsFromLeft, combinationsFromTop + 7, 3);
        static Multi quadruplet = new Multi(combinationsFromLeft, combinationsFromTop + 8, 4);
        static Multi kniffel = new Multi(combinationsFromLeft, combinationsFromTop + 9, 5);
        static Multi chance = new Multi(combinationsFromLeft, combinationsFromTop + 10, 1);
        static Multi fullHouse = new Multi(combinationsFromLeft, combinationsFromTop + 11, 6);

        static Straight smallStraight = new Straight(combinationsFromLeft, combinationsFromTop + 12, 1);
        static Straight largeStraight = new Straight(combinationsFromLeft, combinationsFromTop + 13, 2);

        static List<int> thrownNumbers = new List<int>();

        static int thisDice;
        static int thisCombination;
        static bool pointsWereAssigned;

        static int numberOfCombinations = 13;

        static int finalScore = 0;
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
            Console.SetCursorPosition(0, diceFromTop - 2);
            Console.WriteLine("Your dice:");
            for (int i = 0; i < 5; i++) Console.Write("  ***  ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) Console.Write("  *?*  ");
            Console.WriteLine();
            for (int i = 0; i < 5; i++) Console.Write("  ***  ");
        }
        
        static void ThrowDice()
        {
            classic1.isActive = true;
            classic2.isActive = true;
            classic3.isActive = true;
            classic4.isActive = true;
            classic5.isActive = true;

            ClearSomeLines(1, classic1.positionTop + 2);

            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + i + 1);
                Console.Write(" ");
            }

            for (int i = 0; i < 3; i++)
            {
                ClearSomeLines(2, diceFromTop + 7);
                Console.SetCursorPosition(0, diceFromTop + 7);
                Console.WriteLine("To throw, press Spacebar.");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true to not show key press
                while (keyInfo.Key != ConsoleKey.Spacebar)
                {
                    Console.SetCursorPosition(0, diceFromTop + 7);
                    for (int j = 0; j < 2 * Console.WindowWidth; j++) Console.Write(" ");
                    Console.SetCursorPosition(0, diceFromTop + 7);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("To throw, press Spacebar.");
                    Console.BackgroundColor = ConsoleColor.Black;
                    keyInfo = Console.ReadKey(true);
                }


                for (int j = 0; j < 8; j++)
                {
                    if(classic1.isActive) classic1.Throw();
                    if(classic2.isActive) classic2.Throw();
                    if(classic3.isActive) classic3.Throw();
                    if(classic4.isActive) classic4.Throw();
                    if(classic5.isActive) classic5.Throw();
                    //Console.Beep(300 + j * 20, 100);
                    Thread.Sleep(j * j * 4);
                }
                if (i == 0 || i == 1) SelectDice();
                ClearSomeLines(2, diceFromTop + 7);
            }
        }
        static void SelectDice()
        {
            for (int i = 0; i < numberOfCombinations; i++)
            {
                Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + i + 1);
                Console.Write(" ");
            } 

            Console.SetCursorPosition(0, diceFromTop + 7);
            Console.WriteLine("Select by arrows those dice, that you want to put on side. To confirm putting a certain dice on side, press Arrow up. Exit by pressing Enter.");
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
                        if (thisDice == 1) classic1.isActive = false;
                        if (thisDice == 2) classic2.isActive = false;
                        if (thisDice == 3) classic3.isActive = false;
                        if (thisDice == 4) classic4.isActive = false;
                        if (thisDice == 5) classic5.isActive = false;
                        break;
                    case ConsoleKey.DownArrow:
                        ChangeCursorPosition(0, -1);
                        Console.Write(" ");
                        ChangeCursorPosition(-1, 1);
                        if (thisDice == 1) classic1.isActive = true;
                        if (thisDice == 2) classic2.isActive = true;
                        if (thisDice == 3) classic3.isActive = true;
                        if (thisDice == 4) classic4.isActive = true;
                        if (thisDice == 5) classic5.isActive = true;
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
                    case ConsoleKey.Enter:
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

        static void DisplayCombinations()
        {
            
            List<string> combinations = new List<string>();
            combinations.Add("Combinations:");
            combinations.Add("1's..........");
            combinations.Add("2's..........");
            combinations.Add("3's..........");
            combinations.Add("4's..........");
            combinations.Add("5's..........");
            combinations.Add("6's..........");
            combinations.Add("3-same.......");
            combinations.Add("4-same.......");
            combinations.Add("kniffel......");
            combinations.Add("chance.......");
            combinations.Add("full-house...");
            combinations.Add("small straight");
            combinations.Add("large straight");

            Console.SetCursorPosition(0, 1);
            foreach (string combination in combinations) {  Console.WriteLine(combination); }


        }

        static void ClearSomeLines(int numberOfLines, int distanceFromTop)
        {
            Console.SetCursorPosition(0, distanceFromTop);
            for (int j = 0; j < numberOfLines * Console.WindowWidth; j++) Console.Write(" ");
        }
        
        static void CreateListOfThrownNumbers()
        {
            thrownNumbers.Clear();
            thrownNumbers.Add(classic1.ThrownNumber());
            thrownNumbers.Add(classic2.ThrownNumber());
            thrownNumbers.Add(classic3.ThrownNumber());
            thrownNumbers.Add(classic4.ThrownNumber());
            thrownNumbers.Add(classic5.ThrownNumber());

        }

        static void SelectCombination()
        {
            Console.SetCursorPosition(0, combinationsFromTop);
            Console.WriteLine("Select by arrow keys that combination, in which you want to write this throw. Confirm by pressing Enter.");

            thisCombination = 1;
            Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + thisCombination);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("←");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // true to not show key press
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (thisCombination > 1)
                        {
                            // Clear previous arrow
                            Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + thisCombination);
                            Console.Write(" ");

                            thisCombination--; 

                            // Draw new arrow
                            Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + thisCombination);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("←");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (thisCombination < numberOfCombinations)
                        {
                            // Clear previous arrow
                            Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + thisCombination);
                            Console.Write(" ");
   
                            thisCombination++;

                            // Draw new arrow
                            Console.SetCursorPosition(combArrowFromLeft, combinationsFromTop + thisCombination);
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("←");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Enter:
                        return;
                }
            }
        }

        static void AddPointsToCombination()
        {
            pointsWereAssigned = true;
            if (thisCombination == 1 && ones.isActive) ones.Write(thrownNumbers);
            else if (thisCombination == 2 && twos.isActive) twos.Write(thrownNumbers);
            else if (thisCombination == 3 && threes.isActive) threes.Write(thrownNumbers);
            else if (thisCombination == 4 && fours.isActive) fours.Write(thrownNumbers);
            else if (thisCombination == 5 && fives.isActive) fives.Write(thrownNumbers);
            else if (thisCombination == 6 && sixs.isActive) sixs.Write(thrownNumbers);
            else if (thisCombination == 7 && triplet.isActive) triplet.Write(thrownNumbers);
            else if (thisCombination == 8 && quadruplet.isActive) quadruplet.Write(thrownNumbers);
            else if (thisCombination == 9 && kniffel.isActive) kniffel.Write(thrownNumbers);
            else if (thisCombination == 10 && chance.isActive) chance.Write(thrownNumbers);
            else if (thisCombination == 11 && fullHouse.isActive) fullHouse.Write(thrownNumbers);
            else if (thisCombination == 12 && smallStraight.isActive) smallStraight.Write(thrownNumbers);
            else if (thisCombination == 13 && largeStraight.isActive) largeStraight.Write(thrownNumbers);
            else pointsWereAssigned = false;

        }

        static void Ending()
        {
            finalScore = 0;
            finalScore += ones.points + twos.points + threes.points + fours.points + fives.points + sixs.points;
            Console.Clear();
            Console.WriteLine("Well played!! Your final score is: " + finalScore + " points!");
        }
        static void Main(string[] args)
        {
            Intro();
            Console.ReadKey();

            Console.Clear();
            DisplayCombinations();
            DisplayDice();

            for (int i = 0; i < numberOfCombinations; i++)
            {
                ThrowDice();
                CreateListOfThrownNumbers();

                do
                {
                    SelectCombination();
                    AddPointsToCombination();
                } while (!pointsWereAssigned);




            }

            Ending();

            Console.WriteLine("aaa");

            

            
            

            Console.ReadKey();
        }
    }
}
