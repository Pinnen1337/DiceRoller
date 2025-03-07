using DiceRoller.ViewModels;

namespace DiceRoller;

public partial class HitsPage : ContentPage
{
	private HitsViewModel viewModel;
	public HitsPage()
	{
		InitializeComponent();
		viewModel = new HitsViewModel();
		BindingContext = viewModel;
	}

    private void OnHitsRollClicked(object sender, EventArgs e)
    {
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount < 0)
		{
			HitsLabel.Text = "Ange attacker!";
			return;
		}

		if (BSPicker.SelectedIndex == -1)
		{
			HitsLabel.Text = "Ange BS/WS";
			return;
		}

		int bsThreshold = int.Parse(BSPicker.SelectedItem.ToString()[0].ToString());

		viewModel.RollHits(diceCount, bsThreshold);

		if (viewModel.Hits == 1)
		{
			HitsLabel.Text = $"Du fick {viewModel.Hits} träff";
		}
		else
		{
            HitsLabel.Text = $"Du fick {viewModel.Hits} träffar";
        }
		

    }
}