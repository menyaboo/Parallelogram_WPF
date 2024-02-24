using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Practice.Models;

namespace Practice
{
    // Класс для преобразования точек в BindablePoint
    public sealed class ViewPoints : INotifyPropertyChanged
    {
        // Поля
        private ObservableCollection<BindablePoint> _firstParallelogramPoints;
        private ObservableCollection<BindablePoint> _secondParallelogramPoints;
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Свойства
        public string Area { get; set; }
        public ObservableCollection<BindablePoint> FirstParallelogramPoints
        {
            get => _firstParallelogramPoints;
            private set
            {
                if (_firstParallelogramPoints != value)
                {
                    _firstParallelogramPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<BindablePoint> SecondParallelogramPoints
        {
            get => _secondParallelogramPoints;
            private set
            {
                if (_secondParallelogramPoints != value)
                {
                    _secondParallelogramPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        // Дефолтный конструктор
        public ViewPoints()
        {
            FirstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(150, 0),
                new BindablePoint(200, 50),
                new BindablePoint(50, 50)
            };

            SecondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(150, 0),
                new BindablePoint(200, 50),
                new BindablePoint(50, 50)
            };

            UpdateArea();
        }

        // Метод для обновления свойств
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Метод для обновления точек
        public void UpdateParallelogramPoint(string parallelogramTag, int pointIndex, double newX, double newY)
        {
            if (parallelogramTag == "FirstParallelogram")
            {
                _firstParallelogramPoints[pointIndex].X = newX;
                _firstParallelogramPoints[pointIndex].Y = newY;
            }

            if (parallelogramTag == "SecondParallelogram")
            {
                _secondParallelogramPoints[pointIndex].X = newX;
                _secondParallelogramPoints[pointIndex].Y = newY;
            }
        }

        // Метод для обновления площади
        public void UpdateArea()
        {
            // Создаем экземпляры параллелограммов на основе текущих точек
            Parallelogram firstParallelogram = new Parallelogram { Points = FirstParallelogramPoints };
            Parallelogram secondParallelogram = new Parallelogram { Points = SecondParallelogramPoints };

            // Сравниваем площади параллелограммов
            int comparisonResult = firstParallelogram.CompareAreaTo(secondParallelogram);
            Area = comparisonResult > 0 ? "Площадь первого параллелограмма больше." :
                comparisonResult < 0 ? "Площадь второго параллелограмма больше." :
                "Площади параллелограммов равны.";

            // Уведомляем об изменении площади
            OnPropertyChanged(nameof(Area));
        }
    }
}