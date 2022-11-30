using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.ViewModels;

[QueryProperty("AdvertId", "AdvertId")]

public partial class AdvertDetailsVM : ObservableObject
{
    [ObservableProperty]
    public Advert _advert;

    [ObservableProperty]
    public bool isRefreshing;

    [ObservableProperty]
    public int advertId;

    private readonly IMyHttpClient _httpClient;

    public AdvertDetailsVM(IMyHttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    [RelayCommand]
    public async Task LoadAdvertAsync()
    {
        try
        {
            var result = await _httpClient.GetAdvertAsync(AdvertId);

            Advert = JsonConvert.DeserializeObject<Advert>(await result.Content.ReadAsStringAsync());
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}
