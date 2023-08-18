using System.ComponentModel;
using System.Drawing;

namespace OnBoxingGame
{
    internal class Program
    {
        private static string Character = "";
        private static int Luck;
        private static RarityType Rarity;
        private static int Money = 10;
        private static int Score = 0;
        private static string AgainAnswer = "";
        private static int ReleasedLegendaryNumber;
        private static int ReleasedChromoticNumber;
        private static int AdMoney;
        // To prevent rare characters from appearing more than 3 times in a row.
        private static int ConsecutiveRares = 0;

        private enum RarityType
        {
            [Description("Rare")]
            Rare,
            SuperRare,
            Epic,
            Mysterious,
            Legendary,
            Chromotic
        }



        static void Main(string[] args)
        {
            WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.DarkGray);
            WriteLineMessageWithColor("Box Price = 5$", ConsoleColor.DarkGray);
            AskOpening();
        }


        static void AskOpening()
        {
            WriteMessageWithColor("Type \"A\" to open a box.", ConsoleColor.Gray);
            WriteLineMessageWithColor(" Type \"i\" to learn about the game.", ConsoleColor.White);
            try
            {
                char UserChar = Convert.ToChar(Console.ReadLine());
                if (char.ToLower(UserChar) == 'a')
                {
                    if (Money > 4)
                    {
                        Money -= 5;
                        OpenBox();
                    }
                    else
                    {
                        WriteLineMessageWithColor("Insufficient Money!", ConsoleColor.DarkRed);
                        WriteLineMessageWithColor("--- GAME OVER ---", ConsoleColor.DarkRed);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("Your Score : " + Score);
                        Console.ResetColor();
                        Console.WriteLine("");
                        AskAgain();


                    }
                }
                else if (char.ToLower(UserChar) == 'i') //About The Game
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    WriteLineMessageWithColor("Earn money by opening boxes. Type A to open a box.\r\nDifferent rarities give money in different quantity ranges.\r\n\r\nStarting with the lowest rarity:\r\n\r\n-Rare\r\n-Super Rare\r\n-Epic\r\n-Mysterious\r\n-Legendary\r\n\r\nHow does the game over?\r\n\r\nWhen you don't have enough money to open a box, it's game over.\r\n(One box costs $5)",
                        ConsoleColor.Black);
                    Thread.Sleep(3500); // Read Time
                    Console.WriteLine("");

                    Console.WriteLine("***************************************************");
                    AskOpening();
                }
                else if (char.ToLower(UserChar) == 'e') // SECRET ANSWER
                {
                    WriteLineMessageWithColor("Number of Legendary characters released : " + ReleasedLegendaryNumber, ConsoleColor.Yellow);
                    PrintRainbowText("Number of Chromotic characters released : " + ReleasedChromoticNumber);
                    AskOpening();
                }
                else
                {
                    WriteLineMessageWithColor("Please enter a valid value!", ConsoleColor.DarkRed);
                    AskOpening();
                }
            }
            catch (Exception)
            {
                Console.BackgroundColor = ConsoleColor.White;
                WriteMessageWithColor("Incorrect entry! Try again", ConsoleColor.Red);
                Console.WriteLine("");
                Thread.Sleep(600);
                AskOpening();
            }


        }

        static void OpenBox()
        {
            Random rdm = new();
            Console.WriteLine("The box is opening...");
            Thread.Sleep(2000);
            

            Luck = (ConsecutiveRares > 2) ? rdm.Next(2) : 1;
            if (Luck == 0)
            {
                Rarity = RarityType.Rare;
                CharacterOpen();
                Console.WriteLine("------[]------");
                WriteLineMessageWithColor($"Character : {Character}", ConsoleColor.White);
                WriteLineMessageWithColor($"Rarity : Rare", ConsoleColor.Green);

                GiveMoney();
                Thread.Sleep(900);
                AskOpening();
            }
            else if (Luck == 1)
            {
                Rarity = RarityType.SuperRare;
                Luck = rdm.Next(3);
                if (Luck != 2)
                {
                    // Super Rare
                    CharacterOpen();
                    Console.WriteLine("------[]------");
                    WriteLineMessageWithColor($"Character : {Character}", ConsoleColor.White);
                    WriteLineMessageWithColor("Rarity : Super Rare", ConsoleColor.DarkCyan);

                    GiveMoney();
                    ConsecutiveRares = 0;
                    Thread.Sleep(1000);
                    AskOpening();
                }
                else if (Luck == 2)
                {
                    Rarity = RarityType.Epic;
                    Luck = rdm.Next(3);
                    if (Luck == 0 || Luck == 3)
                    {
                        // Epic
                        CharacterOpen();
                        Console.WriteLine("------[]------");
                        WriteLineMessageWithColor($"Character : {Character}", ConsoleColor.White);
                        WriteLineMessageWithColor("Rarity : Epic", ConsoleColor.DarkBlue);
                        GiveMoney();
                        ConsecutiveRares = 0;
                        Thread.Sleep(1000);
                        AskOpening();

                    }
                    else if (Luck == 2)
                    {
                        Rarity = RarityType.Mysterious;
                        Luck = rdm.Next(4);
                        if (Luck != 2)
                        {
                            // Mysterious
                            CharacterOpen();
                            WriteLineMessageWithColor("**--?---[???]---?--**", ConsoleColor.DarkRed);
                            Thread.Sleep(850);
                            WriteLineMessageWithColor($"Character : {Character}", ConsoleColor.White);
                            WriteLineMessageWithColor("Rarity : Mysterious", ConsoleColor.Red);
                            WriteLineMessageWithColor("----?-----------?----", ConsoleColor.DarkRed);

                            GiveMoney();
                            ConsecutiveRares = 0;
                            Thread.Sleep(1300);
                            AskOpening();
                        }
                        else if (Luck == 2)
                        {
                            Rarity = RarityType.Legendary;
                            Luck = rdm.Next(7);

                            if (Luck != 5)
                            {

                                // Legendary
                                CharacterOpen();
                                WriteLineMessageWithColor("~~~~~~~~~~~ [-( * )-] ~~~~~~~~~~~", ConsoleColor.DarkYellow);
                                WriteLineMessageWithColor($"Character : {Character}", ConsoleColor.White);
                                WriteLineMessageWithColor("Rarity : Legendary", ConsoleColor.Yellow);
                                GiveMoney();
                                WriteLineMessageWithColor("~~~~~~~~~~~~~~~ * ~~~~~~~~~~~~~~~", ConsoleColor.DarkYellow);

                                ConsecutiveRares = 0;
                                Thread.Sleep(1850);
                                AskOpening();
                            }
                            else if (Luck == 5)
                            {
                                Rarity = RarityType.Chromotic;

                                // Chromotic
                                CharacterOpen();
                                PrintRainbowText("~~~~~~~~~ [ # # # ] ~~~~~~~~~");
                                WriteLineMessageWithColor($"Character : {Character}", ConsoleColor.White);
                                PrintRainbowText("Rarity : Chromotic");
                                GiveMoney();
                                PrintRainbowText("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            }
                        }

                    }

                }
            }


        }

        static void GiveMoney()
        {
            Random rdm = new();
            switch (Rarity)
            {
                case RarityType.Rare:
                    AdMoney = rdm.Next(2, 7); // Min. -3
                    Score += 1;
                    break;

                case RarityType.SuperRare:
                    AdMoney = rdm.Next(3, 8); // Min. -2
                    Score += 2;
                    break;

                case RarityType.Epic:
                    AdMoney = rdm.Next(4, 12); // Min. -1 Max. 7
                    Score += 4;
                    break;

                case RarityType.Mysterious:
                    AdMoney = rdm.Next(14, 23); // Min. +9
                    Score += 6;
                    break;

                case RarityType.Legendary:
                    AdMoney = rdm.Next(28, 40); //23-35

                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Money : " + AdMoney.ToString(), ConsoleColor.White);
                    Score += 10;
                    ReleasedLegendaryNumber++;
                    break;

                case RarityType.Chromotic:
                    AdMoney = rdm.Next(55, 75); //50-70

                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Money : " + AdMoney.ToString(), ConsoleColor.White);
                    Score += 18;
                    ReleasedChromoticNumber++;
                    break;
            }


            if (Rarity != RarityType.Mysterious && Rarity != RarityType.Legendary && Rarity != RarityType.Chromotic)    // If not Mysterius , Legendary or Chromotic...
            {
                Money += AdMoney;

                AdMoney -= 5;
                WriteLineMessageWithColor($"Money : {AdMoney}", ConsoleColor.White);
                Console.WriteLine("--------------");
                WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
            }
            else //If Legendary, Mysterious or Chromotic...
            {
                if (Rarity == RarityType.Mysterious)
                {
                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                }

                if (Rarity == RarityType.Legendary)
                {
                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                    Console.WriteLine($"Number of Legendary characters released : {ReleasedLegendaryNumber}");
                }

                if (Rarity == RarityType.Chromotic)
                {
                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                    Console.WriteLine($"Number of Chromotic characters released : {ReleasedChromoticNumber}");
                }
            }


        }

        static void CharacterOpen()
        {
            string[] RareCharacters = { "Nita", "Colt", "Bull", "Brock", "El Primo", "Poco", "Barley", "Rosa" };
            string[] SuperRareCharacters = { "Rico", "Jacky", "8-Bit", "Jessie", "Carl", "Darryl", "Penny", "Tick" };
            string[] EpicCharacters = { "Bibi", "Pam", "Bo", "Emz", "Frank", "Hank", "Piper", "Bonnie", "Edgar", "Bea", "Nani" };
            string[] MysteriousCharacters = { "Byron", "Mortis", "Max", "Tara", "Gene", "Doug", "Mr.P", "Gray", "Squeak", "Sprout" };
            string[] LegendaryCharacters = { "Sandy", "Spike", "Leon", "Crow", "Amber", "Meg", "Chester" };
            string[] ChromaticCharacters = { "Gale", "Surge", "Colette", "Colonel Ruffs", "Fang", "Lola", "Lou", "Otis", "Sam", "Maisie",
                                             "Cordeilus", "Buster", "Janet", "Eve", "Mandy", "R-T", "Ash", "Belle", "Buzz" };

            switch (Rarity)
            {
                case RarityType.Rare:
                    Character = RareCharacters[new Random().Next(0, 7)];
                    break;

                case RarityType.SuperRare:
                    Character = SuperRareCharacters[new Random().Next(0, 7)];
                    break;

                case RarityType.Epic:
                    Character = EpicCharacters[new Random().Next(0, 9)];
                    break;

                case RarityType.Mysterious:
                    Character = MysteriousCharacters[new Random().Next(0, MysteriousCharacters.Length - 1)];
                    break;

                case RarityType.Legendary:
                    Character = LegendaryCharacters[new Random().Next(0, 6)];
                    break;

                case RarityType.Chromotic:
                    Character = ChromaticCharacters[new Random().Next(0, ChromaticCharacters.Length - 1)];
                    break;

                default:
                    break;
            }


        }

        static void AskAgain()
        {
            Console.WriteLine("***************************************************");
            WriteLineMessageWithColor("Type \"yes\" to restart the game.", ConsoleColor.White);

            try
            {
                AgainAnswer = Console.ReadLine();
                if (AgainAnswer.ToLower() == "yes")
                {
                    Score = 0;
                    Money = 10;
                    Console.WriteLine("***************************************************");
                    AskOpening();

                }
            }
            catch (Exception)
            {
                Console.BackgroundColor = ConsoleColor.White;
                WriteLineMessageWithColor("Incorrect entry! Try again", ConsoleColor.DarkRed);
                AskAgain();
            }
        }

        static void WriteLineMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void WriteMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        static void PrintRainbowText(string text)
        {
            ConsoleColor[] colors = {
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkYellow,
            };

            int colorIndex = 0;

            foreach (char c in text)
            {
                Console.ForegroundColor = colors[colorIndex];
                Console.Write(c);
                colorIndex = (colorIndex + 1) % colors.Length;
            }



            Console.ResetColor();
            Console.WriteLine();
        }

    }

}