using System.Diagnostics;
using CardGameLib;

namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
	private static readonly ImageSource s_imageSource;

	//HAS-A relationship between the page and the card game
	private CardGame _cardGame;
	
    public MainPage()
    {
        InitializeComponent();

        _cardGame = new CardGame();
        _txtPlayerScore.Text = "0";
        _txtHouseScore.Text = "0";
    }

    static MainPage()
    {
	    s_imageSource = ImageSource.FromFile("playing_card_back.jpg");
    }

    private void OnDealCards(object sender, EventArgs e)
    {
	    //before dealing the cards make sure the cards are face down
	    _imgPlayerCard.Source = s_imageSource;
	    _imgHouseCard.Source = s_imageSource;
	    
	    //ask the game to deal cards to the player and house
	    _cardGame.DealCards();
	    
	    //inform the user they can play the next round
	    _txtGameBoard.Text = "Play the next round. You can swap cards with the house if you want";
	    
	    //enable the next commands
	    _btnDealCards.IsEnabled = false;
	    _btnSwitchCards.IsEnabled = true;
	    _btnPlayCards.IsEnabled = true;
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
	    //ask teh game to switch the cards between player and house
	    _cardGame.SwitchCards();
    }

    private void OnPlayCards(object sender, EventArgs e)
    {
	    //ask the game to play a round
	    sbyte roundResult = _cardGame.PlayRound();
	    
	    //show the result of the round
	    ShowRoundResult(roundResult);

	    //disable the play round commands to for the user to deal new cards
	    _btnDealCards.IsEnabled = true;
	    _btnSwitchCards.IsEnabled = false;
	    _btnPlayCards.IsEnabled = false;
	    
	    //check if the game is over
	    if (_cardGame.IsOver)
	    {
		    ShowGameOver();
	    }
    }

    private void ShowRoundResult(sbyte roundResult)
    {
	    //update the score board with the new score
	    _txtPlayerScore.Text = _cardGame.Score.PlayerScore.ToString();
	    _txtHouseScore.Text = _cardGame.Score.HouseScore.ToString();
	    
	    //show the cards that have been played
	    ShowCard(_imgPlayerCard, _cardGame.PlayerCard);
	    ShowCard(_imgHouseCard, _cardGame.HouseCard);
	    
	    //display who won the round on the game board
	    switch (roundResult)
	    {
		    case 1:
			    _txtGameBoard.Text = "Player wins the round.";
			    break;
		    
		    case -1:
			    _txtGameBoard.Text = "House wins the round.";
			    break;
		    
		    case 0:
			    _txtGameBoard.Text = "Round is a draw";
			    break;
		    
		    default:
			    Debug.Assert(false, "Unknown round result.");
			    break;
	    }
    }

    private void ShowCard(Image imageControl, Card card)
    {
	    //determine the name of the image file based on the card suit and value
	    char suitId = card.Suit.ToString()[0];
	    string fileName = $"{suitId}{card.Value.ToString("00")}.png";
	    
	    //set the image source of the control
	    imageControl.Source = ImageSource.FromFile(fileName);
    }
    
    private void ShowGameOver()
    {
	    //display who won the game on the game board
	    if ((_cardGame).PlayerWins)
	    {
		    _txtGameBoard.Text = "Player wins!";
	    }
	    else if (_cardGame.HouseWins)
	    {
		    _txtGameBoard.Text = "House wins!";
	    }
	    else
	    {
		    _txtGameBoard.Text = "The game is a draw!";
	    }

	    //disallow the dealing of the cards
	    _btnDealCards.IsEnabled = false;

	    //TODO: ask the user if they want to play again
	    //and make it so
    }
}