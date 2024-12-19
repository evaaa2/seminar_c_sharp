using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /*
    public class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
    }
    */

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
                0 <= numberCoordinate && numberCoordinate < 10 &&
                myField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] == "~"

                )
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
               {"L", 5},
               {"B", 4},
               {"K", 3},
               {"P", 3},
               {"T", 2},
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
            string letterCoordinate;
            int numberCoordinate = -1;
            foreach(KeyValuePair<string, int> kvp in ships)
            {
                Console.WriteLine("Dalsi lod");
                do
                {
                    Console.WriteLine("pocatecni souradnice");
                    string coordinate = Console.ReadLine();
                    letterCoordinate = Convert.ToString(coordinate[0]);
                    if (!int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinate))
                    {
                        Console.WriteLine("spatny vstup");
                    }
                    
                    playerField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = kvp.Key;
                } while (CheckMyCell(letterCoordinate, numberCoordinate, letters, playerField));
                break;
            }
            PrintArray(playerField, letters);

            
        /*
            //pokus pouziti tridy z chatu GPT
             List<Monster> monsters = new List<Monster>
        {
            new Monster { Name = "slime", Level = 2, Health = 15 },
            new Monster { Name = "fanged beast", Level = 8, Health = 60 },
            new Monster { Name = "dragon", Level = 20, Health = 300 }
        };

                // Example: Print the monster list
                foreach (var monster in monsters)
                {
                    Console.WriteLine($"Name: {monster.Name}, Level: {monster.Level}, Health: {monster.Health}");
                }
        */
            
        


        Console.ReadKey();
        }
    }
}
