using System;
using System.Windows.Data;
namespace UniverApp;

/// <summary>
/// Конвертер int <-> string
/// </summary>
//  [ValueConversion(typeof(decimal), typeof(string))]
public class MyIntConverter : IValueConverter
{
    /// <summary>
    /// Конвертируем число в строку
    /// </summary>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        // Возвращаем строку
        return ((int)value).ToString();
    }


    /// <summary>
    /// Конвертируем строку в число
    /// </summary>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var str = value as string;
        if (string.IsNullOrEmpty(str)) return 0;

        string newStr = "";
        for (int i = 0; i < str.Length; i++) //перебираем символы в строке
        {
            if (Char.IsDigit(str[i])) newStr += str[i]; //если это цифра, тогда оставляем её
        }

        //если число больше int.MaxValue
        if (decimal.TryParse(newStr, out decimal num) && num > int.MaxValue)
            newStr=newStr.Remove(newStr.Length-1);  //удаляем последний символ

        int result;
        if (int.TryParse(newStr, System.Globalization.NumberStyles.Any,culture, out result))
            return result;

        return 0; 
    }
}

