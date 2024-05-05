using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Chaîne de caractères à hasher
        string input = "Hello, world!";
        // Appel de la méthode de hachage SHA-256
        string hashedString = GetSHA256Hash(input);
        // Affichage du résultat
        Console.WriteLine($"Chaîne d'entrée: {input}");
        Console.WriteLine($"Chaîne hachée SHA-256: {hashedString}");
    }
    static string GetSHA256Hash(string input)
    {
        // Création d'un objet SHA256
        using (SHA256 sha256 = SHA256.Create())
        {
            // Convertir la chaîne d'entrée en tableau de bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            // Calculer le haché SHA-256
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
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
