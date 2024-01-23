using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace BankingProyect.Utils
{
	public static class Cryptographic
	{
		public static byte[] EncryptStringToByte(string plainText, string Key, byte[] IV)
		{
			byte[] encrypted;

			if (plainText == null && plainText.Length <= 0)
				throw new ArgumentNullException("plainText");
			if (Key == null && Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null && IV.Length <= 0)
				throw new ArgumentNullException("IV");

			//Step 1: Create an object Rijndael
			
			using (Rijndael myRijndael = Rijndael.Create())
			{
				myRijndael.Key = Encoding.UTF8.GetBytes(Key);
				myRijndael.IV = IV;

				//Step 2: Create object encrytor
				ICryptoTransform encryptor = myRijndael.CreateEncryptor(myRijndael.Key, myRijndael.IV);

				//Step 3: Create the stream used for encryption

				using (MemoryStream msEncrypt = new MemoryStream())
				{
					using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
						{
							//Step 4: Write data in to the stream
							swEncrypt.Write(plainText);	
						}
						encrypted = msEncrypt.ToArray();
					}

				}

			}

			return encrypted;
		}

		public static string DecryptStringFromBytes(byte[] cipherText, string Key, byte[] IV)
		{
			string plaintext = string.Empty;

			if (cipherText == null && cipherText.Length <= 0)
				throw new ArgumentNullException("cipherText");
			if (Key == null && Key.Length <= 0)
				throw new ArgumentNullException("Key");
			if (IV == null && IV.Length <= 0)
				throw new ArgumentNullException("IV");

			//Step 1: Create an object Rijndael 
			using (Rijndael myRijndael = Rijndael.Create())
			{
				myRijndael.Key = Encoding.UTF8.GetBytes(Key);
				myRijndael.IV = IV;


				// Step 2: Create an object decryptor
				ICryptoTransform decryptor = myRijndael.CreateDecryptor(myRijndael.Key, myRijndael.IV);


				//Step 3: Create stream decryptor 
				using (MemoryStream msDecryptor = new MemoryStream(cipherText))
				{
					using (CryptoStream csDecrytor = new CryptoStream(msDecryptor, decryptor, CryptoStreamMode.Read))
					{
						using (StreamReader srDecryptor = new StreamReader(csDecrytor))
						{
							//Step 4: Read the decrypted from byte decrypting stream

							plaintext = srDecryptor.ReadToEnd();

						}

					}
				}
			}

			return plaintext;

		}

	}
}
