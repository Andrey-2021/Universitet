namespace UniverApp.Views;

public partial class AddLearningDateWindow : Window, IAddLearningDateView
{
	public IViewModelWithParametr ViewModel { get; set; }
	public AddLearningDateWindow(AddLearningDateViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
