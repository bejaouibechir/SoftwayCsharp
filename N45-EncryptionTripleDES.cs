﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string original = "This is the string to be encrypted.";

        // Generate a random key and IV
        byte[] key = GenerateRandomKey();
        byte[] iv = GenerateRandomIV();

        // Encrypt the data
        byte[] encryptedData = EncryptStringToBytes(original, key, iv);

        // Decrypt the data
        string decrypted = DecryptStringFromBytes(encryptedData, key, iv);

        Console.WriteLine("Original: {0}", original);
        Console.WriteLine("Encrypted: {0}", Convert.ToBase64String(encryptedData));
        Console.WriteLine("Decrypted: {0}", decrypted);
        Console.ReadLine();
    }

    static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
    {
        // Check arguments
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length != 24) // TripleDES key size is 24 bytes
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length != 8) // TripleDES IV size is 8 bytes
            throw new ArgumentNullException("IV");

        using (TripleDESCryptoServiceProvider tripleDESAlg = new TripleDESCryptoServiceProvider())
        {
            tripleDESAlg.Key = Key;
            tripleDESAlg.IV = IV;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = tripleDESAlg.CreateEncryptor(tripleDESAlg.Key, tripleDESAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        // Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }
    }

    static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length != 24) // TripleDES key size is 24 bytes
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length != 8) // TripleDES IV size is 8 bytes
            throw new ArgumentNullException("IV");

        // Declare the string used to hold the decrypted text.
        string plaintext = null;

        // Create an TripleDES object with the specified key and IV.
        using (TripleDESCryptoServiceProvider tripleDESAlg = new TripleDESCryptoServiceProvider())
        {
            tripleDESAlg.Key = Key;
            tripleDESAlg.IV = IV;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = tripleDESAlg.CreateDecryptor(tripleDESAlg.Key, tripleDESAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }

    static byte[] GenerateRandomKey()
    {
        using (TripleDESCryptoServiceProvider tripleDESAlg = new TripleDESCryptoServiceProvider())
        {
            tripleDESAlg.GenerateKey();
            return tripleDESAlg.Key;
        }
    }

    static byte[] GenerateRandomIV()
    {
        using (TripleDESCryptoServiceProvider tripleDESAlg = new TripleDESCryptoServiceProvider())
        {
            tripleDESAlg.GenerateIV();
            return tripleDESAlg.IV;
        }
    }
}
