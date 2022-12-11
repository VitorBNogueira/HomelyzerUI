using HomelyzerUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.Common.HomelyzerClient;

internal class HomelyzerClient : HttpClient, IMyHttpClient
{
    private UriBuilder AdvertsUriBuilder { get; set; }
    public string Host { get; set; }
    public Uri GetAdvertUri { get; set; }

    public HomelyzerClient()
    {
        Host = "homelyzer.azurewebsites.net";

        AdvertsUriBuilder = new UriBuilder();
        AdvertsUriBuilder.Scheme = "https";
        AdvertsUriBuilder.Host = Host;
    }

    public async Task<HttpResponseMessage> GetAllAdvertsAsync()
    {
        AdvertsUriBuilder.Path = "adverts";
        return await this.GetAsync(AdvertsUriBuilder.Uri);
    }

    public async Task<HttpResponseMessage> GetAdvertAsync(int id)
    {
        AdvertsUriBuilder.Path = $"adverts/{id.ToString()}";
        return await this.GetAsync(AdvertsUriBuilder.Uri);
    }

    public async Task<HttpResponseMessage> UpdateAdvertAsync<T>(T data)
    {
        AdvertsUriBuilder.Path = $"adverts/advert";
        var x = await this.PutAsJsonAsync<T>(AdvertsUriBuilder.Uri, data);
        return x;
    }

    public async Task<HttpResponseMessage> UpdateAdvertAltAsync(AdvertDTO data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
        AdvertsUriBuilder.Path = $"adverts/advert/";
        var x = await this.PutAsync(AdvertsUriBuilder.Uri, requestContent);
        return x;
    }

    public async Task<HttpResponseMessage> SaveAdvertAsync<T>(T data)
    {
        AdvertsUriBuilder.Path = $"adverts/advert";
        var x = await this.PostAsJsonAsync<T>(AdvertsUriBuilder.Uri, data);
        return x;
    }
}
