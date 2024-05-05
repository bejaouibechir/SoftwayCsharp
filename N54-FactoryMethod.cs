/*l'Abstract Factory crée des familles d'objets, tandis que le Factory Method crée un seul objet*/
using FactoryMethod;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlFactory factory = new ConcreteSqlFactory();
            var services = factory.CreateServices();
            var sqlserver = services[0];
            sqlserver.Connect();
            sqlserver.Execute();
            sqlserver.Disconnect();


        }
    }


}

namespace FactoryMethod
{
    using System;
    using System.Collections.Generic;

    public abstract class SqlService
    {
        abstract public void Connect();
        abstract public void Execute();
        abstract public void Disconnect();
    }

    public class SqlServerService : SqlService
    {
        public override void Connect()
        => Console.WriteLine("Connect to sql service");

        public override void Disconnect()
        => Console.WriteLine("Disconnect to sql service");

        public override void Execute()
        => Console.WriteLine("Execute sql service command");
    }

    public class PostgesService : SqlService
    {
        public override void Connect()
        => Console.WriteLine("Connect to postgres sql ");

        public override void Disconnect()
        => Console.WriteLine("Disconnect postgres to sql ");

        public override void Execute()
        => Console.WriteLine("Execute postgres sql  command");
    }

    public abstract class SqlFactory
    {
        List<SqlService> _services;
        protected SqlFactory() => CreateServices();

        public List<SqlService> Services => _services;

        abstract public List<SqlService> CreateServices();

    }

    public class ConcreteSqlFactory : SqlFactory
    {
        public override List<SqlService> CreateServices()
        {
            Services.Add(new SqlServerService());
            Services.Add(new PostgesService());
            return Services;
        }
    }
}




