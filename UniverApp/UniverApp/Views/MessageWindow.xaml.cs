namespace UniverApp.Views;

public partial class MessageWindow : Window, IMessageWindowView
{
	public IViewModelWithParametr ViewModel { get; set; }
	public MessageWindow(MessageViewModel viewModel)
    {
        InitializeComponent();
		DataContext = viewModel;
		ViewModel = viewModel;
	}
}
