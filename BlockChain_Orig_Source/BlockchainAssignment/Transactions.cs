using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Transactions
    {
        public string Hash{get; set;} // The Hash
        public string Signature{get; set;} // Hash signed with private key of sender
        public string SenderAddress{get; set;} // Public key of sender
        public string RecipientAddress{get; set;} // public key of reciever 
        public DateTime TimeStamp{get; set;} // Time of transaction
        public float Amount{get; set;} // amount sent  // decimal Amount = 2.1M (suffix M needed )
        public float Fee{get; set;} // the fee added to transaction 

        Transactions()
        {

        }
        Transactions(string senderPublic, string senderPrivate, string recipientPublic, float amount, float fee)
        {
            this.TimeStamp = DateTime.Now;

            this.SenderAddress = senderPublic;

            this.RecipientAddress = recipientPublic;

            this.Amount = Amount;

            this.Fee = fee;

            this.Hash = Create256Hash();

            this.Signature = Wallet.Wallet.CreateSignature(SenderAddress, senderPrivate, Hash);
          
        }

        private string Create256Hash()
        { // i think this can be simplified // Simplified Heavily is "this" needed?
            SHA256 hasher;
            hasher = SHA256Managed.Create();
            String input = this.SenderAddress + this.RecipientAddress + this.TimeStamp.ToString() + this.Amount.ToString() + this.Fee.ToString();
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));

            String hash = string.Empty;

            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }
            return hash;

        }
    }
}
