using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Block
    {
        //private DateTime timeStamp;
        //private int index;
        //private string hash;
        //private string prevHash;
        public List<Transaction> transactionList { get; set; }
        public DateTime timeStamp { get; set; }
        public int index { get; set; }
        public string hash { get; set; }
        public string prevHash { get; set; }

        // Constructor which is passed the previous block
        public Block(Block lastBlock) {
            this.timeStamp = DateTime.Now;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.hash = this.Create256Hash();                              //    Create hash from index, prevhash and time
            this.transactionList = new List<Transaction>();
        }

        public Block(Block lastBlock, List<Transaction> TPool)
        {
            this.transactionList = new List<Transaction>();
            this.timeStamp = DateTime.Now;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.addFromPool(TPool);
            this.hash = this.Create256Hash();    //    Create hash from index, prevhash and time
        }
        // Constructor which is passed the index & hash of previous block
        public Block(int lastIndex, string lastHash) {
            this.timeStamp = DateTime.Now;                      // new time
            this.index = lastIndex + 1;                         // increment on last block
            this.prevHash = lastHash;                               //needs fixing 
            this.hash = this.Create256Hash();                              //    Create hash from index, prevhash and time
        }

        // Constructor which is not passed anything
        public Block() {
            // This generates the Genesis Block 
            this.transactionList = new List<Transaction>();
            this.timeStamp = DateTime.Now;                                    // new time
            this.index = 0;                                                  //  First Block = 0 
            this.prevHash = string.Empty;                                   //   No Previous Hash  
            this.hash = this.Create256Hash();                              //    Create hash from index, prevhash and time
        }

        /* OLD GETTER / SETTERS 
                public DateTime GetTimeStamp() { return this.timeStamp; }
                public int GetIndex() { return this.index; }
                public string GetHash() { return this.hash; }
                */

        public string ReturnString() {
            return (" The Block with Index: " + this.index +
                    "\n Creates a hash value of: " + this.hash +
                    "\n By using the previous hash of: " + this.prevHash +
                    "\n And the timestamp of when the block was created: " + this.timeStamp +
                    "\n The Block has "+this.transactionList.Count+ " associated transactions. "
                    );
        }


        public string readblock()
        {
            string s = "";
            s += this.ReturnString();

            foreach (Transaction T in transactionList)
            {
                s += ("\n" + T.ReturnString());
            }
            return s;

        }


        public void add2TList(Transaction T)
        {
            this.transactionList.Add(T);
        }

        public void addFromPool(List<Transaction> TP )
        {
            int LIMIT = 5;
            for (int i = 0; ((i < TP.Count) && (i < LIMIT)); i++   )
            {
                this.transactionList.Add(TP.ElementAt(i));
            }
        }

            

        

        private string Create256Hash() { // i think this can be simplified // Simplified Heavily is "this" needed?
            SHA256 hasher;
            hasher = SHA256Managed.Create();
            String input = this.index.ToString() + this.timeStamp.ToString() + this.prevHash;
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
