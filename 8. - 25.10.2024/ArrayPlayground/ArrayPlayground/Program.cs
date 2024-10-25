using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové pole a naplň ho pěti libovolnými čísly.
            int[] newArray = new int[100];
            //TODO 8: Přepiš pole na úplně nové tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9.

            Random rng = new Random();
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = rng.Next(1,10);
            }


            //TODO 2: Vypiš do konzole všechny prvky pole, zkus jak klasický for, kde i využiješ jako index v poli, tak foreach.
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine(newArray[i]);
            }

            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            foreach (int num in newArray)
            {
                sum += num;
            }
            Console.WriteLine("Soucet vsech cisel v poli je: " + sum);


            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average;
            //average = sum / newArray.Length;
            average = (int)newArray.Average();
            Console.WriteLine("Prumer je: " + average);


            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max;
            max = newArray.Max();
            Console.WriteLine("maximum: " + max);


            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min;
            min = newArray.Min();
            Console.WriteLine("minimum: " + min);
            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            int index;
            Console.WriteLine("Napis cislo ktere chces.");
            int numberToFind = int.Parse(Console.ReadLine());
            bool foundNumber = false;

            for (int i = 0; i < newArray.Length; i++)
            {
                if (newArray[i] == numberToFind)
                {
                    Console.WriteLine();
                    foundNumber = true;
                    Console.WriteLine("index cisla " + 5 + " je " + i);
                } 

            }
            if (!foundNumber)
            {
                Console.WriteLine("Cislo v poli neni");
            }
            
            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            
            foreach (int num in newArray)
            {
                counts[num-1]++;
            }
            for (int i = 0;i < counts.Length;i++) {
                int a = i + 0;
            Console.WriteLine("Číslo " + a + " je v poli " + counts[i] + " krát");
            }
            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.


            //Zkus is dál hrát s polem dle své libosti. Můžeš třeba prohodit dva prvky, ukládat do pole prvky nějaké posloupnosti (a pak si je vyhledávat) nebo cokoliv dalšího tě napadne

            Console.ReadKey();
        }
    }
}
