namespace CardGameInteractive;

/// <summary>
/// Defines the card game that implements the game logic and holds the card deck
/// </summary>
public class CardGame
{
    #region Fields
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

    #endregion
    
    #region Constructors
    /// <summary>
    /// The constructor of the card game class
    /// </summary>
    public CardGame()
    {
        _cardDeck = new CardDeck();
        _cardDeck.ShuffleCards();
        _score = new Score();
        _playerCard = null;
        _houseCard = null;
    }
    #endregion

    #region Properties

    public Score Score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
        }
    }

    public Card PlayerCard
    {
        get
        {
            return _playerCard;
        }
    }

    public Card HouseCard
    {
        get
        {
            return _houseCard;
        }
    }

    public bool IsOver
    {
        get
        {
            return _cardDeck.CardCount < 2;
        }
    }

    public bool PlayerWins
    {
        get
        {
            return this.IsOver && (_score.PlayerScore > _score.HouseScore);
        }
    }

    public bool HouseWins
    {
        get
        {
            return this.IsOver && (_score.HouseScore > _score.PlayerScore);
        }
    }

    #endregion
    
    #region Methods
    /// <summary>
    /// Plays the game
    /// </summary>
    public void Play()
    {
        //TODO: Implement Play
    }
    
    /// <summary>
    /// Play a round of the game
    /// </summary>
    /// <returns>
    ///     +1: the user won the round
    ///     0: there was tie
    ///     -1: the house won the round
    /// </returns>
    public sbyte PlayRound()
    {
        //determine the card ranks for the player and house cards
        byte cardRank = DetermineCardRank(_playerCard);
        byte houseRank = DetermineCardRank(_houseCard);
        
        //check which card has the higer rank to determine the winner
        if (cardRank > houseRank)
        {
            //the player won the round
            return 1;
        }
        else if (houseRank > cardRank)
        {
            //the house won the round
            return -1;
        }
        else
        {
            //there was a tie
            return 0;
        }
    }

    /// <summary>
    /// Deals the cards to the player and house when a new round starts
    /// </summary>
    public void DealCards()
    {
    }

    public void SwitchCards()
    {
    }

    /// <summary>
    /// Determine the rank of the card as used in the game. The Ace is the higest hard
    /// </summary>
    /// <returns>the rank of the card</returns>
    private byte DetermineCardRank(Card card)
    {
        return (card.Value == 1) ? (byte)14 : card.Value;;
    }

    private void ShowRoundResult()
    {
    }

    private void ShowGameOver()
    {
    }

    #endregion

}