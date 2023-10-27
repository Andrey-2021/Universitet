namespace UniverApp.Views;

public partial class AddUserWindow : Window, IAddUserView
{
	public IViewModelWithParametr ViewModel { get; set; }

	public AddUserWindow(AddUserViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
