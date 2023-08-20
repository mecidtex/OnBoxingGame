using OnBoxingGame.Common;

namespace OnBoxingGame.Models;

public class LuckyBox
{
    // Gives bonus money
    public int Bonus { get; set; }
    
    // Gives XP to score
    public int Xp { get; set; }

    public GameCharacter Character { get; set; }
}