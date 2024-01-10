using System;
using System.Windows.Forms;

namespace Pirard_Florian_Cryptage_Decryptage
{
    public partial class ApplicationCryptage : Form
    {
        public CryptagePerso cryptagePerso;
        public CryptageDotNet cryptageDotNet;

        public ApplicationCryptage()
        {
            InitializeComponent();

            cryptagePerso = new CryptagePerso();
            cryptageDotNet = new CryptageDotNet();
            TexteCle.Enter += TexteCle_Enter;
        }
        private void TexteCle_Enter(object sender, EventArgs e)
        {
            TexteCle.Text = string.Empty;
        }
        private void DecryptagePerso_Click(object sender, EventArgs e)
        {
            string texteCrypte = TexteCryptePerso.Text;
            int cle;

            if (int.TryParse(TexteCle.Text, out cle) && cle >= 0 && cle <= 25)
            {
                string texteClair = cryptagePerso.Decrypter(texteCrypte, cle);
                TexteDecryptePerso.Text = texteClair;
                FlecheHautPerso.Visible = true;
                FlecheBasPerso.Visible = false;
                FlecheBasNet.Visible = false;
                FlecheHautNet.Visible = false;
            }
            else
            {
                MessageBox.Show("Veuillez entrer une clé numérique valide entre 0 et 25.");
            }
        }

        private void CryptagePerso_Click(object sender, EventArgs e)
        {
            string texteClair = TexteDecryptePerso.Text;
            int cle;

            if (int.TryParse(TexteCle.Text, out cle) && cle >= 0 && cle <= 25)
            {
                string texteCrypte = cryptagePerso.Crypter(texteClair, cle);
                TexteCryptePerso.Text = texteCrypte;
                FlecheHautPerso.Visible = false;
                FlecheBasPerso.Visible = true;
                FlecheBasNet.Visible = false;
                FlecheHautNet.Visible = false;
            }
            else
            {
                MessageBox.Show("Veuillez entrer une clé numérique valide entre 0 et 25.");
            }
        }

        private void CryptageNet_Click(object sender, EventArgs e)
        {
            FlecheHautPerso.Visible = false;
            FlecheBasPerso.Visible = false;
            FlecheBasNet.Visible = true;
            FlecheHautNet.Visible = false;

            string texteClair = TexteDecrypteNet.Text;
            string texteCrypte = cryptageDotNet.CrypterRSA(texteClair);
            TexteCrypteNet.Text = texteCrypte;

            TexteCle.Text = cryptageDotNet.PublicKey;
        }

        private void DecryptageNet_Click(object sender, EventArgs e)
        {
            FlecheHautPerso.Visible = false;
            FlecheBasPerso.Visible = false;
            FlecheBasNet.Visible = false;
            FlecheHautNet.Visible = true;
            string texteCrypteBase64 = TexteCrypteNet.Text;
            string texteClair = cryptageDotNet.DecrypterRSA(texteCrypteBase64);
            TexteDecrypteNet.Text = texteClair;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FlecheHautPerso.Visible = false;
            FlecheBasPerso.Visible = false;
            FlecheBasNet.Visible = false;
            FlecheHautNet.Visible = false;
        }

        private void Quitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
