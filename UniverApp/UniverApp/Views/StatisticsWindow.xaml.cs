namespace UniverApp.Views;

public partial class StatisticsWindow : Window, IStatisticsView
{
    public StatisticsWindow(StatisticsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

	}
}
