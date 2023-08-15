namespace OnBoxingGame
{
    internal class Program
    {
        private static string chr;
        private static int Luck;
        private static string Rarity;
        private static int Money = 10;
        private static int Score = 0;
        private static string AgainAnswer;
        private static int ReleasedLegendaryNumber;
        private static int ConsecutiveRares; //To prevent rare characters from appearing more than 3 times in a row.
        private static int AdMoney;

        static void Main(string[] args)
        {
            WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
            WriteLineMessageWithColor("Box Price = 5$", ConsoleColor.Gray);
            AskOpening();
        }

        static void WriteLineMessageWithColor(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void AskOpening()
        {
            WriteLineMessageWithColor("Type \"A\" to open a box.", ConsoleColor.DarkGray);
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
                        WriteLineMessageWithColor("Your Score : " + Score, ConsoleColor.White);
                        

                    }
                }
                else if(char.ToLower(UserChar) == 'e')
                {
                    WriteLineMessageWithColor("Number of Legendary characters released : " + ReleasedLegendaryNumber, ConsoleColor.Yellow);
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
                WriteLineMessageWithColor("Incorrect entry! Try again", ConsoleColor.Red);
                AskOpening();
            }
            
            
        }

        static void OpenBox()
        {
            Random rdm = new();
            Console.WriteLine("The box is opening...");
            Thread.Sleep(2000);

            //Rare
            Rarity = "Rare";
            Luck = rdm.Next(2); //Like True-False
            if (Luck == 0)
            {
                CharacterOpen();
                Console.WriteLine("------[]------");
                WriteLineMessageWithColor("Character : " + chr, ConsoleColor.White);
                WriteLineMessageWithColor("Rarity : " + Rarity, ConsoleColor.Green);

                GiveMoney();
                Thread.Sleep(1000);
                AskOpening();
            }
            else if (Luck == 1)
            {
                Rarity = "Super Rare";
                Luck = rdm.Next(2);
                if (Luck == 0)
                {
                    // Super Rare
                    CharacterOpen();
                    Console.WriteLine("------[]------");
                    WriteLineMessageWithColor("Character : " + chr, ConsoleColor.White);
                    WriteLineMessageWithColor("Rarity : " + Rarity, ConsoleColor.DarkCyan);

                    GiveMoney();
                    Thread.Sleep(1000);
                    AskOpening();
                }
                else if (Luck == 1)
                {
                    Rarity = "Epic";
                    Luck = rdm.Next(2);
                    if (Luck == 0)
                    {
                        // Epic
                        CharacterOpen();
                        Console.WriteLine("------[]------");
                        WriteLineMessageWithColor("Character : " + chr, ConsoleColor.White);
                        WriteLineMessageWithColor("Rarity : " + Rarity, ConsoleColor.DarkBlue);   
                        GiveMoney();
                        Thread.Sleep(1000);
                        AskOpening();

                    }
                    else if (Luck == 1)
                    {
                        Rarity = "Myhtical";
                        Luck = rdm.Next(3);
                        if (Luck == 0 || Luck == 1 || Luck == 3)
                        {
                            // Myhtical
                            CharacterOpen();
                            WriteLineMessageWithColor("**--?---[???]---?--**", ConsoleColor.DarkRed);
                            Thread.Sleep(700);
                            WriteLineMessageWithColor("Character : " + chr, ConsoleColor.White);
                            WriteLineMessageWithColor("Rarity : " + Rarity, ConsoleColor.Red);
                            WriteLineMessageWithColor("-----------------", ConsoleColor.DarkRed);

                            GiveMoney();
                            Thread.Sleep(1000);
                            AskOpening();
                        }
                        else if (Luck == 2)
                        {
                            Rarity = "Legendary";

                            // Legendary
                            CharacterOpen();
                            WriteLineMessageWithColor("~~~~~~~~~~~ * ~~~~~~~~~~~", ConsoleColor.DarkYellow);
                            WriteLineMessageWithColor("Character : " + chr, ConsoleColor.White);
                            WriteLineMessageWithColor("Rarity : " + Rarity, ConsoleColor.Yellow);
                            WriteLineMessageWithColor("~~~~~~~~~~~ * ~~~~~~~~~~~", ConsoleColor.DarkYellow);
                            GiveMoney();

                            Thread.Sleep(1500);
                            AskOpening();
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
                case "Rare":
                    AdMoney = rdm.Next(2, 7); // Min. -3
                    Score +=1;
                    break;

                case "Super Rare":
                    AdMoney = rdm.Next(3, 8); // Min. -2
                    Score += 2;
                    break;

                case "Epic":
                    AdMoney = rdm.Next(4, 12); // Min. -1 Max. 7
                    Score += 4;
                    break;

                case "Myhtical":
                    AdMoney = rdm.Next(14, 23); // Min. +9
                    Score += 6;
                    break;
                                
                case "Legendary":
                    AdMoney = rdm.Next(28, 40); //23-35

                    Money = Money + AdMoney;

                    AdMoney -= 5;
                    WriteLineMessageWithColor("Money : " + AdMoney.ToString(), ConsoleColor.Yellow);
                    Score += 10;
                    ReleasedLegendaryNumber++;
                    break;
            }

            if(Rarity != "Legendary" && Rarity != "Myhtical") //If not Legandary...
            {
                Money = Money + AdMoney;

                AdMoney -= 5;
                WriteLineMessageWithColor($"Money : {AdMoney}", ConsoleColor.White);
                Console.WriteLine("-----------------");
                WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
            }
            else //If Legendary...
            {
                switch (Rarity)
                {
                    case "Myhtical":
                        Money = Money + AdMoney;

                        AdMoney -= 5;
                        WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                        break;

                    case "Legendary":
                        Money = Money + AdMoney;

                        AdMoney -= 5;
                        WriteLineMessageWithColor("Your Money : " + Money, ConsoleColor.Gray);
                        Console.WriteLine($"Number of Legendary characters released : {ReleasedLegendaryNumber}");
                        break;
                }
            }
            

        }

        static void CharacterOpen()
        {
            string[] RareCharacters = { "Nita", "Colt", "Bull", "Brock", "El Primo", "Poco", "Barley", "Rosa" };
            string[] SuperRareCharacters = { "Rico", "Jacky", "8-Bit", "Jessie", "Carl", "Darryl", "Penny", "Tick" };
            string[] EpicCharacters = { "Bibi", "Pam", "Bo", "Emz", "Frank", "Hank", "Piper", "Bonnie", "Edgar", "Bea", "Nani" };
            string[] MyhticalCharacters = { "Byron", "Mortis", "Max", "Tara", "Gene", "Doug", "Mr.P", "Gray" , "Squeak" , "Sprout" };
            string[] LegendaryCharacters = { "Sandy", "Spike", "Leon", "Crow", "Amber", "Meg", "Chester" };

            switch (Rarity)
            {
                case "Rare":
                    chr = RareCharacters[new Random().Next(0, 7)];
                    break;

                case "Super Rare":
                    chr = SuperRareCharacters[new Random().Next(0, 7)];
                    break;

                case "Epic":
                    chr = EpicCharacters[new Random().Next(0, 10)];
                    break;

                case "Myhtical":
                    chr = MyhticalCharacters[new Random().Next(0, 8)];
                    break;

                case "Legendary":
                    chr = LegendaryCharacters[new Random().Next(0, 6)];
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
                if (AgainAnswer.ToLower() == "yes")
                {
                    Score = 0;
                    Money = 10;
                    AskOpening();

                }
            }
            catch (Exception)
            {
                Console.BackgroundColor = ConsoleColor.White;
                WriteLineMessageWithColor("Incorrect entry! Try again", ConsoleColor.DarkRed);
            }
        }

    }

}