using System.Collections.ObjectModel;
using NUnit.Framework;
using Practice.Models;

namespace Practice.Tests
{
    [TestFixture]
    public class UnitTests
    {
        
        [Test]
        public void TestFirst()
        {
            // Подготовка (Arrange)
            var firstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(200, 0),
                new BindablePoint(250, 50),
                new BindablePoint(100, 50)
            };

            var secondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(150, 0),
                new BindablePoint(200, 50),
                new BindablePoint(50, 50)
            };
            
            // Выполнение (Act)
            string result = Service.GetComparisonResult(firstParallelogramPoints, secondParallelogramPoints);

            // Проверка (Assert)
            Assert.That(result, Is.EqualTo(Service.ComparisonResult.First));
        }
        
        [Test]
        public void TestSecond()
        {
            // Подготовка (Arrange)
            var firstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(150, 0),
                new BindablePoint(200, 50),
                new BindablePoint(50, 50)
            };

            var secondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(200, 0),
                new BindablePoint(250, 50),
                new BindablePoint(100, 50)
            };

            // Выполнение (Act)
            string result = Service.GetComparisonResult(firstParallelogramPoints, secondParallelogramPoints);

            // Проверка (Assert)
            Assert.That(result, Is.EqualTo(Service.ComparisonResult.Second));
        }

        [Test]
        public void TestEqual()
        {
            // Подготовка (Arrange)
            var firstParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(150, 0),
                new BindablePoint(200, 50),
                new BindablePoint(50, 50)
            };

            var secondParallelogramPoints = new ObservableCollection<BindablePoint>
            {
                new BindablePoint(0, 0),
                new BindablePoint(150, 0),
                new BindablePoint(200, 50),
                new BindablePoint(50, 50)
            };

            // Выполнение (Act)
            string result = Service.GetComparisonResult(firstParallelogramPoints, secondParallelogramPoints);

            // Проверка (Assert)
            Assert.That(result, Is.EqualTo(Service.ComparisonResult.Equal));
        }
        
    }
}