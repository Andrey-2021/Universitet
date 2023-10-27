namespace ViewModels;

public class AddSubjectScoreViewModel : BaseAddEntityViewModel<SubjectScore>
{
	/// <summary>
	/// Список Студентов
	/// </summary>
	public ObservableCollection<Student>? Students { get => students; set { students = value; OnPropertyChanged(); } }
	public ObservableCollection<Student>? students;

	/// <summary>
	/// Выбранный студент
	/// </summary>
	public Student? SelectedStudent { get => selectedStudent; set { selectedStudent = value; OnPropertyChanged(); } }
	public Student? selectedStudent;


	/// <summary>
	/// Список изучаемых предметов
	/// </summary>
	public ObservableCollection<Subject>? Subjects { get => subjects; set { subjects = value; OnPropertyChanged(); } }
	public ObservableCollection<Subject>? subjects;

	/// <summary>
	/// Выбранный предмет
	/// </summary>
	public Subject? SelectedSubject { get => selectedSubject; set { selectedSubject = value; OnPropertyChanged(); } }
	public Subject? selectedSubject;



	/// <summary>
	/// Список дат учёбы
	/// </summary>
	public ObservableCollection<LearningDate>? LearningDates { get => learningDates; set { learningDates = value; OnPropertyChanged(); } }
	public ObservableCollection<LearningDate>? learningDates;

	/// <summary>
	/// Выбранная дата учёбы
	/// </summary>
	public LearningDate? SelectedLearningDate { get => selectedLearningDate; set { selectedLearningDate = value; OnPropertyChanged(); } }
	public LearningDate? selectedLearningDate;


	/// <summary>
	/// Список Типов заданий
	/// </summary>
	public ObservableCollection<TaskType>? TaskTypes { get => taskTypes; set { taskTypes = value; OnPropertyChanged(); } }
	public ObservableCollection<TaskType>? taskTypes;

	/// <summary>
	/// Выбранный тип задания
	/// </summary>
	public TaskType? SelectedTaskType { get => selectedTaskType; set { selectedTaskType = value; OnPropertyChanged(); } }
	public TaskType? selectedTaskType;


	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AddSubjectScoreViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		LoadNecessaryDates();
	}

	private async void LoadNecessaryDates()
	{
		IsBusy = true;

		var studentsResponse = await repository.GetEntitiesAsync<Student>();
		var subjectsResponse = await repository.GetEntitiesAsync<Subject>();
		var learningdatesResponse = await repository.GetEntitiesAsync<LearningDate>();
		var taskTypesResponse = await repository.GetEntitiesAsync<TaskType>();


		if (studentsResponse == null) Subjects = null;
		else Students = new ObservableCollection<Student>(studentsResponse);

		if (subjectsResponse == null) Subjects = null;
		else Subjects= new ObservableCollection<Subject>(subjectsResponse);

		if (learningdatesResponse == null) LearningDates = null;
		else LearningDates = new ObservableCollection<LearningDate>(learningdatesResponse);

		if (taskTypesResponse == null) TaskTypes = null;
		else TaskTypes = new ObservableCollection<TaskType>(taskTypesResponse);

		IsBusy = false;
	}
}
