namespace WindowsInterfaces;

public interface IViewModelWithParametr : IViewModel
{
	/// <summary>
	/// Параметр
	/// </summary>
	public object? Parametr { set; }
}

