using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
    }

    internal class Program
    {
        static void PrintArray(string[,] arrayToPrint, string[] letters)
        {
            
            for (int i = 0; i <= arrayToPrint.GetLength(1); i++)
            {
                Console.Write(letters[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < arrayToPrint.GetLength(0); i++)
            {
                Console.Write(i+1 + " ");
                for (int j = 0; j < arrayToPrint.GetLength(1); j++)
                {
                    Console.Write(arrayToPrint[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    
        static void FillArray(string[,] arrayToFill)
        {
            for (int i = 0; i < arrayToFill.GetLength(0); i++)
            {
                for (int j = 0; j < arrayToFill.GetLength(1); j++)
                {
                    arrayToFill[i, j] = "~";
                }
                Console.WriteLine();
            }
        }

        static void NewShip()
        {

        }
        static void Main(string[] args)
        {
            // definovani promennych
            string[,] playerField = new string[10, 10];
            string[,] computerField = new string[10, 10];
            Dictionary<string, string> ships = new Dictionary<string, string>();

            string[] letters = {"*", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            // uvod do hry
            Console.WriteLine("Vitej ve hre Battleship!");
            Console.WriteLine("Toto je tve pole, do ktereho umistis sve lode");
            FillArray(playerField);
            PrintArray(playerField, letters);
            //umistovani lode do hraciho pole
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
            
        


        Console.ReadKey();
        }
    }
}
