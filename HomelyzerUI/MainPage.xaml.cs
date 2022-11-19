using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Models.ViewModels;

namespace HomelyzerUI;

public partial class MainPage : ContentPage
{
	private readonly IMyHttpClient _httpClient;
	int count = 0;

	public MainPage(IMyHttpClient httpClient)
	{
		InitializeComponent();
        _httpClient = httpClient;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

