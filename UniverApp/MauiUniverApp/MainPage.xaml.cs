using ViewModels;
namespace MauiUniverApp;

public partial class MainPage : ContentPage, IMainWindowView
{
	int count = 0;

	
	public MainPage()
	{
		

		InitializeComponent();

		//BindingContext = viewModel; //new MainViewModel();

		 var vm=MyServiceProvider.GetService<MainWindowViewModel>();


		BindingContext = vm; // new MainWindowViewModel(serviceProvider);
	}

	public void Close()
	{
		throw new NotImplementedException();
	}

	public void Show()
	{
		throw new NotImplementedException();
	}

	public bool? ShowDialog()
	{
		throw new NotImplementedException();
	}


	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}