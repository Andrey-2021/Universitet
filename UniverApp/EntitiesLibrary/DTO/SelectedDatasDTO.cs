﻿namespace EntitiesLibrary.DTO;

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
	/// Выбранный предмет
	/// </summary>
	public Subject? SelectedSubject
	{
		get => selectedSubject;
		set
		{
			selectedSubject = value;
			OnPropertyChanged();
		}
	}
	public Subject? selectedSubject;




	/// <summary>
	/// Выбранный тип задания
	/// </summary>
	public TaskType? SelectedTaskType { get => selectedTaskType; set { selectedTaskType = value; OnPropertyChanged(); } }
	public TaskType? selectedTaskType;




	/// <summary>
	/// Метод который будем вызывать когда изменится какое-нибудь значение
	/// </summary>
	private Action action;

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="action"></param>
	public SelectedDatasDTO(Action action)
	{
		StartDate = new DateTime(DateTime.Now.Year, 1, 1);
		EndDate = DateTime.Now;
		this.action = action;
		PropertyChanged += OnPropertyChanged;
	}
	
	protected void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		action.Invoke();
	}

	public void Dispose()
	{
		PropertyChanged -= OnPropertyChanged;
	}
}
