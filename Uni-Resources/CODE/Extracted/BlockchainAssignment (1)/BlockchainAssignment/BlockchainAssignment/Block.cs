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
        DateTime timestamp;
        public int index;
        public String hash;
        public String prevHash;

        public List<Transaction> transactionList = new List<Transaction>();
        public String merkleRoot;

        // Proof-of-work
        public long nonce = 0;
        public int difficulty = 4;

        //Rewards and fees
        public double reward = 1.0; // Fixed logic 
        public double fees = 0.0;

        public String minerAddress = String.Empty;


        /* Genesis Block Constructor */
        public Block()
        {
            timestamp = DateTime.Now;
            index = 0;
            prevHash = String.Empty;
            reward = 0;
            hash = Mine();
        }

        public Block(String prevHash, int index)
        {
            timestamp = DateTime.Now;
            this.prevHash = prevHash;
            this.index = index + 1;
            hash = CreateHash();
        }

        public Block(Block lastBlock, List<Transaction> transactions, String address = "")
        {
            timestamp = DateTime.Now;
            prevHash = lastBlock.hash;
            index = lastBlock.index + 1;

            minerAddress = address;

            transactions.Add(CreateRewardTransaction(transactions));
            transactionList = transactions;

            merkleRoot = MerkleRoot(transactionList);

            hash = Mine();
        }

        public Transaction CreateRewardTransaction(List<Transaction> transactions)
        {
            // Sum the fees in the list of transactions in the mined block
            fees = transactions.Aggregate(0.0, (acc, t) => acc + t.fee);

            // Create the "Reward Transaction" being the sum of fees and reward being transferred from "Mine Rewards" (Coin Base) to miner
            return new Transaction("Mine Rewards", minerAddress, (reward + fees), 0, "");
        }

        public String CreateHash()
        {
            String hash = String.Empty;
            SHA256 hasher = SHA256Managed.Create();

            //Concatenate all Block properties for hashing
            String input = index.ToString() + timestamp.ToString() + prevHash + nonce.ToString() + reward.ToString() + merkleRoot;
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach(byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }

            return hash;
        }

        public String Mine()
        {
            String hash = CreateHash();

            //Difficulty critera definition
            String re = new string('0', difficulty); //Create a "regex" string of N (difficulty i.e. 4) 0's

            // Re-Hash until difficulty critera is met
            while (!hash.StartsWith(re))
            {
                nonce++; // Increment nonce
                hash = CreateHash();
            }
            
            return hash;
        }

        public static String MerkleRoot(List<Transaction> transactionList)
        {
            List<String> hashes = transactionList.Select(t => t.hash).ToList();
            if(hashes.Count == 0)
            {
                return String.Empty;
            }
            if(hashes.Count == 1)
            {
                return HashCode.HashTools.combineHash(hashes[0], hashes[0]);
            }
            while(hashes.Count != 1)
            {
                List<String> merkleLeaves = new List<String>();
                for (int i=0; i<hashes.Count; i += 2)
                {
                    if(i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i]));
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i + 1]));
                    }
                }
                hashes = merkleLeaves;
            }
            return hashes[0];
        }


        public override string ToString()
        {
            String output = String.Empty;
            transactionList.ForEach(t => output += (t.ToString() + "\n"));

            return "Index: " + index.ToString() +
                "\tTimestamp: " + timestamp.ToString() +
                "\nPrevious Hash: " + prevHash +
                "\nHash: " + hash +
                "\nNonce: " + nonce.ToString() +
                "\nDifficulty: " + difficulty.ToString() +
                "\nReward: " + reward.ToString() + 
                "\nFees: " + fees.ToString() +
                "\nMiner's Address: " + minerAddress + 
                "\nTransactions:\n" + output + "\n";
        }
    }
}
