﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace RockPaperScissors
{
    internal class Program
    {
        static int LoadAndCheckInput()
        {
            int userNumInput = -1;
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "k":
                    userNumInput = 1;
                    break;
                case "n":
                    userNumInput = 2;
                    break;
                case "p":
                    userNumInput = 3;
                    break;
                default:
                    Console.WriteLine("Spatny input");
                    break;
            }
            return userNumInput;
        }


        static int DecideRound(int userInput, int pcInput)
        {
            if (pcInput == userInput)
            {
                Console.WriteLine("\nRemiza! Bod neziskava nikdo");
            }
            else if ((pcInput == 1 && userInput == 2) || (pcInput == 2 && userInput == 3) || (pcInput == 3 && userInput == 1))
            {
                Console.WriteLine("\nProhral jsi! Souper ziskava bod");
                int result = 1;
                return result;
            }
            else if ((pcInput == 1 && userInput == 3) || (pcInput == 2 && userInput == 1) || (pcInput == 3 && userInput == 2))
            {
                Console.WriteLine("\nVyhral jsi! Ziskavas bod");
                int result = 2;
               return result;
            }
            else
            {
                Console.WriteLine("\nZase tam mas ERROR!!!:(");
            }
        }
        static void Main(string[] args)
        {
            /*
             * Jednoduchy program na procviceni podminek a cyklu.
             * 
             * Vytvor program, kde bude uzivatel hrat s pocitacem kamen-nuzky-papir.
             * 
             * Struktura:
             * 
             * - nadefinuj promenne, ktere budes potrebovat po celou dobu hry, tedy skore obou, pripadne cokoliv dalsiho budes potrebovat
             *
             * Opakuj tolikrat, kolik kol chces hrat, nebo treba do doby, nez bude mit jeden z hracu pocet bodu nutnych k vyhre:
             * {
             *      Dokud uzivatel nezada vstup spravne:
             *      {
             *          - nacitej vstup od uzivatele
             *      }
             *      
             *      - vygeneruj s pomoci rng.Next() nahodny vstup pocitace
             *      
             *      Pokud vyhral uzivatel:
             *      {
             *          - informuj uzivatele, ze vyhral kolo
             *          - zvys skore uzivateli o 1
             *      }
             *      Pokud vyhral pocitac:
             *      {
             *          - informuj uzivatele, ze prohral kolo
             *          - zvys skore pocitaci o 1
             *      }
             *      Pokud byla remiza:
             *      {
             *          - informuj uzivatele, ze doslo k remize
             *      }
             * }
             * 
             * - informuj uzivatele, jake mel skore on/a a pocitac a kdo vyhral.
             */

            Random rng = new Random(); //instance tridy Random pro generovani nahodnych cisel

            int pcScore;
            int userScore;
            int pocetKol;
            string userInput = "";
            int userNumInput = -1;
            string repeat = "a";
            int pcInput;
            string pcOutput = "";

            while (repeat == "a" || repeat == "A")
            {
                pcScore = 0;
                userScore = 0;
                pocetKol = 0;
                Console.WriteLine("Vitej u hry kamen nuzky papir! \n Hraje se na tri vitezna kola. Muzes hrat\n kamen(napis k) \n nuzky(napis n) \n papir(napis p)\n");
                while (userScore < 3 && pcScore < 3)
                {
                    pocetKol++;
                    Console.WriteLine(pocetKol + ". kolo");

                    do
                    {
                        userNumInput = LoadAndCheckInput();
                        
                    } while (userNumInput == -1);

                    pcInput = rng.Next(3) + 1;

                    // kamen = 1, nuzky = 2 papir = 3
                    if (pcInput == userNumInput)
                    {
                        Console.WriteLine("\nRemiza! Bod neziskava nikdo");
                    }
                    else if ((pcInput == 1 && userNumInput == 2) || (pcInput == 2 && userNumInput == 3) || (pcInput == 3 && userNumInput == 1))
                    {
                        Console.WriteLine("\nProhral jsi! Souper ziskava bod");
                        pcScore++;
                    }
                    else if ((pcInput == 1 && userNumInput == 3) || (pcInput == 2 && userNumInput == 1) || (pcInput == 3 && userNumInput == 2))
                    {
                        Console.WriteLine("\nVyhral jsi! Ziskavas bod");
                        userScore++;
                    }
                    else
                    {
                        Console.WriteLine("\nZase tam mas ERROR!!!:(");
                    }
                    //Co dal pocitac
                    switch (pcInput)
                    {
                        case 1:
                            pcOutput = "kamen";
                            break;
                        case 2:
                            pcOutput = "nuzky";
                            break;
                        case 3:
                            pcOutput = "papir";
                            break;
                        default:
                            Console.WriteLine("pocitac asi blazni");
                            break;
                    }
                    Console.WriteLine("Pocitac dal " + pcOutput + "\n");
                    //vypsani skore
                    Console.WriteLine("\nSkore je " + userScore + " : " + pcScore);
                    //aaa
                    int result = DecideRound(userNumInput, pcInput);
                    if (result == 2) userScore++;
                    else if(result == 1) pcScore++;
                    
                }
                //vysledek
                if (pcScore == 3) Console.WriteLine("Bohuzel jsi prohral:(");
                else Console.WriteLine("Gratuluji, jsi vitez!!!");

                //opakovat hru
                Console.WriteLine("Chces hrat znovu? Napis 'a'");
                repeat = Console.ReadLine();
            }
            Console.ReadKey(); //Aby se nam to hnedka neukoncilo
            
        }
    }
}
