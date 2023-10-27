namespace ViewModels;

public class AttendancesViewModel : BaseAllEntitiesViewModel<Attendance, IAddAttendanceView>
{

	/// <summary>
	/// Список Груп
	/// </summary>
	public ObservableCollection<UniversitetGroup>? UniversitetGroups { get => universitetGroups; set { universitetGroups = value; OnPropertyChanged(); } }
	public ObservableCollection<UniversitetGroup>? universitetGroups;

	/// <summary>
	/// Список Дат учёбы
	/// </summary>
	public ObservableCollection<LearningDate>? LearningDates { get => learningDates; set { learningDates = value; OnPropertyChanged(); } }
	public ObservableCollection<LearningDate>? learningDates;

	/// <summary>
	/// Выбранная группа
	/// </summary>
	public UniversitetGroup? SelectedGroup
	{
		get => selectedGroup;
		set
		{
			selectedGroup = value;
			SelectAttendancesForTable();
			OnPropertyChanged();
		}
	}
	public UniversitetGroup? selectedGroup;


	/// <summary>
	/// Выбранная дата учёбы
	/// </summary>
	public LearningDate? SelectedLearningDate
	{
		get => selectedLearningDate;
		set
		{
			selectedLearningDate = value;
			SelectAttendancesForTable();
			OnPropertyChanged();
		}
	}
	public LearningDate? selectedLearningDate;


	///// <summary>
	///// Список отфтльтрованных сущностей из БД
	///// </summary>
	//public ObservableCollection<Attendance>? FilteredAttendances
	//{
	//	get => filteredAttendances;
	//	set
	//	{
	//		filteredAttendances = value;
	//		OnPropertyChanged();
	//	}
	//}
	//public ObservableCollection<Attendance>? filteredAttendances;


	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="serviceProvider"></param>
	public AttendancesViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		LoadInitDates();
	}

	private async void LoadInitDates()
	{
		IsBusy = true;
		//читаем из БД
		var responseGroups = await repository.GetEntitiesAsync<UniversitetGroup>();
		var responseLearningDates = await repository.GetEntitiesAsync<LearningDate>();

		if (responseGroups == null) UniversitetGroups = null;
		else UniversitetGroups = new ObservableCollection<UniversitetGroup>(responseGroups);

		if (responseLearningDates == null) LearningDates = null;
		else LearningDates = new ObservableCollection<LearningDate>(responseLearningDates);
		IsBusy = false;
	}

	protected override async void RefreshEntities(object? parametr)
	{
		SelectedGroup = null;
		SelectedLearningDate = null;
		await LoadNecessaryDates();
	}

	protected override async Task LoadNecessaryDates()
	{//return (x => x.BrandId == (int)PrimaryId);

		System.Linq.Expressions.Expression<Func<Attendance, bool>>? predicat = null;

		if (SelectedLearningDate != null && SelectedGroup != null)
		{
			predicat = (a => a.LearningDateId == SelectedLearningDate.Id
							&& a.Student.UniversitetGroupId == SelectedGroup.Id);
		}
		else
		if (SelectedLearningDate != null)
			predicat = (a =>  a.LearningDateId == SelectedLearningDate.Id );
		else
		if (SelectedGroup != null)
			predicat = (a => a.Student.UniversitetGroupId == SelectedGroup.Id);

		IsBusy = true;
		var response = await repository.GetEntitiesAsync<Attendance>(predicat);
		if (response == null)
			Entities = null;
		else
			Entities = new ObservableCollection<Attendance>(response
															.OrderBy(x=>x.LearningDate.Date)
															.ThenBy(x=>x.Student.UniversitetGroupId)
															.ToList());
		IsBusy = false;
	}


	//protected override void AfterLoadNecessaryDates()
	//{
	//	SelectedGroup = null;
	//	SelectedLearningDate = null;
	////	LoadInitDates();
	////	SelectAttendancesForTable();
	//}

	
	public void SelectAttendancesForTable()
	{
		LoadNecessaryDates();
		/*
		if(Entities==null)
		{
			FilteredAttendances = null;
			return;
		}

		var list = Entities.OrderBy(x=>x.LearningDate.Date).AsQueryable();

		if (SelectedGroup != null)
		{
			//list = list.Where(a => a.LearningDateId == SelectedLearningDate.Id);
		}

		if (SelectedLearningDate!=null)
		 list = list.Where(a => a.LearningDateId == SelectedLearningDate.Id);
		

		if (list == null)
			FilteredAttendances = null;
		else
			FilteredAttendances = new ObservableCollection<Attendance>(list);
		*/
	}
}
