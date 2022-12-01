using HomelyzerUI.Common.HomelyzerClient;
using HomelyzerUI.Pages;
using HomelyzerUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui;

namespace HomelyzerUI;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        // pages
        builder.Services.AddScoped<MainPage>();
        builder.Services.AddTransient<AdvertDetails>();
        // view models
        builder.Services.AddTransient<HomeAdvertsVM>();
        builder.Services.AddTransient<AdvertDetailsVM>();
        // http client
        builder.Services.AddScoped<IMyHttpClient, HomelyzerClient>();

        return builder.Build();
    }
}