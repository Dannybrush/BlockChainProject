
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
            this.printBtn = new System.Windows.Forms.Button();
            this.indexTBox = new System.Windows.Forms.TextBox();
            this.infoLbl = new System.Windows.Forms.Label();
            this.genWalletBtn = new System.Windows.Forms.Button();
            this.valKeysBtn = new System.Windows.Forms.Button();
            this.pubKeyTBox = new System.Windows.Forms.TextBox();
            this.pubKeyLbl = new System.Windows.Forms.Label();
            this.privKeyLbl = new System.Windows.Forms.Label();
            this.privKeyTBox = new System.Windows.Forms.TextBox();
            this.createTransBtn = new System.Windows.Forms.Button();
            this.amountLbl = new System.Windows.Forms.Label();
            this.feeLbl = new System.Windows.Forms.Label();
            this.RKeyLbl = new System.Windows.Forms.Label();
            this.amountTBox = new System.Windows.Forms.TextBox();
            this.feeTBox = new System.Windows.Forms.TextBox();
            this.recieverKeyTBox = new System.Windows.Forms.TextBox();
            this.blockGenBtn = new System.Windows.Forms.Button();
            this.printAllBtn = new System.Windows.Forms.Button();
            this.readPendTrandBtn = new System.Windows.Forms.Button();
            this.GenwTransBTN = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.validate = new System.Windows.Forms.Button();
            this.CheckBalance = new System.Windows.Forms.Button();
            this.addressFind = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(799, 314);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(817, 12);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 1;
            this.printBtn.Text = "Print";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // indexTBox
            // 
            this.indexTBox.Location = new System.Drawing.Point(898, 14);
            this.indexTBox.Name = "indexTBox";
            this.indexTBox.Size = new System.Drawing.Size(60, 20);
            this.indexTBox.TabIndex = 2;
            this.indexTBox.TextChanged += new System.EventHandler(this.IndexInput_TextChanged);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(814, 38);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(182, 39);
            this.infoLbl.TabIndex = 3;
            this.infoLbl.Text = "Type the index  of the block which \r\nyou wish to reveal information about, \r\nthen" +
    " press the \"Print\" button.\r\n";
            // 
            // genWalletBtn
            // 
            this.genWalletBtn.Location = new System.Drawing.Point(12, 332);
            this.genWalletBtn.Name = "genWalletBtn";
            this.genWalletBtn.Size = new System.Drawing.Size(245, 23);
            this.genWalletBtn.TabIndex = 4;
            this.genWalletBtn.Text = "Generate New Wallet";
            this.genWalletBtn.UseVisualStyleBackColor = true;
            this.genWalletBtn.Click += new System.EventHandler(this.GenWalletBtn_Click);
            // 
            // valKeysBtn
            // 
            this.valKeysBtn.Location = new System.Drawing.Point(321, 413);
            this.valKeysBtn.Name = "valKeysBtn";
            this.valKeysBtn.Size = new System.Drawing.Size(153, 23);
            this.valKeysBtn.TabIndex = 5;
            this.valKeysBtn.Text = "Validate Keys";
            this.valKeysBtn.UseVisualStyleBackColor = true;
            this.valKeysBtn.Click += new System.EventHandler(this.ValKeysBtn_Click);
            // 
            // pubKeyTBox
            // 
            this.pubKeyTBox.Location = new System.Drawing.Point(17, 374);
            this.pubKeyTBox.Name = "pubKeyTBox";
            this.pubKeyTBox.Size = new System.Drawing.Size(657, 20);
            this.pubKeyTBox.TabIndex = 6;
            this.pubKeyTBox.TextChanged += new System.EventHandler(this.PubKeyTBox_TextChanged);
            // 
            // pubKeyLbl
            // 
            this.pubKeyLbl.AutoSize = true;
            this.pubKeyLbl.Location = new System.Drawing.Point(14, 358);
            this.pubKeyLbl.Name = "pubKeyLbl";
            this.pubKeyLbl.Size = new System.Drawing.Size(57, 13);
            this.pubKeyLbl.TabIndex = 7;
            this.pubKeyLbl.Text = "Public Key";
            // 
            // privKeyLbl
            // 
            this.privKeyLbl.AutoSize = true;
            this.privKeyLbl.Location = new System.Drawing.Point(14, 397);
            this.privKeyLbl.Name = "privKeyLbl";
            this.privKeyLbl.Size = new System.Drawing.Size(61, 13);
            this.privKeyLbl.TabIndex = 8;
            this.privKeyLbl.Text = "Private Key";
            // 
            // privKeyTBox
            // 
            this.privKeyTBox.Location = new System.Drawing.Point(17, 413);
            this.privKeyTBox.Name = "privKeyTBox";
            this.privKeyTBox.Size = new System.Drawing.Size(298, 20);
            this.privKeyTBox.TabIndex = 9;
            this.privKeyTBox.TextChanged += new System.EventHandler(this.PrivKeyTBox_TextChanged);
            // 
            // createTransBtn
            // 
            this.createTransBtn.Location = new System.Drawing.Point(160, 439);
            this.createTransBtn.Name = "createTransBtn";
            this.createTransBtn.Size = new System.Drawing.Size(73, 46);
            this.createTransBtn.TabIndex = 10;
            this.createTransBtn.Text = "Create Transaction";
            this.createTransBtn.UseVisualStyleBackColor = true;
            this.createTransBtn.Click += new System.EventHandler(this.CreateTransBtn_Click);
            // 
            // amountLbl
            // 
            this.amountLbl.AutoSize = true;
            this.amountLbl.Location = new System.Drawing.Point(14, 446);
            this.amountLbl.Name = "amountLbl";
            this.amountLbl.Size = new System.Drawing.Size(43, 13);
            this.amountLbl.TabIndex = 11;
            this.amountLbl.Text = "Amount";
            // 
            // feeLbl
            // 
            this.feeLbl.AutoSize = true;
            this.feeLbl.Location = new System.Drawing.Point(14, 468);
            this.feeLbl.Name = "feeLbl";
            this.feeLbl.Size = new System.Drawing.Size(25, 13);
            this.feeLbl.TabIndex = 12;
            this.feeLbl.Text = "Fee";
            // 
            // RKeyLbl
            // 
            this.RKeyLbl.AutoSize = true;
            this.RKeyLbl.Location = new System.Drawing.Point(12, 504);
            this.RKeyLbl.Name = "RKeyLbl";
            this.RKeyLbl.Size = new System.Drawing.Size(71, 13);
            this.RKeyLbl.TabIndex = 13;
            this.RKeyLbl.Text = "Receiver Key";
            // 
            // amountTBox
            // 
            this.amountTBox.Location = new System.Drawing.Point(54, 439);
            this.amountTBox.Name = "amountTBox";
            this.amountTBox.Size = new System.Drawing.Size(100, 20);
            this.amountTBox.TabIndex = 14;
            // 
            // feeTBox
            // 
            this.feeTBox.Location = new System.Drawing.Point(54, 465);
            this.feeTBox.Name = "feeTBox";
            this.feeTBox.Size = new System.Drawing.Size(100, 20);
            this.feeTBox.TabIndex = 15;
            // 
            // recieverKeyTBox
            // 
            this.recieverKeyTBox.Location = new System.Drawing.Point(12, 520);
            this.recieverKeyTBox.Name = "recieverKeyTBox";
            this.recieverKeyTBox.Size = new System.Drawing.Size(571, 20);
            this.recieverKeyTBox.TabIndex = 16;
            // 
            // blockGenBtn
            // 
            this.blockGenBtn.Location = new System.Drawing.Point(817, 109);
            this.blockGenBtn.Name = "blockGenBtn";
            this.blockGenBtn.Size = new System.Drawing.Size(128, 87);
            this.blockGenBtn.TabIndex = 17;
            this.blockGenBtn.Text = "Generate New Block";
            this.blockGenBtn.UseVisualStyleBackColor = true;
            this.blockGenBtn.Click += new System.EventHandler(this.BlockGenBtn_Click);
            // 
            // printAllBtn
            // 
            this.printAllBtn.Location = new System.Drawing.Point(830, 80);
            this.printAllBtn.Name = "printAllBtn";
            this.printAllBtn.Size = new System.Drawing.Size(141, 23);
            this.printAllBtn.TabIndex = 18;
            this.printAllBtn.Text = "Print All";
            this.printAllBtn.UseVisualStyleBackColor = true;
            this.printAllBtn.Click += new System.EventHandler(this.PrintAllBtn_Click);
            // 
            // readPendTrandBtn
            // 
            this.readPendTrandBtn.Location = new System.Drawing.Point(239, 439);
            this.readPendTrandBtn.Name = "readPendTrandBtn";
            this.readPendTrandBtn.Size = new System.Drawing.Size(100, 46);
            this.readPendTrandBtn.TabIndex = 19;
            this.readPendTrandBtn.Text = "Read Pending Transactions ";
            this.readPendTrandBtn.UseVisualStyleBackColor = true;
            this.readPendTrandBtn.Click += new System.EventHandler(this.ReadPendTrandBtn_Click);
            // 
            // GenwTransBTN
            // 
            this.GenwTransBTN.Location = new System.Drawing.Point(817, 202);
            this.GenwTransBTN.Name = "GenwTransBTN";
            this.GenwTransBTN.Size = new System.Drawing.Size(75, 23);
            this.GenwTransBTN.TabIndex = 20;
            this.GenwTransBTN.Text = "Gen W/ T";
            this.GenwTransBTN.UseVisualStyleBackColor = true;
            this.GenwTransBTN.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(898, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "PRNT ALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "None";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Greedy",
            "Altruistic",
            "Random",
            "Address Preference"});
            this.comboBox1.Location = new System.Drawing.Point(818, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(163, 21);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Text = "Mining Preference System";
            this.comboBox1.ValueMember = "None";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // validate
            // 
            this.validate.Location = new System.Drawing.Point(346, 439);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(116, 46);
            this.validate.TabIndex = 23;
            this.validate.Text = "Validate Blockchain";
            this.validate.UseVisualStyleBackColor = true;
            this.validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // CheckBalance
            // 
            this.CheckBalance.Location = new System.Drawing.Point(469, 439);
            this.CheckBalance.Name = "CheckBalance";
            this.CheckBalance.Size = new System.Drawing.Size(114, 46);
            this.CheckBalance.TabIndex = 24;
            this.CheckBalance.Text = "Check Balance";
            this.CheckBalance.UseVisualStyleBackColor = true;
            this.CheckBalance.Click += new System.EventHandler(this.CheckBalance_Click);
            // 
            // addressFind
            // 
            this.addressFind.Location = new System.Drawing.Point(818, 260);
            this.addressFind.Name = "addressFind";
            this.addressFind.Size = new System.Drawing.Size(163, 20);
            this.addressFind.TabIndex = 25;
            this.addressFind.Text = "Search for: ";
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(993, 557);
            this.Controls.Add(this.addressFind);
            this.Controls.Add(this.CheckBalance);
            this.Controls.Add(this.validate);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.GenwTransBTN);
            this.Controls.Add(this.readPendTrandBtn);
            this.Controls.Add(this.printAllBtn);
            this.Controls.Add(this.blockGenBtn);
            this.Controls.Add(this.recieverKeyTBox);
            this.Controls.Add(this.feeTBox);
            this.Controls.Add(this.amountTBox);
            this.Controls.Add(this.RKeyLbl);
            this.Controls.Add(this.feeLbl);
            this.Controls.Add(this.amountLbl);
            this.Controls.Add(this.createTransBtn);
            this.Controls.Add(this.privKeyTBox);
            this.Controls.Add(this.privKeyLbl);
            this.Controls.Add(this.pubKeyLbl);
            this.Controls.Add(this.pubKeyTBox);
            this.Controls.Add(this.valKeysBtn);
            this.Controls.Add(this.genWalletBtn);
            this.Controls.Add(this.infoLbl);
            this.Controls.Add(this.indexTBox);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.richTextBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.TextBox indexTBox;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.Button genWalletBtn;
        private System.Windows.Forms.Button valKeysBtn;
        private System.Windows.Forms.TextBox pubKeyTBox;
        private System.Windows.Forms.Label pubKeyLbl;
        private System.Windows.Forms.Label privKeyLbl;
        private System.Windows.Forms.TextBox privKeyTBox;
        private System.Windows.Forms.Button createTransBtn;
        private System.Windows.Forms.Label amountLbl;
        private System.Windows.Forms.Label feeLbl;
        private System.Windows.Forms.Label RKeyLbl;
        private System.Windows.Forms.TextBox amountTBox;
        private System.Windows.Forms.TextBox feeTBox;
        private System.Windows.Forms.TextBox recieverKeyTBox;
        private System.Windows.Forms.Button blockGenBtn;
        private System.Windows.Forms.Button printAllBtn;
        private System.Windows.Forms.Button readPendTrandBtn;
        private System.Windows.Forms.Button GenwTransBTN;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button validate;
        private System.Windows.Forms.Button CheckBalance;
        private System.Windows.Forms.TextBox addressFind;
    }
}
