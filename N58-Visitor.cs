/*
 Ce pattern permet d'ajouter de nouvelles fonctionnalités (par exemple, un nouveau type de rendu) 
sans modifier la structure des objets visités, ce qui rend le système plus flexible et extensible.
 
Dans cet exemple :

    *Visiteur (Visitor) : L'interface IVisitor définit les méthodes de visite pour chaque type d'objet 
     dans la structure de document.
    *Visiteur concret (ConcreteVisitor) : Renderer est un visiteur concret 
     qui implémente IVisitor et fournit l'implémentation des méthodes de visite pour chaque type d'objet.
    *Élément (Element) : L'interface IElement définit la méthode Accept pour accepter le visiteur.
    *Élément concret (ConcreteElement) : Text, Image, et Video sont des éléments concrets 
     qui implémentent IElement et définissent la méthode Accept pour chaque type d'objet.
    *Structure (ObjectStructure) : Document est une structure qui contient une collection 
     d'objets Élément et fournit une méthode Accept pour itérer sur ces objets et appeler 
     la méthode Accept du visiteur.
 
 */

using System;
using System.Collections.Generic;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            Document document = new Document();
            document.Attach(new Text { Content = "Hello, world!" });
            document.Attach(new Image { FileName = "image.jpg" });
            document.Attach(new Video { Title = "video.mp4" });

            Renderer renderer = new Renderer();
            document.Accept(renderer);

            Console.ReadLine();

        }
    }


    // Visitor interface
    interface IVisitor
    {
        void VisitText(Text text);
        void VisitImage(Image image);
        void VisitVideo(Video video);
    }

    // Concrete visitor
    class Renderer : IVisitor
    {
        public void VisitText(Text text)
        {
            Console.WriteLine($"Rendering text: {text.Content}");
        }

        public void VisitImage(Image image)
        {
            Console.WriteLine($"Rendering image: {image.FileName}");
        }

        public void VisitVideo(Video video)
        {
            Console.WriteLine($"Rendering video: {video.Title}");
        }
    }

    // Element interface
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // Concrete elements
    class Text : IElement
    {
        public string Content { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitText(this);
        }
    }

    class Image : IElement
    {
        public string FileName { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitImage(this);
        }
    }

    class Video : IElement
    {
        public string Title { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitVideo(this);
        }
    }

    // Object structure
    class Document
    {
        private List<IElement> elements = new List<IElement>();

        public void Attach(IElement element)
        {
            elements.Add(element);
        }

        public void Detach(IElement element)
        {
            elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var element in elements)
            {
                element.Accept(visitor);
            }
        }
    }





}