using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlockchainAssignment
{
    class Block
    {
        public Boolean THREADING { get; set; } = true;                                 // Boolean to tell whether to use threading or not
        public List<Transaction> transactionList { get; set; }                  // List of transactions in this block
        public DateTime timeStamp { get; set; }                                 // Time of creation
        public int index { get; set; }                                          // Position of the block in the sequence of blocks
        public int difficulty { get; set; }                                    // An arbitrary number of 0's to proceed a hash value
        public long nonce { get; set; } = 0;                                    // Number used once for Proof-of-Work and mining
        public string hash { get; set; }                                        // The current blocks "identity"
        public string prevHash { get; set; }                                    // A reference pointer to the previous block
        public string merkleRoot { get; set; } = "0";                              // The merkle root of all transactions in the block
        public string minerAddress { get; set; }                                // Public Key (Wallet Address) of the Miner
        public double reward { get; set; } = 100;                                     // Simple fixed reward established by "Coinbase"

// private int nonce = 0;
        public int nonce0 { get; set; } = 0;
        public int nonce1 { get; set; } = 1;
        public string finalHash { get; set; }
        public string finalHash0 { get; set; }
        public string finalHash1 { get; set; }

        private bool th1Fin = false, th2Fin = false;




        // Constructor which is passed the previous block
        public Block(Block lastBlock) {
            this.timeStamp = DateTime.Now;
            this.nonce = 0;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            if (THREADING == true){
                ThreadedMine();
                this.hash = this.finalHash;
            }
            else this.hash = this.Create256Hash();
            //    Create hash from index, prevhash and time
            this.transactionList = new List<Transaction>();
           
        }

        public Block(Block lastBlock, List<Transaction> TPool)
        {
            this.transactionList = new List<Transaction>();
            this.nonce = 0;
            this.timeStamp = DateTime.Now;
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.addFromPool(TPool, 2, "!");

            //this.hash = this.Create256Hash();    //    Create hash from index, prevhash and time
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
            this.difficulty = 4;
        }

        public Block(Block lastBlock, List<Transaction> TPool, string MinerAddress, int setting, string address )
        {
            this.transactionList = new List<Transaction>();
            this.nonce = 0;
            this.timeStamp = DateTime.Now;
            this.difficulty = lastBlock.difficulty;
            this.adjustdiff(lastBlock.timeStamp); // comment out this line to turn off adjustable difficulty
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;
            this.minerAddress = MinerAddress;
            TPool.Add(createRewardTransaction(TPool)); // Create and append the reward transaction
            this.addFromPool(TPool, setting, address );
            // this.hash = this.Create256Mine();    //    Create hash from index, prevhash and time
            this.merkleRoot = MerkleRoot(transactionList); // Calculate the merkle root of the blocks transactions

            if (THREADING == true)
            {
                this.ThreadedMine();
                this.hash = this.finalHash;
            }
            else this.hash = this.Create256Mine();//this.Create256Hash();
            Console.WriteLine("Here");
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
                + "\nHash: " + this.hash + " " + this.finalHash
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

        public void addFromPool(List<Transaction> TP, int mode, string address)
        {
            int LIMIT = 5;
            int idx =0 ;

            
            while (transactionList.Count < LIMIT && TP.Count > 0 ) {
                if (mode == 0 ) {// greedy
                    //int idx = 0;
                    for (int i = 0; ((i < TP.Count)); i++)
                    {
                        if (TP.ElementAt(i).Fee > TP.ElementAt(idx).Fee)
                        {
                            idx = i;
                        }
                    }
                    this.transactionList.Add(TP.ElementAt(idx));
                } 
                else if (mode == 1) {// altruistic
                    for (int i = 0; ((i < TP.Count) && (i < LIMIT)); i++)
                    {
                        this.transactionList.Add(TP.ElementAt(i));
                    }
                } 
                else if (mode == 2 ) {  //random      
                    Random random = new Random();
                    idx = random.Next(0, TP.Count);
                    this.transactionList.Add(TP.ElementAt(idx));
                }       
                else if (mode == 3) {
                    
                    //this.transactionList.Add(TP.ElementAt(0));
                    for (int i = 0; i < TP.Count && (transactionList.Count < LIMIT); i++)
                    {                       
                        if (TP.ElementAt(i).SenderAddress == address)
                        {
                            this.transactionList.Add(TP.ElementAt(i));
                        }
                        else if (TP.ElementAt(i).RecipientAddress == address)
                        {
                            this.transactionList.Add(TP.ElementAt(i));
                        }
                        else
                        {
                            // ONLY TAKE FROM THIS ADDRESS: 
                            // If take address as priority and then add up to get to 5 --> add mode = 2 here
                        }
                        //TP = TP.Except(this.transactionList).ToList();
                        
                    }
                    Console.WriteLine("Endless loop");
                }
                else
                { // No Valid input, choose default --> Altruistic
                    mode = 1; 
                }
                TP = TP.Except(this.transactionList).ToList();
                
            }

        }

       
        public string Create256Hash()
        { // i think this can be simplified // Simplified Heavily is "this" needed?
            SHA256 hasher;
            hasher = SHA256Managed.Create();
            String input = this.index.ToString() + this.timeStamp.ToString() + this.prevHash + this.nonce + this.merkleRoot + this.reward.ToString();
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
            if (hash is null){
                throw new IndexOutOfRangeException("No hash generated"); }
            return hash;
        }

        public static string MerkleRoot(List<Transaction> transactionList) {

            // X => f(X) means given X return f(X)
            List<String> hashlist = transactionList.Select(t => t.Hash).ToList(); // Get a list of transaction hashlist for "combining"
            // Handle Blocks with...
            if (hashlist.Count == 0) // No transactions
            {
                return String.Empty;
            }
            else if (hashlist.Count == 1) // One transaction - hash with "self"
            {
                return HashCode.HashTools.combineHash(hashlist[0], hashlist[0]);
            }
            while (hashlist.Count != 1) // Multiple transactions - Repeat until tree has been traversed
            {
                List<String> merkleLeaves = new List<String>(); // Keep track of current "level" of the tree

                for (int i = 0; i < hashlist.Count; i += 2) // Step over neighbouring pair combining each
                {
                    if (i == hashlist.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashlist[i], hashlist[i])); // Handle an odd number of leaves
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashlist[i], hashlist[i + 1])); // Hash neighbours leaves
                    }
                }
                hashlist = merkleLeaves; // Update the working "layer"
            }
            return hashlist[0]; // Return the root node
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

        /*FOR MULTI THREADING */

        public void ThreadedMine(){
            Thread th1 = new Thread(this.Mine0);
            Thread th2 = new Thread(this.Mine1);

            th1.Start();
            th2.Start();

            while (th1.IsAlive == true || th2.IsAlive == true){Thread.Sleep(1);}

            //if (this.nonce0  < this.nonce1){
            if (this.finalHash1 is null) { 
                this.nonce = this.nonce0;
                this.finalHash = this.finalHash0;
            }
            else{
                this.nonce = this.nonce1;
                this.finalHash = this.finalHash1;
            }
            if (this.finalHash is null)
            {
                Console.WriteLine(this.ReturnString());
                throw new Exception("NULL finalhash" + 
                    " Nonce0: " + this.nonce0 + 
                    " Nonce1: "+ this.nonce1 + 
                    " Nonce: " + this.nonce +
                    " finalhash0 " + this.finalHash0 +
                    " finalhash1: " + this.finalHash1 +
                    " NewHash: " + this.Create256Hash());
               
            }
            //Console.WriteLine("FINALHASH = " + finalHash);
            //return finalHash;
        }

        public void Mine0(){
            th1Fin = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Boolean check = false;
            String newHash;
            string diffString = new string('0', this.difficulty);

            while (check == false)
            {
                newHash = Create256Hash(this.nonce0);
                if (newHash.StartsWith(diffString) == true){
                    check = true;
                    this.finalHash0 = newHash;
                    Console.WriteLine("Block index: " + this.index);
                    Console.WriteLine("Thread 1 closed: Thread 1 found: " + this.finalHash0);
                    th1Fin = true;

                    Console.WriteLine(nonce0);
                    sw.Stop();
                    Console.WriteLine("Th1 mine:");
                    Console.WriteLine(sw.Elapsed);

                    return;
                }
                else if (th2Fin == true){
                    Console.WriteLine("Thread 1 closed: Thread 2 found: " + this.finalHash1 );
                    Thread.Sleep(1);
                    return;
                }
                else{
                    check = false;
                    this.nonce0 += 2;
                }
            }
            return;
        }

        public void Mine1()
        {
            th2Fin = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Boolean check = false;
            String newHash;
            string diffString = new string('0', this.difficulty);
            while (check == false){
                newHash = Create256Hash(this.nonce1);
                if (newHash.StartsWith(diffString) == true){
                    check = true;
                    this.finalHash1 = newHash;
                    Console.WriteLine("Block index: " + this.index);
                   Console.WriteLine("Thread 2 closed: Thread 2 found: " + this.finalHash1);
                    th2Fin = true;

                    Console.WriteLine(this.nonce1);
                    sw.Stop();
                    Console.WriteLine("Th2 mine:");
                    Console.WriteLine(sw.Elapsed);

                    return;
                }
                else if (th1Fin == true){
                    Console.WriteLine("Thread 2 closed: Thread 1 found: " + this.finalHash0);
                    Thread.Sleep(1);
                    return;
                }
                else{
                    check = false;
                    this.nonce1 += 2;
                }
            }
            return;
        }

        //Version of above method to take nonce as a parameter
        public String Create256Hash(int inNonce)
        {
            SHA256 hasher;
            hasher = SHA256Managed.Create();
            String input = this.index.ToString() + this.timeStamp.ToString() + this.prevHash + inNonce + this.merkleRoot + this.reward.ToString();
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));
            String hash = string.Empty;

            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }
            return hash;
        }

        //Function to adjust the difficulty
        public void adjustdiff(DateTime lastTime)
        {
            //Gets the elapsed time between now and the last block mined
            DateTime startTime = DateTime.UtcNow;
            TimeSpan timeDiff = startTime - lastTime;

            //If the difference is less than 5 seconds, the difficulty is increased to attempt to increase the time
            if (timeDiff < TimeSpan.FromSeconds(5))
            {
                this.difficulty++;
                Console.WriteLine("Time since last mine");
                Console.WriteLine(timeDiff);
                Console.WriteLine("New Difficulty:");
                Console.WriteLine(this.difficulty);
            }
            //If the difference is more than 5 seconds, the difficulty is increased to attempt to decrease the time
            else if (timeDiff > TimeSpan.FromSeconds(5))
            {
                difficulty--;
                Console.WriteLine("Time since last mine");
                Console.WriteLine(timeDiff);
                Console.WriteLine("New Difficulty:");
                Console.WriteLine(this.difficulty);
            }

            //Difficulty can never be higher than 5 or lower than 0
            if (this.difficulty <= 0)
            {
                this.difficulty = 0;
                Console.WriteLine("Difficulty too low, new difficulty:");
                Console.WriteLine(this.difficulty);
            }
            else if (this.difficulty >= 6)
            {
                this.difficulty = 4;
                Console.WriteLine("Difficulty too high, new difficulty:");
                Console.WriteLine(this.difficulty);
            }
        }




    }

}
