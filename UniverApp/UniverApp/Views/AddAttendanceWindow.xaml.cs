namespace UniverApp.Views;

public partial class AddAttendanceWindow : Window, IAddAttendanceView
{
	public IViewModelWithParametr ViewModel { get; set; }

	public AddAttendanceWindow(AddAttendanceViewModel viewModel)
	{
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
