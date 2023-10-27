namespace UniverApp.Views;

public partial class AttendancesWindow : Window, IAttendancesView
{
    public AttendancesWindow(AttendancesViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
	}
}
