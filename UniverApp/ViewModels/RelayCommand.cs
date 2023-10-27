using System.Windows.Input;
namespace ViewModels;

public class RelayCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;
	//{
	//	add { CommandManager.RequerySuggested += value; }
	//	remove { CommandManager.RequerySuggested -= value; }
	//}

	private readonly Action<object?> execute;
	private readonly Func<object?, bool>? canExecute;

	public RelayCommand(Action<object?> execute, Func<object?, bool> canExecute)
	{
		this.execute = execute;
		this.canExecute = canExecute;
	}

	public RelayCommand(Action<object?> execute)
	{
		this.execute = execute;
		this.canExecute = this.AlwaysCanExecute; ;
	}

	public bool CanExecute(object? parameter)
	{
		return this.canExecute == null || this.canExecute(parameter);
	}

	public void Execute(object? parameter)
	{
		this.execute(parameter);
	}

	// Метод CanExecute по умолчанию
	private bool AlwaysCanExecute(object? param)
	{
		return true;
	}

	public void RaiseCanExecuteChanged()
	{
		if (CanExecuteChanged != null)
		{
			CanExecuteChanged(this, EventArgs.Empty);
		}
	}
}
