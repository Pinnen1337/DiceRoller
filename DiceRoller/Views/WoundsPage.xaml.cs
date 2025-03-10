using DiceRoller.ViewModels;

namespace DiceRoller;

public partial class WoundsPage : ContentPage
{
	private WoundsViewModel viewModel;
	public WoundsPage()
	{
		InitializeComponent();
		viewModel = new WoundsViewModel();
		BindingContext = viewModel;
	}

    private void OnWoundRollClicked(object sender, EventArgs e)
    {
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount < 0)
		{
			WoundsLabel.Text = "Ange träffar!";
			return;
		}

		if (StrengthPicker.SelectedIndex == -1 || ToughnessPicker.SelectedIndex == -1)
		{
			WoundsLabel.Text = "Ange strength & toughness";
			return;
		}

		int strength = int.Parse(StrengthPicker.SelectedItem.ToString()[0].ToString());
		int toughness = int.Parse(ToughnessPicker.SelectedItem.ToString()[0].ToString());

		viewModel.RollWounds(diceCount, strength, toughness);

		WoundsLabel.Text = $"Du gjorde {viewModel.Wounds} sår";
    }
}