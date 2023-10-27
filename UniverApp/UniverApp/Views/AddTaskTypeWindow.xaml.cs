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

	private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
	{

	}
}
