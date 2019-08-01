using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography{
    
    class RAS_Helper{

        public string EncriptarTexto(string publickey, string text){
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes(text);

            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()){
                rsa.FromXmlString(publickey);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            return byteConverter.GetString(encryptedData);
        }

        public string DecriptarTexto(string privatekey, string ctext){
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToDecrypt = byteConverter.GetBytes(ctext);

            byte[] decryptedData;
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider()){
                rsa.FromXmlString(privatekey);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }

            return byteConverter.GetString(decryptedData);
        }
    }
}