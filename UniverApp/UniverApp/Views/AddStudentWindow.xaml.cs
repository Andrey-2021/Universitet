namespace UniverApp.Views;

public partial class AddStudentWindow : Window, IAddStudentView
{
	public IViewModelWithParametr ViewModel { get; set; }

	public AddStudentWindow(AddStudentViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
