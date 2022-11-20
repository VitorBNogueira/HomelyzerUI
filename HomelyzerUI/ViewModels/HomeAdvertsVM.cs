using CommunityToolkit.Mvvm.ComponentModel;
using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.ViewModels;

public partial class HomeAdvertsVM : ObservableObject
{
    [ObservableProperty]
    public List<Advert> _adverts;

    [ObservableProperty]
    public List<string> test;

    [ObservableProperty]
    public string test2;

    private readonly IMyHttpClient _httpClient;

    public HomeAdvertsVM(IMyHttpClient httpClient)
    {
        Test2 = "cenas";

        Test = new List<string>
        {
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
            "Lorem ipsum dolor sit amet, consectetur",
        };

        this._httpClient = httpClient;
        LoadAdverts();
    }

    public async Task LoadAdverts()
    {
        var result = await _httpClient.GetAllAdverts();

        Adverts = JsonConvert.DeserializeObject<List<Advert>>(await result.Content.ReadAsStringAsync());

        
    }
}
