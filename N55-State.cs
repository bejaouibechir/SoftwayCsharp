/*
Contient le point d'entrée Main.
Crée un contexte avec un état initial (ConcreteStateA).
Simule des requêtes successives sur le contexte, où chaque état réagit à la requête et peut changer l'état du contexte en conséquence.
Le design pattern State permet à un objet de modifier son comportement lorsque son état interne change. Cela se traduit par une meilleure modularité du code,
où les états sont encapsulés dans des classes distinctes, facilitant ainsi l'extension et la maintenance du code.

Explication
Interface IState :

Déclare la méthode Handle que tous les états concrets doivent implémenter pour gérer les requêtes.
Classe Context :

Contient une référence à un état (_state) et permet de changer dynamiquement l'état courant via la méthode TransitionTo.
Appelle la méthode Handle de l'état courant lorsqu'une requête est reçue via la méthode Request.
Classes d'états concrètes (ConcreteStateA, ConcreteStateB) :

Implémentent l'interface IState.
Chaque état gère la requête selon sa propre logique métier et peut déclencher un changement d'état en appelant TransitionTo sur le contexte.
Classe Program :


*/

using System;

namespace StatePattern
{
    // Interface de l'état
    public interface IState
    {
        void Handle(Context context);
    }

    // Contexte
    public class Context
    {
        private IState _state;

        public Context(IState state)
        {
            TransitionTo(state);
        }

        public void TransitionTo(IState state)
        {
            Console.WriteLine($"Context: Transition vers {state.GetType().Name}.");
            _state = state;
            _state.Handle(this);
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }

    // Implémentations concrètes d'états

    public class ConcreteStateA : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("ConcreteStateA gère la requête.");
            context.TransitionTo(new ConcreteStateB());
        }
    }

    public class ConcreteStateB : IState
    {
        public void Handle(Context context)
        {
            Console.WriteLine("ConcreteStateB gère la requête.");
            context.TransitionTo(new ConcreteStateA());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialisation avec un état concret
            var context = new Context(new ConcreteStateA());

            // Simulation de requêtes successives
            context.Request();
            context.Request();
            context.Request();
        }
    }
}
