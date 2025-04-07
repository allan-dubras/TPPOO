
namespace TP8
{
    public class Shape
    {
        public virtual double Width { get; set; }
        public virtual double Height { get; set; }

        public Shape(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public virtual double Area()
        {
            return Width * Height;
        }

        public virtual double Perimeter()
        {
            return 2 * (Width + Height);
        }

        public virtual void SetDimensions(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}