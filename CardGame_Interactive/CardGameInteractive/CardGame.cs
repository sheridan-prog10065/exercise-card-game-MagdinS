namespace CardGameInteractive;

/// <summary>
/// Defines the card game that implements the game logic and holds the card deck
/// </summary>
public class CardGame
{
    /// <summary>
    /// Represents the deck of cards the game is using
    /// </summary>
    private CardDeck _cardDeck;

    /// <summary>
    /// The score of the game
    /// </summary>
    private Score _score;

    /// <summary>
    /// The last card played by the user
    /// </summary>
    private Card _playerCard;

    /// <summary>
    /// The last card player by the house
    /// </summary>
    private Card _houseCard;

}