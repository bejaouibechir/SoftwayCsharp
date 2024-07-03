/*
Explication
Interface Handler :

Déclare la méthode HandleRequest que tous les handlers concrets doivent implémenter.
Contient un champ successor pour référencer le handler suivant dans la chaîne.
Classes ManagerHandler, DirectorHandler, VicePresidentHandler, PresidentHandler :

Implémentent l'interface Handler.
Chaque handler concret gère une catégorie spécifique de demandes en fonction de son niveau d'autorité.
Si la demande dépasse son autorité, elle la transmet à son successeur s'il existe.
Classe Program :

Contient le point d'entrée Main où une chaîne de responsabilité est configurée avec des handlers de différents niveaux.
Démontre comment les demandes sont traitées successivement jusqu'à ce qu'une réponse soit donnée ou que la demande soit rejetée si elle dépasse le pouvoir de tous les handlers.
Le design pattern Chain of Responsibility permet de créer une chaîne de handlers où chaque handler a la possibilité de traiter une demande ou de la transmettre au suivant dans la chaîne, 
permettant ainsi de gérer dynamiquement les requêtes sans connaître à l'avance le traitement exact nécessaire.

*/

using System;

namespace ChainOfResponsibilityPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuration de la chaîne de responsabilité
            Handler manager = new ManagerHandler();
            Handler director = new DirectorHandler();
            Handler vicePresident = new VicePresidentHandler();
            Handler president = new PresidentHandler();

            manager.SetSuccessor(director);
            director.SetSuccessor(vicePresident);
            vicePresident.SetSuccessor(president);

            // Simuler différentes demandes
            Console.WriteLine("Exemple 1:");
            manager.HandleRequest(800);

            Console.WriteLine("\nExemple 2:");
            manager.HandleRequest(1500);

            Console.WriteLine("\nExemple 3:");
            manager.HandleRequest(5000);
        }
    }

    // Interface Handler
    public abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int amount);
    }

    // Handlers concrets
    public class ManagerHandler : Handler
    {
        public override void HandleRequest(int amount)
        {
            if (amount <= 1000)
            {
                Console.WriteLine($"Le manager approuve la demande de {amount} dollars.");
            }
            else if (successor != null)
            {
                successor.HandleRequest(amount);
            }
            else
            {
                Console.WriteLine("La demande ne peut pas être approuvée.");
            }
        }
    }

    public class DirectorHandler : Handler
    {
        public override void HandleRequest(int amount)
        {
            if (amount <= 2500)
            {
                Console.WriteLine($"Le directeur approuve la demande de {amount} dollars.");
            }
            else if (successor != null)
            {
                successor.HandleRequest(amount);
            }
            else
            {
                Console.WriteLine("La demande ne peut pas être approuvée.");
            }
        }
    }

    public class VicePresidentHandler : Handler
    {
        public override void HandleRequest(int amount)
        {
            if (amount <= 5000)
            {
                Console.WriteLine($"Le vice-président approuve la demande de {amount} dollars.");
            }
            else if (successor != null)
            {
                successor.HandleRequest(amount);
            }
            else
            {
                Console.WriteLine("La demande ne peut pas être approuvée.");
            }
        }
    }

    public class PresidentHandler : Handler
    {
        public override void HandleRequest(int amount)
        {
            if (amount > 5000)
            {
                Console.WriteLine($"Le président approuve la demande de {amount} dollars.");
            }
            else
            {
                Console.WriteLine("La demande ne peut pas être approuvée.");
            }
        }
    }
}
