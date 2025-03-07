namespace DiceRoller;

public partial class WoundsPage : ContentPage
{
	public WoundsPage()
	{
		InitializeComponent();

		int hits = Preferences.Get("HitsCount", 0);
		
	}

    private void OnWoundRollClicked(object sender, EventArgs e)
    {

    }
}