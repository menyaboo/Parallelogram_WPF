using System;
using System.Collections.ObjectModel;

namespace Practice.Models
{
    public sealed class Parallelogram
    {
        private ObservableCollection<BindablePoint> _points;

        public ObservableCollection<BindablePoint> Points
        {
            get => _points;
            set
            {
                if (!Equals(_points, value))
                {
                    _points = value;
                }
            }
        }

        private double Area
        {
            get
            {
                if (Points == null || Points.Count < 4)
                {
                    return 0;
                }

                // Вычисляем векторное произведение для каждой пары векторов
                double crossProduct1 = (Points[1].X - Points[0].X) * (Points[2].Y - Points[1].Y) - (Points[1].Y - Points[0].Y) * (Points[2].X - Points[1].X);
                double crossProduct2 = (Points[2].X - Points[1].X) * (Points[3].Y - Points[2].Y) - (Points[2].Y - Points[1].Y) * (Points[3].X - Points[2].X);

                // Площадь параллелограмма - модуль среднего векторного произведения
                return Math.Abs((crossProduct1 + crossProduct2) / 2.0);
            }
        }

        public Parallelogram()
        {
            Points = new ObservableCollection<BindablePoint>();
        }
        
        public int CompareAreaTo(Parallelogram other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            double areaDifference = this.Area - other.Area;
            if (areaDifference > 0)
            {
                return 1; // Площадь текущего параллелограмма больше
            }
            else if (areaDifference < 0)
            {
                return -1; // Площадь другого параллелограмма больше
            }
            else
            {
                return 0; // Площади параллелограммов равны
            }
        }
    }
}