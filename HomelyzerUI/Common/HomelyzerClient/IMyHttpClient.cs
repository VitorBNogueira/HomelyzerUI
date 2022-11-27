namespace HomelyzerUI.Common.HomelyzerClient
{
    public interface IMyHttpClient
    {
        string Host { get; set; }

        Task<HttpResponseMessage> GetAllAdvertsAsync();
        Task<HttpResponseMessage> GetAdvertAsync(int Id);
    }
}