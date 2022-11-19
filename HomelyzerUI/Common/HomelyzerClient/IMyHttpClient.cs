namespace HomelyzerUI.Common.HomelyzerClient
{
    public interface IMyHttpClient
    {
        string AdvertsPath { get; set; }
        Uri GetAllAdvertsUri { get; set; }
        string Host { get; set; }

        Task<HttpResponseMessage> GetAllAdverts();
    }
}