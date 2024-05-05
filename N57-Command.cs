/*
   Ce pattern permet de déconnecter 
   l'émetteur (télécommande) de l'exécuteur (récepteur),
   ce qui rend le système plus flexible et extensible.
 */

using System;

namespace Client
{
    public class Program
    {
        public static void Main()
        {

        }
    }

    // Command interface
    interface ICommand
    {
        void Execute();
    }

    // Concrete command
    class LightOnCommand : ICommand
    {
        private Light _light;
        public LightOnCommand(Light light) => _light = light;
        public void Execute() => _light.TurnOn();

    }

    // Receiver
    class Light
    {
        public void TurnOn() => Console.WriteLine("Light is on");
    }

    // Invoker
    class RemoteControl
    {
        private ICommand _command;
        public void SetCommand(ICommand command) => _command = command;
        public void PressButton() => _command.Execute();

    }
}