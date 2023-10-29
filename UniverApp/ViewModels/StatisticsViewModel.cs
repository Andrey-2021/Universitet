using DbLibrary;
using EntitiesLibrary;
using EntitiesLibrary.DTO;
using System.ComponentModel;
using System.Xml.Linq;

namespace ViewModels;

public class StatisticsViewModel:BaseNotifyPropertyChanged
{
	/// <summary>
	/// Репозиторий для работы с БД
	/// </summary>
	protected DbRepository repository;
	private IServiceProvider serviceProvider;

	public SelectedDatasDTO? DTO { get=> dTO; set { dTO = value; OnPropertyChanged(); } }
	public SelectedDatasDTO? dTO;

	/// <summary>
	/// Список групп
	/// </summary>
	public ObservableCollection<UniversitetGroup>? Groups { get => groups; set { groups = value; OnPropertyChanged(); } }
	public ObservableCollection<UniversitetGroup>? groups;

	/// <summary>
	/// Список Типов заданий
	/// </summary>
	public ObservableCollection<TaskType>? TaskTypes { get => taskTypes; set { taskTypes = value; OnPropertyChanged(); } }
	public ObservableCollection<TaskType>? taskTypes;

	/// <summary>
	/// Список оценок
	/// </summary>
	public ObservableCollection<SubjectScore>? SubjectScores { get => subjectScores; set { subjectScores = value; OnPropertyChanged(); } }
	public ObservableCollection<SubjectScore>? subjectScores;

	public SubjectScore? SelectedSubjectScore { get => selectedSubjectScore; set { selectedSubjectScore = value; OnPropertyChanged(); } }
	public SubjectScore? selectedSubjectScore;



	/// <summary>
	/// Команда "Сбросить выбранную Группу"
	/// </summary>
	public ICommand? ClearSelectedGroupCommand { get; private set; }

	/// <summary>
	/// Команда "Сбросить выбранного студента"
	/// </summary>
	public ICommand? ClearSelectedStudentCommand { get; private set; }

	/// <summary>
	/// Команда "Сбросить выбранный предмет"
	/// </summary>
	public ICommand? ClearSelectedSubjectCommand { get; private set; }

	/// <summary>
	/// Команда "Сбросить выбранный тип зпдания"
	/// </summary>
	public ICommand? ClearSelectedTaskTypeCommand { get; private set; }


	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public StatisticsViewModel(IServiceProvider serviceProvider)
	{
		ClearSelectedGroupCommand = new RelayCommand(ClearSelectedGroup);
		ClearSelectedStudentCommand = new RelayCommand(ClearSelectedStudent);
		ClearSelectedTaskTypeCommand = new RelayCommand(ClearSelectedTaskType);
		ClearSelectedSubjectCommand = new RelayCommand(ClearSelectedSubject);

		this.serviceProvider = serviceProvider;
		repository = this.serviceProvider.GetRequiredService<DbRepository>(); //сразу создаём репозиторий для работы с БД
		DTO = new(OnSelectChangedLoadDates);
		LoadNecessaryDates();

	}

	private void ClearSelectedGroup(object? parametr)
	{
		DTO.SelectedGroup = null;
	}

	private void ClearSelectedStudent(object? parametr)
	{
		DTO.SelectedStudent = null;
	}

	private void ClearSelectedSubject(object? parametr)
	{
		DTO.SelectedSubject= null;
	}

	private void ClearSelectedTaskType(object? parametr)
	{
		DTO.SelectedTaskType = null;
	}



	/// <summary>
	/// Загрузка начальных данных
	/// </summary>
	private async void LoadNecessaryDates()
	{

		var groupsResponse = await repository.GetGroupsAsync();
		var taskTypesResponse = await repository.GetEntitiesAsync<TaskType>();

		if (groupsResponse == null) Groups = null;
		else Groups = new ObservableCollection<UniversitetGroup>(groupsResponse);

		if (taskTypesResponse == null) TaskTypes = null;
		else TaskTypes = new ObservableCollection<TaskType>(taskTypesResponse);

	}

	/// <summary>
	/// Загрузка данных для статистики приизменении выбранных фильтров
	/// </summary>
	private async void OnSelectChangedLoadDates()
	{
		var studentsResponse = await repository.GetDatesAsync(DTO);
		
		if (studentsResponse == null) SubjectScores = null;
		else SubjectScores = new(studentsResponse);

	}
}

