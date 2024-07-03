/*
Explication
Interface IStrategy :

Déclare une méthode Execute que toutes les stratégies concrètes doivent implémenter.
Classes de stratégies concrètes (ConcreteStrategyA, ConcreteStrategyB, ConcreteStrategyC) :

Implémentent l'interface IStrategy.
Chaque classe représente une implémentation spécifique d'une stratégie (par exemple, A, B, C).
Classe Context :

Contient une référence à une stratégie (_strategy) et fournit des méthodes pour définir et exécuter cette stratégie.
La méthode SetStrategy permet de changer dynamiquement la stratégie utilisée par le contexte.
La méthode ExecuteStrategy appelle la méthode Execute de la stratégie courante, permettant ainsi au contexte d'utiliser différentes stratégies de manière interchangeable.
Classe Program :

Contient le point d'entrée Main.
Crée un contexte avec une stratégie initiale (ConcreteStrategyA).
Exécute la stratégie actuelle, change la stratégie à la volée, puis réexécute la nouvelle stratégie.
Le design pattern Strategy permet de définir une famille d'algorithmes, encapsuler chacun d'eux et les rendre interchangeables. Cela permet au client d'utiliser différents algorithmes de manière dynamique sans modifier son code.

*/

using System;

namespace StrategyPattern
{
    // Interface pour la stratégie
    public interface IStrategy
    {
        void Execute();
    }

    // Implémentations concrètes des stratégies

    public class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Exécution de la stratégie A.");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Exécution de la stratégie B.");
        }
    }

    public class ConcreteStrategyC : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Exécution de la stratégie C.");
        }
    }

    // Contexte qui utilise la stratégie
    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Création du contexte avec une stratégie initiale
            var context = new Context(new ConcreteStrategyA());

            // Exécution de la stratégie actuelle
            context.ExecuteStrategy();

            // Changement de stratégie dynamiquement
            context.SetStrategy(new ConcreteStrategyB());
            context.ExecuteStrategy();

            // Changement de stratégie à nouveau
            context.SetStrategy(new ConcreteStrategyC());
            context.ExecuteStrategy();
        }
    }
}
