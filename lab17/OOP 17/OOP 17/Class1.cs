using System;

namespace OOP_17
{
    public abstract class Triangle
    {
        protected double side1;
        protected double side2;
        protected double angle;

        public Triangle(double side1, double side2, double angle)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.angle = angle;
        }

        public virtual double Area()
        {
            return 0.5 * side1 * side2 * Math.Sin(angle);
        }

        public virtual double Perimeter()
        {
            double side3 = Math.Sqrt(side1 * side1 + side2 * side2 - 2 * side1 * side2 * Math.Cos(angle));
            return side1 + side2 + side3;
        }
    }

    // Прямокутний трикутник
    public class RightTriangle : Triangle
    {
        public RightTriangle(double side1, double side2) : base(side1, side2, Math.PI / 2)
        {
        }

        public override double Area()
        {
            return 0.5 * side1 * side2;
        }

        public override double Perimeter()
        {
            double side3 = Math.Sqrt(side1 * side1 + side2 * side2);
            return side1 + side2 + side3;
        }
    }

    // Рівнобедрений трикутник
    public class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double baseSide, double equalSide) : base(baseSide, equalSide, Math.Asin((baseSide / 2) / equalSide))
        {
        }

        public override double Area()
        {
            return 0.5 * side1 * side2 * Math.Sin(angle);
        }

        public override double Perimeter()
        {
            double equalSide = side2;
            double baseSide = 2 * equalSide * Math.Sin(angle / 2);
            double height = Math.Sqrt(equalSide * equalSide - (baseSide / 2) * (baseSide / 2));
            double side3 = 2 * height + equalSide;
            return baseSide + 2 * equalSide;
        }
    }

    // Рівносторонній трикутник
    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double side) : base(side, side, 2 * Math.PI / 3)
        {
        }

        public override double Area()
        {
            return 0.25 * Math.Sqrt(3) * side1 * side1;
        }

        public override double Perimeter()
        {
            return 3 * side1;
        }
    }
}