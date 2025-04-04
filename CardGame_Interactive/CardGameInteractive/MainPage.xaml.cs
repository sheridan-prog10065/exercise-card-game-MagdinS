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
 }