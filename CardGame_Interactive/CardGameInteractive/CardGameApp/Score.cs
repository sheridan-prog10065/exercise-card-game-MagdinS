namespace CardGameInteractive;

/// <summary>
/// Define the score of the game
/// </summary>
public struct Score
{
    /// <summary>
    /// The number of rounds won by the player of the game
    /// </summary>
    private int _playerScore;
    
    /// <summary>
    /// The number of rounds won by the house
    /// </summary>
    private int _houseScore;

    public int PlayerScore
    {
        get
        {
            return _playerScore;
        }
    }

    public int HouseScore
    {
        get
        {
            return _houseScore;
        }
    }
}