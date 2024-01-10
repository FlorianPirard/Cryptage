using System;
using System.Text;
using System.Security.Cryptography;

namespace Pirard_Florian_Cryptage_Decryptage
{
    public class CryptageDotNet
    {
        private RSACryptoServiceProvider rsaCryptoProvider;
        private string publicKey;
        private string privateKey;

        public CryptageDotNet()
        {
            GenerateRSAKeys();
        }

        public string PublicKey
        {
            get
            {
                var xmlDoc = new System.Xml.XmlDocument();
                xmlDoc.LoadXml(publicKey);
                var modulus = xmlDoc.SelectSingleNode("//Modulus").InnerText;
                return modulus;
            }
        }

        public string CrypterRSA(string texteClair)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(texteClair);
            byte[] texteCrypteBytes = rsa.Encrypt(dataToEncrypt, false);

            return Convert.ToBase64String(texteCrypteBytes);
        }

        public string DecrypterRSA(string texteCrypteBase64)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            byte[] texteCrypteBytes = Convert.FromBase64String(texteCrypteBase64);
            byte[] decryptedData = rsa.Decrypt(texteCrypteBytes, false);

            return Encoding.UTF8.GetString(decryptedData);
        }

        public void GenerateRSAKeys()
        {
            rsaCryptoProvider = new RSACryptoServiceProvider();
            publicKey = rsaCryptoProvider.ToXmlString(false);
            privateKey = rsaCryptoProvider.ToXmlString(true);
        }
    }
}