using System;
using System.IO;
using System.Security.Cryptography;



class RSAEncryption
{
    static void Main(string[] args)
    {
        // Get plaintext message from user input
        Console.Write("Enter plaintext message: ");
        string plaintext = Console.ReadLine();

        // Convert plaintext to bytes
        byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);

        // Generate a new RSA key pair
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // Get the public key
            string publicKey = rsa.ToXmlString(false);
            Console.WriteLine("Public Key: " + publicKey);

            // Encrypt the plaintext using the public key
            byte[] ciphertextBytes = rsa.Encrypt(plaintextBytes, false);

            // Print the ciphertext
            Console.WriteLine("Ciphertext: " + Convert.ToBase64String(ciphertextBytes));

            // Get the private key
            string privateKey = rsa.ToXmlString(true);

            // Decrypt the ciphertext using the private key
            byte[] decryptedBytes = rsa.Decrypt(ciphertextBytes, false);

            // Convert decrypted bytes to plaintext
            string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);

            // Print the decrypted plaintext
            Console.WriteLine("Decrypted plaintext: " + decryptedText);
        }
    }
}



//AES Encryption
/*

class AESEncryption
{
    static void Main(string[] args)
    {
        // Get plaintext message from user input
        Console.Write("Enter plaintext message: ");
        string plaintext = Console.ReadLine();

        // Get key from user input
        Console.Write("Enter key: ");
        string key = Console.ReadLine();

        // Convert plaintext and key to bytes
        byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);

        // Create an Aes object with the specified key
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV(); // automatically generates a new IV

            // Create a encryptor to perform the stream transformation.
            ICryptoTransform encryptor = aes.CreateEncryptor();

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // Write the plaintext bytes to the stream
                    csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
                    csEncrypt.FlushFinalBlock();

                    // Get the ciphertext bytes from the stream
                    byte[] ciphertextBytes = msEncrypt.ToArray();

                    // Print the ciphertext
                    Console.WriteLine("Ciphertext: " + Convert.ToBase64String(ciphertextBytes));
                }
            }
        }
    }
}

*/




//or


/*
class AESEncryption
{
    static void Main(string[] args)
    {
        // Get plaintext message from user input
        Console.Write("Enter plaintext message: ");
        string plaintext = Console.ReadLine();

        // Get key from user input
        Console.Write("Enter key: ");
        string key = Console.ReadLine();

        // Check key length
        if (key.Length != 16 && key.Length != 24 && key.Length != 32)
        {
            Console.WriteLine("Error: Invalid key length. Key must be 128, 192, or 256 bits (16, 24, or 32 bytes).");
            return;
        }

        // Convert plaintext and key to bytes
        byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);

        // Create an Aes object with the specified key
        using (Aes aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.GenerateIV(); // automatically generates a new IV

            // Create a encryptor to perform the stream transformation.
            ICryptoTransform encryptor = aes.CreateEncryptor();

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    // Write the plaintext bytes to the stream
                    csEncrypt.Write(plaintextBytes, 0, plaintextBytes.Length);
                    csEncrypt.FlushFinalBlock();

                    // Get the ciphertext bytes from the stream
                    byte[] ciphertextBytes = msEncrypt.ToArray();

                    // Print the ciphertext
                    Console.WriteLine("Ciphertext: " + Convert.ToBase64String(ciphertextBytes));
                }
            }
        }
    }
}
*/