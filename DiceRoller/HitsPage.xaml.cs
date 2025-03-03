namespace DiceRoller;

public partial class HitsPage : ContentPage
{
	Random random = new Random();
	public HitsPage()
	{
		InitializeComponent();
	}

    private void OnHitsRollClicked(object sender, EventArgs e)
    {
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount < 0)
		{
			HitsLabel.Text = "Ange antal attacker!";
			return;
		}

		if (BSPicker.SelectedIndex == -1)
		{
			HitsLabel.Text = "Ange BS!";
			return;
		}

		int bsThreshold = int.Parse(BSPicker.SelectedItem.ToString()[0].ToString());

		int hits = 0;
		int[] hitDiceCounter = new int[6];
		for (int i = 0; i < diceCount; i++)
		{
			int roll = random.Next(1, 7);
			hitDiceCounter[roll - 1]++;
			if (roll >= bsThreshold)
			{
				hits++;
			}
		}

		HitsCount1.Text = hitDiceCounter[0].ToString();
		HitsCount2.Text = hitDiceCounter[1].ToString();
		HitsCount3.Text = hitDiceCounter[2].ToString();
		HitsCount4.Text = hitDiceCounter[3].ToString();
		HitsCount5.Text = hitDiceCounter[4].ToString();
		HitsCount6.Text = hitDiceCounter[5].ToString();

		if (hits == 1)
		{
			HitsLabel.Text = $"Du fick {hits} träff!";
		}
		else
		{
			HitsLabel.Text = $"Du fick {hits} träffar!";
		}

		Preferences.Set("HitsCount", hits);
    }
}