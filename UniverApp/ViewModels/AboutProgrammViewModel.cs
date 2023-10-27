namespace ViewModels;

/// <summary>
/// View Model для окна "О программе"
/// </summary>
public class AboutProgrammViewModel: BaseNotifyPropertyChanged
{
	public AboutProgramm? aboutProgramm;
	public AboutProgramm? AboutProgramm
	{
		get => aboutProgramm;
		set
		{
			aboutProgramm = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Конструктор
	/// </summary>
	public AboutProgrammViewModel()
	{
		Task.Run(() => LoadAboutProgramm());
	}

	private async Task LoadAboutProgramm()
	{
		AboutProgramm = await HelpRepositiry.GetAboutProgrammAsync();
	}
}
