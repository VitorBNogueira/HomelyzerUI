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

    [ObservableProperty]
    public List<OwnerDTO> _owners;

    [ObservableProperty]
    public OwnerDTO _selectedOwner;

    public List<string> Types
    {
        get
        {
            return Enum.GetNames(typeof(EAdvertType)).ToList();
        }
    }

    //public List<string> Owners
    //{
    //    get
    //    {
    //        return Enum.GetNames(typeof(EAdvertType)).ToList();
    //    }
    //}

    private readonly IMyHttpClient _httpClient;

    public NewAdvertVM(IMyHttpClient httpClient)
    {
        this._httpClient = httpClient;
        NewAd = new AdvertDTO();
        NewAd.Type = EAdvertType.Rent;

        LoadOwnersAsync();
    }

    [RelayCommand]
    public async Task SaveAdvertAsync()
    {
        try
        {
            var result = await _httpClient.GetAllAdvertsAsync();
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
        var z = x;
    }
}
