namespace UniverApp.Views;

public partial class TasksTypesWindow : Window, ITasksTypesView
{
	public TasksTypesWindow(TasksTypesViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}
