using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace UI.Converters
{
    /// <summary>
    /// Базовый класс конвертеров <see cref="bool"/> в другие типы
    /// </summary>
    /// <typeparam name="T">Тип итогового значения</typeparam>
    public abstract class BooleanConverter<T> : IValueConverter
    {
        protected BooleanConverter(T trueValue, T falseValue)
        {
            True = trueValue;
            False = falseValue;
        }

        public T True { get; set; }
        public T False { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is bool && (bool) value ? True : False;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is T && EqualityComparer<T>.Default.Equals((T) value, True);
        }
    }
}