namespace ViewModels;

public class GroupsViewModel : BaseAllEntitiesViewModel<UniversitetGroup, IAddGroupView>
{


	public Subject? selectedSubjectForDel;

	/// <summary>
	/// Выбранный предмет для удаления из таблицы Предметов (принадлежащих выбранной Группе)
	/// </summary>
	public Subject? SelectedSubjectForDel
	{
		get => selectedSubjectForDel;
		set
		{
			selectedSubjectForDel = value;
			OnPropertyChanged();
		}
	}

	/// <summary>
	/// Команда "Добавить"
	/// </summary>
	public RelayCommand? AddSubjectForGroupCommand { private set; get; }

	/// <summary>
	/// Команда "Удалить"
	/// </summary>
	public RelayCommand? DelSubjectFromGroupCommand { private set; get; }

	public GroupsViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		AddSubjectForGroupCommand = new RelayCommand(ShowAddSubjectForGroupWindow, CheckIsPossibleShowAddSubjectForGroupWindow);
		DelSubjectFromGroupCommand = new RelayCommand(DelSubjectFromGroup, CheckIsPossibleDelSubjectFromGroup);
	}

	protected virtual async void ShowAddSubjectForGroupWindow(object? parametr)
	{
		//1)запоминаем Id выбранной группы
		int selectedId = SelectedEntity!.Id;

		var view = serviceProvider.GetRequiredService<IAddAddSubjectForGroupView>();
		view.ViewModel.Parametr = SelectedEntity; //В качестве параметра передаём выбранную ГРУППУ, для котороу будем выбирать предмет
		view.ShowDialog();
		await LoadNecessaryDates();

		//2)восстановление выделения - выбранной группы
		SelectedEntity = Entities?.FirstOrDefault(x => x.Id == selectedId);
	}

	/// <summary>
	/// Проверка можно ли выполнить команду AddSubjectForGroupCommand чтобы показать окно с предметами
	/// </summary>
	/// <param name="parametr"></param>
	/// <returns></returns>
	protected virtual bool CheckIsPossibleShowAddSubjectForGroupWindow(object? parametr)
	{
		return SelectedEntity != null;
	}

	/// <summary>
	/// Удалить Предмет из Группы
	/// </summary>
	/// <param name="parametr"></param>
	protected virtual async void DelSubjectFromGroup(object? parametr)
	{
		//1)запоминаем Id выбранной группы
		int selectedId = SelectedEntity!.Id;

		var result = await repository.DelSubjectFromGroupAsync(SelectedEntity, SelectedSubjectForDel!);
		if (result != null) //если ошибка
		{
			//Message = "Ошибка";
			//return;
		}
		await LoadNecessaryDates();

		//2)восстановление выделения - выбранной группы
		SelectedEntity = Entities?.FirstOrDefault(x => x.Id == selectedId);
	}

	/// <summary>
	/// Проверка можно ли выполнить команду для удаления Предмета из Группы
	/// </summary>
	/// <param name="parametr"></param>
	/// <returns></returns>
	protected virtual bool CheckIsPossibleDelSubjectFromGroup(object? parametr)
	{
		return SelectedSubjectForDel != null;
	}

	protected override void CheckCommands()
	{
		base.CheckCommands();
		AddSubjectForGroupCommand?.RaiseCanExecuteChanged();
		DelSubjectFromGroupCommand?.RaiseCanExecuteChanged();
	}

	//protected override void ShowAddEntityWindow(object? parametr)
	//{
	//	var view = serviceProvider.GetRequiredService<IAddGroupView>();
	//	view.ShowDialog();
	//}
}
