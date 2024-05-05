/*Le modèle de conception Builder sépare la construction d'un objet complexe de sa représentation 
 * afin que le même processus de construction puisse créer différentes représentations. */
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    abstract public class SqlBuilder
    {
        abstract public void Connect();
        abstract public void Execute();
        abstract public void Disconnect();
    }

    public class SqlServerBuilder : SqlBuilder
    {
        public override void Connect()
        {
            Console.WriteLine("Connect to sql server");
        }
        public override void Execute()
        {
            Console.WriteLine("Execute sql server command");
        }
        public override void Disconnect()
        {
            Console.WriteLine("Disonnect to sql server");
        }


    }

    public class PostgresSqlBuilder : SqlBuilder
    {
        public override void Connect()
        {
            Console.WriteLine("Connect to postgres sql");
        }
        public override void Execute()
        {
            Console.WriteLine("Execute postgres sql command");
        }
        public override void Disconnect()
        {
            Console.WriteLine("Disonnect to postgres sql");
        }


    }

}



