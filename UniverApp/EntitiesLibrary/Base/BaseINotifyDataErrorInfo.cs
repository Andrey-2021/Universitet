using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace EntitiesLibrary.Base;

/// <summary>
/// Базовый класс для реализации интерфейса INotifyDataErrorInfo
/// </summary>
public class BaseINotifyDataErrorInfo: BaseNotifyPropertyChanged, INotifyDataErrorInfo
{
	private IDictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

	public bool HasErrors => _errors.Any();

	public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

	public System.Collections.IEnumerable GetErrors(string propertyName)
	{
		return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
	}


	protected void Validate(object? val, [CallerMemberName] string propertyName = null)
	{
		if (_errors.ContainsKey(propertyName)) _errors.Remove(propertyName);

		ValidationContext context = new ValidationContext(this) { MemberName = propertyName };
		List<ValidationResult> results = new();

		if (!Validator.TryValidateProperty(val, context, results))
		{
			_errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
		}

		ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
	}

}
