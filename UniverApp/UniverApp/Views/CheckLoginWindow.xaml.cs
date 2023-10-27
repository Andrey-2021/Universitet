namespace UniverApp.Views;

public partial class CheckLoginWindow : Window, ICheckLoginView
{
	public IViewModelWithParametr ViewModel { get; set; }
	public CheckLoginWindow(CheckLoginViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
