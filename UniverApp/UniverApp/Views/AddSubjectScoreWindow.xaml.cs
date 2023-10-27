namespace UniverApp.Views;

public partial class AddSubjectScoreWindow : Window, IAddSubjectScoreView
{
	public IViewModelWithParametr ViewModel { get; set; }
	public AddSubjectScoreWindow(AddSubjectScoreViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
