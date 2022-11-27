using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.ViewModels;

namespace HomelyzerUI.Pages;

public partial class AdvertDetails : ContentPage
{
    private readonly IMyHttpClient _httpClient;

    public AdvertDetails(IMyHttpClient httpClient, AdvertDetailsVM vm)
    {
        _httpClient = httpClient;

        BindingContext = vm;

        InitializeComponent();
    }
}