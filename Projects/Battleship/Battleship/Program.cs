using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{

    internal class Program
    {
		//funkce pro vytisteni pole
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

		//funkcek pro vyplneni pole vlnkami
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
        
	//funkce pro vepsani lodi hrace nebo pocitace do pole
        static void AddingShips(string[,] field, Dictionary<string, int> ships, List<string> letters, string playerOrComputer)
        {

            //nadefinovani promennych
            string letterCoordinateFirst = " ";
            string letterCoordinateLast = " ";
            int numberCoordinateFirst = -1;
            int numberCoordinateLast = -1;
            string coordinate = "0";

            foreach (KeyValuePair<string, int> kvp in ships)
            {
                if (playerOrComputer == "player") Console.WriteLine("\n" + kvp.Key + " o delce " + kvp.Value);

                //prvni souradnice
                FirstCoordinate(letters, playerOrComputer, coordinate, kvp, field, out letterCoordinateFirst, out numberCoordinateFirst);

                // koncova souradnice
                ShipOrientationAndTheLastCoordinate(letters, letterCoordinateFirst, numberCoordinateFirst, numberCoordinateLast, kvp, letterCoordinateLast, coordinate, playerOrComputer, field);
               
                if (playerOrComputer == "player") PrintArray(field, letters);
            }
        }
	//funkce pro vygenerovani jedne nahodne souradnice
        static string RandomCoordinate(List<string> letters)
        {
            Random rnd = new Random();
            StringBuilder firstCoordinate = new StringBuilder();
            string rndLetterCoordinate = letters[rnd.Next(1, 10)];
            int rndNumberCoordinate = rnd.Next(0, 10);
            firstCoordinate.Append(rndLetterCoordinate);
            firstCoordinate.Append(Convert.ToString(rndNumberCoordinate));
            return firstCoordinate.ToString();
        }
	//funkce pro urceni a zapsani pocatecni souradnice lode
        static void FirstCoordinate(List<string> letters, string playerOrComputer, string coordinate, KeyValuePair<string, int> kvp, string[,]field, out string letterCoordinateFirst, out int numberCoordinateFirst)
        {
            bool repeat = true;
            do
            {

                if (playerOrComputer == "player")
                {
                    Console.WriteLine("zadej pocatecni souradnici (napriklad: A3)");
                    coordinate = Console.ReadLine();
                }
                else
                {
                    coordinate = RandomCoordinate(letters);
                }

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
                    if (coordinate.Length != 2 || !letters.Contains(letterCoordinateFirst) || !isTheSecondCharNum || field[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] != "~")
                    {
                        if (playerOrComputer == "player") Console.WriteLine("\nspatne zadana pocatecni souradnice");
                        repeat = true;
                    }
                    else
                    {
                        field[numberCoordinateFirst, letters.IndexOf(letterCoordinateFirst) - 1] = Convert.ToString(letter);
                        repeat = false;
                    }


                }
                else
                {
                    repeat = true;
                    letterCoordinateFirst = " ";
                    numberCoordinateFirst = 0;
                }
		//cyklus se opakuje dokud neni urcena platna souradnice
            } while (repeat);
            if (playerOrComputer == "player") PrintArray(field, letters);

        }
		
	//funkce pro urceni natoceni lode a jeji koncove souradnice
        static void ShipOrientationAndTheLastCoordinate(List<string> letters, string letterCoordinateFirst, int numberCoordinateFirst, int numberCoordinateLast, KeyValuePair<string, int> kvp, string letterCoordinateLast, string coordinate, string playerOrComputer, string[,]field)
        {
            bool repeat = true;
            string orientation = "";
            do
            {
                if (playerOrComputer == "player")
                {
                    Console.WriteLine("zadej koncovou souradnici lode tak, aby delka lode byla " + kvp.Value);
                    coordinate = Console.ReadLine();
                }
                else
                {
                    coordinate = RandomCoordinate(letters);
                }

                // pokud se zadana souradnice sklada z prave dvou znaku
                if (coordinate.Length == 2)
                {
                    //
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
                    if (!lengthIsOkay || coordinate.Length != 2 || !letters.Contains(letterCoordinateLast) || !isTheSecondCharNum || field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                    {
                        if (playerOrComputer == "player") Console.WriteLine("spatne zadana koncova souradnice");
                        repeat = true;
                    }
                    else
                    {
                        repeat = false;
			//zjisteni jestli by se lod neprekryvala s jinou
                        if (orientation == "vodorovne")
                        {
                            if (letters.IndexOf(letterCoordinateFirst) < letters.IndexOf(letterCoordinateLast))
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    if (field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] != "~")
                                    {
                                        repeat = true;
                                    }
                                }
                                if (repeat == false)
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 - i] = Convert.ToString(letter);
                                    }
                                }
                            }
                            else if (letters.IndexOf(letterCoordinateFirst) > letters.IndexOf(letterCoordinateLast))
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    if (field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] != "~")
                                    {
                                        repeat = true;
                                    }

                                }
                                if (repeat == false)
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1 + i] = Convert.ToString(letter);
                                    }
                                }
                            }
                        }
                        else if (orientation == "svisle")
                        {
                            if (numberCoordinateFirst < numberCoordinateLast)
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    if (field[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                                    {
                                        repeat = true;
                                    }
                                }
                                if (repeat == false)
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        field[numberCoordinateLast - i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                                    }
                                }
                            }
                            else if (numberCoordinateFirst > numberCoordinateLast)
                            {
                                for (int i = 0; i < kvp.Value - 1; i++)
                                {
                                    if (field[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] != "~")
                                    {
                                        repeat = true;
                                    }

                                }
                                if (repeat == false)
                                {
                                    for (int i = 0; i < kvp.Value - 1; i++)
                                    {
                                        field[numberCoordinateLast + i, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                                    }
                                }

                            }
                        }

                        if (repeat == false) field[numberCoordinateLast, letters.IndexOf(letterCoordinateLast) - 1] = Convert.ToString(letter);
                        else
                        {
                            if (playerOrComputer == "player")
                            {
                                Console.WriteLine("Lod se nesmi prekryvat s jinou lodi!");
                            }

                        }

                    }
                }

                //pokud není zadaná žádná souřadnice
                else
                {
                    repeat = true;
                }
            } while (repeat);
            //
           

        }
        
	//funkce pro jedno vystreleni
        static void Shooting(List<string> letters, string playerOrComputer, string[,] seenableField, string[,] fieldWithValues, out bool shotWasSuccessful)
        {
            string coordinate;
            bool repeat;
            int numberCoordinate;
            shotWasSuccessful = false;

            //jedna strela
            do
            {
                if (playerOrComputer == "player")
                {
                    Gadgets(letters, seenableField, fieldWithValues);
                    Console.WriteLine("zadej souradnici policka na ktere chces vystrelit");
                    coordinate = Console.ReadLine();
                }
                else
                {
                    coordinate = RandomCoordinate(letters);
                }

                if (coordinate.Length == 2)
                {

                    string letterCoordinate = Convert.ToString(coordinate[0]);
                    repeat = false;
                    bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out numberCoordinate);

                    //kontrola jestli je souradnice ve spravnem formatu
                    if (coordinate.Length != 2 || !letters.Contains(letterCoordinate) || !isTheSecondCharNum || seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] != "~")
                    {
                        if (playerOrComputer == "player") Console.WriteLine("spatne zadana souradnice");
                        repeat = true;
                    }
                    else
                    {
                        //pokud je na danem policku lod
                        if (fieldWithValues[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] != "~")
                        {
                            seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = fieldWithValues[numberCoordinate, letters.IndexOf(letterCoordinate) - 1];
                            if (playerOrComputer == "player")
                            {
                                Console.WriteLine("Zasahl jsi souperovu lod!");

                            }
                            else
                            {
                                fieldWithValues[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = "0";
                                Console.WriteLine("Protivnik zasahl tvoji lod! (Zasah je znacen '0'");
                            }
                            shotWasSuccessful = true;
                        }

                        //pokud je policko prazdne
                        else
                        {
                            
                            if (playerOrComputer == "player")
                            {
                                seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = "X";
                                Console.WriteLine();
                                Console.WriteLine("Bohuzel ses netrefil:(");
                            }
                            else 
                            {
                                seenableField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = "X";
                                fieldWithValues[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = "X";
                            }
                        }

                        repeat = false;
                    }


                }
                else repeat = true;

            } while (repeat);
            if (playerOrComputer == "player") PrintArray(seenableField, letters);
            else
            {
                Console.WriteLine("Tvoje pole:");
                PrintArray(fieldWithValues, letters);
            }

        }

	//funkce pro vylepseni hry(sonar)
        static void Gadgets(List<string>letters, string[,] computerFieldWithout, string[,] computerField)
        {
            Console.WriteLine("Jestli chces prejit do obchodu napis true");
            bool wasSonarUsed = false;
            try
            {
                bool goToStore = Convert.ToBoolean(Console.ReadLine());
                if (goToStore)
                {
                    Console.WriteLine("Muzes si koupit:\n1) Sonar - osviti (ale nevystreli na) 4 tebou vybrana policka ");
                    Console.WriteLine("\nVse muzes pouzit pouze jednou");
                    Console.WriteLine("\npokud chces pouzit sonar, napis s");
                    string sonar = Console.ReadLine();
		//pokud chce hrac pouzit sonar
                    if (sonar == "s" || sonar == "S")
                    {
		//kontrola jestli nebyl sonar jiz drive pouzit
                        if (wasSonarUsed) Console.WriteLine("Sonar byl jiz pouzit");
                        else
                        {
                            wasSonarUsed = true;
                            bool repeat = true;
                            for (int i = 0; i < 4; i++)
                            {
                                do
                                {
                                    Console.WriteLine("zapis souradnici sonaru");
                                    string coordinate = Console.ReadLine();


                                    if (coordinate.Length == 2)
                                    {
                                        repeat = false;
                                        string letterCoordinate = Convert.ToString(coordinate[0]);
                                        bool isTheSecondCharNum = int.TryParse(Convert.ToString(coordinate[1]), out int numberCoordinate);

                                        if (!letters.Contains(letterCoordinate) || !isTheSecondCharNum)
                                        {
                                            Console.WriteLine("\nSpatne zadana souradnice");
                                            repeat = true;
                                        }
                                        else
                                        {
                                            string[,] fieldWithSonar = computerFieldWithout;
                                            repeat = false;
                                            fieldWithSonar[numberCoordinate, letters.IndexOf(letterCoordinate) - 1] = computerField[numberCoordinate, letters.IndexOf(letterCoordinate) - 1];
                                            PrintArray(fieldWithSonar, letters);
                                        }


                                    }
                                    else
                                    {
                                        repeat = true;
                                    }

                                } while (repeat);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {

            }
        }
        
	//funkce pro zjisteni jestli chce hrac zadat souradnice sam nebo jestli si je necha nahodne vygenerovat
        static void HowWillTheShipsBePlaced(string[,]playerField, List<string> letters, Dictionary<string, int> ships)
        {
            string playerOrComputer;

            try
            {
                bool doYouWantItRandom = Convert.ToBoolean(Console.ReadLine());
                if (doYouWantItRandom)
                {
                    Console.WriteLine("Generuji...");
                    Console.WriteLine();
                    playerOrComputer = "computer";
                    AddingShips(playerField, ships, letters, playerOrComputer);
                    Console.WriteLine("Toto je tve pole:");
                    PrintArray(playerField, letters);

                }
                else
                {
                    playerOrComputer = "player";
                    AddingShips(playerField, ships, letters, playerOrComputer);
                }
            }
            catch (Exception)
            {
                playerOrComputer = "player";
                AddingShips(playerField, ships, letters, playerOrComputer);
            }
        }

        static void Main(string[] args)
        {
            // definovani promennych
            int fieldWidth = 10;
            int fieldHeight = 10;
            string[,] playerField = new string[fieldWidth, fieldHeight];
            string[,] playerFieldBlank = new string[fieldWidth, fieldHeight];
            string[,] computerField = new string[fieldWidth, fieldHeight];
            string[,] computerFieldBlank = new string[fieldWidth, fieldHeight];
            string playerOrComputer;

            //retezec stringu pro vypsani tabulky
            List<string> letters = new List<string>
            {"*", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",};

            //definovani lodi
            Dictionary<string, int> ships = new Dictionary<string, int>()
            {
               {"Letadlova lod", 5},
               {"Bitevni lod", 4},
               {"Kriznik", 3},
               {"Ponorka", 3},
               {"Torpedoborec", 2},
            };


            // uvod do hry
            Console.WriteLine("Vitej ve hre Battleship!");
            Console.WriteLine("Toto je tve pole, do ktereho umistis sve lode");
            FillArray(playerField);
            FillArray(playerFieldBlank);
            PrintArray(playerField, letters);

            //pridani lodi hrace
            Console.WriteLine();
            Console.ReadKey();
            Console.WriteLine("K dispozici mas tyto lode:\n1x Letadlova lod (1 x 5)\n1x Bitevni lod (1 x 4)\n1x Kriznik (1 x 3)\n1x Ponorka (1 x 3)\n1x Torpedoborec (1 x 2)\n");
            Console.ReadKey();
            Console.WriteLine("Vzdy zadej pocatecni a koncovou souradnici lode. Pozor at ma pozadovanou delku, je v poli a neprekryva se s zadnou jinou z lodi!");
            Console.ReadKey();
            Console.WriteLine("Pokud jsi liny a chces si nechat vygenerovat umisteni lodi nahodne, napis true.");
            
            HowWillTheShipsBePlaced(playerField, letters, ships);

            //pridani lodi pocitace

            FillArray(computerField);
            playerOrComputer = "computer";
            AddingShips(computerField, ships, letters, playerOrComputer);
            //toto je pro kontrolu rozmisteni lodi pocitace ci pro podvadeni
            //PrintArray(computerField, letters);

            //zacatek hry
            Console.WriteLine("Toto je pole tveho protivnika:");
            FillArray(computerFieldBlank);
            PrintArray(computerFieldBlank, letters);
            Console.WriteLine("Tvym cilem je sestrelit vsechny protivnikovy lode driv nez on sestreli ty tvoje");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Stridate se vzdy po jedne strele");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Zacinas!");

            //strileni
            int playerScore = 0;
            int computerScore = 0;
            bool shotWasSuccessful;
            bool gameIsOver = false;
            while (!gameIsOver)
            {
                //hrac strili
                playerOrComputer = "player";
                Shooting(letters, playerOrComputer, computerFieldBlank, computerField, out shotWasSuccessful);
                if (shotWasSuccessful)
                {
                    playerScore++;
                }
                Console.ReadKey();
                //pocitac strili
                shotWasSuccessful = false;
                playerOrComputer = "computer";
                Shooting(letters, playerOrComputer, playerFieldBlank, playerField, out shotWasSuccessful);
                if (shotWasSuccessful)
                {
                    computerScore++;
                }
                if (playerScore > 16 || computerScore > 16) gameIsOver = true;
            }
	// vyhra
            if (playerScore > computerScore)
            {
                Console.WriteLine("Gratuluji, vyhral jsi! Potopil jsi vsechny lode soupere");
            }
	// prohra
            else if (playerScore < computerScore)
            {
                Console.WriteLine("Bohuzel to nevyslo:(, vsechny tve lode byly potopeny");
	    }

	// remiza
	    else 
	    {
		 Console.WriteLine("Remiza - navzajem jste si naraz sestrelili posledni lod!");
		    }
            Console.ReadKey();

        }
    }
}
