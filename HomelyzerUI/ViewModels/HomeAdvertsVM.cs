using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
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
using CommunityToolkit.Maui.Core;
using HomelyzerUI.Models.Containers;
using HomelyzerUI.Common;

namespace HomelyzerUI.ViewModels;

public partial class HomeAdvertsVM : ObservableObject
{
    [ObservableProperty]
    public List<AdvertDTO> _adverts;

    [ObservableProperty]
    public bool isRefreshing;

    public int NameFontSize { get; set; }

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
            IsRefreshing = true;
            var result = await _httpClient.GetAllAdvertsAsync("MeetingTime", EDirection.Asc);

            Adverts = JsonConvert.DeserializeObject<AdvertsJSONContainerDTO>(await result.Content.ReadAsStringAsync()).Adverts;
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
    }

    [RelayCommand]
    public async Task GetNewAdvertPageAsync()
    {
        await Shell.Current.GoToAsync(nameof(NewAdvert));
    }

    [RelayCommand]
    public void PhoneCall(string number)
    {
        if (!string.IsNullOrWhiteSpace(number) && PhoneDialer.Default.IsSupported)
            PhoneDialer.Default.Open(number);
        else
            Toast.Make("Invalid number", ToastDuration.Short).Show();
    }

    [RelayCommand]
    public async void DisableAd(int id)
    {
        var result = await _httpClient.ToggleAdvertAsync(false, id);

        if (result.IsSuccessStatusCode)
        {
            LoadAdvertsAsync();
            Toast.Make("Advert Removed!", ToastDuration.Short).Show();
        }
        else
        {
            Toast.Make("Couldn't remove Advert", ToastDuration.Short).Show();
        }
    }
}