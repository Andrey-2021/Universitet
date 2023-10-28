﻿using System.ComponentModel;
using System.Reflection;
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

	/// <summary>
	/// Флаг показывает что ещё не было никаких проверок
	/// </summary>
	//public bool IsNoChecks { get; private set; } = true;

	public void Validate(object? val, [CallerMemberName] string propertyName = null)
	{
		//IsNoChecks = false;

		if (propertyName!=null && _errors.ContainsKey(propertyName)) _errors.Remove(propertyName);

		ValidationContext context = new ValidationContext(this) { MemberName = propertyName };
		List<ValidationResult> results = new();

		if (!Validator.TryValidateProperty(val, context, results))
		{
			_errors[propertyName] = results.Select(x => x.ErrorMessage).ToList();
		}

		ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
	}

//	public void Validate()
//	{
//		Validate(this, null);
//	}


	public static bool HasErrorsOnlyInMyPublicProperties(BaseINotifyDataErrorInfo entity)
	{
		if (entity == null) return false;
		
		Type type = entity.GetType();
		PropertyInfo[] properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

		foreach (PropertyInfo property in properties)
		{
			entity.Validate( property.GetValue(entity) , property.Name);
			if (entity.HasErrors) return true;
			//Console.WriteLine("Name: " + property.Name + ", Value: " + property.GetValue(obj, null));
		}
		return false;
	}


}


public static class BaseINotifyDataErrorInfoExtension
{
	public static void CharCount(this BaseINotifyDataErrorInfo str)
	{
		
	}
}