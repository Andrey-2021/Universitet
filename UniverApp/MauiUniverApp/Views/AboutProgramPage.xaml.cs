namespace MauiUniverApp.Views;

public partial class AboutProgramPage : ContentPage, IAboutProgrammView
{
	public AboutProgramPage(AboutProgrammViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

	public void Close()
	{
	}

	public bool? ShowDialog()
	{
		App.Current.MainPage = new NavigationPage(this);
		return true;
	}

	//public async Task ShowMAUIPage()
	//{
	//	//await Navigation.PushAsync(this, true);
	//	App.Current.MainPage = new NavigationPage(this);
	//}

}