using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Practice
{
    public partial class MainWindow
    {
        // Поле для хранения ViewPoints
        private readonly ViewPoints _viewPoints;

        // Конструктор
        public MainWindow()
        {
            InitializeComponent();
            
            // Инициализация ViewPoints и передача DataContext
            _viewPoints = new ViewPoints();
            DataContext = _viewPoints;
        }

        // Обработчик события изменения текста в TextBox
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            ItemsControl itemsControl = FindAncestor<ItemsControl>(textBox);
            int index = itemsControl.Items.IndexOf(textBox.DataContext);
            
            if (double.TryParse(textBox.Text, out double value))
            {
                // Используем конвертер для преобразования текста обратно в координаты
                StringToPointConverter converter = new StringToPointConverter();
                object[] coordinates = converter.ConvertBack(textBox.Text, null, null, null);

                if (coordinates.Length == 2 && coordinates[0] is double x && coordinates[1] is double y)
                {
                    // Обновление точки параллелограмма
                    _viewPoints.UpdateParallelogramPoint(itemsControl.Name, index, x, y);
                }
            }

            ChangeViewData();
            LabelStatus.Content = GetStatus(index, itemsControl);
        }

        // Прохождение по дочерним элементам контейнера чтобы исключить Border в стилистике XAML
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }

                current = VisualTreeHelper.GetParent(current);
            } while (current != null);

            return null;
        }

        // Debug 
        private string GetStatus(int index, ItemsControl itemsControl)
        {
            return $"FirstParallelogramPointChanged: ({_viewPoints.FirstParallelogramPoints[index].X}," +
                   $" {_viewPoints.FirstParallelogramPoints[index].Y})," +
                   $"SecondParallelogramPointChanged: ({_viewPoints.SecondParallelogramPoints[index].X}," +
                   $" {_viewPoints.SecondParallelogramPoints[index].Y})";
        }

        // Обновление данных класса ViewPoints
        private void ChangeViewData()
        {
            _viewPoints.UpdateArea();

            PointsToPointCollectionConverter pointConverter = new PointsToPointCollectionConverter();
            FirstCanvas.Points =
                (PointCollection)pointConverter.Convert(_viewPoints.FirstParallelogramPoints, null, null, null);
            SecondCanvas.Points =
                (PointCollection)pointConverter.Convert(_viewPoints.SecondParallelogramPoints, null, null, null);

            LabelArea.Content = _viewPoints.Area;
        }
    }
}