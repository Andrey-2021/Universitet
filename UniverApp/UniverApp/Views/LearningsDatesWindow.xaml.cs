namespace UniverApp.Views;

public partial class LearningsDatesWindow : Window, ILearningsDatesView
{
    public LearningsDatesWindow(LearningsDatesViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
	}
}
