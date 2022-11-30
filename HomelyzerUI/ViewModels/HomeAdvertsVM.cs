using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Models;
using HomelyzerUI.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.ViewModels;

public partial class HomeAdvertsVM : ObservableObject
{
    [ObservableProperty]
    public List<Advert> _adverts;

    [ObservableProperty]
    public bool isRefreshing;

    private readonly IMyHttpClient _httpClient;

    public HomeAdvertsVM(IMyHttpClient httpClient)
    {
        this._httpClient = httpClient;
        LoadAdvertsAsync();
    }

    [RelayCommand]
    public async Task LoadAdvertsAsync()
    {
        try
        {
            var result = await _httpClient.GetAllAdvertsAsync();

            Adverts = JsonConvert.DeserializeObject<List<Advert>>(await result.Content.ReadAsStringAsync());
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    public async Task GetAdvertDetailsPageAsync(int advertId)
    {
        await Shell.Current.GoToAsync($"{nameof(AdvertDetails)}?AdvertId={advertId}");
        //await Navigation.PushAsync(new AdvertDetails(_httpClient, advertId));
    }
}
