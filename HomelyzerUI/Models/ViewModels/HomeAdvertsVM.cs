using CommunityToolkit.Mvvm.ComponentModel;
using HomelyzerUI.Common.HomelyzerClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.Models.ViewModels
{
    public partial class HomeAdvertsVM : ObservableObject
    {
        [ObservableProperty]
        public List<Advert> _adverts;

        private readonly IMyHttpClient _httpClient;

        public HomeAdvertsVM(IMyHttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task GetAdverts()
        {
                var result = await _httpClient.GetAllAdverts();

                Adverts = JsonConvert.DeserializeObject<List<Advert>>(await result.Content.ReadAsStringAsync());
        }
    }
}
