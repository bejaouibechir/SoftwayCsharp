/*
Explication
Interface IRectangle :

Déclare la méthode Draw qui sera utilisée par le client pour dessiner un rectangle.
Classe LegacyRectangle :

Représente l'adapté (adaptee) avec une interface incompatible, fournissant une méthode DrawRectangle qui utilise des coordonnées différentes.
Classe RectangleAdapter :

Implémente l'interface cible IRectangle.
Contient une référence à une instance de LegacyRectangle.
Convertit les appels de l'interface cible (Draw) en appels compatibles avec l'interface de l'adapté (DrawRectangle).
Classe Program :

Contient le point d'entrée Main où un LegacyRectangle est créé et adapté via un RectangleAdapter pour être utilisé comme un IRectangle.
L'adaptateur permet de connecter l'interface incompatible de LegacyRectangle avec l'interface cible IRectangle, permettant ainsi à un code existant d'être utilisé avec une nouvelle interface sans modifications majeures.

*/

using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création de l'adapté (adaptee)
            LegacyRectangle legacyRectangle = new LegacyRectangle();

            // Création de l'adaptateur (adapter) avec l'adapté
            IRectangle rectangle = new RectangleAdapter(legacyRectangle);

            // Utilisation de l'interface cible
            rectangle.Draw(10, 20, 30, 40);
        }
    }

    // Interface cible
    public interface IRectangle
    {
        void Draw(int x, int y, int width, int height);
    }

    // Adapté (adaptee) avec une interface incompatible
    public class LegacyRectangle
    {
        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine($"Rectangle dessiné de ({x1}, {y1}) à ({x2}, {y2})");
        }
    }

    // Adaptateur (adapter) qui rend l'interface compatible
    public class RectangleAdapter : IRectangle
    {
        private readonly LegacyRectangle _legacyRectangle;

        public RectangleAdapter(LegacyRectangle legacyRectangle)
        {
            _legacyRectangle = legacyRectangle;
        }

        public void Draw(int x, int y, int width, int height)
        {
            // Conversion des coordonnées pour l'adapté
            int x2 = x + width;
            int y2 = y + height;
            _legacyRectangle.DrawRectangle(x, y, x2, y2);
        }
    }
}
