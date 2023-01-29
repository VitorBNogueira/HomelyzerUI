using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Models;
using HomelyzerUI.Models.Enums;
using HomelyzerUI.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.ViewModels;

public partial class NewAdvertVM : ObservableObject
{
    [ObservableProperty]
    public AdvertDTO _newAd;

    // Saves all the pictures in a single string to be split and inserted in the list on saving
    [ObservableProperty]
    public string _allPictures;

    [ObservableProperty]
    public List<OwnerDTO> _owners;

    [ObservableProperty]
    public OwnerDTO? _selectedOwner;

    [ObservableProperty]
    public DateTime _adDate;

    [ObservableProperty]
    public TimeSpan _adTime;

    // List of AdvertTypes in the EAdvertType enum, to display in the picker
    public List<string> Types
    {
        get
        {
            return Enum.GetNames(typeof(EAdvertType)).ToList();
        }
    }

    private readonly IMyHttpClient _httpClient;

    public NewAdvertVM(IMyHttpClient httpClient)
    {
        this._httpClient = httpClient;
        NewAd = new AdvertDTO();
        NewAd.Type = EAdvertType.Rent;

        // If date is older than current day, it will save as empty
        AdDate = DateTime.Now.AddDays(-1);

        LoadOwnersAsync();
    }

    [RelayCommand]
    public async Task SaveAdvertAsync()
    {
        NewAd.EmailContact = SelectedOwner?.EmailContact ?? "";
        NewAd.PhoneContact = SelectedOwner?.PhoneContact ?? "";
        NewAd.OwnerName = SelectedOwner?.Name ?? "";
        NewAd.Pictures = AllPictures?.Trim().Split(' ').ToList();
        NewAd.MeetingTime = AdDate < DateTime.Today ? null : AdDate.Date.Add(AdTime);

        try
        {
            var result = await _httpClient.SaveAdvertAsync(NewAd);

            if (result.IsSuccessStatusCode)
                Toast.Make("Advert Added!", ToastDuration.Short).Show();
            else
                Toast.Make("Couldn't add Advert", ToastDuration.Short).Show();
        }
        catch
        {
            Toast.Make("Something went wrong", ToastDuration.Short).Show();
        }
        finally
        {
        }
    }

    [RelayCommand]
    public async Task LoadOwnersAsync()
    {
        try
        {
            var result = await _httpClient.GetAllOwnersAsync();

            Owners = JsonConvert.DeserializeObject<List<OwnerDTO>>(await result.Content.ReadAsStringAsync());
        }
        finally
        {
        }
    }

    [RelayCommand]
    public async Task PeekValues()
    {
        var x = NewAd;
        var q = SelectedOwner;
        var w = AllPictures;
        var z = x;
    }
}
