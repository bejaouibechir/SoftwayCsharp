/*Explication
Interface IRenderer :

Déclare les méthodes RenderCircle et RenderSquare que toutes les implémentations concrètes doivent définir.
Classes concrètes VectorRenderer et RasterRenderer :

Implémentent l'interface IRenderer.
Fournissent des versions spécifiques de RenderCircle et RenderSquare.
Classe abstraite Shape :

Contient une référence à un IRenderer.
Définit un constructeur pour initialiser le renderer et une méthode abstraite Draw.
Classes concrètes Circle et Square :

Héritent de la classe abstraite Shape.
Implémentent la méthode Draw en utilisant les méthodes de l'interface IRenderer.
Classe Program :

Contient le point d'entrée Main où différentes formes sont créées avec des implémentations de rendu différentes et dessinées.
Le design pattern Bridge permet de séparer l'abstraction (forme) de son implémentation (rendu), permettant de varier indépendamment les deux hiérarchies.*/

using System;

namespace BridgePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création des implémentations concrètes
            IRenderer vectorRenderer = new VectorRenderer();
            IRenderer rasterRenderer = new RasterRenderer();

            // Création des formes avec différentes implémentations
            Shape circle = new Circle(vectorRenderer, 5);
            Shape square = new Square(rasterRenderer, 10);

            // Dessin des formes
            circle.Draw();
            square.Draw();
        }
    }

    // Interface d'implémentation
    public interface IRenderer
    {
        void RenderCircle(float radius);
        void RenderSquare(float side);
    }

    // Implémentation concrète 1 : rendu vectoriel
    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Dessiner un cercle de rayon {radius} en utilisant le rendu vectoriel.");
        }

        public void RenderSquare(float side)
        {
            Console.WriteLine($"Dessiner un carré de côté {side} en utilisant le rendu vectoriel.");
        }
    }

    // Implémentation concrète 2 : rendu raster
    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Dessiner un cercle de rayon {radius} en utilisant le rendu raster.");
        }

        public void RenderSquare(float side)
        {
            Console.WriteLine($"Dessiner un carré de côté {side} en utilisant le rendu raster.");
        }
    }

    // Abstraction
    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
    }

    // Abstraction raffinée : Cercle
    public class Circle : Shape
    {
        private float radius;

        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }
    }

    // Abstraction raffinée : Carré
    public class Square : Shape
    {
        private float side;

        public Square(IRenderer renderer, float side) : base(renderer)
        {
            this.side = side;
        }

        public override void Draw()
        {
            renderer.RenderSquare(side);
        }
    }
}
