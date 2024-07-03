/*
Explication
Classe Memento :

Contient l'état sauvegardé (State) que l'originator peut restaurer.
Classe Originator :

Contient l'état actuel (State) que l'on peut modifier.
Permet de créer un memento (CreateMemento) avec l'état actuel.
Permet de restaurer l'état à partir d'un memento (SetMemento).
Classe Caretaker :

Garde une référence vers un memento.
Utile pour sauvegarder et restaurer l'état d'un originator sans exposer la représentation interne du memento.
Classe Program :

Contient le point d'entrée Main.
Crée un originator et un caretaker.
Modifie l'état de l'originator, crée un memento, modifie à nouveau l'état, puis restaure l'état précédent à partir du memento.
Le design pattern Memento permet de capturer et de restaurer l'état interne d'un objet sans violer l'encapsulation, en fournissant une manière de revenir à un état précédent d'un objet. Cela est utile pour l'implémentation de 
fonctionnalités telles que les annulations, les sauvegardes ou les points de restauration dans une application.

*/

using System;

namespace MementoPattern
{
    // Classe Memento contenant l'état sauvegardé
    public class Memento
    {
        public string State { get; }

        public Memento(string state)
        {
            State = state;
        }
    }

    // Classe Originator qui crée et restaure les mementos
    public class Originator
    {
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine($"État actuel : {_state}");
            }
        }

        // Création d'un nouveau memento avec l'état actuel
        public Memento CreateMemento()
        {
            return new Memento(_state);
        }

        // Restauration de l'état à partir d'un memento
        public void SetMemento(Memento memento)
        {
            _state = memento.State;
            Console.WriteLine($"État restauré : {_state}");
        }
    }

    // Classe Caretaker qui gère les mementos
    public class Caretaker
    {
        public Memento Memento { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Création de l'originator
            Originator originator = new Originator();
            
            // Création du caretaker
            Caretaker caretaker = new Caretaker();

            // Modification de l'état de l'originator
            originator.State = "État 1";

            // Sauvegarde du memento
            caretaker.Memento = originator.CreateMemento();

            // Modification de l'état de l'originator
            originator.State = "État 2";

            // Restauration de l'état précédent à partir du memento
            originator.SetMemento(caretaker.Memento);
        }
    }
}
