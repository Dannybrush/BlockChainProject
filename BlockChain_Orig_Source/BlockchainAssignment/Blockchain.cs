using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        public int maxBlock { get => this.Blocks.Count;}
        List<Block> Blocks = new List<Block>();
        List<Transaction> TransactionPool = new List<Transaction>();

        public Blockchain()
        {
            Block genesis = new Block();
            Blocks.Add(genesis);
            // Blocks.Add(new Block());             // Another way of writing the same thing 

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

        public void purgeTPool(List<Transaction> chosenT)
        {
            TransactionPool = TransactionPool.Except(chosenT).ToList();
        }
        public Block getLastBlock()
        {
            return Blocks[Blocks.Count - 1];
        }

        public List<Transaction> retTPool() {
            return TransactionPool;
        }

    }
}
