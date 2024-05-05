using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Chaîne de caractères à hasher
        string input = "Hello, world!";

        // Appel de la méthode de hachage MD5
        string hashedString = GetMD5Hash(input);

        // Affichage du résultat
        Console.WriteLine($"Chaîne d'entrée: {input}");
        Console.WriteLine($"Chaîne hachée MD5: {hashedString}");
    }

    static string GetMD5Hash(string input)
    {
        // Création d'un objet MD5
        using (MD5 md5 = MD5.Create())
        {
            // Convertir la chaîne d'entrée en tableau de bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Calculer le haché MD5
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convertir le haché en une chaîne hexadécimale
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                stringBuilder.Append(hashBytes[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
