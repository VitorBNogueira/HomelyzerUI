using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.ViewModels;

namespace HomelyzerUI;

public partial class MainPage : ContentPage
{
	private readonly IMyHttpClient _httpClient;

	public MainPage(IMyHttpClient httpClient, HomeAdvertsVM vm)
	{
        _httpClient = httpClient;

		BindingContext = vm;

        InitializeComponent();
	}

}

