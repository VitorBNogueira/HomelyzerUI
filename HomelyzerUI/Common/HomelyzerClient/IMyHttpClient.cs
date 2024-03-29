﻿using HomelyzerUI.Models;

namespace HomelyzerUI.Common.HomelyzerClient
{
    public interface IMyHttpClient
    {
        Task<HttpResponseMessage> GetAllAdvertsAsync(string sortBy, EDirection direction);
        Task<HttpResponseMessage> GetAdvertAsync(int Id);
        Task<HttpResponseMessage> UpdateAdvertAsync<T>(T advert, int Id);
        Task<HttpResponseMessage> UpdateAdvertAltAsync(AdvertDTO advert, int Id);
        Task<HttpResponseMessage> SaveAdvertAsync<T>(T data);
        Task<HttpResponseMessage> SaveAdvertAltAsync(AdvertDTO advert);
        Task<HttpResponseMessage> GetAllOwnersAsync();
        Task<HttpResponseMessage> ToggleAdvertAsync(bool enable, int id);
    }
}