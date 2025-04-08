namespace CardGameApp;

/// <summary>
/// Defines the card deck as a list of cards 
/// </summary>
public class CardDeck
{
    /// <summary>
    /// The list of cards in the deck
    /// </summary>
    private List<Card> _cardList;
    
    //Define card deck constants
    private const int MAX_SUIT_COUNT = 4;
    private const int MAX_CARD_VALUE = 13;

    //define a singleton randomizer object
    private static Random s_randomizer;

    static CardDeck()
    {
        s_randomizer = new Random();
    }

    public CardDeck()
    {
        _cardList = new List<Card>();
        
        //Create the cards in the deck
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
        //for each suit in the card deck
        for(int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++)
        {
            CardSuit suit = (CardSuit)iSuit;
            
            //for each card value
            for (byte value = 1; value <= MAX_CARD_VALUE; value++)
            {
                //create the card object with the given suit and value
                Card card = new Card(value, suit);

                //add the card to deck
                _cardList.Add(card);
            }
        }
    }

    public void ShuffleCards()
    {
        //for each card in the deck
        for (int iCard = 0; iCard < _cardList.Count; iCard++)
        {
            //choose random position in the deck
            int randPos = s_randomizer.Next(iCard, _cardList.Count);
            
            //replace the current card with the card at the random position
            Card crtCard = _cardList[iCard];
            Card randCard = _cardList[randPos];
            _cardList[iCard] = randCard;
            _cardList[randPos] = crtCard;
        }
    }

    /// <summary>
    /// Extracts two random cards from the deck
    /// </summary>
    /// <param name="cardOne">first card output</param>
    /// <param name="cardTwo">second card output</param>
    /// <returns>true if the extraction was possible, false if there are no cards left</returns>
    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        //check that we have enough cards for the extraction
        if (_cardList.Count >= 2)
        {
            //extract the first card
            //generate a random position to extract the card from 
            int randPos = CardDeck.Randomizer.Next(_cardList.Count);
            
            //access the card at the random index
            cardOne = _cardList[randPos];
            
            //remove the card from the deck
            _cardList.RemoveAt(randPos);
            
            //extract the second card
            randPos = CardDeck.Randomizer.Next(_cardList.Count);
            cardTwo = _cardList[randPos];
            _cardList.RemoveAt(randPos);

            //indicate the success of the extraction
            return true;
        }
        else
        {
            //there are not enough cards, the game must be over
            cardOne = null;
            cardTwo = null;    
            return false;
        }
    }

    public void ExchangeCards(ref Card cardOne, ref Card cardTwo)
    {
        //swap the two cards using tuple deconstruction
        (cardOne, cardTwo) = (cardTwo, cardOne);
    }
}