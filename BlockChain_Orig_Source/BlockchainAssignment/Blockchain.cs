using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        public int maxBlock { get => this.Blocks.Count; }                                    // Maximum number of transactions per block
        public List<Block> Blocks = new List<Block>();                                      // List of block objects forming the blockchain
        public List<Transaction> TransactionPool = new List<Transaction>();                // List of pending transactions to be mined

        public Blockchain()
        {
            Block genesis = new Block();
            Blocks.Add(genesis);
            // Blocks.Add(new Block());             // Another way of writing the same thing 
            /* and another way
             * blocks = new List<Block>()
            {
                new Block() // Create and append the Genesis Block
            };
            */
        }
        public string BlockString(int index)
        {
            return (Blocks.ElementAt(index).ReturnString());
        }


        public void add2TPool(Transaction Trans)
        {
            TransactionPool.Add(Trans);
        }
        public void add2Block(Block blck)
        {
            Blocks.Add(blck);
        }

        // Prints the block at the specified index to the UI
        public String GetBlockAsString(int index)
        {
            // Check if referenced block exists
            if (index >= 0 && index < Blocks.Count)
                return Blocks[index].ToString(); // Return block as a string
            else
                return "No such block exists";
        }
        public void purgeTPool(List<Transaction> chosenT)
        {
            TransactionPool = TransactionPool.Except(chosenT).ToList();
        }
        public Block GetLastBlock()
        {
            return Blocks[Blocks.Count - 1];
        }

        public List<Transaction> retTPool() {
            return TransactionPool;
        }
        public override string ToString()
        {
            return string.Join("\n", Blocks);
        }

        // Check validity of a blocks hash by recomputing the hash and comparing with the mined value
        public static bool ValidateHash(Block b){
            String rehash = b.Create256Hash();
            return rehash.Equals(b.hash);
        }

        // Check the balance associated with a wallet based on the public key
        public double GetBalance(String address)
        {
            // Accumulator value
            double balance = 0;

            // Loop through all approved transactions in order to assess account balance
            foreach (Block b in Blocks)
            {
                foreach (Transaction t in b.transactionList)
                {
                    if (t.RecipientAddress.Equals(address))
                    {
                        balance += t.Amount; // Credit funds recieved
                    }
                    if (t.SenderAddress.Equals(address))
                    {
                        balance -= (t.Amount + t.Fee); // Debit payments placed
                    }
                }
            }
            return balance;
        }

        // Check validity of the merkle root by recalculating the root and comparing with the mined value
        public static bool ValidateMerkleRoot(Block b){
            String reMerkle = Block.MerkleRoot(b.transactionList);
            return reMerkle.Equals(b.merkleRoot);
        }
    }
}
