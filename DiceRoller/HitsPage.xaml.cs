namespace DiceRoller;

public partial class HitsPage : ContentPage
{
	Random random = new Random();
	public HitsPage()
	{
		InitializeComponent();
	}

    private void OnRollClicked(object sender, EventArgs e)
    {
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount < 0)
		{
			ResultLabel.Text = "Ange antal attacker!";
			return;
		}

		if (BSPicker.SelectedIndex == -1)
		{
			ResultLabel.Text = "Ange BS!";
			return;
		}

		int bsThreshold = int.Parse(BSPicker.SelectedItem.ToString()[0].ToString());

		int hits = 0;
		for (int i = 0; i < diceCount; i++)
		{
			int roll = random.Next(1, 7);
			if (roll >= bsThreshold)
			{
				hits++;
			}
		}

		ResultLabel.Text = $"Du fick {hits} träffar!";
		Preferences.Set("HitsCount", hits);
    }
}