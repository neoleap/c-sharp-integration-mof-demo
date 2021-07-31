using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;


namespace CSharpDemo
{
    class Aes
    {
        private const string SAMPLE_KEY = "10256623430310256623430310256623";
        private const string SAMPLE_IV = "PGKEYENCDECIVSPC";

        public string EncryptString(string message)
        {
            byte[] Key = ASCIIEncoding.UTF8.GetBytes(SAMPLE_KEY);
            byte[] IV = ASCIIEncoding.UTF8.GetBytes(SAMPLE_IV);

            string encrypted = null;
            RijndaelManaged rj = new RijndaelManaged
            {
                Key = Key,
                IV = IV,
                Mode = CipherMode.CBC
            };

            try
            {
                MemoryStream ms = new MemoryStream();

                using (CryptoStream cs = new CryptoStream(ms, rj.CreateEncryptor(Key, IV), CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                        sw.Close();
                    }
                    cs.Close();
                }
                byte[] encoded = ms.ToArray();
                encrypted = Convert.ToBase64String(encoded);

                ms.Close();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("A file error occurred: {0}", e.Message);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: {0}", e.Message);
            }
            finally
            {
                rj.Clear();
            }
            return Regex.Replace(BitConverter.ToString(Convert.FromBase64String(encrypted)), "-", "");
        }

        public string Decrypt(string cipherData)
        {
            byte[] key = Encoding.UTF8.GetBytes(SAMPLE_KEY);
            byte[] iv = Encoding.UTF8.GetBytes(SAMPLE_IV);

            try
            {
                using (var rijndaelManaged =
                       new RijndaelManaged { Key = key, IV = iv, Mode = CipherMode.CBC })
                using (var memoryStream =
                       new MemoryStream(Convert.FromBase64String(System.Convert.ToBase64String(HexStringToHex(cipherData)))))
                using (var cryptoStream =
                       new CryptoStream(memoryStream,
                           rijndaelManaged.CreateDecryptor(key, iv),
                           CryptoStreamMode.Read))
                {
                    return new StreamReader(cryptoStream).ReadToEnd();
                }
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
                return null;
            }
            // You may want to catch more exceptions here...
        }

        public byte[] HexStringToHex(string inputHex)
        {
            var resultantArray = new byte[inputHex.Length / 2];
            for (var i = 0; i < resultantArray.Length; i++)
            {
                resultantArray[i] = System.Convert.ToByte(inputHex.Substring(i * 2, 2), 16);
            }
            return resultantArray;
        }

    }
}
