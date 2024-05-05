using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    //DSA is priamrily used for digital signature rather than encrypting and decrypting data
    static void Main()
    {
        string originalMessage = "This is the message to be signed.";

        // Generate DSA key pair
        using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
        {
            // Get private and public key
            string privateKey = dsa.ToXmlString(true);
            string publicKey = dsa.ToXmlString(false);

            // Create a digital signature
            byte[] signature = CreateSignature(originalMessage, privateKey);

            // Verify the digital signature
            bool isVerified = VerifySignature(originalMessage, signature, publicKey);

            Console.WriteLine("Original Message: {0}", originalMessage);
            Console.WriteLine("Is Signature Verified: {0}", isVerified);
            Console.Read();
        }
    }

    static byte[] CreateSignature(string message, string privateKey)
    {
        using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
        {
            dsa.FromXmlString(privateKey);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            return dsa.SignData(messageBytes);
        }
    }

    static bool VerifySignature(string message, byte[] signature, string publicKey)
    {
        using (DSACryptoServiceProvider dsa = new DSACryptoServiceProvider())
        {
            dsa.FromXmlString(publicKey);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            return dsa.VerifyData(messageBytes, signature);
        }
    }
}
