namespace UniverApp.Views;

public partial class AddSubjectWindow : Window, IAddSubjectView
{
	public IViewModelWithParametr ViewModel { get; set; }

	public AddSubjectWindow(AddSubjectViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
