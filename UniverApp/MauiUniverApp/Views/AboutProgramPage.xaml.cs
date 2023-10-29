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
		
		 Navigation.PushModalAsync(this);
		

		return true;
	}


}