using WindowsInterfaces;
namespace UniverApp.Views;

public partial class AddSubjectForGroupWindow : Window, IAddAddSubjectForGroupView
{
	public IViewModelWithParametr ViewModel { get; set; }

	public AddSubjectForGroupWindow(AddSubjectForGroupViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
