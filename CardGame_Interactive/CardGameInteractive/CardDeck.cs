namespace CardGameInteractive;

/// <summary>
/// Defines the card deck as a list of cards 
/// </summary>
public class CardDeck
{
    /// <summary>
    /// The list of cards in the deck
    /// </summary>
    private List<Card> _cardList;

    public CardDeck()
    {
        _cardList = new List<Card>();
    }

    /// <summary>
    /// Read-only property that returns the number of cards in the deck
    /// </summary>
    public int CardCount
    {
        get
        {
            return _cardList.Count;
        }
    }
}