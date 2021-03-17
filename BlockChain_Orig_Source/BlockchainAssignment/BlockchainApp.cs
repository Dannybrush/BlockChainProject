using System;
using System.Drawing;
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
            outputToRichTextBox1("New Blockchain Initialised by 27016005");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
               // Produces error when attempting to print nothing
        private void printBtn_Click(object sender, EventArgs e)
        {
            // richTextBox1.Text = indexInput.Text;         // first gen
            // outputToRichTextBox1(indexInput.Text);       // second gen
            if (Int32.TryParse(indexTBox.Text, out int index))
                outputToRichTextBox1(blockchain.GetBlockAsString(index));
            else
                outputToRichTextBox1("Invalid Block No.");
           // outputToRichTextBox1(blockchain.BlockString();
        }

        private void outputToRichTextBox1(string toBePrinted) { richTextBox1.Text = toBePrinted; }
        private void outputToTextBox(TextBox TBox, string toBePrinted) { TBox.Text = toBePrinted; }

        private void GenWalletBtn_Click(object sender, EventArgs e)
        {
            //String privKey;
            Wallet.Wallet myNewWallet = new Wallet.Wallet(out string privKey);
            String publicKey = myNewWallet.publicID;
            //Console.WriteLine(publicKey + "\n" + privKey);
            outputToTextBox(privKeyTBox, privKey);
            outputToTextBox(pubKeyTBox, publicKey) ;
        }

        private void ValKeysBtn_Click(object sender, EventArgs e)
        {
            Color color; 
           color =  Wallet.Wallet.ValidatePrivateKey(privKeyTBox.Text, pubKeyTBox.Text) ? Color.Green : Color.Red;
            valKeysBtn.BackColor = color;
        }

        private void CreateTransBtn_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(pubKeyTBox.Text, privKeyTBox.Text, recieverKeyTBox.Text, Convert.ToSingle(amountTBox.Text), Convert.ToSingle(feeTBox.Text));
            blockchain.add2TPool(transaction);
            outputToRichTextBox1(transaction.ReturnString());
        }

        private void BlockGenBtn_Click(object sender, EventArgs e)
        {
            Block block = new Block(blockchain.GetLastBlock());
            blockchain.add2Block(block);
        }
        /*private void BlockGenwithTransBtn_Click(object sender, EventArgs e)
        {
            Block block = new Block(blockchain.getLastBlock());
            blockchain.add2Block(block);
        }*/
        private void PrintAllBtn_Click(object sender, EventArgs e)
        {
            string printall = "";
            for (int i = 0; i < blockchain.maxBlock; i++)
            {
                printall += (blockchain.BlockString(Convert.ToInt32(i)) + "\n \n");
            }
            outputToRichTextBox1(printall);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Block block = new Block(blockchain.GetLastBlock(), blockchain.retTPool(), pubKeyTBox.Text);
            blockchain.purgeTPool(block.transactionList);
            blockchain.add2Block(block);
        }

        private void ReadPendTrandBtn_Click(object sender, EventArgs e)
        {string s = "";
            foreach (Transaction T in blockchain.retTPool()) {
               s+= T +": \n "+T.ReturnString() + "\n \n ";
            }
            outputToRichTextBox1(s);
        }


        /*If Text in Key boxes changes, Reset validation 
         
             In future there is possibility to autonomise this so a button is not required. */
        private void PubKeyTBox_TextChanged(object sender, EventArgs e)
        {
            valKeysBtn.BackColor = Color.AntiqueWhite;
        }
        private void PrivKeyTBox_TextChanged(object sender, EventArgs e)
        {
            valKeysBtn.BackColor = Color.AntiqueWhite;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            outputToRichTextBox1(blockchain.ToString());
        }

        private void BlockchainApp_Load(object sender, EventArgs e)
        {

        }

          private void IndexInput_TextChanged(object sender, EventArgs e)
        {

        }
    

        private void Validate_Click(object sender, EventArgs e)
        {
            // CASE: Genesis Block - Check only hash as no transactions are currently present
            if (blockchain.Blocks.Count == 1)
            {
                if (!Blockchain.ValidateHash(blockchain.Blocks[0])) // Recompute Hash to check validity
                    outputToRichTextBox1("Blockchain is invalid");
                else
                    outputToRichTextBox1("Blockchain is valid");
                return;
            }

            for (int i = 1; i < blockchain.Blocks.Count - 1; i++)
            {
                if (
                    blockchain.Blocks[i].prevHash != blockchain.Blocks[i - 1].hash || // Check hash "chain"
                    !Blockchain.ValidateHash(blockchain.Blocks[i]) ||  // Check each Block hash
                    !Blockchain.ValidateMerkleRoot(blockchain.Blocks[i]) // Check transaction integrity using Merkle Root
                )
                {
                    outputToRichTextBox1("Blockchain is invalid");
                    return;
                }
            }
            outputToRichTextBox1("Blockchain is valid");
        }
    }
}
