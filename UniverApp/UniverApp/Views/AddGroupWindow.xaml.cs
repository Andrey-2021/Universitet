namespace UniverApp;

public partial class AddGroupWindow : Window, IAddGroupView
{
	public IViewModelWithParametr ViewModel { get; set; }

	public AddGroupWindow(AddGroupViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
