using OnBoxingGame.Common;
using OnBoxingGame.Models;

namespace OnBoxingGame
{
    internal abstract class Program
    {
        private static Constants.RarityLevel Level;
        private static readonly int[] DifficultyLevels = { 0, 1, 2, 3, 4, 5, 6, 7 };
        private static int[] CurrentDifficultyLevelRange = DifficultyLevels[..2];
        private static int Money = 10;
        private static int Score;
        private static string AgainAnswer = "";
        private static int ReleasedLegendaryNumber;
        private static int ReleasedChromaticNumber;

        private static int AdMoney;

        // To prevent rare characters from appearing more than 3 times in a row.
        private static int ConsecutiveRares;
        private static List<LuckyBox> LuckyBoxes = new();

        private static void Main()
        {
            WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.DarkGray);
            WriteLineMessageWithColor("Box Price = 5$", ConsoleColor.DarkGray);
            AskOpening();
        }


        private static void AskOpening()
        {
            WriteMessageWithColor("Type \"A\" to open a box.", ConsoleColor.Gray);
            WriteLineMessageWithColor(" Type \"i\" to learn about the game.", ConsoleColor.White);
            try
            {
                var userChar = Convert.ToChar(Console.ReadLine() ?? string.Empty);
                switch (char.ToLower(userChar))
                {
                    case 'a' when Money > 4:
                        Money -= 5;
                        OpenBox();
                        break;
                    case 'a':
                        WriteLineMessageWithColor("Insufficient Money!", ConsoleColor.DarkRed);
                        WriteLineMessageWithColor("--- GAME OVER ---", ConsoleColor.DarkRed);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("Your Score : " + Score);
                        Console.ResetColor();
                        Console.WriteLine("");
                        AskAgain();
                        break;
                    //About The Game
                    case 'i':
                        Console.BackgroundColor = ConsoleColor.Gray;
                        WriteLineMessageWithColor(@"
Earn money by opening boxes. Type A to open a box.
Different rarities give money in different quantity ranges.
Starting with the lowest rarity:
-Rare
-Super Rare
-Epic
-Mysterious
-Legendary

How does the game over?
When you don't have enough money to open a box, it's game over.
(One box costs $5)", ConsoleColor.Black);
                        Thread.Sleep(3500); // Read Time
                        Console.WriteLine("");

                        Console.WriteLine("***************************************************");
                        AskOpening();
                        break;
                    // SECRET ANSWER
                    case 'e':
                        WriteLineMessageWithColor(
                            "Number of Legendary characters released : " + ReleasedLegendaryNumber,
                            ConsoleColor.Yellow);
                        PrintRainbowText("Number of Chromatic characters released : " + ReleasedChromaticNumber);
                        AskOpening();
                        break;
                    default:
                        WriteLineMessageWithColor("Please enter a valid value!", ConsoleColor.DarkRed);
                        AskOpening();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.BackgroundColor = ConsoleColor.White;
                WriteMessageWithColor("Incorrect entry! Try again", ConsoleColor.Red);
                Console.WriteLine("");
                Thread.Sleep(600);
                AskOpening();
            }
        }

        private static void OpenBox()
        {
            Random rdm = new();
            Console.WriteLine("The box is opening...");
            Thread.Sleep(2000);

            var selectedLevelUpNumber = rdm.Next(CurrentDifficultyLevelRange.Length);

            var theRandomLuckNumber = rdm.Next(CurrentDifficultyLevelRange.Length);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"selected value: {selectedLevelUpNumber} | lucky value: {theRandomLuckNumber}");
            Console.ResetColor();
            if (selectedLevelUpNumber == theRandomLuckNumber)
            {
                switch (Level)
                {
                    case Constants.RarityLevel.Rare:
                        Level = Constants.RarityLevel.SuperRare;
                        CurrentDifficultyLevelRange = DifficultyLevels[..3];
                        break;
                    case Constants.RarityLevel.SuperRare:
                        Level = Constants.RarityLevel.Epic;
                        CurrentDifficultyLevelRange = DifficultyLevels[..4];
                        break;
                    case Constants.RarityLevel.Epic:
                        Level = Constants.RarityLevel.Mysterious;
                        CurrentDifficultyLevelRange = DifficultyLevels[..5];
                        break;
                    case Constants.RarityLevel.Mysterious:
                        Level = Constants.RarityLevel.Legendary;
                        CurrentDifficultyLevelRange = DifficultyLevels[..6];
                        break;
                    case Constants.RarityLevel.Legendary:
                        Level = Constants.RarityLevel.Chromatic;
                        CurrentDifficultyLevelRange = DifficultyLevels[..];
                        break;
                    case Constants.RarityLevel.Chromatic:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            switch (Level)
            {
                case Constants.RarityLevel.Rare:
                    RareBox();
                    break;
                case Constants.RarityLevel.SuperRare:
                    SuperRareBox();
                    break;
                case Constants.RarityLevel.Epic:
                    EpicBox();
                    break;
                case Constants.RarityLevel.Mysterious:
                    MysteriousBox();
                    break;
                case Constants.RarityLevel.Legendary:
                    LegendaryBox();
                    break;
                case Constants.RarityLevel.Chromatic:
                    ChromaticBox();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void RareBox()
        {
            var character = GetRandomCharacter();
            LuckyBox box = new()
            {
                Character = character,
            };

            Console.WriteLine("------[]------");
            WriteLineMessageWithColor($"Character : {box.Character.Name}", ConsoleColor.White);
            WriteLineMessageWithColor($"Rarity : Rare", ConsoleColor.Green);

            GiveMoney();
            Thread.Sleep(900);
            AskOpening();
            LuckyBoxes.Add(box);
        }

        private static void SuperRareBox()
        {
            var character = GetRandomCharacter();
            LuckyBox box = new()
            {
                Character = character,
            };
            
            Console.WriteLine("------[]------");
            WriteLineMessageWithColor($"Character : {box.Character.Name}", ConsoleColor.White);
            WriteLineMessageWithColor("Rarity : Super Rare", ConsoleColor.DarkCyan);
            GiveMoney();

            ConsecutiveRares = 0;
            Thread.Sleep(1000);
            AskOpening();
            LuckyBoxes.Add(box);
        }

        private static void EpicBox()
        {
            var character = GetRandomCharacter();
            LuckyBox box = new()
            {
                Character = character,
            };
            
            Console.WriteLine("------[]------");
            WriteLineMessageWithColor($"Character : {box.Character.Name}", ConsoleColor.White);
            WriteLineMessageWithColor("Rarity : Epic", ConsoleColor.DarkBlue);
            GiveMoney();

            ConsecutiveRares = 0;
            Thread.Sleep(1000);
            AskOpening();
            LuckyBoxes.Add(box);
        }

        private static void MysteriousBox()
        {
            var character = GetRandomCharacter();
            LuckyBox box = new()
            {
                Character = character,
            };
            
            WriteLineMessageWithColor("**--?---[???]---?--**", ConsoleColor.DarkRed);
            WriteLineMessageWithColor($"Character : {box.Character.Name}", ConsoleColor.White);
            WriteLineMessageWithColor("Rarity : Mysterious", ConsoleColor.Red);
            GiveMoney();
            WriteLineMessageWithColor("----?-----------?----", ConsoleColor.DarkRed);

            ConsecutiveRares = 0;
            Thread.Sleep(1000);
            AskOpening();
            LuckyBoxes.Add(box);
        }

        private static void LegendaryBox()
        {
            var character = GetRandomCharacter();
            LuckyBox box = new()
            {
                Character = character,
            };
            
            WriteLineMessageWithColor("~~~~~~~~~~~ [-( * )-] ~~~~~~~~~~~", ConsoleColor.DarkYellow);
            WriteLineMessageWithColor($"Character : {box.Character.Name}", ConsoleColor.White);
            WriteLineMessageWithColor("Rarity : Legendary", ConsoleColor.Yellow);
            GiveMoney();
            WriteLineMessageWithColor("~~~~~~~~~~~~~~~ * ~~~~~~~~~~~~~~~", ConsoleColor.DarkYellow);

            ConsecutiveRares = 0;
            Thread.Sleep(2000);
            AskOpening();
            LuckyBoxes.Add(box);
        }

        private static void ChromaticBox()
        {
            var character = GetRandomCharacter();
            LuckyBox box = new()
            {
                Character = character,
            };
            
            PrintRainbowText("~~~~~~~~~ [ # # # ] ~~~~~~~~~");
            WriteLineMessageWithColor($"Character : {box.Character.Name}", ConsoleColor.White);
            PrintRainbowText("Rarity : Chromatic");
            GiveMoney();
            PrintRainbowText("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            ConsecutiveRares = 0;
            Thread.Sleep(2000);
            AskOpening();
            LuckyBoxes.Add(box);
        }

        private static void GiveMoney()
        {
            Random rdm = new();
            switch (Level)
            {
                case Constants.RarityLevel.Rare:
                    AdMoney = rdm.Next(2, 7); // Min. -3
                    Score += 1;
                    break;

                case Constants.RarityLevel.SuperRare:
                    AdMoney = rdm.Next(3, 8); // Min. -2
                    Score += 2;
                    break;

                case Constants.RarityLevel.Epic:
                    AdMoney = rdm.Next(4, 12); // Min. -1 Max. 7
                    Score += 4;
                    break;

                case Constants.RarityLevel.Mysterious:
                    AdMoney = rdm.Next(9, 23); // Min. +4
                    Score += 6;
                    break;

                case Constants.RarityLevel.Legendary:
                    AdMoney = rdm.Next(28, 40); //23-35

                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Money : " + AdMoney, ConsoleColor.White);
                    Score += 10;
                    ReleasedLegendaryNumber++;
                    break;

                case Constants.RarityLevel.Chromatic:
                    AdMoney = rdm.Next(55, 75); //50-70

                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Money : " + AdMoney, ConsoleColor.White);
                    Score += 18;
                    ReleasedChromaticNumber++;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }


            if (Level != Constants.RarityLevel.Mysterious && Level != Constants.RarityLevel.Legendary &&
                Level != Constants.RarityLevel.Chromatic)
            {
                Money += AdMoney;

                AdMoney -= 5;
                WriteLineMessageWithColor($"Money : {AdMoney}", ConsoleColor.White);
                Console.WriteLine("--------------");
                WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
            }
            else //If Legendary, Mysterious or Chromatic...
            {
                if (Level == Constants.RarityLevel.Mysterious)
                {
                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                }

                if (Level == Constants.RarityLevel.Legendary)
                {
                    Money += AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                    Console.WriteLine($"Number of Legendary characters released : {ReleasedLegendaryNumber}");
                }

                if (Level != Constants.RarityLevel.Chromatic) return;

                Money += AdMoney;
                AdMoney -= 5;
                WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                Console.WriteLine($"Number of Chromatic characters released : {ReleasedChromaticNumber}");
            }
        }

        private static GameCharacter GetRandomCharacter()
        {
            var gameCharacters = Constants.GameCharacters.FindAll(
                character => character.Rarity == Level
            );
            return gameCharacters[new Random().Next(gameCharacters.Count)];
        }

        private static void AskAgain()
        {
            Console.WriteLine("***************************************************");
            WriteLineMessageWithColor("Type \"yes\" to restart the game.", ConsoleColor.White);

            try
            {
                AgainAnswer = Console.ReadLine() ?? string.Empty;
                if (AgainAnswer.ToLower() != "yes") return;
                Score = 0;
                Money = 10;
                Console.WriteLine("***************************************************");
                AskOpening();
            }
            catch (Exception)
            {
                Console.BackgroundColor = ConsoleColor.White;
                WriteLineMessageWithColor("Incorrect entry! Try again", ConsoleColor.DarkRed);
                AskAgain();
            }
        }

        private static void WriteLineMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void WriteMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void PrintRainbowText(string text)
        {
            ConsoleColor[] colors =
            {
                ConsoleColor.DarkBlue,
                ConsoleColor.DarkRed,
                ConsoleColor.DarkYellow,
            };

            var colorIndex = 0;

            foreach (var c in text)
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