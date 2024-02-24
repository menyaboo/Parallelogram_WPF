using System.Collections.ObjectModel;
using Practice.Models;

namespace Practice.Tests
{
    public static class Service
    {
        public static string GetComparisonResult(ObservableCollection<BindablePoint> firstParallelogramPoints,
            ObservableCollection<BindablePoint> secondParallelogramPoints)
        {
            Parallelogram firstParallelogram = new Parallelogram { Points = firstParallelogramPoints };
            Parallelogram secondParallelogram = new Parallelogram { Points = secondParallelogramPoints };

            int comparisonResult = firstParallelogram.CompareAreaTo(secondParallelogram);
            string result = comparisonResult > 0 ? "Площадь первого параллелограмма больше." :
                comparisonResult < 0 ? "Площадь второго параллелограмма больше." :
                "Площади параллелограммов равны.";

            return result;
        }

        public static class ComparisonResult
        {
            public static readonly string First = "Площадь первого параллелограмма больше.";
            public static readonly string Second = "Площадь второго параллелограмма больше.";
            public static readonly string Equal = "Площади параллелограммов равны.";
        }
    }
}