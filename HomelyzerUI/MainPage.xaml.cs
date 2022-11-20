using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.ViewModels;

namespace HomelyzerUI;

public partial class MainPage : ContentPage
{
	private readonly IMyHttpClient _httpClient;
	int count = 0;

	public MainPage(IMyHttpClient httpClient)
	{
        _httpClient = httpClient;

		BindingContext = new HomeAdvertsVM(_httpClient);

        InitializeComponent();
	}

}

