using CommunityToolkit.Mvvm.ComponentModel;
using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.ViewModels;

namespace HomelyzerUI.Pages;

public partial class AdvertDetails : ContentPage
{
    private readonly IMyHttpClient _httpClient;
    private AdvertDetailsVM _vm;
    public AdvertDetails(AdvertDetailsVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
        _vm = vm;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        // Has to be called after it finishes navigating to the page, otherwise the passed parameter (AdvertId) won't have been loaded yet
        _vm.LoadAdvertAsync();
    }
}