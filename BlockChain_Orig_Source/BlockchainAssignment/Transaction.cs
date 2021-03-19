using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Transaction
    {
        public string Hash{get; set;} // The Hash
        public string Signature{get; set;} // Hash signed with private key of sender
        public string SenderAddress{get; set;} // Public key of sender
        public string RecipientAddress{get; set;} // public key of reciever 
        public DateTime TimeStamp{get; set;} // Time of transaction
        public double Amount{get; set;} // amount sent  // decimal Amount = 2.1M (suffix M needed )
        public double Fee{get; set;} // the fee added to transaction 

        public Transaction()
        {

        }
        public Transaction(string senderPublic, string senderPrivate, string recipientPublic, double amount, double fee)
        {
            this.TimeStamp = DateTime.Now;

            this.SenderAddress = senderPublic;

            this.RecipientAddress = recipientPublic;

            this.Amount = amount;

            this.Fee = fee;

            this.Hash = Create256Hash();

            this.Signature = Wallet.Wallet.CreateSignature(SenderAddress, senderPrivate, Hash);
          
        }

        private string Create256Hash()
        { // i think this can be simplified // Simplified Heavily is "this" needed?

            SHA256 hasher;
            hasher = SHA256Managed.Create();

            /* Concatenate all transaction properties */
            String input = this.SenderAddress + this.RecipientAddress + this.TimeStamp.ToString() + this.Amount.ToString() + this.Fee.ToString();
            /* Apply the hash function to the "input" string */
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));

            String hash = string.Empty;


            /* Reformat to a string */
            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }
            return hash;

        }

        /* Two  similar implementations to print the contents of a transaction: one using the ToString Override*/
        public override string ToString()
        {
            return ("[TRANSACTION START]"
                + "\n\t  Timestamp: " + this.TimeStamp
                + "\n  -- Verification --"
                + "\n\t  Hash: " + this.Hash
                + "\n\t  Signature: " + this.Signature
                + "\n  -- Quantities --"
                + "\n\t  Transferred: " + this.Amount + " Energy Drink Induced Crypto Coin"
                + "\t  Fee: " + this.Fee
                + "\n  -- Participants --"
                + "\n\t  Sender: " + this.SenderAddress
                + "\n\t  Reciever: " + this.RecipientAddress
                + "\n  [TRANSACTION END]");
        }
        public string ReturnString()
        {
            return ("[TRANSACTION START]"
                + "\n\t  Timestamp: " + this.TimeStamp
                + "\n  -- Verification --"
                + "\n\t  Hash: " + this.Hash
                + "\n\t  Signature: " + this.Signature
                + "\n  -- Quantities --"
                + "\n\t  Transferred: " + this.Amount + " Energy Drink Induced Crypto Coin"
                + "\t  Fee: " + this.Fee
                + "\n  -- Participants --"
                + "\n\t  Sender: " + this.SenderAddress
                + "\n\t  Reciever: " + this.RecipientAddress
                + "\n  [TRANSACTION END]");

            /*("Requested by:  27016005 " +
                "\n Transaction Hash: " + this.Hash +
                "\n Digital Signature: " + this.Signature +
                "\n Timestamp: " + this.TimeStamp +
                "\n Transferred: " + this.Amount + 
                "\n Fees: "+this.Fee +
                "\n Sender Address: " + this.SenderAddress +
                "\n Receiver Address: "+ this.RecipientAddress +
                ". "
                );*/
        }

    }
}
