namespace WindowsInterfaces;

/// <summary>
/// Базовый класс для всех ViewModel
/// </summary>
public interface IViewModel
{
	/// <summary>
	/// Выполняется "длинная/долгая" операция
	/// </summary>
	public bool IsBusy { get; set; }
}
