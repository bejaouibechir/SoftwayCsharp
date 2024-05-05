using System.Collections.Generic;

namespace Client
{
    using System;
    using System.Dynamic;

    // Define a custom dynamic object by inheriting from DynamicObject
    public class CustomDynamicObject : DynamicObject
    {
        private readonly Dictionary<string, object> properties = new Dictionary<string, object>();

        // Implement TryGetMember to provide dynamic member access
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string propertyName = binder.Name;
            return properties.TryGetValue(propertyName, out result);
        }

        // Implement TrySetMember to provide dynamic member assignment
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            string propertyName = binder.Name;
            properties[propertyName] = value;
            return true;
        }
    }

    /*class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the custom dynamic object
            dynamic dynamicObject = new CustomDynamicObject();

            // Set properties dynamically
            dynamicObject.Name = "John";
            dynamicObject.Age = 30;

            // Get properties dynamically
            Console.WriteLine($"Name: {dynamicObject.Name}, Age: {dynamicObject.Age}");

            // Try accessing a non-existing property
            Console.WriteLine($"Address: {dynamicObject.Address}");
        }
    }*/

}
