using System;

namespace TP8
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius) : base(radius * 2, radius * 2)
        {
            this.radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                base.Width = value * 2;
                base.Height = value * 2;
            }
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override void SetDimensions(double width, double height)
        {
            // Un cercle ne peut pas avoir width != height
            double avgDimension = (width + height) / 2;
            radius = avgDimension / 2;
            base.Width = avgDimension;
            base.Height = avgDimension;
        }
    }
}