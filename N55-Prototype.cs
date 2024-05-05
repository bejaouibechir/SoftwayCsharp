/*
 * Le modèle de conception Prototype spécifie le type d'objets à créer à 
 * l'aide d'une instance prototypique et crée de nouveaux objets en copiant ce prototype
 
 */

using prototype;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Prototype1 prototype11 = new Prototype1(1);
            Prototype1 prototype12 = (Prototype1)prototype11.Clone();
        }
    }
}


namespace prototype
{
    abstract public class AbstractPrototype
    {
        private int _id;
        public AbstractPrototype(int id) => _id = id;
        public int Id { get { return _id; } }

        abstract public AbstractPrototype Clone();
    }

    public class Prototype1 : AbstractPrototype
    {
        public Prototype1(int id) : base(id) { }

        public override AbstractPrototype Clone()
        {
            return (Prototype1)MemberwiseClone();
        }
    }

    public class Prototype2 : AbstractPrototype
    {
        public Prototype2(int id) : base(id) { }
        public override AbstractPrototype Clone()
        {
            return (Prototype2)MemberwiseClone();
        }
    }

}


