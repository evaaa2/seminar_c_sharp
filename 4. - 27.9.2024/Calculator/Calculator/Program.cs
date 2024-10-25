using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        
            static double WhatIsTheResult(string operation, double result, double firstInput, double secondInput)
            {
                switch (operation)
                {
                    case "+":
                        result = firstInput + secondInput;
                        break;
                    case "-":
                        result = firstInput - secondInput;
                        break;
                    case "*":
                        result = firstInput * secondInput;
                        break;
                    case "/":
                        result = firstInput / secondInput;
                        break;
                    case "^":
                        result = Math.Pow(firstInput, secondInput);
                        break;
                    case "ˇ":
                        result = Math.Pow(secondInput, 1 / firstInput);
                        break;
                    case "Abs":
                        result = Math.Abs(firstInput);
                        break;
                    case "Sign":
                        result = Math.Sign(firstInput);
                        break;
                    case "Round":
                        result = Math.Round(firstInput);
                        break;

                    default:
                        Console.WriteLine("Zadal jsi spatnou operaci");
                        break;
                }
                return result;
            }


            static void Main(string[] args)
            {
                /*
                 * ZADANI
                 * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
                 * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.
                 * 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
                 * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
                 * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
                 * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
                 * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
                 *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
                 * 7) Vypis promennou result do konzole
                 * 
                 * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
                 * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
                 * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
                 * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
                 *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
                 * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
                 */
                //zavedeni promennych

                string operation;
                double result = 0.0;
                double firstInput = 0.0;
                double secondInput = 0.0;
                string stopCalculator = " ";
                string firstInputString, secondInputString;

                //cyklus kalkulačky
                while (stopCalculator != "a" && stopCalculator != "A")
                {
                    //4) - Nacteni operace
                    do
                    {
                        Console.WriteLine("Jakou operaci chces provest? \nZadej +, -, *, /, ^ pro mocnění, ˇ pro odmocňování, Abs pro absolutni hodnotu, Sign pro signum, Round pro zaokrouhlení na nejbližší celé číslo nebo 2 pro převod čísla do dvojkové soustavy ");
                        operation = Console.ReadLine();

                    } while (operation != "+" && operation != "-" && operation != "*" && operation != "/" && operation != "^" && operation != "ˇ" && operation != "Abs" && operation != "Sign" && operation != "Round" && operation != "2");

                    //1),2),3) - Nacteni vstupu
                    /*metoda TryParse z https://learn.microsoft.com/cs-cz/dotnet/api/system.double.tryparse?view=net-8.0#system-double-tryparse(system-string-system-double@) - kontrola jestli je input číslo
                     */

                    //pro operace se dvěmi čísly
                    if (operation != "Sign" && operation != "Abs" && operation != "Round" && operation != "2")
                    {
                        // Precteni prvni promenne
                        do
                        {
                            Console.WriteLine("\nZadej prvni cislo");
                            firstInputString = Console.ReadLine();
                        } while (!Double.TryParse(firstInputString, out firstInput));
                        // Precteni druhe promenne

                        do
                        {
                            Console.WriteLine("\nZadej druhe cislo");
                            secondInputString = Console.ReadLine();
                        } while (!Double.TryParse(secondInputString, out secondInput));
                    }

                    //pro operace s jedním číslem
                    else if (operation == "Sign" || operation == "Abs" || operation == "Round")
                    {
                        // Precteni promenne
                        do
                        {
                            Console.WriteLine("\nZadej cislo");
                            firstInputString = Console.ReadLine();
                        } while (!Double.TryParse(firstInputString, out firstInput));
                    }
                    // kod pro dvojkovou soustavu
                    else if (operation == "2")
                    {
                        string resultString = "0";
                        Console.WriteLine("\nZadej cislo");
                        string inputString = Console.ReadLine();
                        Int32.TryParse(inputString, out int input);

                        if (input < 0)
                        {
                            Console.WriteLine("Zaporna cisla do dvojkove soustavy prevadet jeste neumim:(");
                        }
                        while (input >= 1)
                        {
                            int restFromDividing = input % 2;
                            resultString = Convert.ToString(restFromDividing) + resultString;
                            input = input / 2;
                        }
                        result = Convert.ToInt32(resultString);
                    }
                    //6) - precteni a provedeni chtene operace (funkce definovana nahore v kodu)
                    if (operation != "2")
                    {
                        result = WhatIsTheResult(operation, result, firstInput, secondInput);
                    }
                    //7) - vypsani vysledku do konzole
                    Console.WriteLine("\nVysledek: " + result);
                    Console.WriteLine("Chces pokracovat? Zmackni Enter. Chces skoncit? Napis a\n\n");
                    stopCalculator = Console.ReadLine();
                }

                Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
