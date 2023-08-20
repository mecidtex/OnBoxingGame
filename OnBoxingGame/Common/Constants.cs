using OnBoxingGame.Models;

namespace OnBoxingGame.Common;

public abstract class Constants
{
    public enum RarityLevel
    {
        Rare,
        SuperRare,
        Epic,
        Mysterious,
        Legendary,
        Chromatic
    }

    public static List<GameCharacter> GameCharacters = new()
    {
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Nita"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Colt"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Bull"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Brock"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "El Primo"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Poco"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Barley"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Rare,
            Name = "Rosa"
        },
        
        // SUPER-RARE
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Rico"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Jacky"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "8-Bit"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Jessie"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Carl"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Darryl"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Penny"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.SuperRare,
            Name = "Tick"
        },
        
        // EPIC
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Bibi"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Pam"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Bo"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Emz"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Frank"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Hank"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Piper"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Bonnie"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Edgar"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Bea"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Epic,
            Name = "Nani"
        },
        
        // MYSTERIOUS
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Byron"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Mortis"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Max"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Tara"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Gene"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Doug"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Mr.P"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Gray"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Squeak"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Mysterious,
            Name = "Sprout"
        },
        
        // LEGENDARY
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Sandy"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Spike"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Leon"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Crow"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Amber"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Meg"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Legendary,
            Name = "Chester"
        },
        
        // CHROMATIC
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Gale"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Surge"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Colette"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Colonel Ruffs"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Fang"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Lola"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Lou"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Otis"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Sam"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Maisie"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Cordeilus"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Buster"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Janet"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Eve"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Mandy"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "R-T"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Ash"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Belle"
        },
        new GameCharacter
        {
            Rarity = RarityLevel.Chromatic,
            Name = "Buzz"
        },
    };
}