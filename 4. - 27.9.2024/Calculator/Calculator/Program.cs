﻿using System;
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
        
        static double WhatIsTheResult(string operation, double result, double firstInput, double secondInput )
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
            double firstInput, secondInput;
            string firstInputString, secondInputString;

            
            
            //4) - Nacteni operace
            do
            {
                Console.WriteLine("Jakou operaci chces provest? Zadej +, -, *, /, ^ pro mocnění, ˇ pro odmocňování, Abs pro absolutni hodnotu, Sign pro signum ");
                operation = Console.ReadLine();

            } while (operation != "+" && operation != "-" && operation != "*" && operation != "/" && operation != "^" && operation != "ˇ" && operation != "Abs" && operation != "Sign");

            //1),2),3) - Nacteni vstupu
            /*metoda TryParse z https://learn.microsoft.com/cs-cz/dotnet/api/system.double.tryparse?view=net-8.0#system-double-tryparse(system-string-system-double@) - kontrola jestli je input číslo
             */
            do
            {
               Console.WriteLine("Zadej prvni cislo");
               firstInputString = Console.ReadLine();
            } while (!Double.TryParse(firstInputString, out firstInput));

            do
            {
                Console.WriteLine("Zadej druhe cislo");
                secondInputString = Console.ReadLine();
            } while (!Double.TryParse(secondInputString, out secondInput));

            //6) - precteni a provedeni chtene operace
            result = WhatIsTheResult(operation, result, firstInput, secondInput);
            
            //7) - vypsani vysledku do konzole
            Console.WriteLine("Vysledek: " + result);

            Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
        }
    }
}
