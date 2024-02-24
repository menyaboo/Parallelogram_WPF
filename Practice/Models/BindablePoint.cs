using System.Collections.Generic;

namespace Practice.Models
{
    public sealed class BindablePoint
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set
            {
                if (!EqualityComparer<double>.Default.Equals(_x, value))
                {
                    _x = value;
                }
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (!EqualityComparer<double>.Default.Equals(_y, value))
                {
                    _y = value;
                }
            }
        }

        public BindablePoint(double x, double y)
        {
            _x = x;
            _y = y;
        }
    }
}