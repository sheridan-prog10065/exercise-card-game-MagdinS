namespace CardGameInteractive;

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
	    _cardGame.PlayRound();
    }
}