using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Blockchain
    {
        List<Block> Blocks = new List<Block>();
        List<Transaction> TransactionPool = new List<Transaction>();

        public Blockchain()
        {
            Block genesis = new Block();
            Blocks.Add(genesis);
            // Blocks.Add(new Block());             // Another way of writing the same thing 
 
        }
        public string BlockString(int index) {
            return (Blocks.ElementAt(index).ReturnString());
        }
        public void add2TPool(Transaction Trans)
        {
            TransactionPool.Add(Trans);
        }
    }
}
