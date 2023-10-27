namespace UniverApp;

public partial class GroupsWindow : Window, IGroupsView
{
	public GroupsWindow(GroupsViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
		
		//this.Cursor = Cursors.Wait;
	}
}
