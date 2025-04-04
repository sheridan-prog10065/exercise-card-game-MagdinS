namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
	//define the HAS-A relationship to the CardGame
	private CardGame _cardGame;
	
    public MainPage()
    {
        InitializeComponent();
        
        //initilize the game object
        _cardGame = new CardGame();
    }

    private void OnDealCards(object sender, EventArgs e)
    {
	    //ask the game object to deal cards to player and house
	    _cardGame.DealCards();
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