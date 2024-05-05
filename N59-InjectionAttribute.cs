using System;
using System.Reflection;


namespace Client
{
    public class Program
    {
        public static void Main()
        {
            Client client = new Client();
            Console.ReadLine();
        }
    }

    public interface IService
    {
        void Fonction();
    }

    public class Service : IService
    {
        public void Fonction()
        {
            Console.WriteLine("Rendre service");
        }
    }

    public class ServiceV2 : IService
    {
        public void Fonction()
        {
            Console.WriteLine("Rendre service version 2");
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class InejctAttribute : Attribute
    {
        bool _flag;
        public InejctAttribute(bool flag)
        {
            _flag = flag;

        }
        public void Injection()
        {
            if (_flag == true)
            {
                ServiceV2 service = new ServiceV2();
                service.Fonction();
            }

        }
    }

    public class ClientBase
    {
        public ClientBase()
        {
            var attribute = GetType().GetCustomAttribute<InejctAttribute>();
            if (attribute != null)
            {
                attribute.Injection();
            }
        }
    }

    [Inejct(false)]
    public class Client : ClientBase
    {
        private readonly IService _service;


        public Client()
        {

        }

        private int _myProperty;
        public int MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                Fonction(new ServiceV2());
            }
        }


        public Client(IService service) => _service = service;


        private void Fonction(IService service)
        {
            service.Fonction();
        }
        public void Fonction() => _service.Fonction();

    }


}