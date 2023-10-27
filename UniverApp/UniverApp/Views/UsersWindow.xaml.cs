namespace UniverApp.Views;

public partial class UsersWindow : Window, IUsersView
{
    public UsersWindow(UsersViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
	}
}
