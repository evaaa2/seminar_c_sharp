using System;
using System.Collections.Generic;
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
        static bool CheckMyCell(string letterCoordinate, int numberCoordinate, List<string> letters, string[,] myField)
        {
            if (
                letters.Contains(letterCoordinate) &&
                numberCoordinate >= 0 && numberCoordinate < 10 &&
                myField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] == "~")
            {
                return false;
            }
            else
            {
                Console.WriteLine("spatny vstup");
                return true;
            }
        }
        static void AddingShips(string[,]playerField, Dictionary<string, int> ships, List<string> letters)        
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
                Console.WriteLine("\n" + kvp.Key + " o delce " + kvp.Value);
                //prvni souradnice
                do
                {
                    Console.WriteLine("zadej pocatecni souradnici (napriklad: A3)");

                    coordinate = Console.ReadLine();
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
                        if (coordinate.Length != 2 || !letters.Contains(letterCoordinateFirst) || !isTheSecondCharNum || playerField[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] != "~")
                        {
                            Console.WriteLine("spatne zadana pocatecni souradnice");
                            repeat = true;
                        }
                        else
                        {
                            playerField[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] = Convert.ToString(letter);
                            repeat = false;
                        }
                    }
                    else repeat = true;

                } while (repeat);
                PrintArray(playerField, letters);
                // koncova souradnice
                string orientation = " ";
                do
                {
                    Console.WriteLine("zadej koncovou souradnici lode tak, aby delka lode byla " + kvp.Value);
                    coordinate = Console.ReadLine();
                    //pokud není zadaná žádná souřadnice
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
                        if (!lengthIsOkay || coordinate.Length != 2 || !letters.Contains(letterCoordinateLast) || !isTheSecondCharNum || playerField[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                        {
                            Console.WriteLine("spatne zadana koncova souradnice");
                            repeat = true;
                        }
                        else
                        {
                            repeat = false;
                            playerField[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                        }
                        // zaznamenani lode na zbyvajici policka
                        if (orientation == "vodorovne")
                        {
                            if (letters.IndexOf(letterCoordinateFirst) < letters.IndexOf(letterCoordinateLast))
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    playerField[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] = Convert.ToString(letter);
                                }
                            }
                            else if (letters.IndexOf(letterCoordinateFirst) > letters.IndexOf(letterCoordinateLast))
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    playerField[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] = Convert.ToString(letter);
                                }
                            }
                        }
                        else if (orientation == "svisle")
                        {
                            if (numberCoordinateFirst < numberCoordinateLast)
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    playerField[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                                }
                            }
                            else if (numberCoordinateFirst > numberCoordinateLast)
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    playerField[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                                }
                            }
                        }
                    }
                    else
                    {
                        repeat = true;
                    }
                } while (repeat);
                PrintArray(playerField, letters);
            }
        }
        
        static void Main(string[] args)
        {
            // definovani promennych
            string[,] playerField = new string[10, 10];
            string[,] computerField = new string[10, 10];
            //definovani lodi
            Dictionary<string, int> ships = new Dictionary<string, int>()
            {
               {"Letadlova lod", 5},
               {"Bitevni lod", 4},
               {"Kriznik", 3},
               {"Ponorka", 3},
               {"Torpedoborec", 2},
            };
            //retezec stringu pro vypsani tabulky
            List<string> letters = new List<string>
            {"*", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",};

            // uvod do hry
            Console.WriteLine("Vitej ve hre Battleship!");
            Console.WriteLine("Toto je tve pole, do ktereho umistis sve lode");
            FillArray(playerField);
            PrintArray(playerField, letters);
            //umistovani lode do hraciho pole
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("K dispozici mas tyto lode:\n1x Letadlova lod (1 x 5)\n1x Bitevni lod (1 x 4)\n1x Kriznik (1 x 3)\n1x Ponorka (1 x 3)\n1x Torpedoborec (1 x 2)\n");
            Console.ReadKey();
            Console.WriteLine("Vzdy zadej pocatecni a koncovou souradnici lode. Pozor at ma pozadovanou delku, je v poli a neprekryva se s zadnou jinou z lodi!");
            
            AddingShips(playerField, ships, letters);
            
           
                Console.ReadKey();
            
        }
    }
}
