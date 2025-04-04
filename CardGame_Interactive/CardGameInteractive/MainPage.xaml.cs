namespace CardGameInteractive;

public partial class MainPage : ContentPage
{
	//HAS-A relationship between the page and the card game
	private CardGame _cardGame;
	
    public MainPage()
    {
        InitializeComponent();
        
        _cardGame = new CardGame();
    }

    private void OnDealCards(object sender, EventArgs e)
    {
	    //ask the game to deal cards to the player and house
	    _cardGame.DealCards();
    }

    private void OnSwitchCards(object sender, EventArgs e)
    {
	    //ask teh game to switch the cards between player and house
	    _cardGame.SwitchCards();
    }

    private void OnPlayCards(object sender, EventArgs e)
    {
	    //ask the game to play a round
	    _cardGame.PlayRound();
    }
}