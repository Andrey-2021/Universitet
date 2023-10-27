namespace UniverApp.Views;

public partial class AddTaskTypeWindow : Window, IAddTaskTypeView
{
	public IViewModelWithParametr ViewModel { get; set; }
	public AddTaskTypeWindow(AddTaskTypeViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
