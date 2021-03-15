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
        public List<Transaction> transactionList { get; set; }                  // List of transactions in this block
        public DateTime timeStamp { get; set; }                                 // Time of creation
        public int index { get; set; }                                          // Position of the block in the sequence of blocks
        public int difficulty { get; set; } = 4;                                // An arbitrary number of 0's to proceed a hash value
        public long nonce { get; set; } = 0;                                    // Number used once for Proof-of-Work and mining
        public string hash { get; set; }                                        // The current blocks "identity"
        public string prevHash { get; set; }                                    // A reference pointer to the previous block
        public string merkleRoot { get; set; } = "0";                              // The merkle root of all transactions in the block
        public string minerAddress { get; set; }                                // Public Key (Wallet Address) of the Miner
        public double reward { get; set; }                                      // Simple fixed reward established by "Coinbase"



        // Constructor which is passed the previous block
        public Block(Block lastBlock) {
            this.timeStamp = DateTime.Now;
            this.nonce = 0;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.hash = this.Create256Hash();                              //    Create hash from index, prevhash and time
            this.transactionList = new List<Transaction>();
           
        }

        public Block(Block lastBlock, List<Transaction> TPool)
        {
            this.transactionList = new List<Transaction>();
            this.nonce = 0;
            this.timeStamp = DateTime.Now;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.addFromPool(TPool);
            this.hash = this.Create256Hash();    //    Create hash from index, prevhash and time
        }
        // Constructor which is passed the index & hash of previous block
        public Block(int lastIndex, string lastHash) {
            this.nonce = 0;
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
            this.hash = this.Create256Mine();                              //    Create hash from index, prevhash and time
        }

        public Block(Block lastBlock, List<Transaction> TPool, string MinerAddress)
        {
            this.transactionList = new List<Transaction>();
            this.nonce = 0;
            this.timeStamp = DateTime.Now;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.addFromPool(TPool);
            this.hash = this.Create256Mine();    //    Create hash from index, prevhash and time
        }

        public override string ToString()
        {
            return ("\n\n\t\t[BLOCK START]"
                + "\nIndex: " + this.index
                + "\tTimestamp: " + this.timeStamp
                + "\nPrevious Hash: " + this.prevHash
                + "\n\t\t-- PoW --"
                + "\nDifficulty Level: " + this.difficulty
                + "\nNonce: " + this.nonce
                + "\nHash: " + this.hash
                + "\n\t\t-- Rewards --"
                + "\nReward: " + this.reward
                + "\nMiners Address: " + this.minerAddress
                + "\n\t\t-- " + this.transactionList.Count + " Transactions --"
                + "\nMerkle Root: " + this.merkleRoot
                + "\n" + String.Join("\n", this.transactionList)
                + "\n\t\t[BLOCK END]");
                /*("[BLOCK START]"
                + "\nIndex: " + this.index
                + "\tTimestamp: " + this.timeStamp
                + "\nPrevious Hash: " + this.prevHash
                + "\n\t\t-- PoW --"
                + "\nDifficulty Level: " + this.difficulty
                + "\nNonce: " + this.nonce
                + "\nHash: " + this.hash
                + "\n\t\t-- Rewards --"
                + "\nReward: " + this.reward
                + "\nMiners Address: " + this.minerAddress
                + "\n\t\t-- " + this.transactionList.Count + " Transactions --"
                + "\nMerkle Root: " + this.merkleRoot
                + "\n" + String.Join("\n", this.transactionList)
                + "\n\t\t[BLOCK END]");*/
        }
        public string ReturnString() {
            return ("\n\n\t\t[BLOCK START]"
                + "\nIndex: " + this.index
                + "\tTimestamp: " + this.timeStamp
                + "\nPrevious Hash: " + this.prevHash
                + "\n\t\t-- PoW --"
                + "\nDifficulty Level: " + this.difficulty
                + "\nNonce: " + this.nonce
                + "\nHash: " + this.hash
                + "\n\t\t-- Rewards --"
                + "\nReward: " + this.reward
                + "\nMiners Address: " + this.minerAddress
                + "\n\t\t-- " + this.transactionList.Count + " Transactions --"
                + "\nMerkle Root: " + this.merkleRoot
                + "\n" + String.Join("\n", this.transactionList)
                + "\n\t\t[BLOCK END]");
       
                
                /*(" The Block with Index: " + this.index +
                    "\n Creates a hash value of: " + this.hash +
                    "\n By using the previous hash of: " + this.prevHash +
                    "\n And the timestamp of when the block was created: " + this.timeStamp +
                    "\n The Block has "+this.transactionList.Count+ " associated transactions. "
                    );*/
        }

        public string readblock()
        {
            string s = "";
            s += this.ToString();

            foreach (Transaction T in transactionList)
            {
                s += ("\n" + T.ToString());
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

       
        private string Create256Hash()
        { // i think this can be simplified // Simplified Heavily is "this" needed?
            SHA256 hasher;
            hasher = SHA256Managed.Create();
            String input = this.index.ToString() + this.timeStamp.ToString() + this.prevHash+this.nonce;
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));

            String hash = string.Empty;

            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }
            return hash;


        }

        private string Create256Mine()
        {             
            string hash =  "";          // could also do Createhash here, then no need to nonce--
            string diffString = new string('0', this.difficulty);
            while (hash.StartsWith(diffString)== false)
            {
                hash = this.Create256Hash();
                this.nonce++;
            }
            this.nonce--;

            return hash;


        }

        public static string MerkleRoot(List<Transaction> transactionList) {

            // X => f(X) means given X return f(X)
            List<String> hashes = transactionList.Select(t => t.Hash).ToList(); // Get a list of transaction hashes for "combining"
            // Handle Blocks with...
            if (hashes.Count == 0) // No transactions
            {
                return String.Empty;
            }
            else if (hashes.Count == 1) // One transaction - hash with "self"
            {
                return HashCode.HashTools.combineHash(hashes[0], hashes[0]);
            }
            while (hashes.Count != 1) // Multiple transactions - Repeat until tree has been traversed
            {
                List<String> merkleLeaves = new List<String>(); // Keep track of current "level" of the tree

                for (int i = 0; i < hashes.Count; i += 2) // Step over neighbouring pair combining each
                {
                    if (i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i])); // Handle an odd number of leaves
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i + 1])); // Hash neighbours leaves
                    }
                }
                hashes = merkleLeaves; // Update the working "layer"
            }
            return hashes[0]; // Return the root node
        }

        // Create reward for incentivising the mining of block
        public Transaction createRewardTransaction(List<Transaction> transactions)
        {
            double fees = transactions.Aggregate(0.0, (acc, t) => acc + t.Fee); // Sum all transaction fees
            return new Transaction("Mine Rewards", "", minerAddress, (this.reward + fees), 0); // Issue reward as a transaction in the new block
        }
        private string ArchivedCreate256Hash() { // i think this can be simplified // Simplified Heavily is "this" needed?
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
