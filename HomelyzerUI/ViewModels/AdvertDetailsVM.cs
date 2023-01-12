﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HomelyzerUI.ViewModels;

[QueryProperty(nameof(AdvertId), nameof(AdvertId))]

public partial class AdvertDetailsVM : ObservableObject
{
    [ObservableProperty]
    public AdvertDTO _advert;

    [ObservableProperty]
    public bool isRefreshing;

    [ObservableProperty]
    public int advertId;

    [ObservableProperty]
    public bool imageIsVisible = false;
    [ObservableProperty]
    public bool viewIsVisible = true;
    [ObservableProperty]
    public bool dateTimePickersAreVisible = false;

    [ObservableProperty]
    public string expandedPicture;

    // Meeting Date
    [ObservableProperty]
    public DateTime _adDate;
    // Meeting Time of Day
    [ObservableProperty]
    public TimeSpan _adTime;

    // Displays meeting time if there is one 
    [ObservableProperty]
    public string _adDateTime;

    private readonly IMyHttpClient _httpClient;

    public AdvertDetailsVM(IMyHttpClient httpClient)
    {
        this._httpClient = httpClient;
        IsRefreshing = true;
    }

    [RelayCommand]
    public async Task LoadAdvertAsync()
    {
        try
        {
            var result = await _httpClient.GetAdvertAsync(AdvertId);

            Advert = JsonConvert.DeserializeObject<AdvertDTO>(await result.Content.ReadAsStringAsync());

            UpdateDisplayMeetingDate();
        }
        finally
        {
            IsRefreshing = false;
        }
    }

    private void UpdateDisplayMeetingDate()
    {
        AdDateTime = Advert.MeetingTime != null ? Advert.MeetingTime?.ToString("HH:mm, dddd, dd MMMM yyyy") : "Not yet scheduled";
    }

    [RelayCommand]
    public void ExpandPicture(string url)
    {
        ExpandedPicture= url;
        ViewIsVisible= false;
        ImageIsVisible= true;
    }

    [RelayCommand]
    public void SetDateTime()
    {
        ViewIsVisible = false;
        DateTimePickersAreVisible = true;
    }

    [RelayCommand]
    public void CloseDateTime(string save)
    {
        ViewIsVisible = true;
        DateTimePickersAreVisible = false;

        if (save == "true")
        {
            Advert.MeetingTime = AdDate.Add(AdTime);
            UpdateDisplayMeetingDate();
        }
    }

    [RelayCommand]
    public void BackToView()
    {
        ViewIsVisible = true;
        ImageIsVisible = false;
        ExpandedPicture = "";
    }

    [RelayCommand]
    public void OpenMaps()
    {
        var enc = HttpUtility.UrlEncode(Advert.Address);
        Launcher.OpenAsync($"https://www.google.com/maps/search/?api=1&query={enc}");
    }

    [RelayCommand]
    public void GoToOriginalAd()
    {
        if (Uri.IsWellFormedUriString(Advert.Url, UriKind.Absolute))
            Launcher.OpenAsync(Advert.Url);
    }

    [RelayCommand]
    public void PhoneCall()
    {
        if (PhoneDialer.Default.IsSupported)
            PhoneDialer.Default.Open(Advert.PhoneContact);
    }

    [RelayCommand]
    public async Task SaveChangesAsync()
    {
        if (Advert != null)
        {
            //Advert.PersonalNotes = Advert.PersonalNotes ?? string.Empty;
            //Advert.Url = Advert.Url ?? string.Empty;
            //Advert.Area = Advert.Area ?? string.Empty;

            _ = await _httpClient.UpdateAdvertAsync(Advert, Advert.AdvertId);
        }
    }
}
