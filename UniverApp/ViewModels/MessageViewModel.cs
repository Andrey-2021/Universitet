namespace ViewModels;

public class MessageViewModel: IViewModelWithParametr
{
	public bool IsBusy { get; set; }
	public object? Parametr { set => OnParametrSet(value); }

	public string? Message { get; set; }

	protected void OnParametrSet(object? parametr)
	{
		Message = parametr as string;
	}

	/// <summary>
	/// Команда "Отмена/закрыть окно"
	/// </summary>
	public RelayCommand? CloseWindowCommand { get; set; }

	public MessageViewModel()
	{
		CloseWindowCommand = new RelayCommand(CloseWindow);
	}

	/// <summary>
	/// Закрыть окно. (Метод который вызывается командой CloseWindowCommand)
	/// </summary>
	/// <param name="parametr"></param>
	protected void CloseWindow(object? parametr)
	{
		var view = parametr as IView;
		if (view != null) view.Close();
	}
}
