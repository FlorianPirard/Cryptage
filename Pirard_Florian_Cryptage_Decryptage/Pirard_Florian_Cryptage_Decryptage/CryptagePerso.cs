using System.Text;

namespace Pirard_Florian_Cryptage_Decryptage
{
    public class CryptagePerso
    {
        public string Crypter(string texte, int decalage)
        {
            StringBuilder texteCrypte = new StringBuilder();

            foreach (char caractere in texte)
            {
                texteCrypte.Append(CrypterCaractere(caractere, decalage));
            }

            return texteCrypte.ToString();
        }

        public string Decrypter(string texte, int decalage)
        {
            return Crypter(texte, -decalage);
        }

        public char CrypterCaractere(char caractere, int decalage)
        {
            if (char.IsLetter(caractere))
            {
                char baseChar = char.IsUpper(caractere) ? 'A' : 'a';
                return (char)((caractere - baseChar + decalage + 26) % 26 + baseChar);
            }
            return caractere;
        }
    }

}