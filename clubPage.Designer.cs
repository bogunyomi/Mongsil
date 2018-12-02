namespace appTest
{
    partial class clubPage
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
            this.lbx_clbMembers = new System.Windows.Forms.ListBox();
            this.lbl_clbMembers = new System.Windows.Forms.Label();
            this.lbl_Balance = new System.Windows.Forms.Label();
            this.lbl_clBalance = new System.Windows.Forms.Label();
            this.lbl_paymentTxt = new System.Windows.Forms.Label();
            this.txt_Pay = new System.Windows.Forms.TextBox();
            this.lbl_rem = new System.Windows.Forms.Label();
            this.btn_Pay = new System.Windows.Forms.Button();
            this.btn_backMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbx_clbMembers
            // 
            this.lbx_clbMembers.FormattingEnabled = true;
            this.lbx_clbMembers.Location = new System.Drawing.Point(50, 74);
            this.lbx_clbMembers.Name = "lbx_clbMembers";
            this.lbx_clbMembers.Size = new System.Drawing.Size(247, 277);
            this.lbx_clbMembers.TabIndex = 0;
            // 
            // lbl_clbMembers
            // 
            this.lbl_clbMembers.AutoSize = true;
            this.lbl_clbMembers.Location = new System.Drawing.Point(51, 55);
            this.lbl_clbMembers.Name = "lbl_clbMembers";
            this.lbl_clbMembers.Size = new System.Drawing.Size(74, 13);
            this.lbl_clbMembers.TabIndex = 1;
            this.lbl_clbMembers.Text = "Club Members";
            // 
            // lbl_Balance
            // 
            this.lbl_Balance.AutoSize = true;
            this.lbl_Balance.Location = new System.Drawing.Point(51, 363);
            this.lbl_Balance.Name = "lbl_Balance";
            this.lbl_Balance.Size = new System.Drawing.Size(87, 13);
            this.lbl_Balance.TabIndex = 2;
            this.lbl_Balance.Text = "Club balance ($):";
            // 
            // lbl_clBalance
            // 
            this.lbl_clBalance.AutoSize = true;
            this.lbl_clBalance.Location = new System.Drawing.Point(143, 365);
            this.lbl_clBalance.Name = "lbl_clBalance";
            this.lbl_clBalance.Size = new System.Drawing.Size(0, 13);
            this.lbl_clBalance.TabIndex = 3;
            // 
            // lbl_paymentTxt
            // 
            this.lbl_paymentTxt.AutoSize = true;
            this.lbl_paymentTxt.Location = new System.Drawing.Point(51, 386);
            this.lbl_paymentTxt.Name = "lbl_paymentTxt";
            this.lbl_paymentTxt.Size = new System.Drawing.Size(49, 13);
            this.lbl_paymentTxt.TabIndex = 4;
            this.lbl_paymentTxt.Text = "Make ($)";
            // 
            // txt_Pay
            // 
            this.txt_Pay.Location = new System.Drawing.Point(105, 383);
            this.txt_Pay.Name = "txt_Pay";
            this.txt_Pay.Size = new System.Drawing.Size(47, 20);
            this.txt_Pay.TabIndex = 5;
            // 
            // lbl_rem
            // 
            this.lbl_rem.AutoSize = true;
            this.lbl_rem.Location = new System.Drawing.Point(155, 387);
            this.lbl_rem.Name = "lbl_rem";
            this.lbl_rem.Size = new System.Drawing.Size(47, 13);
            this.lbl_rem.TabIndex = 6;
            this.lbl_rem.Text = "payment";
            // 
            // btn_Pay
            // 
            this.btn_Pay.Location = new System.Drawing.Point(202, 382);
            this.btn_Pay.Name = "btn_Pay";
            this.btn_Pay.Size = new System.Drawing.Size(43, 23);
            this.btn_Pay.TabIndex = 7;
            this.btn_Pay.Text = "pay";
            this.btn_Pay.UseVisualStyleBackColor = true;
            this.btn_Pay.Click += new System.EventHandler(this.btn_Pay_Click);
            // 
            // btn_backMain
            // 
            this.btn_backMain.Location = new System.Drawing.Point(50, 414);
            this.btn_backMain.Name = "btn_backMain";
            this.btn_backMain.Size = new System.Drawing.Size(75, 23);
            this.btn_backMain.TabIndex = 8;
            this.btn_backMain.Text = "<- back";
            this.btn_backMain.UseVisualStyleBackColor = true;
            this.btn_backMain.Click += new System.EventHandler(this.btn_backMain_Click);
            // 
            // clubPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 460);
            this.Controls.Add(this.btn_backMain);
            this.Controls.Add(this.btn_Pay);
            this.Controls.Add(this.lbl_rem);
            this.Controls.Add(this.txt_Pay);
            this.Controls.Add(this.lbl_paymentTxt);
            this.Controls.Add(this.lbl_clBalance);
            this.Controls.Add(this.lbl_Balance);
            this.Controls.Add(this.lbl_clbMembers);
            this.Controls.Add(this.lbx_clbMembers);
            this.Name = "clubPage";
            this.Text = "clubPage";
            this.Load += new System.EventHandler(this.clubPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_clbMembers;
        private System.Windows.Forms.Label lbl_clbMembers;
        private System.Windows.Forms.Label lbl_Balance;
        private System.Windows.Forms.Label lbl_clBalance;
        private System.Windows.Forms.Label lbl_paymentTxt;
        private System.Windows.Forms.TextBox txt_Pay;
        private System.Windows.Forms.Label lbl_rem;
        private System.Windows.Forms.Button btn_Pay;
        private System.Windows.Forms.Button btn_backMain;
    }
}