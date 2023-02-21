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

    public async Task<HttpResponseMessage> GetAllAdvertsAsync(string sortBy, EDirection direction)
    {
        var uri = BuildUri("api/adverts", query: $"sort={sortBy}&direction={(int)direction}");
        var result = await this.GetAsync(uri);
        return result;
    }

    public async Task<HttpResponseMessage> GetAdvertAsync(int id)
    {
        var uri = BuildUri($"api/adverts/{id.ToString()}");
        return await this.GetAsync(uri);
    }

    public async Task<HttpResponseMessage> UpdateAdvertAsync<T>(T data, int Id)
    {
        var uri = BuildUri($"api/adverts/{Id.ToString()}");
        var x = await this.PutAsJsonAsync<T>(uri, data);
        return x;
    }

    public async Task<HttpResponseMessage> UpdateAdvertAltAsync(AdvertDTO data, int Id)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var uri = BuildUri($"api/adverts/{Id}");
        var x = await this.PutAsync(uri, requestContent);
        return x;
    }

    public async Task<HttpResponseMessage> SaveAdvertAsync<T>(T data)
    {
        var uri = BuildUri($"api/adverts");
        var x = await this.PostAsJsonAsync<T>(uri, data);
        return x;
    }

    public async Task<HttpResponseMessage> SaveAdvertAltAsync(AdvertDTO data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        var requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var uri = BuildUri($"api/adverts");
        var x = await this.PostAsync(uri, requestContent);
        return x;
    }

    public async Task<HttpResponseMessage> GetAllOwnersAsync()
    {
        var uri = BuildUri($"api/owners");
        return await GetAsync(uri);
    }

    public async Task<HttpResponseMessage> ToggleAdvertAsync(bool enable, int id)
    {
        var uri = BuildUri($"api/adverts/toggle/{id.ToString()}");
        var x = await this.PostAsJsonAsync<bool>(uri, enable); 

        return x;
    }

    private Uri BuildUri(string path, string query = "", string scheme = "https", string host = "homelyzer.azurewebsites.net")
    {
        var uriBuilder = new UriBuilder(scheme, host);
        uriBuilder.Path = path;
        uriBuilder.Query = query;

        return uriBuilder.Uri;
    }
}
