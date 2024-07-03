/*
Classe Singleton :
Variable de classe privée _instance : Contient l'unique instance du Singleton.
Objet de verrouillage _lock : Utilisé pour rendre le Singleton thread-safe.
Constructeur privé : Empêche l'instanciation directe de la classe.
Propriété publique Instance : Retourne l'instance unique du Singleton en utilisant une vérification doublement verrouillée pour garantir la thread-safety.
Méthode Log : Une méthode d'exemple pour démontrer la fonctionnalité du Singleton.
Classe Program :

*/

using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton instance1 = Singleton.Instance;
            instance1.Log("First message");

            Singleton instance2 = Singleton.Instance;
            instance2.Log("Second message");

            // Les deux instances devraient être les mêmes
            if (ReferenceEquals(instance1, instance2))
            {
                Console.WriteLine("Les deux instances sont identiques.");
            }
            else
            {
                Console.WriteLine("Les instances sont différentes.");
            }
        }
    }

    public class Singleton
    {
        // Variable de classe privée qui contient l'unique instance du Singleton
        private static Singleton _instance;

        // Objet pour le verrouillage afin de rendre le Singleton thread-safe
        private static readonly object _lock = new object();

        // Constructeur privé pour empêcher l'instanciation directe
        private Singleton() 
        {
            // Initialisation, si nécessaire
        }

        // Propriété publique pour obtenir l'instance unique du Singleton
        public static Singleton Instance
        {
            get
            {
                // Vérification doublement verrouillée pour garantir la thread-safety
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }
                return _instance;
            }
        }

        // Méthode d'exemple pour démontrer la fonctionnalité du Singleton
        public void Log(string message)
        {
            Console.WriteLine($"Message logged: {message}");
        }
    }
}
