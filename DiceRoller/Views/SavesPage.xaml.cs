using DiceRoller.Models;
using DiceRoller.ViewModels;
namespace DiceRoller;

public partial class SavesPage : ContentPage
{
	private SavesViewModel viewModel;
	public SavesPage()
	{
		InitializeComponent();
        viewModel = new SavesViewModel();
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SavesLabel.Text = $"Du har {RollSave.Instance.Wounds} sår att rädda!";

        DiceInput.Text = RollSave.Instance.Wounds.ToString();
    }

    private void OnSavesRollClicked(object sender, EventArgs e)
	{
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount < 0)
		{
			SavesLabel.Text = "Ange sår!";
			return;
		}

		if (SavesPicker.SelectedIndex == -1 || APPicker.SelectedIndex == -1)
		{
			SavesLabel.Text = "Ange Save & AP";
			return;
		}

		int saveThreshold = int.Parse(SavesPicker.SelectedItem.ToString().TrimEnd('+'));
		int apValue = int.Parse(APPicker.SelectedItem.ToString());

        viewModel.RollSaves(RollSave.Instance.Wounds, saveThreshold, apValue);

        RollSave.Instance.Saves = viewModel.Saves;
        RollSave.Instance.SavesCounter = viewModel.SavesCounter;

        SavesLabel.Text = viewModel.Saves == 1 ? $"Du lyckades rädda {viewModel.Saves} skada!" : $"Du lyckades rädda {viewModel.Saves} skador!";
    }
}