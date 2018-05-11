using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace GiphyAPI.Helpers
{
    public class Crypto
    {
        public static String EncryptText(String Data, String Key, String IV)
        {
            // Extract the bytes of each of the values
            byte[] input = Encoding.UTF8.GetBytes(Data);
            byte[] key = Convert.FromBase64String(Key);
            byte[] iv = Convert.FromBase64String(IV);

            // Create a new instance of the algorithm with the desired settings
            RijndaelManaged algorithm = new RijndaelManaged();
            algorithm.Mode = CipherMode.CBC;
            algorithm.Padding = PaddingMode.PKCS7;
            algorithm.BlockSize = 128;
            algorithm.KeySize = 128;
            algorithm.Key = key;
            algorithm.IV = iv;

            // Create a new encryptor and encrypt the given value
            ICryptoTransform cipher = algorithm.CreateEncryptor();
            byte[] output = cipher.TransformFinalBlock(input, 0, input.Length);

            // Return the encrypted value in base64 format
            // String encrypted = Convert.ToBase64String(output);

            // Return the encrypted value in hex format
            String encrypted = BitConverter.ToString(output).Replace("-", string.Empty);

            return encrypted;
        }

        public static String DecryptText(String toDecrypt, String Key, String IV)
        {
            //String Data = Convert.ToBase64String(HexToBytes(toDecrypt));

            // Extract the bytes of each of the values
            byte[] input = HexToBytes(toDecrypt); // Convert.FromBase64String(Data);
            byte[] key = Convert.FromBase64String(Key);
            byte[] iv = Convert.FromBase64String(IV);

            // Create a new instance of the algorithm with the desired settings
            RijndaelManaged algorithm = new RijndaelManaged();
            algorithm.Mode = CipherMode.CBC;
            algorithm.Padding = PaddingMode.PKCS7;
            algorithm.BlockSize = 128;
            algorithm.KeySize = 128;
            algorithm.Key = key;
            algorithm.IV = iv;

            //FromBase64String
            // Create a new encryptor and encrypt the given value
            ICryptoTransform cipher = algorithm.CreateDecryptor();
            byte[] output = cipher.TransformFinalBlock(input, 0, input.Length);

            // Finally, convert the decrypted value to UTF8 format
            String decrypted = Encoding.UTF8.GetString(output);
            return decrypted;
        }


        public static byte[] HexToBytes(string hexString)
        {
            byte[] b = new byte[hexString.Length / 2];
            char c;
            for (int i = 0; i < hexString.Length / 2; i++)
            {
                c = hexString[i * 2];
                b[i] = (byte)((c < 0x40 ? c - 0x30 : (c < 0x47 ? c - 0x37 : c - 0x57)) << 4);
                c = hexString[i * 2 + 1];
                b[i] += (byte)(c < 0x40 ? c - 0x30 : (c < 0x47 ? c - 0x37 : c - 0x57));
            }

            return b;
        }

        public static string BytesToHex(byte[] barray, bool toLowerCase = true)
        {
            byte addByte = 0x37;
            if (toLowerCase) addByte = 0x57;
            char[] c = new char[barray.Length * 2];
            byte b;
            for (int i = 0; i < barray.Length; ++i)
            {
                b = ((byte)(barray[i] >> 4));
                c[i * 2] = (char)(b > 9 ? b + addByte : b + 0x30);
                b = ((byte)(barray[i] & 0xF));
                c[i * 2 + 1] = (char)(b > 9 ? b + addByte : b + 0x30);
            }

            return new string(c);
        }
    }
}