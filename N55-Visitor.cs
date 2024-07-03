/*
Explication
Interface IVisitable :

Déclare la méthode Accept(IVisitor visitor) que tous les éléments visitables doivent implémenter. Cette méthode permet au visiteur de visiter l'élément.
Interface IVisitor :

Déclare les méthodes Visit(ElementA element) et Visit(ElementB element) que tous les visiteurs concrets doivent implémenter pour visiter les différents types d'éléments.
Classes d'éléments visitables (ElementA, ElementB) :

Implémentent l'interface IVisitable.
Chaque classe a une méthode Accept qui appelle la méthode Visit correspondante du visiteur en lui transmettant une référence à elle-même.
Classe de visiteur concret (ConcreteVisitor) :

Implémente l'interface IVisitor.
Contient des méthodes Visit spécifiques pour traiter chaque type d'élément visitable (ElementA, ElementB).
Classe Program :

Contient le point d'entrée Main.
Crée une liste d'éléments visitables (ElementA, ElementB).
Crée un visiteur concret (ConcreteVisitor).
Parcourt la liste d'éléments et appelle la méthode Accept sur chaque élément, en passant le visiteur en paramètre.
Le design pattern Visitor permet de séparer les algorithmes appliqués à une structure de données de sa structure proprement dite. Il permet d'ajouter de nouveaux comportements à une hiérarchie d'objets sans avoir à les modifier, tout en maintenant l'encapsulation des opérations spécifiques dans les classes appropriées.
*/

using System;
using System.Collections.Generic;

namespace VisitorPattern
{
    // Interface de l'élément visitable
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }

    // Interface du visiteur
    public interface IVisitor
    {
        void Visit(ElementA element);
        void Visit(ElementB element);
    }

    // Implémentations concrètes des éléments visitables

    public class ElementA : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string OperationA()
        {
            return "Opération A de ElementA";
        }
    }

    public class ElementB : IVisitable
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public int OperationB()
        {
            return 42;
        }
    }

    // Implémentation concrète du visiteur

    public class ConcreteVisitor : IVisitor
    {
        public void Visit(ElementA element)
        {
            Console.WriteLine($"Visiteur traite {element.OperationA()}");
        }

        public void Visit(ElementB element)
        {
            Console.WriteLine($"Visiteur traite {element.OperationB()}");
        }
    }

    // Utilisation du pattern Visitor

    class Program
    {
        static void Main(string[] args)
        {
            var elements = new List<IVisitable>
            {
                new ElementA(),
                new ElementB()
            };

            var visitor = new ConcreteVisitor();

            foreach (var element in elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
