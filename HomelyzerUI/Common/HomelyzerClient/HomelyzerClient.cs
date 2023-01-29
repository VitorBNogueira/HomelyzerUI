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
    private UriBuilder HomelyzerUriBuilder { get; set; }
    public Uri GetAdvertUri { get; set; }
    public string Host { get; set; }

    public HomelyzerClient()
    {
        HomelyzerUriBuilder = new UriBuilder();
        HomelyzerUriBuilder.Scheme = "https";
        HomelyzerUriBuilder.Host = "homelyzer.azurewebsites.net";
    }

    public async Task<HttpResponseMessage> GetAllAdvertsAsync()
    {
        HomelyzerUriBuilder.Path = "api/adverts";
        return await this.GetAsync(HomelyzerUriBuilder.Uri);
    }

    public async Task<HttpResponseMessage> GetAdvertAsync(int id)
    {
        HomelyzerUriBuilder.Path = $"api/adverts/{id.ToString()}";
        return await this.GetAsync(HomelyzerUriBuilder.Uri);
    }

    public async Task<HttpResponseMessage> UpdateAdvertAsync<T>(T data, int Id)
    {
        HomelyzerUriBuilder.Path = $"api/adverts/" + Id.ToString();
        var x = await this.PutAsJsonAsync<T>(HomelyzerUriBuilder.Uri, data);
        return x;
    }

    public async Task<HttpResponseMessage> UpdateAdvertAltAsync(AdvertDTO data, int Id)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HomelyzerUriBuilder.Path = $"api/adverts/" + Id.ToString();
        var x = await this.PutAsync(HomelyzerUriBuilder.Uri, requestContent);
        return x;
    }

    public async Task<HttpResponseMessage> SaveAdvertAsync<T>(T data)
    {
        HomelyzerUriBuilder.Path = $"api/adverts";
        var x = await this.PostAsJsonAsync<T>(HomelyzerUriBuilder.Uri, data);
        return x;
    }

    public async Task<HttpResponseMessage> SaveAdvertAltAsync(AdvertDTO data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        HomelyzerUriBuilder.Path = $"api/adverts";
        var x = await this.PostAsync(HomelyzerUriBuilder.Uri, requestContent);
        return x;
    }

    public async Task<HttpResponseMessage> GetAllOwnersAsync()
    {
        HomelyzerUriBuilder.Path = "api/owners";
        return await GetAsync(HomelyzerUriBuilder.Uri);
    }

    public async Task<HttpResponseMessage> ToggleAdvertAsync(bool enable, int id)
    {
        HomelyzerUriBuilder.Path = $"api/adverts/toggle/{id.ToString()}";
        var x = await this.PostAsJsonAsync<bool>(HomelyzerUriBuilder.Uri, enable);
        return x;
    }
}
