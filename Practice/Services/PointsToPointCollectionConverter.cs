using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using Practice.Models;

namespace Practice
{
    // Конвертер для преобразования точек в PointCollection
    public class PointsToPointCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<BindablePoint> points)
            {
                return new PointCollection(points.Select(p => new System.Windows.Point(p.X, p.Y)));
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}