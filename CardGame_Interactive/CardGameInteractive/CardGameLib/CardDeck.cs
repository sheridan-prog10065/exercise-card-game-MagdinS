namespace CardGameLib;

/// <summary>
/// Defines the card deck as a list of cards 
/// </summary>
public class CardDeck
{
    /// <summary>
    /// The list of cards in the deck
    /// </summary>
    private List<Card> _cardList;

    private const int MAX_SUIT_COUNT = 4;
    private const byte MAX_CARD_VALUE = 13;

    private static Random s_randomizer;

    static CardDeck()
    {
        s_randomizer = new Random();
    }

    public CardDeck()
    {
        _cardList = new List<Card>();
        
        //create the cards of the deck
        CreateCards();
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

    public static Random Randomizer
    {
        get { return s_randomizer; }
    }

    private void CreateCards()
    {
        //for each suit in the deck
        for(int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++ )
        {
            CardSuit suit = (CardSuit)iSuit;
            
            //for each card in the current suite
            for(byte value = 1; value <= MAX_CARD_VALUE; value++)
            {
                //create the card
                Card card = new Card(value, suit);

                //add the card to the list
                _cardList.Add(card);
            }
        }
    }
    public void ShuffleCards()
    {
        //for each card position in the deck 
        for(int iCard = 0; iCard < _cardList.Count; iCard++)
        {
            //pick a random card in the deck
            int randPos = s_randomizer.Next(iCard, _cardList.Count);
            
            //swap the random card with the card in the current position
            Card randomCard = _cardList[randPos];
            _cardList[randPos] = _cardList[iCard];
            _cardList[iCard] = randomCard;
        }
    }

    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        //check that we have enough cards
        if (_cardList.Count >= 2)
        {
            //extract two random cards from the deck. How?

            //generate a random index using the static randomizer field variable directly
            int randIndex = s_randomizer.Next(_cardList.Count);
                
            //access the card at the random index
            cardOne = _cardList[randIndex];
                
            //remove the card from the deck
            _cardList.RemoveAt(randIndex);

            //extract the second card
            //generate a random index using the static randomizer property. Note the
            //use of class name, "CardDeck." as opposed to "this."
            randIndex = CardDeck.Randomizer.Next(_cardList.Count);
            cardTwo = _cardList[randIndex];
            _cardList.RemoveAt(randIndex);

            //extraction was successful
            return true;
        }
        else
        {
            //extraction was not successful
            cardOne = null;
            cardTwo = null;
            return false;
        }
    }

    public void ExchangeCards(ref Card cardOne, ref Card cardTwo)
    {
        //swap the player cards and the house card with tuple deconstruction
        (cardOne, cardTwo) = (cardTwo, cardOne);
    }
}