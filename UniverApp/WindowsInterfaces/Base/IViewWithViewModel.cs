namespace WindowsInterfaces;

/// <summary>
/// Интерфейс для окон у которых есть свойство ViewModel этого окна
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IViewWithViewModel : IView
{
	public IViewModelWithParametr ViewModel { get; set; }
}
