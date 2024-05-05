using System;

namespace Client
{
    public class Program
    {
        public static void Main()
        {
            Client client = new Client();
            Button button = new Button(client);
            button.Click();

        }
    }


    interface IObserver
    {
        void Update();
    }

    // Observable (Subject)
    class Button
    {
        private readonly IObserver observer;

        public Button(IObserver observer)
        {
            this.observer = observer;
        }

        public void Click()
        {
            observer.Update();
        }
    }


    // Concrete Observer
    class Client : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Button clicked!");
        }
    }

}