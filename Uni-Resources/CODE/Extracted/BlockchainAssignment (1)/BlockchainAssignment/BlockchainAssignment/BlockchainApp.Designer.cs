namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.publicKey = new System.Windows.Forms.TextBox();
            this.privateKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.createTransaction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fee = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.receiver = new System.Windows.Forms.Label();
            this.receiverKey = new System.Windows.Forms.TextBox();
            this.newBlock = new System.Windows.Forms.Button();
            this.validateChain = new System.Windows.Forms.Button();
            this.checkBalance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(18, 18);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(984, 481);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 517);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Print Block";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 522);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(33, 26);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(898, 523);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 66);
            this.button2.TabIndex = 3;
            this.button2.Text = "Generate Wallet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(551, 523);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(341, 26);
            this.publicKey.TabIndex = 4;
            // 
            // privateKey
            // 
            this.privateKey.Location = new System.Drawing.Point(553, 563);
            this.privateKey.Name = "privateKey";
            this.privateKey.Size = new System.Drawing.Size(339, 26);
            this.privateKey.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(464, 527);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Public Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(464, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Private Key";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(869, 596);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 39);
            this.button3.TabIndex = 8;
            this.button3.Text = "Validate Keys";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // createTransaction
            // 
            this.createTransaction.Location = new System.Drawing.Point(18, 661);
            this.createTransaction.Name = "createTransaction";
            this.createTransaction.Size = new System.Drawing.Size(115, 67);
            this.createTransaction.TabIndex = 9;
            this.createTransaction.Text = "Create Transaction";
            this.createTransaction.UseVisualStyleBackColor = true;
            this.createTransaction.Click += new System.EventHandler(this.createTransaction_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 705);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 666);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Amount";
            // 
            // fee
            // 
            this.fee.Location = new System.Drawing.Point(237, 702);
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(61, 26);
            this.fee.TabIndex = 11;
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(235, 662);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(63, 26);
            this.amount.TabIndex = 10;
            // 
            // receiver
            // 
            this.receiver.AutoSize = true;
            this.receiver.Location = new System.Drawing.Point(444, 702);
            this.receiver.Name = "receiver";
            this.receiver.Size = new System.Drawing.Size(101, 20);
            this.receiver.TabIndex = 15;
            this.receiver.Text = "Receiver Key";
            // 
            // receiverKey
            // 
            this.receiverKey.Location = new System.Drawing.Point(562, 699);
            this.receiverKey.Name = "receiverKey";
            this.receiverKey.Size = new System.Drawing.Size(341, 26);
            this.receiverKey.TabIndex = 14;
            // 
            // newBlock
            // 
            this.newBlock.Location = new System.Drawing.Point(18, 585);
            this.newBlock.Name = "newBlock";
            this.newBlock.Size = new System.Drawing.Size(115, 61);
            this.newBlock.TabIndex = 16;
            this.newBlock.Text = "Generate New Block";
            this.newBlock.UseVisualStyleBackColor = true;
            this.newBlock.Click += new System.EventHandler(this.newBlock_Click);
            // 
            // validateChain
            // 
            this.validateChain.Location = new System.Drawing.Point(869, 646);
            this.validateChain.Name = "validateChain";
            this.validateChain.Size = new System.Drawing.Size(133, 40);
            this.validateChain.TabIndex = 17;
            this.validateChain.Text = "Validate Chain";
            this.validateChain.UseVisualStyleBackColor = true;
            this.validateChain.Click += new System.EventHandler(this.validateChain_Click);
            // 
            // checkBalance
            // 
            this.checkBalance.Location = new System.Drawing.Point(716, 597);
            this.checkBalance.Name = "checkBalance";
            this.checkBalance.Size = new System.Drawing.Size(137, 37);
            this.checkBalance.TabIndex = 18;
            this.checkBalance.Text = "Check Balance";
            this.checkBalance.UseVisualStyleBackColor = true;
            this.checkBalance.Click += new System.EventHandler(this.checkBalancce_Click);
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1022, 740);
            this.Controls.Add(this.checkBalance);
            this.Controls.Add(this.validateChain);
            this.Controls.Add(this.newBlock);
            this.Controls.Add(this.receiver);
            this.Controls.Add(this.receiverKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.createTransaction);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.privateKey);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox publicKey;
        private System.Windows.Forms.TextBox privateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button createTransaction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fee;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label receiver;
        private System.Windows.Forms.TextBox receiverKey;
        private System.Windows.Forms.Button newBlock;
        private System.Windows.Forms.Button validateChain;
        private System.Windows.Forms.Button checkBalance;
    }
}

