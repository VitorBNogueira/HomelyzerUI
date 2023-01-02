using HomelyzerUI.Models;

namespace HomelyzerUI.Common.HomelyzerClient
{
    public interface IMyHttpClient
    {
        string Host { get; set; }

        Task<HttpResponseMessage> GetAllAdvertsAsync();
        Task<HttpResponseMessage> GetAdvertAsync(int Id);
        Task<HttpResponseMessage> UpdateAdvertAsync<T>(T advert);
        Task<HttpResponseMessage> UpdateAdvertAltAsync(AdvertDTO advert);
        Task<HttpResponseMessage> SaveAdvertAsync<T>(T data);
        Task<HttpResponseMessage> GetAllOwnersAsync();


    }
}