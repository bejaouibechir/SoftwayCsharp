/*l'Abstract Factory crée des familles d'objets, tandis que le Factory Method crée un seul objet*/

/*
 Abstract Factory :
L'Abstract Factory fournit une interface pour créer des familles d'objets apparentés 
sans spécifier leurs classes concrètes.

Il encapsule une ou plusieurs Factory Methods et chaque Factory Method peut créer plusieurs types d'objets.

L'Abstract Factory est souvent utilisé lorsque le système doit être indépendant de
la façon dont ses produits sont créés, composés ou représentés.
 
 */
using AbstractFactory;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IDatabaseFactory factory = new SqlServerFactory();
            ISqlService sqlService = factory.CreateService();
            sqlService.Connect();
            sqlService.Execute();
            sqlService.Disconnect();

        }
    }
}

namespace AbstractFactory
{
    // Interface de fabrique abstraite
    public interface IDatabaseFactory
    {
        ISqlService CreateService();
    }

    // Interface pour les services de connexion
    public interface ISqlService
    {
        void Connect();
        void Execute();
        void Disconnect();
    }


    // Implémentation de service pour SQL Server
    public class SqlServerService : ISqlService
    {
        public void Connect()
        {
            Console.WriteLine("Connect to sql server database ");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnect to sql server database ");
        }

        public void Execute()
        {
            Console.WriteLine("Execute sql server command ");
        }
    }

    // Implémentation de service pour PostgreSQL
    public class PostgresService : ISqlService
    {
        public void Connect()
        {
            Console.WriteLine("Connect to postgres sql database ");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnect to postgres sql database ");
        }

        public void Execute()
        {
            Console.WriteLine("Execute postgres sql command ");
        }
    }

    // Implémentation de service pour MySQL
    public class MySqlService : ISqlService
    {
        public void Connect()
        {
            Console.WriteLine("Connect to mysql    database ");
        }

        public void Disconnect()
        {
            Console.WriteLine("Disconnect to mysql    database ");
        }

        public void Execute()
        {
            Console.WriteLine("Execute mysql    command ");
        }
    }



    // Implémentation de la fabrique pour SQL Server
    public class SqlServerFactory : IDatabaseFactory
    {
        public ISqlService CreateService()
        {
            return new SqlServerService();
        }
    }

    // Implémentation de la fabrique pour PostgreSQL
    public class PostgresFactory : IDatabaseFactory
    {
        public ISqlService CreateService()
        {
            return new PostgresService();
        }
    }

    // Implémentation de la fabrique pour MySQL
    public class MySqlFactory : IDatabaseFactory
    {
        public ISqlService CreateService()
        {
            return new MySqlService();
        }
    }

}



