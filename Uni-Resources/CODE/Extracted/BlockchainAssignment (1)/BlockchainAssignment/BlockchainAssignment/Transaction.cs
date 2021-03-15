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
        public String senderAddress;
        public String recipientAddress;

        public double amount;
        public double fee;

        DateTime timestamp;

        public String hash;
        String signature;

        public Transaction(String from, String to, double amount, double fee, String privateKey)
        {
            senderAddress = from;
            recipientAddress = to;
            this.amount = amount;
            this.fee = fee;
            timestamp = DateTime.Now;

            hash = CreateHash();
            signature = Wallet.Wallet.CreateSignature(from, privateKey, hash);
        }

        public String CreateHash()
        {
            String hash = String.Empty;
            SHA256 hasher = SHA256Managed.Create();

            String input = senderAddress + recipientAddress + timestamp.ToString() + amount.ToString() + fee.ToString();
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }

            return hash;
        }

        public override string ToString()
        {
            return "Transaction Hash: " + hash + "\n"
                + "Digital Signature: " + signature + "\n"
                + "Timestamp: " + timestamp.ToString() + "\n" 
                + "Transferred: " + amount.ToString() + " AssignmentCoin\n"
                + "Fees: " + fee.ToString() + "\n"
                + "Sender Address: " + senderAddress + "\n"
                + "Receiver Address: " + recipientAddress + "\n";
        }
    }
}
