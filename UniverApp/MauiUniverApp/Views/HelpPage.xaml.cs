namespace MauiUniverApp.Views;

public partial class HelpPage : ContentPage, IHelpView
{
	public HelpPage()
	{
		InitializeComponent();
	}

	public void Close()
	{

	}

	public bool? ShowDialog()
	{
		return true;
	}
}