using System;

namespace ITвесна_3_таск_2атт
{

    class Program
    {
        static void Main(string[] args)
        {
   
            Square mySquare = new Square(new Point(1, 1), new Segment(1));

            mySquare.Sizing(2);
            mySquare.Stretching(3);
            mySquare.Compressing(0.5);
            mySquare.Rotating(90);
            mySquare.ChangeColor("blue");

        }
    }

    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class Segment
    {
        public double Length { get; set; }

        public Segment(double length)
        {
            Length = length;
        }

        public Segment(double x, double y)
        {
            Length = Math.Sqrt(x * x + y * y);
        }
    }

    class Square
    {
        public Point Origin { get; set; }
        public Segment Side { get; set; }
        public string Color { get; set; }

        public Square(Point origin, Segment side)
        {
            Origin = origin;
            Side = side;
            Color = "black";
            Console.WriteLine($"In start color is: {Color}");

        }

        public void Sizing(double factor)
        {
            Side.Length *= factor;
            Console.WriteLine($"Sizing change Length to: {Side.Length}");
        }

        public void Stretching(double factor)
        {
            Origin.X *= factor;
            Origin.Y *= factor;
            Side.Length *= factor;
            Console.WriteLine($"Stretching change Length to: {Side.Length}");
        }

        public void Compressing(double factor)
        {
            Origin.X *= factor;
            Origin.Y *= factor;
            Side.Length *= factor;
            Console.WriteLine($"Compressing change Length to: {Side.Length}");
            Console.WriteLine($"Checking the original before rotating: {Origin.X}");
            Console.WriteLine($"Checking the original before rotating: {Origin.Y}");
        }

        public void Rotating(double angle)
        {
            double radians = angle * Math.PI / 180;
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);

            double newX = Origin.X * cos - Origin.Y * sin;
            double newY = Origin.X * sin + Origin.Y * cos;

            Origin.X = newX;
            Origin.Y = newY;
            Console.WriteLine($"Checking the original after rotating: {Origin.X}");
            Console.WriteLine($"Checking the original after rotating: {Origin.Y}");
        }

        public void ChangeColor(string color)
        {
            Color = color;
            Console.WriteLine($"Now color is: {Color}");
        }
    }

}
