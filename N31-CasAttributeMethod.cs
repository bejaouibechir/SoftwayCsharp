using System;
using System.Diagnostics;
using System.Reflection;

namespace Client
{
    [AttributeUsage(AttributeTargets.Module)]
    public class TraceAttribute :Attribute
    {
        public void Trace()
        {
            Debug.WriteLine($"Call : {DateTime.Now}");
        }

    }

    public class CobailleBase2
    {
        public CobailleBase2()
        {
            var methodslist = GetType().GetMethods();
            foreach (var method in methodslist)
            {

                if (method.GetCustomAttribute<TraceAttribute>() != null)
                {
                    Debug.WriteLine(method.Name);
                    method.GetCustomAttribute<TraceAttribute>().Trace();
                }
            }
        }
    }


    public class Cobaille2:CobailleBase2
    {
        public void method1()
        {
            ;
        }
       
        public void method2()
        {
            ;
        }
        public void method3()
        {
            ;
        }
    }
}
