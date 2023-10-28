using DbLibrary;
using EntitiesLibrary;
using EntitiesLibrary.DTO;

namespace ViewModels;

public class StatisticsViewModel:BaseNotifyPropertyChanged
{
	

	/// <summary>
	/// Список
	/// </summary>
	public ObservableCollection<UniversitetGroup>? Groups { get => groups; set { groups = value; OnPropertyChanged(); } }
	public ObservableCollection<UniversitetGroup>? groups;

	













	private IServiceProvider serviceProvider;
	
	/// <summary>
	/// Репозиторий для работы с БД
	/// </summary>
	protected DbRepository repository;

	public SelectedDatasDTO DTO { get=> dTO; set { dTO = value; OnPropertyChanged(); } }
	public SelectedDatasDTO dTO=new();

	public StatisticsViewModel(IServiceProvider serviceProvider)
	{

		this.serviceProvider = serviceProvider;
		repository = this.serviceProvider.GetRequiredService<DbRepository>(); //сразу создаём репозиторий для работы с БД
		LoadNecessaryDates();
	}

	private async void LoadNecessaryDates()
	{

		var groupsResponse = await repository.GetEntitiesAsync<UniversitetGroup>();
		var taskTypesResponse = await repository.GetEntitiesAsync<TaskType>();

		if (groupsResponse == null) Groups = null;
		else Groups = new ObservableCollection<UniversitetGroup>(groupsResponse);

		//if (taskTypesResponse == null) TaskTypes = null;
		//else TaskTypes = new ObservableCollection<TaskType>(taskTypesResponse);

	}

	private async void LoadDates()
	{
		var studentsResponse = await repository.GetDatesAsync(dTO);

	}
}

