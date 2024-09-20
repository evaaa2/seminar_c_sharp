using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            int skorePocitac = 0;
            int skoreHrac = 0;
            int pocetKol = 0;
            Random rng = new Random(); //instance tridy Random pro generovani nahodnych cisel
            
            int pocitac;
            Console.WriteLine("Vitej u hry kamen nuzky papir! \n Hraje se na tri kola. Muzes hrat\n kamen(napis k) \n nuzky(napis n) \n papir(napis p)");
            while (skoreHrac < 3 || skorePocitac < 3)
            {
                
                pocetKol++;
                string vstup = " ";
                while (vstup != "k" || vstup != "n" || vstup != "p") ;
                {
                    vstup = Console.ReadLine();
                } 
                
                pocitac = rng.Next(3);
                // kamen = 1, nuzky = 2 papir = 3
                if ((pocitac == 1 && vstup == "k") || (pocitac == 2 && vstup == "n") || (pocitac == 3 && vstup == "p"))
                {
                    Console.WriteLine("Remiza! Bod neziskava nikdo");
                }
                else if (pocitac == 1 && vstup == "n" || pocitac == 2 && vstup == "p" || pocitac == 3 && vstup == "k")
                {
                    Console.WriteLine("Prohral jsi! Souper ziskava bod");
                    skorePocitac++;
                }
                else
                {
                    Console.WriteLine("Vyhral jsi! Ziskavas bod");
                    skoreHrac++;
                }
                Console.WriteLine("Skore je" + skoreHrac + " : " + skorePocitac);
            }
            if (skorePocitac == 3)
            {
                Console.WriteLine("Bohuzel jsi prohral:(");
            }
            else
            {
                Console.WriteLine("Gratuluji, jsi vitez!!!");
            }
            Console.WriteLine("Chces hrat znovu? Napis ano");
            string repeat = Console.ReadLine();
            if (repeat == "ano" || repeat == "Ano")
            {
                skorePocitac = 0;
                skoreHrac = 0;
            }
            



            Console.ReadKey(); //Aby se nam to hnedka neukoncilo
        }
    }
}
