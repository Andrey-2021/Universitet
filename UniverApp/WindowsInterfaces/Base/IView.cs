namespace WindowsInterfaces;

/// <summary>
/// Базовый интерфейс для всех Окон (Window)
/// </summary>
public interface IView
{
	/// <summary>
	/// Показать окно
	/// </summary>
	/// <returns></returns>
	public bool? ShowDialog()
	{ 
		return false; 
	}
	
	/// <summary>
	/// Закрыть окно
	/// </summary>
	public void Close()
	{
	}
}
