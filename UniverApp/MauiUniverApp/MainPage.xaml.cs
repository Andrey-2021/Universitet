using ViewModels;
namespace MauiUniverApp;

public partial class MainPage : ContentPage, IMainWindowView
{
	public MainPage()
	{
		InitializeComponent();
		var vm = MyServiceProvider.GetService<MainWindowViewModel>();
		BindingContext = vm; 
	}
}