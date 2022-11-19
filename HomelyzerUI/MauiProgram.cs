using HomelyzerUI.Common.HomelyzerClient;
using Microsoft.Extensions.DependencyInjection;

namespace HomelyzerUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddScoped<MainPage>();
		builder.Services.AddScoped<IMyHttpClient, HomelyzerClient>();

		return builder.Build();
	}
}
