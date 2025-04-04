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
 }