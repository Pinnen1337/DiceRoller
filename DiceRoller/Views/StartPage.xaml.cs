using DiceRoller.ViewModels;

namespace DiceRoller;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		LoadJoke();
	}

	private async void LoadJoke()
	{
		Models.Joke joke = await JokeViewModel.GetJokeAsync();
		if (joke != null)
		{
			JokeLabel.Text = joke.joke;
		}
	}

    private async void OnStartClicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
    }
}