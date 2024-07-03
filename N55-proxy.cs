/*
Explication
Interface IService :

Définit la méthode Request que le service concret et le proxy implémenteront.
Classe ConcreteService :

Implémente l'interface IService.
Fournit une implémentation concrète de Request qui simule le chargement de données à partir d'un service.
Classe ProxyService :

Implémente également l'interface IService.
Contient une instance du ConcreteService qu'il utilise pour effectuer les requêtes réelles.
Utilise une mise en cache simple pour stocker les résultats précédemment demandés afin d'éviter de charger les mêmes données à plusieurs reprises.
Classe Program :

Contient le point d'entrée Main où un proxy est créé et utilisé pour accéder au service.
Démontre comment le proxy intercepte les appels à Request pour gérer le cache et éviter les chargements inutiles de données.
Le design pattern Proxy permet de contrôler l'accès à un objet en fournissant un substitut ou un proxy qui agit comme une interface vers cet objet. Dans cet exemple,
le proxy ProxyService gère le chargement des données à partir du service réel (ConcreteService) et utilise un cache pour éviter les chargements redondants.
*/

using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Création et utilisation du proxy pour accéder à un service
            IService proxy = new ProxyService();

            Console.WriteLine(proxy.Request("Data1")); // Chargement initial depuis le service
            Console.WriteLine(proxy.Request("Data2")); // Chargement initial depuis le service
            Console.WriteLine(proxy.Request("Data1")); // Récupération depuis le cache

            // Démonstration du chargement paresseux
            Console.WriteLine(proxy.Request("Data3")); // Chargement initial depuis le service
        }
    }

    // Interface du service
    public interface IService
    {
        string Request(string data);
    }

    // Service concret
    public class ConcreteService : IService
    {
        public string Request(string data)
        {
            Console.WriteLine($"Chargement de {data} depuis le service.");
            return $"Données de {data}";
        }
    }

    // Proxy
    public class ProxyService : IService
    {
        private ConcreteService service = new ConcreteService();
        private string cachedData;

        public string Request(string data)
        {
            // Vérifier si les données sont en cache
            if (cachedData == null || cachedData != data)
            {
                cachedData = service.Request(data);
            }
            else
            {
                Console.WriteLine($"Récupération de {data} depuis le cache.");
            }
            return cachedData;
        }
    }
}
