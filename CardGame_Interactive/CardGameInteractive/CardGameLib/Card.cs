using System.Diagnostics;

namespace CardGameLib;

/// <summary>
/// Defines the card in a card game with its value and suit
/// </summary>
public class Card
{
    /// <summary>
    /// The value of the playing card
    /// </summary>
    private byte _value;

    /// <summary>
    /// The suit of the player card
    /// </summary>
    private CardSuit _suit;

    public Card(byte value, CardSuit suit)
    {
        _value = value;
        _suit = suit;
    }

    public byte Value
    {
        get
        {
            return _value;
        }
    }

    public CardSuit Suit
    {
        get
        {
            return _suit;
        }
        set
        {
            _suit = value;
        }
    }

    public string CardName
    {
        get
        {
            switch (_value)
            {
                case 1:
                    return "Ace";
                
                case 13:
                    return "King";
                
                case 12:
                    return "Queen";
                
                case 11:
                    return "Jack";
                
                default:
                    //Convert the numeric value into a string. We CANNOT cast integer to a string
                    return _value.ToString();
                    
            }
        }
    }

    public string SuiteName
    {
        get
        {
            switch(_suit)
            {
                case CardSuit.Clubs:
                    return "Clubs";
                
                case CardSuit.Diamonds:
                    return "Diamonds";
                
                case CardSuit.Hearts:
                    return "Hearts";
                
                case CardSuit.Spades:
                    return "Spades";
                
                default:
                    Debug.Assert(false, "Unknown suit value. Cannot return suit name");
                    return _suit.ToString();
            }
        }
    }
}









