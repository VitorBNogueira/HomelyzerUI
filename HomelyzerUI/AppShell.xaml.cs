using HomelyzerUI.Pages;

namespace HomelyzerUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AdvertDetails), typeof(AdvertDetails));
		Routing.RegisterRoute(nameof(NewAdvert), typeof(NewAdvert));
	}
}
