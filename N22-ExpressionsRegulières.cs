using System;
using System.Text.RegularExpressions;

namespace Client
{
    internal class ExpressionsRegulières
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public static bool IsMastercardValid(string creditCardNumber)
        {
            string pattern = @"^5[1-5][0-9]{14}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(creditCardNumber);
        }
        public static bool IsVisaValid(string creditCardNumber)
        {
            string pattern = @"^4[0-9]{12}(?:[0-9]{3})?$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(creditCardNumber);
        }
        public static bool IsTunisianPhoneNumberValid(string phoneNumber)
        {  
            string pattern = @"^(\+?216)?[24-9]\d{7}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public static bool IsUrlValid(string url)
        {
            string pattern = @"^(https?|ftp)://[^\s/$.?#].[^\s]*$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }


        public void CasMatchCollectionPhone()
        {
            string input = "John's phone number is (123) 456-7890. Jane's phone number is (987) 654-3210.";

            
            string pattern = @"\(\d{3}\) \d{3}-\d{4}";

            // Création d'un objet Regex avec le modèle
            Regex regex = new Regex(pattern);
            // Recherche de toutes les correspondances dans la chaîne d'entrée
            MatchCollection matches = regex.Matches(input);
            // Affichage des correspondances trouvées
            Console.WriteLine("Phone numbers found:");
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }

        public void RepalcePhone()
        {
            string input = "John's phone number is (123) 456-7890. Jane's phone number is (987) 654-3210.";
             // Modèle d'expression régulière pour correspondre à un numéro de téléphone au format américain
            string pattern = @"\(\d{3}\) \d{3}-\d{4}";
            Regex regex = new Regex(pattern);
            string maskedInput = regex.Replace(input, "***-***-****");
            // Affichage du résultat
            Console.WriteLine("Original text:");
            Console.WriteLine(input);
            Console.WriteLine("\nMasked text:");
            Console.WriteLine(maskedInput);
        }

        public void Split()
        {
            string input = "apple, banana; orange grape pineapple";
            string pattern = @"[,;\s]+";

          
            Regex regex = new Regex(pattern);
            string[] words = regex.Split(input);

            // Affichage des mots individuels
            Console.WriteLine("Words found:");
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }



    }
}
