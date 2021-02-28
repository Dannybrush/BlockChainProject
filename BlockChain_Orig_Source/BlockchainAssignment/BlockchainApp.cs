﻿using System;
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
            outputToRichTextBox1(blockchain.BlockString(Convert.ToInt32(indexTBox.Text)));
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

        private void CreateTransBtn_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(pubKeyTBox.Text, privKeyTBox.Text, recieverKeyTBox.Text, Convert.ToSingle(amountTBox.Text), Convert.ToSingle(feeTBox.Text));
            blockchain.add2TPool(transaction);
            outputToRichTextBox1(transaction.ReturnString());
        }

        private void BlockGenBtn_Click(object sender, EventArgs e)
        {
            Block block = new Block(blockchain.getLastBlock());
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
            Block block = new Block(blockchain.getLastBlock(), blockchain.retTPool());
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
    }
}
