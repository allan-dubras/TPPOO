using System;


namespace TP8
{
    public class LSPTest
    {
        public static void Main()
        {
            ShapeProcessor processor = new ShapeProcessor();

            Console.WriteLine("Test avec un Rectangle:");
            Rectangle rectangle = new Rectangle(2, 3);
            processor.ProcessRectangle(rectangle);
            // Résultat attendu: Aire = 50, Dimensions: 5 x 10

            Console.WriteLine("\nTest avec un Square (devrait se comporter comme un Rectangle):");
            Square square = new Square(4);
            processor.ProcessRectangle(square);
            // Résultat: Aire = 100, Dimensions: 10 x 10
            // La hauteur a également changé lorsque la largeur a été modifiée,
            // ce qui viole les attentes du client sur le comportement d'un Rectangle
        }
    }
}