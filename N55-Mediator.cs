/*
     Ce pattern permet de déconnecter les utilisateurs du chat room en leur permettant de communiquer 
     à travers le médiateur, ce qui réduit les dépendances entre les utilisateurs individuels et 
     favorise la modularité et la maintenabilité du système.
  Dans cet exemple :

    Médiateur (Mediator) : L'interface IChatMediator définit une méthode SendMessage pour envoyer un message 
    à tous les utilisateurs du chat room.

    Médiateur concret (ConcreteMediator) : ChatRoom est un médiateur concret qui implémente IChatMediator
    et coordonne la communication entre les utilisateurs.

    Composant (Component) : L'interface IUser définit les méthodes SendMessage et ReceiveMessage pour que    
    les utilisateurs puissent communiquer.
    Composant concret (ConcreteComponent) : User est un composant concret qui implémente 
    IUser et interagit avec les autres utilisateurs via le médiateur.
 */

using System;
using System.Collections.Generic;


namespace Client
{
    public class Program
    {
        public static void Main()
        {
            ChatRoom chatRoom = new ChatRoom();

            IUser user1 = new User("Alice", chatRoom);
            IUser user2 = new User("Bob", chatRoom);
            IUser user3 = new User("Charlie", chatRoom);

            chatRoom.AddUser(user1);
            chatRoom.AddUser(user2);
            chatRoom.AddUser(user3);

            user1.SendMessage("Hello everyone!");


            Console.ReadLine();

        }
    }

    // Mediator interface
    public interface IChatMediator
    {
        void SendMessage(string message, IUser user);
    }

    // Component interface
    public interface IUser
    {
        void SendMessage(string message);
        void ReceiveMessage(string message);
    }

    // Concrete component
    class User : IUser
    {
        private readonly string _name;
        private readonly IChatMediator _chatMediator;

        public User(string name, IChatMediator chatMediator)
        {
            _name = name;
            _chatMediator = chatMediator;
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"{_name} sends message: {message}");
            _chatMediator.SendMessage(message, this);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"{_name} receives message: {message}");
        }
    }

    // Concrete mediator
    class ChatRoom : IChatMediator
    {
        private List<IUser> _users;
        public ChatRoom() => _users = new List<IUser>();
        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public void SendMessage(string message, IUser sender)
        {
            foreach (var user in _users)
            {
                if (user != sender) // Exclude the sender
                {
                    user.ReceiveMessage(message);
                }
            }
        }
    }
}