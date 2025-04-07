using System;


namespace TP8
{
    public class ShapeProcessor
    {
        public void ProcessRectangle(Rectangle rectangle)
        {
            // Le client s'attend à ce comportement pour un rectangle:
            // La largeur et la hauteur sont indépendantes
            rectangle.Width = 5;
            rectangle.Height = 10;

            // Vérifier que l'aire est bien width * height (devrait être 50)
            double area = rectangle.Area();
            Console.WriteLine($"Aire du rectangle: {area}");

            // Vérifier que le rectangle a bien les dimensions définies
            Console.WriteLine($"Dimensions: {rectangle.Width} x {rectangle.Height}");
        }
    }
}