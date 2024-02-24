using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Practice
{
    // Конвертер для преобразования текста в координаты
    public class StringToPointConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 2 && values[0] is double x && values[1] is double y)
            {
                return $"{x:F1} {y:F1}";
            }
            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if (value is string pointString)
            {
                string[] parts = pointString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2 &&
                    double.TryParse(parts[0], NumberStyles.Number, CultureInfo.InvariantCulture, out double x) &&
                    double.TryParse(parts[1], NumberStyles.Number, CultureInfo.InvariantCulture, out double y))
                {
                    return new object[] { x, y };
                }
            }
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}