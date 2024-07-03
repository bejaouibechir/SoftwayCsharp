/*
Explication
Classe abstraite AbstractClass :

Définit le Template Method TemplateMethod() qui représente l'algorithme général avec des étapes prédéfinies.
Déclare des méthodes abstraites PrimitiveOperation1() et PrimitiveOperation2() que les sous-classes doivent implémenter.
Classes concrètes (ConcreteClassA, ConcreteClassB) :

Implémentent les opérations primitives spécifiques PrimitiveOperation1() et PrimitiveOperation2() définies dans AbstractClass.
Utilisent ces méthodes pour personnaliser le comportement spécifique à chaque classe concrète.
Classe Program :

Contient le point d'entrée Main.
Instancie et utilise ConcreteClassA et ConcreteClassB pour démontrer l'utilisation du Template Method avec différentes implémentations spécifiques.
Le design pattern Template Method permet de définir le squelette d'un algorithme dans une méthode, en laissant aux sous-classes le soin de redéfinir certaines étapes de cet algorithme sans changer sa structure globale. Cela favorise la réutilisation du code et permet de structurer des algorithmes communs tout en permettant des variations spécifiques à chaque sous-classe.

*/

using System;

namespace TemplateMethodPattern
{
    // Classe abstraite définissant le Template Method
    public abstract class AbstractClass
    {
        // Template Method définissant l'algorithme général
        public void TemplateMethod()
        {
            Console.WriteLine("Template Method : Étape 1");
            PrimitiveOperation1();
            Console.WriteLine("Template Method : Étape 2");
            PrimitiveOperation2();
            Console.WriteLine("Template Method : Fin");
        }

        // Opérations primitives à implémenter par les sous-classes
        protected abstract void PrimitiveOperation1();
        protected abstract void PrimitiveOperation2();
    }

    // Classes concrètes étendant AbstractClass
    public class ConcreteClassA : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.WriteLine("Implémentation de l'opération 1 pour ConcreteClassA");
        }

        protected override void PrimitiveOperation2()
        {
            Console.WriteLine("Implémentation de l'opération 2 pour ConcreteClassA");
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        protected override void PrimitiveOperation1()
        {
            Console.WriteLine("Implémentation de l'opération 1 pour ConcreteClassB");
        }

        protected override void PrimitiveOperation2()
        {
            Console.WriteLine("Implémentation de l'opération 2 pour ConcreteClassB");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Utilisation de ConcreteClassA
            AbstractClass a = new ConcreteClassA();
            a.TemplateMethod();

            Console.WriteLine();

            // Utilisation de ConcreteClassB
            AbstractClass b = new ConcreteClassB();
            b.TemplateMethod();
        }
    }
}
