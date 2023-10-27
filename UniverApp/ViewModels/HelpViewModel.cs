namespace ViewModels;

/// <summary>
/// View Model для окна "Помощь"
/// </summary>
public class HelpViewModel : BaseNotifyPropertyChanged
{
	public Help? help;
	public Help? Help 
	{
		get=>help;
		set 
		{
			help = value;
			OnPropertyChanged();
		} 
	}

	/// <summary>
	/// Конструктор
	/// </summary>
	public HelpViewModel()
	{
		Task.Run(() => LoadHelp());
	}

	private async Task LoadHelp()
	{
		Help = await	HelpRepositiry.GetHelpAsync();
	}

	
}
