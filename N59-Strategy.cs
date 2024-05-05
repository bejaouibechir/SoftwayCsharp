/*
 Ce pattern permet de changer dynamiquement l'algorithme de tri utilisé par le contexte sans modifier 
 la classe du contexte, ce qui rend le système plus flexible et extensible

  Dans cet exemple :

    * Stratégie (Strategy) : L'interface ISortStrategy définit la méthode Sort commune
      à toutes les stratégies de tri.

    * Stratégie concrète (ConcreteStrategy) : BubbleSortStrategy et QuickSortStrategy 
      sont des stratégies concrètes qui implémentent ISortStrategy et fournissent 
      l'implémentation spécifique de l'algorithme de tri.

    * Contexte (Context) : La classe Sorter utilise une référence vers 
      l'interface ISortStrategy pour déléguer l'appel à l'algorithme de tri approprié. 

 */

using System;


namespace Client
{
    public class Program
    {
        public static void Main()
        {
            int[] array = { 7, 2, 5, 1, 9 };

            Sorter sorter = new Sorter();

            sorter.SetStrategy(new BubbleSortStrategy());
            sorter.SortArray(array);

            sorter.SetStrategy(new QuickSortStrategy());
            sorter.SortArray(array);

            Console.ReadLine();

        }
    }

    // Strategy interface
    public interface ISortStrategy
    {
        void Sort(int[] array);
    }


    // Context
    class Sorter
    {
        private ISortStrategy _strategy;

        public void SetStrategy(ISortStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SortArray(int[] array)
        {
            _strategy.Sort(array);
        }
    }


    // Concrete strategies
    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting array using Bubble Sort");
            // Bubble sort implementation
        }
    }

    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(int[] array)
        {
            Console.WriteLine("Sorting array using Quick Sort");
            // Quick sort implementation
        }
    }
}