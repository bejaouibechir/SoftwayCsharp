/*
    Le modèle de conception Composite compose les objets 
   en structures arborescentes pour 
   représenter des hiérarchies partie-tout
 */

using System;
using System.Collections.Generic;

namespace Client
{
    public class Program
    {
        public static void Main()
        {

        }
    }

    public interface IFileSystemComponent
    {
        void showDetails();
    }

    // Leaf
    public class File : IFileSystemComponent
    {
        private string name;
        public File(string name) => this.name = name;
        public void showDetails() => Console.WriteLine("File: " + name);

    }

    public class Directory : IFileSystemComponent
    {
        private string name;
        private List<IFileSystemComponent> children;

        public Directory(string name)
        {
            this.name = name;
            children = new List<IFileSystemComponent>();
        }

        public void Add(IFileSystemComponent component)
        {
            children.Add(component);
        }

        public void Remove(IFileSystemComponent component)
        {
            children.Remove(component);
        }
        public void showDetails()
        {
            Console.WriteLine("Directory: " + name);
            foreach (IFileSystemComponent component in children)
            {
                component.showDetails();
            }
        }
    }
}