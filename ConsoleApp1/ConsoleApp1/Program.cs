using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

           /* for (int i; i>10; i++) {
                int a = rnd.Next(100);
                
                if (a >= 50)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine("a je menší než padesát");
                }
                Console.WriteLine("aaa");
                
            }
           */


            bool canContinue = true;
            do
            {
                int a = rnd.Next(100);
                Console.WriteLine(a);
                string userInput = Console.ReadLine();
                if (userInput == "n" || userInput == "N")
                {
                    canContinue = false;
                    Console.WriteLine("Uzivatel chce skoncit!");
                }
                
            } while (canContinue);
            string text = rnd.Next(100) > 50 ? "yes" : "no";
            Console.WriteLine(text);
            Console.ReadKey();

        }
    }
}
