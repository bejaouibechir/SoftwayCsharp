using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string original = "This is the string to be encrypted.";

        // Create RSA key pair
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Get public and private key
            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);

            // Encrypt the data with the public key
            byte[] encryptedData = EncryptString(original, publicKey);

            // Decrypt the data with the private key
            string decrypted = DecryptString(encryptedData, privateKey);

            Console.WriteLine("Original: {0}", original);
            Console.WriteLine("Encrypted: {0}", Convert.ToBase64String(encryptedData));
            Console.WriteLine("Decrypted: {0}", decrypted);
            Console.ReadLine();
        }
    }

    static byte[] EncryptString(string plainText, string publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            return rsa.Encrypt(plainBytes, false);
        }
    }

    static string DecryptString(byte[] cipherData, string privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedBytes = rsa.Decrypt(cipherData, false);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
