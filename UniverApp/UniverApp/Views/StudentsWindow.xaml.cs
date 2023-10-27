namespace UniverApp.Views;

public partial class StudentsWindow : Window, IStudentsView
{
    public StudentsWindow(StudentsViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
	}
}
