using System;
using System.Collections.Generic;
using System.Linq;
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
        AdvertsUriBuilder.Scheme = "http";
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
}
