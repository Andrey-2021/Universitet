using System.Windows;
namespace UniverApp;

public partial class HelpWindow : Window, IHelpView
{
	public HelpWindow(HelpViewModel viewModel)
	{
		InitializeComponent();
		DataContext = viewModel;
	}
}
