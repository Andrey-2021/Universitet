namespace ViewModels;

public class AddStudentViewModel : BaseAddEntityViewModel<Student> //, INotifyPropertyChanged
{
	/// <summary>
	/// Список Групп из БД
	/// </summary>
	public ObservableCollection<UniversitetGroup>? Entities
	{
		get => entities;
		set
		{
			entities = value;
			OnPropertyChanged();
		}
	}
	public ObservableCollection<UniversitetGroup>? entities;


	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddStudentViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		Task.Run(() => LoadNecessaryDates());
	}

	/// <summary>
	/// Загружаем список Групп из БД
	/// </summary>
	/// <returns></returns>
	protected virtual async Task LoadNecessaryDates()
	{
		IsBusy = true;
		var response = await repository.GetEntitiesAsync<UniversitetGroup>();
		if (response == null)
			Entities = null;
		else
			Entities = new ObservableCollection<UniversitetGroup>(response);
		IsBusy = false;
	}


	//public event PropertyChangedEventHandler? PropertyChanged;
	//public void OnPropertyChanged([CallerMemberName] string prop = "")
	//{
	//	if (PropertyChanged != null)
	//		PropertyChanged(this, new PropertyChangedEventArgs(prop));
	//}
}
