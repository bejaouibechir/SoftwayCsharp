using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { Id = 1, Nom = "Bechir" };
            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Context = new StreamingContext(StreamingContextStates.File);
                serializer.Serialize(ms, person);
            }
        }
    }


    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [OnSerializing]
        public void onserilaizing(StreamingContext context)
        {
            if (context.State == StreamingContextStates.File)
            {
                Debug.WriteLine("Serialisation sous forme de fichier");
            }
        }
    }



}
