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

[QueryProperty("AdvertId", "Id")]

public partial class AdvertDetailsVM : ObservableObject
{
    [ObservableProperty]
    public Advert _advert;

    [ObservableProperty]
    public bool isRefreshing;

    [ObservableProperty]
    public string advertId;

    private readonly IMyHttpClient _httpClient;

    public AdvertDetailsVM(IMyHttpClient httpClient)
    {
        this._httpClient = httpClient;
        LoadAdvertAsync(Convert.ToInt32(AdvertId));
    }

    [RelayCommand]
    public async Task LoadAdvertAsync(int advertId)
    {
        try
        {
            var result = await _httpClient.GetAdvertAsync(advertId);

            Advert = JsonConvert.DeserializeObject<Advert>(await result.Content.ReadAsStringAsync());
        }
        finally
        {
            IsRefreshing = false;
        }
    }
}
