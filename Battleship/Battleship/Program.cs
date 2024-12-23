﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{

    internal class Program
    {
        static void PrintArray(string[,] arrayToPrint, List<string> letters)
        {
            Console.WriteLine();
            for (int i = 0; i <= arrayToPrint.GetLength(1); i++)
            {
                Console.Write(letters[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {
                    Console.Write(arrayToPrint[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void FillArray(string[,] arrayToFill)
        {
            Console.WriteLine();
            for (int i = 0; i < arrayToFill.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToFill.GetLength(1); j++)
                {
                    arrayToFill[i, j] = "~";
                }
            }
        }
        
        static void AddingShips(string[,]field, Dictionary<string, int> ships, List<string> letters, string playerOrComputer)        
        {
            
            //nadefinovani promennych
            string letterCoordinateFirst = " ";
            string letterCoordinateLast = " ";
            int numberCoordinateFirst = -1;
            int numberCoordinateLast = -1;
            bool repeat;
            string coordinate = "0";

            foreach (KeyValuePair<string, int> kvp in ships)
            {
                if (playerOrComputer == "player") Console.WriteLine("\n" + kvp.Key + " o delce " + kvp.Value);

                //prvni souradnice
                //FirstCoordinate(letterCoordinateFirst, numberCoordinateFirst, kvp, letters, field, playerOrComputer);
                do
                {
                    
                    if (playerOrComputer == "player")
                    {
                        Console.WriteLine("zadej pocatecni souradnici (napriklad: A3)");
                        coordinate = Console.ReadLine();
                    }
                    else
                    {
                        coordinate = RandomCoordinate(letters);
                    }

                    if (coordinate.Length == 2)
                    {

                        letterCoordinateFirst = Convert.ToString(coordinate[0]);
                        char letter = kvp.Key[0];
                        repeat = false;
                        bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinateFirst);
                        /* vrati repeat = true, pokud pro input neplati jedno z nasledovnych:
                         * ma jenom dva znaky
                         * prvni znak je pismeno A-J
                         * druhy znak je cislo
                         * policko jeste neni obsazene jinou lodi
                         */
                        if (coordinate.Length != 2 || !letters.Contains(letterCoordinateFirst) || !isTheSecondCharNum || field[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] != "~")
                        {
                            if (playerOrComputer == "player") Console.WriteLine("spatne zadana pocatecni souradnice");
                            repeat = true;
                        }
                        else
                        {
                            field[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] = Convert.ToString(letter);
                            repeat = false;
                        }


                    }
                    else repeat = true;

                } while (repeat);
                if (playerOrComputer == "player") PrintArray(field, letters);

                // koncova souradnice
                string orientation = " ";
                do
                {
                    if (playerOrComputer == "player")
                    {
                        Console.WriteLine("zadej koncovou souradnici lode tak, aby delka lode byla " + kvp.Value);
                        coordinate = Console.ReadLine();
                    }
                    else
                    {
                        coordinate = RandomCoordinate(letters);
                    }
                    
                    if (coordinate.Length == 2)
                    {
                        letterCoordinateLast = Convert.ToString(coordinate[0]);
                        char letter = kvp.Key[0];
                        repeat = false;
                        bool lengthIsOkay;
                        bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinateLast);

                        //special pro konc. sour.
                        //kdyz je lod vodorovne

                        if (Math.Abs(letters.IndexOf(letterCoordinateFirst) - letters.IndexOf(letterCoordinateLast)) == kvp.Value - 1 && numberCoordinateFirst == numberCoordinateLast)
                        {
                            lengthIsOkay = true;
                            orientation = "vodorovne";
                        }
                        //kdyz je lod svisle

                        else if (Math.Abs(numberCoordinateFirst - numberCoordinateLast) == kvp.Value - 1 && letterCoordinateFirst == letterCoordinateLast)
                        {
                            lengthIsOkay = true;
                            orientation = "svisle";
                        }
                        //delka lodi neodpovida
                        else lengthIsOkay = false;

                        /* vrati repeat = true, pokud pro input neplati jedno z nasledovnych:
                         * ma jenom dva znaky
                         * prvni znak je pismeno A-J
                         * druhy znak je cislo
                         * policko jeste neni obsazene jinou lodi
                         */
                        if (!lengthIsOkay || coordinate.Length != 2 || !letters.Contains(letterCoordinateLast) || !isTheSecondCharNum || field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                        {
                            if (playerOrComputer == "player")Console.WriteLine("spatne zadana koncova souradnice");
                            repeat = true;
                        }
                        else
                        {
                            repeat = false;

                            //FillRestOfTheCells(orientation, letterCoordinateFirst, letterCoordinateLast, letters, kvp, numberCoordinateFirst, numberCoordinateLast, field, Convert.ToString(letter), repeat);
                            if (orientation == "vodorovne")
                            {
                                if (letters.IndexOf(letterCoordinateFirst) < letters.IndexOf(letterCoordinateLast))
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        if (field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] != "~")
                                        {
                                            repeat = true;
                                        }
                                    }
                                    if (repeat == false)
                                    {
                                        for (int i = 0; i < kvp.Value - 1; i++)
                                        {
                                            field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] = Convert.ToString(letter);
                                        }
                                    }
                                }
                                else if (letters.IndexOf(letterCoordinateFirst) > letters.IndexOf(letterCoordinateLast))
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        if (field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] != "~")
                                        {
                                            repeat = true;
                                        }

                                    }
                                    if (repeat == false)
                                    {
                                        for (int i = 0; i < kvp.Value - 1; i++)
                                        {
                                            field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] = Convert.ToString(letter);
                                        }
                                    }
                                }
                            }
                            else if (orientation == "svisle")
                            {
                                if (numberCoordinateFirst < numberCoordinateLast)
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        if (field[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                                        {
                                            repeat = true;
                                        }
                                    }
                                    if (repeat == false)
                                    {
                                        for (int i = 0; i < kvp.Value - 1; i++)
                                        {
                                            field[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                                        }
                                    }
                                }
                                else if (numberCoordinateFirst > numberCoordinateLast)
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        if (field[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                                        {
                                            repeat = true;
                                        }
                                        
                                    }
                                    if (repeat == false)
                                    {
                                        for (int i = 0; i < kvp.Value - 1; i++)
                                        {
                                            field[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                                        }
                                    }
                                    
                                }
                            }

                            if (repeat == false) field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                            else Console.WriteLine("Lod se nesmi prekryvat s jinou lodi!");
                        }
                        
                        
                        
                    }
                    //pokud není zadaná žádná souřadnice
                    else
                    {
                        repeat = true;
                    }
                } while (repeat);
                if (playerOrComputer == "player") PrintArray(field, letters);
            }
        }

       /*static void FirstCoordinate(string letterCoordinateFirst, int numberCoordinateFirst, KeyValuePair<string, int> kvp, List<string>letters, string[,]field, string playerOrComputer)
        {
            bool repeat = true;
            do
            {
                string coordinate = " ";
                if (playerOrComputer == "player")
                {
                    Console.WriteLine("zadej pocatecni souradnici (napriklad: A3)");
                    coordinate = Console.ReadLine();
                }
                else
                {
                    coordinate = RandomCoordinate(letters);
                }
                
                if (coordinate.Length == 2)
                {

                    letterCoordinateFirst = Convert.ToString(coordinate[0]);
                    char letter = kvp.Key[0];
                    repeat = false;
                    bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinateFirst);
                    /* vrati repeat = true, pokud pro input neplati jedno z nasledovnych:
                     * ma jenom dva znaky
                     * prvni znak je pismeno A-J
                     * druhy znak je cislo
                     * policko jeste neni obsazene jinou lodi
                     *
                    if (coordinate.Length != 2 || !letters.Contains(letterCoordinateFirst) || !isTheSecondCharNum || field[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] != "~")
                    {
                        if (playerOrComputer == "player") Console.WriteLine("spatne zadana pocatecni souradnice");
                        repeat = true;
                    }
                    else
                    {
                        field[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] = Convert.ToString(letter);
                        repeat = false;
                    }

                    
                }
                else repeat = true;
                
            } while (repeat);
        }
            */
       /* static void FillRestOfTheCells(string orientation, string letterCoordinateFirst, string letterCoordinateLast, List<string> letters, KeyValuePair<string, int> kvp, int numberCoordinateFirst, int numberCoordinateLast, string[,]field, string letter, bool repeat)
        {
            // zaznamenani lode na zbyvajici policka
            if (orientation == "vodorovne")
            {
                if (letters.IndexOf(letterCoordinateFirst) < letters.IndexOf(letterCoordinateLast))
                {
                    for (int i = 0; i < kvp.Value - 1; i++)
                    {
                        if (field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] != "~")
                        {
                            repeat = true;
                        }
                        field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] = Convert.ToString(letter);
                    }
                }
                else if (letters.IndexOf(letterCoordinateFirst) > letters.IndexOf(letterCoordinateLast))
                {
                    for (int i = 0; i < kvp.Value - 1; i++)
                    {
                        if (field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] != "~")
                        {
                            repeat = true;
                        }
                        field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] = Convert.ToString(letter);
                    }
                }
            }
            else if (orientation == "svisle")
            {
                if (numberCoordinateFirst < numberCoordinateLast)
                {
                    for (int i = 0; i < kvp.Value - 1; i++)
                    {
                        if (field[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                        {
                            repeat = true;
                        }
                        field[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                    }
                }
                else if (numberCoordinateFirst > numberCoordinateLast)
                {
                    for (int i = 0; i < kvp.Value - 1; i++)
                    {
                        if (field[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                        {
                            repeat = true;
                        }
                        field[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                    }
                }
            }
        }
       */
        static string RandomCoordinate(List<string>letters)
        {
            Random rnd = new Random();
            StringBuilder firstCoordinate = new StringBuilder();
            string rndLetterCoordinate = letters[rnd.Next(1, 10)];
            int rndNumberCoordinate = rnd.Next(0, 10);
            firstCoordinate.Append(rndLetterCoordinate);
            firstCoordinate.Append(Convert.ToString(rndNumberCoordinate));
            return firstCoordinate.ToString();
        }

        static void Shooting(List<string> letters, string playerOrComputer, string[,] seenableField, string[,] fieldWithValues, out int playerScoreOut, out int computerScoreOut, int playerScore, int computerScore)
        {
            string coordinate = " ";
            bool repeat;
            int numberCoordinate;
           
                //jedna strela
                do
                {
                    if (playerOrComputer == "player")
                    {
                        Console.WriteLine("zadej souradnici policka na ktere chces vystrelit");
                        coordinate = Console.ReadLine();
                    }
                    else
                    {
                        coordinate = RandomCoordinate(letters);
                    }

                    if (coordinate.Length == 2)
                    {

                        string letterCoordinate = Convert.ToString(coordinate[0]);
                        repeat = false;
                        bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinate);
                        if (coordinate.Length != 2 || !letters.Contains(letterCoordinate) || !isTheSecondCharNum || seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] != "~")
                        {
                            if (playerOrComputer == "player") Console.WriteLine("spatne zadana souradnice");
                            repeat = true;
                        }
                        else
                        {
                            if (fieldWithValues[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] != "~")
                            {
                                seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = fieldWithValues[numberCoordinate, letters.IndexOf(letterCoordinate) - 1];
                                if (playerOrComputer == "player")
                                {
                                    Console.WriteLine("Zasahl jsi souperovu lod!");
                                    playerScoreOut = playerScore + 1;
                                }
                                else computerScoreOut = computerScore + 1;
                            }
                            else
                            {
                                seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = "X";
                                if (playerOrComputer == "player") Console.WriteLine("Bohuzel ses netrefil:(");
                                playerScoreOut = computerScore;
                                computerScoreOut = computerScore;
                            }

                            repeat = false;
                        }


                    }
                    else repeat = true;

                } while (repeat);
                if (playerOrComputer == "player") PrintArray(seenableField, letters);
                else
            {
                Console.WriteLine("takto vystrelil tvuj souper:");
                PrintArray(seenableField, letters);
            }
                
            
            
            
        }
        static void Main(string[] args)
        {
            // definovani promennych
            string[,] playerField = new string[10, 10];
            string[,] computerField = new string[10, 10];
            string[,] computerFieldWithout = new string[10, 10];
            string playerOrComputer;
            //retezec stringu pro vypsani tabulky
            List<string> letters = new List<string>
            {"*", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",};

            //definovani lodi
            Dictionary<string, int> ships = new Dictionary<string, int>()
            {
               {"Letadlova lod", 5},
               {"Bitevni lod", 4},
               {"Kriznik", 3},
               {"Ponorka", 3},
               {"Torpedoborec", 2},
            };
            

            // uvod do hry
            Console.WriteLine("Vitej ve hre Battleship!");
            Console.WriteLine("Toto je tve pole, do ktereho umistis sve lode");
            FillArray(playerField);
            PrintArray(playerField, letters);

            //pridani lodi hrace
            /*Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("K dispozici mas tyto lode:\n1x Letadlova lod (1 x 5)\n1x Bitevni lod (1 x 4)\n1x Kriznik (1 x 3)\n1x Ponorka (1 x 3)\n1x Torpedoborec (1 x 2)\n");
            Console.ReadKey();
            Console.WriteLine("Vzdy zadej pocatecni a koncovou souradnici lode. Pozor at ma pozadovanou delku, je v poli a neprekryva se s zadnou jinou z lodi!");
            */
            Console.WriteLine("Chces si nechat lode vygenerovat nahodne? Napis true");
            bool doYouWantItRandom = Convert.ToBoolean(Console.ReadLine());
            if (doYouWantItRandom)
            {
                playerOrComputer = "computer";
                AddingShips(playerField, ships, letters, playerOrComputer);
                PrintArray(playerField, letters);
            }
            else
            {
                playerOrComputer = "player";
                AddingShips(playerField, ships, letters, playerOrComputer);
            }

            //pridani lodi pocitace
            
            FillArray(computerField);
            playerOrComputer = "computer";
            AddingShips(computerField, ships, letters, playerOrComputer);
            //toto je zatím jen pro kontrolu
            PrintArray(computerField, letters);

            //zacatek hry
            Console.WriteLine("Toto je pole tveho protivnika:");
            FillArray(computerFieldWithout);
            PrintArray(computerFieldWithout, letters);
            Console.WriteLine("Tvym cilem je sestrelit vsechny protivnikovy lode driv nez on sestreli ty tvoje");
            Console.ReadKey();
            Console.WriteLine("Stridate se vzdy po jedne strele");
            Console.ReadKey();
            Console.WriteLine("Zacinas!");

            //strileni
            int playerScore = 0;
            int computerScore = 0;
            bool gameIsOver = false;
            while (!gameIsOver)
            {
                //hrac strili
                playerOrComputer = "player";
                Shooting(letters, playerOrComputer, computerFieldWithout, computerField, out playerScore, out computerScore, playerScore, computerScore);
                //pocitac strili
                playerOrComputer = "computer";
                Shooting(letters, playerOrComputer, playerField, playerField, out playerScore, out computerScore, playerScore, computerScore);
                //
                if (playerScore > 16 || computerScore > 16) gameIsOver = true;
            }
            if (playerScore > computerScore)
            {
                Console.WriteLine("Gratuluji, vyhral jsi!");
            }
            else
            {
                Console.WriteLine("Bohuzel to nevyslo:(");
            }
        









        Console.ReadKey();
            
        }
    }
}
