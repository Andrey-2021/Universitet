namespace UniverApp;

public partial class SubjectsWindow : Window, ISubjectsView
{
	public SubjectsWindow(SubjectsViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}
