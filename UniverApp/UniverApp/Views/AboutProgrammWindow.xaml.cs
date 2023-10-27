using System.Windows;
namespace UniverApp;

public partial class AboutProgrammWindow : Window, IAboutProgrammView
{
	public AboutProgrammWindow(AboutProgrammViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}
