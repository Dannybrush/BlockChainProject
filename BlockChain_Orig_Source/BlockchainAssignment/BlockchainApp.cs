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

        private void printButton_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text = indexInput.Text;         // first gen
            // outputToRichTextBox1(indexInput.Text);       // second gen
            outputToRichTextBox1(blockchain.BlockString(Convert.ToInt32(indexInput.Text)));
        }

        private void outputToRichTextBox1(string toBePrinted) { richTextBox1.Text = toBePrinted; }

        private void IndexInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
