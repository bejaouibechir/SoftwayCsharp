/*
Explication
Interface IIterator<T> :

Définit les méthodes HasNext et Next que tous les itérateurs concrets doivent implémenter pour parcourir une collection.
Interface IAggregate<T> :

Définit une méthode CreateIterator pour créer un itérateur qui parcourt les éléments d'un agrégat.
Classe Iterator<T> :

Implémente l'interface IIterator<T>.
Maintient une référence à un tableau (_items) et un index (_position) pour suivre la position actuelle lors du parcours des éléments.
Classe Aggregate<T> :

Implémente l'interface IAggregate<T>.
Contient une collection d'éléments (_items).
Implémente la méthode CreateIterator qui retourne une instance de Iterator<T> pour parcourir les éléments de l'agrégat.
Classe Program :

Contient le point d'entrée Main où un agrégat est créé avec un tableau d'entiers.
Un itérateur est créé à partir de l'agrégat.
Utilisation de l'itérateur pour parcourir et afficher les éléments de l'agrégat à l'aide d'une boucle while.
Le design pattern Iterator permet de parcourir les éléments d'une collection sans exposer sa représentation interne, 
offrant ainsi une manière uniforme d'accéder et de parcourir différents types de collections de manière séquentielle.

*/

using System;
using System.Collections;

namespace IteratorPattern
{
    // Interface d'itérateur
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }

    // Interface d'agrégat
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }

    // Classe concrète d'itérateur
    public class Iterator<T> : IIterator<T>
    {
        private T[] _items;
        private int _position = 0;

        public Iterator(T[] items)
        {
            _items = items;
        }

        public bool HasNext()
        {
            return _position < _items.Length;
        }

        public T Next()
        {
            T currentItem = _items[_position];
            _position++;
            return currentItem;
        }
    }

    // Classe concrète d'agrégat
    public class Aggregate<T> : IAggregate<T>
    {
        private T[] _items;

        public Aggregate(T[] items)
        {
            _items = items;
        }

        public IIterator<T> CreateIterator()
        {
            return new Iterator<T>(_items);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Création de l'agrégat
            Aggregate<int> aggregate = new Aggregate<int>(new int[] { 1, 2, 3, 4, 5 });

            // Création de l'itérateur
            IIterator<int> iterator = aggregate.CreateIterator();

            // Utilisation de l'itérateur pour parcourir et afficher les éléments
            while (iterator.HasNext())
            {
                int item = iterator.Next();
                Console.WriteLine(item);
            }
        }
    }
}
