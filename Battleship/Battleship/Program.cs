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
        static void NewShip()
        {

        }
        static bool CheckTheShip()
        {

            return true;
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
            Console.WriteLine("Nyni umisti sve lode");
            Console.WriteLine("K dispozici mas tyto lode:\n1x Letadlova lod (1 x 5)\n1x Bitevni lod (1 x 4)\n1x Kriznik (1 x 3)\n1x Ponorka (1 x 3)\n1x Torpedoborec (1 x 2)\n");
            Console.WriteLine("Vzdy zadej pocatecni a koncovou souradnici lode. Pozor at ma pozadovanou delku, je v poli a neprekryva se s zadnou jinou z lodi!");
            //Letadlova lod
            string letterCoordinateFirst, letterCoordinateSecond, coordinateFirst;
            int numberCoordinateFirst = -1;
            int numberCoordinateSecond = -1;
            bool repeat;
            
            foreach (KeyValuePair<string, int> kvp in ships)
            {
                Console.WriteLine("\n" + kvp.Key + " o delce " + kvp.Value);
                //prvni souradnice
                do
                {
                    Console.WriteLine("zadej pocatecni souradnici (napriklad: A3)");
                    coordinateFirst = Console.ReadLine();
                    letterCoordinateFirst = Convert.ToString(coordinateFirst[0]);
                    char letter = kvp.Key[0];
                    repeat = false;
                    bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinateFirst[1]), out numberCoordinateFirst);
                    /* vrati repeat = true, pokud pro input neplati jedno z nasledovnych:
                     * ma jenom dva znaky
                     * prvni znak je pismeno A-J
                     * druhy znak je cislo
                     * policko jeste neni obsazene jinou lodi
                     */
                    if (coordinateFirst.Length != 2 || !letters.Contains(letterCoordinateFirst) || !isTheSecondCharNum || playerField[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] != "~")
                    {
                        Console.WriteLine("spatne zadana pocatecni souradnice");
                        repeat = true;
                    }
                    else
                    {
                        playerField[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] = Convert.ToString(letter);
                        repeat = false;
                    }
                } while (repeat);
                PrintArray(playerField, letters);
                // koncova souradnice
                do
                {
                    Console.WriteLine("zadej koncovou souradnici lode tak, aby delka lode byla " + kvp.Value);
                    string coordinate = Console.ReadLine();
                    letterCoordinateSecond = Convert.ToString(coordinate[0]);
                    char letter = kvp.Key[0];
                    repeat = false;
                    bool lengthIsOkay;
                    bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinateSecond);

                    //special pro konc. sour.
                    //kdyz je lod vodorovne
                    if (Math.Abs(letters.IndexOf(letterCoordinateFirst) - letters.IndexOf(letterCoordinateSecond)) == kvp.Value - 1 && numberCoordinateFirst == numberCoordinateSecond) lengthIsOkay = true;
                    //kdyz je lod svisle
                    else if(Math.Abs(numberCoordinateFirst - numberCoordinateSecond) == kvp.Value - 1 && letterCoordinateFirst == letterCoordinateSecond) lengthIsOkay = true;
                    //delka lodi neodpovida
                    else lengthIsOkay = false;

                    /* vrati repeat = true, pokud pro input neplati jedno z nasledovnych:
                     * ma jenom dva znaky
                     * prvni znak je pismeno A-J
                     * druhy znak je cislo
                     * policko jeste neni obsazene jinou lodi
                     */
                    if (!lengthIsOkay || coordinate.Length != 2 || !letters.Contains(letterCoordinateSecond) || !isTheSecondCharNum || playerField[numberCoordinateSecond, letters.IndexOf(letterCoordinateSecond) - 1] != "~")
                    {
                        Console.WriteLine("spatne zadana koncova souradnice");
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
                        playerField[numberCoordinateSecond, letters.IndexOf(letterCoordinateSecond) - 1] = Convert.ToString(letter);
                    }
                } while (repeat);
                PrintArray(playerField, letters);
            }

                PrintArray(playerField, letters);

                Console.ReadKey();
            
        }
    }
}
