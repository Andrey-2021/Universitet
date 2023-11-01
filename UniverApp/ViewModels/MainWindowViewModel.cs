namespace ViewModels;

public class MainWindowViewModel
{

	/// <summary>
	/// Команда "показать статистику"
	/// </summary>
	public ICommand? ShowStatisticCommand { get; private set; }

	/// <summary>
	/// Команда "показать оценки"
	/// </summary>
	public ICommand? ShowAllSubjectScoreCommand { get; private set; }

	/// <summary>
	/// Команда "показать всех Дата учёбы"
	/// </summary>
	public ICommand? ShowAllLearninsgDatesCommand { get; private set; }

	/// <summary>
	/// Команда "показать всех Посещаемость"
	/// </summary>
	public ICommand? ShowAllAttendancesCommand { get; private set; }

	/// <summary>
	/// Команда "показать всех студентов"
	/// </summary>
	public ICommand? ShowAllStudentsCommand { get; private set; }

	/// <summary>
	/// Команда "показать все группы"
	/// </summary>
	public ICommand? ShowAllGroupsCommand { get; private set; }
	
	/// <summary>
	/// Команда "Показать все изучаемые предметы"
	/// </summary>
	public ICommand? ShowAllSubjectsCommand { get; private set; }

	/// <summary>
	/// Команда "Показать все типы опросов"
	/// </summary>
	public ICommand? ShowAllTaskTypesCommand { get; private set; }

	/// <summary>
	/// Команда "Показать помощь"
	/// </summary>
	public ICommand? ShowHelpCommand { get; private set; }
	
	/// <summary>
	/// Команда "Показать информацию о программе"
	/// </summary>
	public ICommand? ShowAboutProgrammCommand { get; private set; }

	/// <summary>
	/// Команда "Создать новую БД"
	/// </summary>
	public ICommand? CreateDbCommand { get; private set; }

	/// <summary>
	/// Команда "Пользователи"
	/// </summary>
	public ICommand? ShowAllUsersCommand { get; private set; }

	private IServiceProvider container;

	/// <summary>
	/// Флаг что это администратор
	/// </summary>
	public bool IsAdmin { get; set; }

	public DateTime StartDateTime { get; set; }=DateTime.Now;


	public MainWindowViewModel(IServiceProvider serviceProvider)
	{
		this.container = serviceProvider;
		var loginUserService = serviceProvider.GetService<LiginUserService>();
		
		//todo исправить
		if(loginUserService !=null && loginUserService.RegisteredUser!=null)
			IsAdmin = loginUserService!.RegisteredUser?.Role == EntitiesLibrary.Enums.RoleEnum.admin;

		//настройка команд
		CreateDbCommand = new RelayCommand(CreateNewDb);
		ShowAllUsersCommand = new RelayCommand(ShowAllUsers);

		ShowAboutProgrammCommand = new RelayCommand(ShowAboutProgramm);
		ShowHelpCommand = new RelayCommand(ShowHelp);

		ShowAllGroupsCommand = new RelayCommand(ShowAllGroups);
		ShowAllSubjectsCommand = new RelayCommand(ShowAllSubjects);
		ShowAllTaskTypesCommand = new RelayCommand(ShowAllTypesTasks);
		ShowAllStudentsCommand = new RelayCommand(ShowAllStudents);

		ShowAllLearninsgDatesCommand = new RelayCommand(ShowAllLearninsgDates);
		ShowAllAttendancesCommand = new RelayCommand(ShowAllAttendances);
		ShowAllSubjectScoreCommand = new RelayCommand(ShowAllSubjectScore);
		ShowStatisticCommand = new RelayCommand(ShowStatistic);
		
	}

	private void ShowStatistic(object? parametr)
	{
		var view = container.GetRequiredService<IStatisticsView>();
		view.ShowDialog();
	}

	private void ShowAllSubjectScore(object? parametr)
	{
		var view = container.GetRequiredService<ISubjectScoreView>();
		view.ShowDialog();
	}

	private void ShowAllLearninsgDates(object? parametr)
	{
		var view = container.GetRequiredService<ILearningsDatesView>();
		view.ShowDialog();
	}

	private void ShowAllAttendances(object? parametr)
	{
		var view = container.GetRequiredService<IAttendancesView>();
		view.ShowDialog();
	}

	/// <summary>
	/// Создать новую БД
	/// </summary>
	/// <param name="parametr"></param>
	private async void CreateNewDb(object? parametr)
	{
		var repository = container.GetRequiredService<DbRepository>();
		//var canConnect= await repository.CanConnectAsync();
		
		//if (canConnect!=null)
		//{ //БД недоступна

		//	var messageView = container.GetRequiredService<IMessageWindowView>();
		//	messageView.ViewModel.Parametr = "Ошибка БД недоступна!. Попробуйте выполнить операцию позже или обратитесь к администратору";
		//	messageView.ShowDialog();
		//	return;
		//}

		var result= await repository.CreateNewDbAsync();

		var view = container.GetRequiredService<IMessageWindowView>();
		if (result.operationResult == false) //если ошибка
			view.ViewModel.Parametr = "Ошибка при создании новой БД. Попробуйте выполнить операцию позже или обратитесь к администратору";
		else
			view.ViewModel.Parametr = "БД создана";
		view.ShowDialog();
	}

	private void ShowAllUsers(object? parametr)
	{
		var view = container.GetRequiredService<IUsersView>();
		view.ShowDialog();
	}

	private void ShowAllGroups(object? parametr)
	{
		var view = container.GetRequiredService<IGroupsView>();
		view.ShowDialog();
	}

	private void ShowAllSubjects(object? parametr)
	{
		var view = container.GetRequiredService<ISubjectsView>();
		view.ShowDialog();
	}

	private void ShowAllTypesTasks(object? parametr)
	{
		var view = container.GetRequiredService<ITasksTypesView>();
		view.ShowDialog();
	}

	private void ShowAllStudents(object? parametr)
	{
		var view = container.GetRequiredService<IStudentsView>();
		view.ShowDialog();
	}

	private void ShowHelp(object? parametr)
	{
		var view = container.GetRequiredService<IHelpView>();
		view.ShowDialog();
	}

	private async void ShowAboutProgramm(object? parametr)
	{
		var view = container.GetRequiredService<IAboutProgrammView>();
		view.ShowDialog();
		//await view.ShowMAUIPage();
	}
}
