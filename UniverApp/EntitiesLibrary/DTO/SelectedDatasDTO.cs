namespace EntitiesLibrary.DTO;

/// <summary>
/// Класс, который будем использовать для хранения исходных данных, которые используются для фильтрации данных статистики
/// </summary>
public class SelectedDatasDTO : BaseNotifyPropertyChanged , IDisposable
{
	/// <summary>
	/// Начальная дата периода
	/// </summary>
	public DateTime StartDate { get => startDate; set { startDate = value; OnPropertyChanged(); } }
	public DateTime startDate;

	/// <summary>
	/// Конечная дата периода
	/// </summary>
	public DateTime EndDate { get => endDate; set { endDate = value; OnPropertyChanged(); } }
	public DateTime endDate;

	/// <summary>
	/// Выбранная группа
	/// </summary>
	public UniversitetGroup? SelectedGroup
	{
		get => selectedGroup;
		set
		{
			selectedGroup = value;
			OnPropertyChanged();
		}
	}
	public UniversitetGroup? selectedGroup;


	/// <summary>
	/// Выбранный студент
	/// </summary>
	public Student? SelectedStudent
	{
		get => selectedStudent;
		set
		{
			selectedStudent = value;
			OnPropertyChanged();
		}
	}
	public Student? selectedStudent;

	/// <summary>
	/// Метод который будем вызывать когда изменится какое-нибудь значение
	/// </summary>
	private Action action;

	public SelectedDatasDTO(Action action)
	{
		StartDate = EndDate = DateTime.Now;
		this.action = action;
		PropertyChanged += OnChanges;
	}
	
	protected void OnChanges(object? sender, PropertyChangedEventArgs e)
	{
		action.Invoke();
	}

	public void Dispose()
	{
		PropertyChanged -= OnChanges;
	}
}
