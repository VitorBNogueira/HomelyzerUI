using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomelyzerUI.Common.HomelyzerClient;

internal class HomelyzerClient : HttpClient, IMyHttpClient
{
    public string Host { get; set; }
    public string AdvertsPath { get; set; }
    public Uri GetAllAdvertsUri { get; set; }

    public HomelyzerClient()
    {
        Host = "homelyzer.azurewebsites.net";
        AdvertsPath = "adverts";

        UriBuilder uriBuilder = new UriBuilder();
        uriBuilder.Scheme = "http";
        uriBuilder.Host = Host;
        uriBuilder.Path = AdvertsPath;

        GetAllAdvertsUri = uriBuilder.Uri;
    }

    public async Task<HttpResponseMessage> GetAllAdvertsAsync()
    {
        return await this.GetAsync(GetAllAdvertsUri);
    }
}
