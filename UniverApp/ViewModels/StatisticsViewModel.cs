using DbLibrary;
using EntitiesLibrary;
using EntitiesLibrary.DTO;

namespace ViewModels;

public class StatisticsViewModel:BaseNotifyPropertyChanged
{
	/// <summary>
	/// Список групп
	/// </summary>
	public ObservableCollection<UniversitetGroup>? Groups { get => groups; set { groups = value; OnPropertyChanged(); } }
	public ObservableCollection<UniversitetGroup>? groups;
	
	/// <summary>
	/// Репозиторий для работы с БД
	/// </summary>
	protected DbRepository repository;
	private IServiceProvider serviceProvider;

	public SelectedDatasDTO DTO { get=> dTO; set { dTO = value; OnPropertyChanged(); } }
	public SelectedDatasDTO dTO;



	/// <summary>
	/// Список оценок
	/// </summary>
	public ObservableCollection<SubjectScore>? SubjectScores { get => subjectScores; set { subjectScores = value; OnPropertyChanged(); } }
	public ObservableCollection<SubjectScore>? subjectScores;

	public SubjectScore SelectedSubjectScore { get => selectedSubjectScore; set { selectedSubjectScore = value; OnPropertyChanged(); } }
	public SubjectScore selectedSubjectScore;






	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public StatisticsViewModel(IServiceProvider serviceProvider)
	{

		this.serviceProvider = serviceProvider;
		repository = this.serviceProvider.GetRequiredService<DbRepository>(); //сразу создаём репозиторий для работы с БД
		dTO = new(LoadDates);
		LoadNecessaryDates();

	}

	/// <summary>
	/// Загрузка начальных данных
	/// </summary>
	private async void LoadNecessaryDates()
	{

		var groupsResponse = await repository.GetGroupsAsync();
		//var taskTypesResponse = await repository.GetEntitiesAsync<TaskType>();

		if (groupsResponse == null) Groups = null;
		else Groups = new ObservableCollection<UniversitetGroup>(groupsResponse);

		//if (taskTypesResponse == null) TaskTypes = null;
		//else TaskTypes = new ObservableCollection<TaskType>(taskTypesResponse);

	}

	/// <summary>
	/// Загрузка данных для статистики
	/// </summary>
	private async void LoadDates()
	{
		var studentsResponse = await repository.GetDatesAsync(dTO);
		
		if (studentsResponse == null) SubjectScores = null;
		else SubjectScores = new(studentsResponse);

	}
}

