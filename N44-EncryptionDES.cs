using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string original = "docker1234@";

        // Generate a random key
        byte[] key = GenerateRandomKey();

        // Encrypt the data
        byte[] encryptedData = EncryptStringToBytes(original, key);

        // Decrypt the data
        string decrypted = DecryptStringFromBytes(encryptedData, key);

        Console.WriteLine("Original: {0}", original);
        Console.WriteLine("Encrypted: {0}", Convert.ToBase64String(encryptedData));
        Console.WriteLine("Decrypted: {0}", decrypted);
        Console.ReadLine();
    }

    static byte[] EncryptStringToBytes(string plainText, byte[] key)
    {
        // Check arguments
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (key == null || key.Length != 8) // DES key size is 8 bytes
            throw new ArgumentNullException("key");

        using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
        {
            desAlg.Key = key;
            desAlg.IV = new byte[8]; // IV is not used, but must be set

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = desAlg.CreateEncryptor(desAlg.Key, desAlg.IV);

            // Create a MemoryStream to hold the encrypted bytes.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // Create a CryptoStream to perform the encryption
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // Write the plaintext to the CryptoStream
                    byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                    csEncrypt.Write(bytes, 0, bytes.Length);
                    csEncrypt.FlushFinalBlock();
                }

                // Return the encrypted bytes from the MemoryStream
                return msEncrypt.ToArray();
            }
        }
    }

    static string DecryptStringFromBytes(byte[] cipherText, byte[] key)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (key == null || key.Length != 8) // DES key size is 8 bytes
            throw new ArgumentNullException("key");

        using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
        {
            desAlg.Key = key;
            desAlg.IV = new byte[8]; // IV is not used, but must be set

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = desAlg.CreateDecryptor(desAlg.Key, desAlg.IV);

            // Create a MemoryStream to hold the decrypted bytes.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                // Create a CryptoStream to perform the decryption
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    // Read the decrypted bytes from the CryptoStream
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    static byte[] GenerateRandomKey()
    {
        using (DESCryptoServiceProvider desAlg = new DESCryptoServiceProvider())
        {
            desAlg.GenerateKey();
            return desAlg.Key;
        }
    }
}
