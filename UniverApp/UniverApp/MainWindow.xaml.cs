namespace UniverApp;

public partial class MainWindow : Window, IMainWindowView
{
	public MainWindow(MainWindowViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}
