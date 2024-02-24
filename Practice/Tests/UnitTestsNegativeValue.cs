using System.Collections.ObjectModel;
using NUnit.Framework;
using Practice.Models;

namespace Practice.Tests
{
    [TestFixture]
    public class UnitTestsNegativeValue
    {
        [Test]
        public void TestFirstWithNegativeValues()
        {
            // Подготовка (Arrange)
            var firstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(-100, -100),
                new BindablePoint(50, -100),
                new BindablePoint(100, -50),
                new BindablePoint(-50, -50)
            };

            var secondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(-50, -50),
                new BindablePoint(100, -50),
                new BindablePoint(150, 0),
                new BindablePoint(50, 0)
            };

            // Выполнение (Act)
            string result = Service.GetComparisonResult(firstParallelogramPoints, secondParallelogramPoints);

            // Проверка (Assert)
            Assert.That(result, Is.EqualTo(Service.ComparisonResult.First));
        }

        [Test]
        public void TestSecondWithNegativeValues()
        {
            // Подготовка (Arrange)
            var firstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(-50, -50),
                new BindablePoint(100, -50),
                new BindablePoint(150, 0),
                new BindablePoint(50, 0)
            };

            var secondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(-100, -100),
                new BindablePoint(50, -100),
                new BindablePoint(100, -50),
                new BindablePoint(-50, -50)
            };

            // Выполнение (Act)
            string result = Service.GetComparisonResult(firstParallelogramPoints, secondParallelogramPoints);

            // Проверка (Assert)
            Assert.That(result, Is.EqualTo(Service.ComparisonResult.Second));
        }

        [Test]
        public void TestFirstWithNegativeValuesAndEqualAreas()
        {
            // Подготовка (Arrange)
            var firstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(-50, -50),
                new BindablePoint(100, -50),
                new BindablePoint(150, 0),
                new BindablePoint(50, 0)
            };

            var secondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(-50, -50),
                new BindablePoint(100, -50),
                new BindablePoint(150, 0),
                new BindablePoint(50, 0)
            };

            // Выполнение (Act)
            string result = Service.GetComparisonResult(firstParallelogramPoints, secondParallelogramPoints);

            // Проверка (Assert)
            Assert.That(result, Is.EqualTo(Service.ComparisonResult.Equal));
        }
    }
}