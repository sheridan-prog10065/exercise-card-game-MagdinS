using System.Diagnostics;

namespace CardGameApp;

public partial class MainPage : ContentPage
{
	private readonly static ImageSource s_imageSourceCardBack;

	//define the HAS-A relationship to the CardGame
	private CardGame _cardGame;
	
    public MainPage()
    {
        InitializeComponent();
        
        //initilize the game object
        _cardGame = new CardGame();
    }

    static MainPage()
    {
	    s_imageSourceCardBack = ImageSource.FromFile("playing_card_back.jpg");
    }

    private void OnDealCards(object sender, EventArgs e)
    {
	    //ensure the cards being dealt are turned face down
	    _imgPlayerCard.Source = s_imageSourceCardBack;
	    _imgHouseCard.Source = s_imageSourceCardBack;
	    
	    //ask the game object to deal cards to player and house
	    _cardGame.DealCards();
	    
	    //inform the user what they can do next: switch or play the cards
	    _txtGameBoard.Text = "You can play the round or swap cards with the house";

	    //allow the user play by enabling the action buttons
	    _btnDealCards.IsEnabled = false;
	    _btnSwitchCards.IsEnabled = true;
	    _btnPlayCards.IsEnabled = true;
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
	    //ask the game to swap the cards of the player with the house
	    _cardGame.SwitchCards();
    }

    private void OnPlayCards(object sender, EventArgs e)
    {
	    //ask the game to play a round in the game
	    sbyte roundResult = _cardGame.PlayRound();
	    
	    //show the results of the round
	    ShowRoundResult(roundResult);
	    
	    //disable the play commands and allow the user to deal another card
	    _btnSwitchCards.IsEnabled = false;
	    _btnPlayCards.IsEnabled = false;
	    _btnDealCards.IsEnabled = true;
	    
	    //check whether the game is over
	    if (_cardGame.IsOver)
	    {
		    //card game is done. Show who won the game
		    ShowGameOver();
	    }
    }
    
    private void ShowRoundResult(sbyte roundResult)
    {
	    //update the score board 
	    _txtPlayerScore.Text = _cardGame.Score.PlayerScore.ToString();
	    _txtHouseScore.Text = _cardGame.Score.HouseScore.ToString();
	    
	    //show the cards that have been played
	    ShowCard(_imgPlayerCard, _cardGame.PlayerCard);
	    ShowCard(_imgHouseCard, _cardGame.HouseCard);
	    
	    //display who won the round, the player or the house
	    switch (roundResult)
	    {
		    case 1:
			    _txtGameBoard.Text = "Player wins the round.";
			    break;
		    
		    case -1:
			    _txtGameBoard.Text = "House wins the round";
			    break;
		    
		    case 0:
			    _txtGameBoard.Text = "The round is a tie.";
			    break;
		    
		    default:
			    Debug.Assert(false, "Uknown round result.");
			    break;
		    
	    }
    }

    private void ShowCard(Image imageControl, Card card)
    {
	    //Determine the image source for imageControl based on the card value and suit
	    char suitId = card.Suit.ToString()[0];
	    string fileName = $"{suitId}{card.Value.ToString("00")}.png";

	    //Set the image source
	    imageControl.Source = ImageSource.FromFile(fileName);
    }

    private void ShowGameOver()
    {
	    //Display who won the game
	    if (_cardGame.PlayerWins)
	    {
		    _txtGameBoard.Text = "The player won the game";
	    }
	    else if (_cardGame.HouseWins)
	    {
		    _txtGameBoard.Text = "The house won the game";
	    }
	    else
	    {
		    _txtGameBoard.Text = "The game was a draw";
	    }

	    //disallow the dealing of the cards
	    _btnDealCards.IsEnabled = false;
	    _btnPlayCards.IsEnabled = false;
	    _btnSwitchCards.IsEnabled = false;
	    
	    //TODO: ask the user if they want to play the game
    }
}