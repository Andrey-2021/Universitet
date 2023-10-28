using System;
using System.Windows.Data;

namespace UniverApp;

// Из статьи
// WPF - how to hide menu item if command's CanExecute is false?
// https://9to5answer.com/wpf-how-to-hide-menu-item-if-command-39-s-canexecute-is-false

/// <summary>
/// Конвертер для того чтобы  конвертировать bool <--> MenuItem.Visibility.
/// Чтобы была возможность спрятать admin-меню
/// </summary>

public class BooleanToCollapsedVisibilityConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		//reverse conversion (false=>Visible, true=>collapsed) on any given parameter
		bool input = (null == parameter) ? (bool)value : !((bool)value);
		return (input) ? Visibility.Visible : Visibility.Collapsed;
	}

	public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
