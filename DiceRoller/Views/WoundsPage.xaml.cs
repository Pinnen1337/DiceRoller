using DiceRoller.Models;
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

    protected override void OnAppearing()
    {
        base.OnAppearing();

        WoundsLabel.Text = $"Du har {RollSave.Instance.Hits} träffar att göra sår på!";

        DiceInput.Text = RollSave.Instance.Hits.ToString();
    }

    private void OnWoundRollClicked(object sender, EventArgs e)
    {
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount <= 0)
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

        viewModel.RollWounds(RollSave.Instance.Hits, strength, toughness);

        RollSave.Instance.Wounds = viewModel.Wounds;
        RollSave.Instance.WoundsCounter = viewModel.WoundsCounter;

        WoundsLabel.Text = viewModel.Wounds == 1 ? $"Du gjorde {viewModel.Wounds} sår!" : $"Du gjorde {viewModel.Wounds} sår!";
    }
}