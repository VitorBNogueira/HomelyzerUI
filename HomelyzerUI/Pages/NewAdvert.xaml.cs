using HomelyzerUI.ViewModels;

namespace HomelyzerUI.Pages;

public partial class NewAdvert : ContentPage
{
	public NewAdvert(NewAdvertVM vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}