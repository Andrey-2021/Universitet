namespace UniverApp.Views;

public partial class SubjectScoreWindow : Window, ISubjectScoreView
{
    public SubjectScoreWindow(SubjectScoresViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
	}
}
