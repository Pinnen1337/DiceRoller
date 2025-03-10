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

	private void OnSavesRollClicked(object sender, EventArgs e)
	{
		if (!int.TryParse(DiceInput.Text, out int diceCount) || diceCount < 0)
		{
			SavesLabel.Text = "Ange s�r!";
			return;
		}

		if (SavesPicker.SelectedIndex == -1 || APPicker.SelectedIndex == -1)
		{
			SavesLabel.Text = "Ange Save & AP";
			return;
		}

		int saveThreshold = int.Parse(SavesPicker.SelectedItem.ToString().TrimEnd('+'));
		int apValue = int.Parse(APPicker.SelectedItem.ToString());

		viewModel.RollSaves(diceCount, saveThreshold, apValue);

		SavesLabel.Text = $"Du r�ddade {viewModel.Saves} s�r";
		
    }
}