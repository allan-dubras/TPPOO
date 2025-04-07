namespace TP8
{

    public class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {
        }

        // Override Width pour maintenir la contrainte du carré (width == height)
        public override double Width
        {
            get { return base.Width; }
            set
            {
                base.Width = value;
                base.Height = value; // Modifie également Height pour maintenir un carré
            }
        }

        // Override Height pour maintenir la contrainte du carré (width == height)
        public override double Height
        {
            get { return base.Height; }
            set
            {
                base.Width = value; // Modifie également Width pour maintenir un carré
                base.Height = value;
            }
        }

        // Override SetDimensions pour maintenir la contrainte du carré
        public override void SetDimensions(double width, double height)
        {
            // Si width != height, utilise width (ou pourrait lever une exception)
            double side = width;
            base.SetDimensions(side, side);
        }
    }
}