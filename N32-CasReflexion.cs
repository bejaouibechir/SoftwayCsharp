using System.Diagnostics;
using System.Reflection;
using System;

public class ExempleRefexion
{
    public const double PI = 3.14;
    public double PCercle(double rayon)
    => rayon * PI * 2;
    public void CodeAppelParReflexion()
    {
        //Invoquer un champ
        ExempleRefexion a = new ExempleRefexion();
        double val = (double)a.GetType().GetField("PI").GetValue(a);

        //Invoquer une methode
        double perimetre = (double)a.GetType().GetMethod("PCercle", new Type[] { typeof(double) })
            .Invoke(a, new object[] { 25 });

        //Invoquer un constructeur
        var constructor = typeof(ExempleRefexion).GetConstructor(new Type[] { });
        a = (ExempleRefexion)constructor.Invoke(null);

        //Explorer les assemblies
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            Debug.WriteLine(type.Name);
        }

        assembly = Assembly.LoadFile(@"C:\temp\Biblio.dll");
        types = assembly.GetTypes();
        foreach (Type type in types)
        {
            Debug.WriteLine(type.Name);
        }
    }
}