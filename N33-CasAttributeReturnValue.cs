using System;
using System.Text.RegularExpressions;

namespace Client
{

    [AttributeUsage(AttributeTargets.ReturnValue, AllowMultiple = false)]
    public class ValidateEmailAttribute : Attribute
    {
        public bool ValidateEmail(string email)
            => Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    public class SomeClass
    {
        [return: ValidateEmailAttribute()]
        public string GetValue()
        {
            return "Hello World";
        }
    }

    public class CobailleBase3
    {
        private  bool ValidateEmail(string valuestring)
        {
            bool result = false;
            try
            {
                object[] attributes = typeof(CobailleBase3).
                          GetMethod("ProcessEmail").
                          ReturnTypeCustomAttributes.
                          GetCustomAttributes(false);
                
                if (attributes != null && attributes[0] is ValidateEmailAttribute)
                {
                    result = (attributes[0] as ValidateEmailAttribute).ValidateEmail(valuestring);
                    if (result == false) throw new FormatException("Pas conforme au format email");
                }
                return result;
            }
            catch (Exception)
            {
                return result;
            }
        }

        //[return: ValidateEmail()]
        public virtual string ProcessEmail(string id)
        {
            string email = id + "@xyz.com";
            ValidateEmail(email);
            return email;
        }

    }

    public class Cobaille3: CobailleBase3
    {

    }



}
