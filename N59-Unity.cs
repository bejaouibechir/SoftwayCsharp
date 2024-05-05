using System;
using Unity;
using Unity.Injection;

namespace Client
{
    // Interface pour le logger
    public interface ILogger
    {
        void Log(string message);
    }

    // Implémentation concrète du logger
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            // Log message to file
            Console.WriteLine($"Logged to file: {message}");
        }
    }

    public class Service
    {
        private readonly ILogger logger;

        // Injection de dépendance via le constructeur
        public Service(ILogger logger)
        {
            this.logger = logger;
        }

        public void DoSomething()
        {
            logger.Log("Doing something");
        }
    }



class Program
    {
        static void Main(string[] args)
        {
            // Créer un conteneur Unity
            var container = new UnityContainer();

            // Enregistrer le mapping entre ILogger et FileLogger
            container.RegisterType<ILogger, FileLogger>();

            // Résoudre la dépendance pour Service
            var service = container.Resolve<Service>();

            // Utiliser le service
            service.DoSomething();
        }
    }


}
