using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockchainAssignment
{
    public partial class BlockchainApp : Form
    {
        Blockchain blockchain;
        public BlockchainApp()
        {
            InitializeComponent();
            blockchain = new Blockchain();
            richTextBox1.Text = "New Blockchain Initialised by 27016005";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
               // Produces error when attempting to print nothing
        private void printBtn_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text = indexInput.Text;         // first gen
            // outputToRichTextBox1(indexInput.Text);       // second gen
            outputToRichTextBox1(blockchain.BlockString(Convert.ToInt32(indexInput.Text)));
        }

        private void outputToRichTextBox1(string toBePrinted) { richTextBox1.Text = toBePrinted; }
        private void outputToTextBox(TextBox TBox, string toBePrinted) { TBox.Text = toBePrinted; }

        private void IndexInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void GenWalletBtn_Click(object sender, EventArgs e)
        {
            String privKey;
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out privKey);
            String publicKey = myNewWallet.publicID;
            Console.WriteLine(publicKey + "\n" + privKey);
            outputToTextBox(privKeyTBox, privKey);
            outputToTextBox(pubKeyTBox, publicKey) ;
        }

        private void ValKeysBtn_Click(object sender, EventArgs e)
        {
            Color color; 
           color =  Wallet.Wallet.ValidatePrivateKey(privKeyTBox.Text, pubKeyTBox.Text) ? Color.Green : Color.Red;
            valKeysBtn.BackColor = color;
        }
    }
}
