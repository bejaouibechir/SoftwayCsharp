/*
 Cet exemple illustre comment le modèle Decorator permet d'ajouter de nouvelles fonctionnalités
à un objet existant de manière flexible et modulaire, sans modifier sa structure de base.
 */

using System;

namespace Client
{
    public class Program
    {
        public static void Main()
        {

        }
    }


    // Component Interface
    interface ICar
    {
        void Assemble();
    }

    // Concrete Component
    class BasicCar : ICar
    {
        public void Assemble()
        {
            Console.WriteLine("Basic Car Assembled");
        }
    }

    // Decorator
    abstract class CarDecorator : ICar
    {
        protected ICar car;

        public CarDecorator(ICar car)
        {
            this.car = car;
        }

        public virtual void Assemble()
        {
            car.Assemble();
        }
    }

    // Concrete Decorator
    class CarWithAC : CarDecorator
    {
        public CarWithAC(ICar car) : base(car) { }

        public override void Assemble()
        {
            base.Assemble();
            Console.WriteLine("Added Air Conditioning");
        }
    }

    // Concrete Decorator
    class CarWithGPS : CarDecorator
    {
        public CarWithGPS(ICar car) : base(car) { }

        public override void Assemble()
        {
            base.Assemble();
            Console.WriteLine("Added Navigation System");
        }
    }
}