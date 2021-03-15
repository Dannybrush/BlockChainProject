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

            // Message printed when initialised
            richTextBox1.Text = "New Blockchain Initialised!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 0;
            if(Int32.TryParse(textBox1.Text, out index))
            {
                richTextBox1.Text = blockchain.getBlockAsString(index);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String privKey;
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out privKey);
            publicKey.Text = myNewWallet.publicID;
            privateKey.Text = privKey;
        }

        /* Validate Keys */
        private void button3_Click(object sender, EventArgs e)
        {
            if(Wallet.Wallet.ValidatePrivateKey(privateKey.Text, publicKey.Text))
            {
                richTextBox1.Text = "Keys are valid!";
            }
            else
            {
                richTextBox1.Text = "Keys are not valid";
            }
        }

        private void createTransaction_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(publicKey.Text, receiverKey.Text, Double.Parse(amount.Text), Double.Parse(fee.Text), privateKey.Text);
            blockchain.transactionPool.Add(transaction);
            richTextBox1.Text = transaction.ToString();
        }

        private void newBlock_Click(object sender, EventArgs e)
        {
            List<Transaction> transactions = blockchain.getPendingTransactions();
            Block newBlock = new Block(blockchain.GetLastBlock(), transactions, publicKey.Text);
            blockchain.Blocks.Add(newBlock);

            richTextBox1.Text = blockchain.ToString();
        }

        private void validateChain_Click(object sender, EventArgs e)
        {
            if(blockchain.Blocks.Count == 1)
            {
                if (!blockchain.validateMerkleRoot(blockchain.Blocks[0]))
                {
                    richTextBox1.Text = "Blockchain is invalid";
                }
                else
                {
                    richTextBox1.Text = "Blockchain is valid";
                }
                return;
            }
            bool valid = true;
            for(int i=1; i<blockchain.Blocks.Count - 1; i++)
            {
                if(blockchain.Blocks[i].prevHash != blockchain.Blocks[i - 1].hash || !blockchain.validateMerkleRoot(blockchain.Blocks[i]))
                {
                    richTextBox1.Text = "Blockchain is invalid";
                    return;
                }
            }
            if (valid)
            {
                richTextBox1.Text = "Blockchain is valid";
            }
            else
            {
                richTextBox1.Text = "Blockchain is invalid";
            }
        }

        private void checkBalancce_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = blockchain.GetBalance(publicKey.Text).ToString() + " Assignment Coin";
        }
    }
}
