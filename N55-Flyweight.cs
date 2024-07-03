/*
Explication
Interface Shape :

Déclare les méthodes Draw et SetRadius que tous les flyweights doivent implémenter.
Classe Circle :

Implémente l'interface Shape.
Contient des champs pour la couleur (intrinsèque) et le rayon (extrinsèque).
Fournit des méthodes pour définir le rayon et dessiner le cercle.
Classe ShapeFactory :

Contient un dictionnaire pour stocker et réutiliser les instances de Circle.
Fournit une méthode GetCircle pour obtenir un cercle de la couleur spécifiée, créant un nouveau cercle si nécessaire.
Classe Program :

Contient le point d'entrée Main où des cercles de différentes couleurs sont créés et dessinés.
Vérifie si deux cercles de la même couleur sont effectivement la même instance.
Le design pattern Flyweight permet de réduire la consommation de mémoire en partageant autant que possible les objets similaires, en extrayant les informations qui varient
en dehors des objets partagés. Dans cet exemple, les cercles de la même couleur partagent la même instance, ce qui réduit l'utilisation de la mémoire.
*/

using System;
using System.Collections.Generic;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();

            // Création de cercles avec différentes couleurs
            Shape redCircle1 = shapeFactory.GetCircle("Red");
            redCircle1.SetRadius(5);
            redCircle1.Draw();

            Shape blueCircle = shapeFactory.GetCircle("Blue");
            blueCircle.SetRadius(10);
            blueCircle.Draw();

            Shape redCircle2 = shapeFactory.GetCircle("Red");
            redCircle2.SetRadius(15);
            redCircle2.Draw();

            // Les deux cercles rouges devraient être la même instance
            if (ReferenceEquals(redCircle1, redCircle2))
            {
                Console.WriteLine("Les deux cercles rouges sont identiques.");
            }
            else
            {
                Console.WriteLine("Les cercles rouges sont différents.");
            }
        }
    }

    // Interface Flyweight
    public interface Shape
    {
        void Draw();
        void SetRadius(int radius);
    }

    // Implémentation concrète de Flyweight
    public class Circle : Shape
    {
        private string color;
        private int radius;

        public Circle(string color)
        {
            this.color = color;
        }

        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Dessiner un cercle de couleur {color} et de rayon {radius}");
        }
    }

    // Fabrique Flyweight
    public class ShapeFactory
    {
        private Dictionary<string, Shape> shapes = new Dictionary<string, Shape>();

        public Shape GetCircle(string color)
        {
            if (!shapes.ContainsKey(color))
            {
                shapes[color] = new Circle(color);
                Console.WriteLine($"Créer un cercle de couleur {color}");
            }
            return shapes[color];
        }
    }
}
