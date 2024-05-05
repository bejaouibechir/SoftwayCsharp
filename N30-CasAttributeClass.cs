using System;
using System.Reflection;
using System.Security.Principal;
using System.Security;

namespace Client
{

    [AttributeUsage(AttributeTargets.Class)]
    public class SecurityAttribute :Attribute
    {
        public bool Activate { get; set; }

        public SecurityAttribute(bool activate)
        {
            Activate = activate;
        }

        public bool Check()
        {
            try
            {
                if (Activate == true)
                {
                    // Avoir l'identité courante
                    WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                    if (windowsIdentity != null)
                    {

                        WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                        bool isAdmin = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
                        if (!isAdmin)
                            throw new SecurityException("Manque de Privilège");
                    }
                }
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message +" " +  DateTime.Now.ToString());
                Console.Read();
            }

            return true;
        }

    }

    public class CobailleBase
    {
        public CobailleBase()
        {
            var securityattr = GetType().GetCustomAttribute<SecurityAttribute>();
            if ((securityattr!=null))
            {
                securityattr.Check();
            }
        }

        public void method()
        {
            Console.WriteLine("Méthode executée");
            Console.Read();
        }
    }


    [Security(true)]
    public class Cobaille : CobailleBase
    {

    }


}

/*
 string groupName = "Administrators"; // Specify the group name you want to check
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            if (windowsIdentity != null)
            {
                WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                bool isInGroup = windowsPrincipal.IsInRole(groupName);

                if (isInGroup)
                {
                    Console.WriteLine($"Current user belongs to the '{groupName}' group.");
                }
                else
                {
                    Console.WriteLine($"Current user does not belong to the '{groupName}' group.");
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve current Windows identity.");
            }
 
 */


/*
 WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

            if (windowsIdentity != null)
            {
                WindowsPrincipal windowsPrincipal = new WindowsPrincipal(windowsIdentity);
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                foreach (var group in identity.Groups)
                    Console.WriteLine($"Group Name: {group.Translate(typeof(NTAccount)).Value}");
            }
            else
                Console.WriteLine("Failed to retrieve current Windows identity.");
 */