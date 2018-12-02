namespace appTest
{
    partial class newDGDialog
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
            this.lbl_dPartner = new System.Windows.Forms.Label();
            this.cmbx_p2OppList = new System.Windows.Forms.ComboBox();
            this.lbl_sOpponent = new System.Windows.Forms.Label();
            this.cmbx_partnerOppList = new System.Windows.Forms.ComboBox();
            this.cmbx_p1OppList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtp_dGameDate = new System.Windows.Forms.DateTimePicker();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_dgetIt = new System.Windows.Forms.Button();
            this.txt_dsetsPlayed = new System.Windows.Forms.TextBox();
            this.lbl_dsetPlayed = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_dPartner
            // 
            this.lbl_dPartner.AutoSize = true;
            this.lbl_dPartner.Location = new System.Drawing.Point(25, 54);
            this.lbl_dPartner.Name = "lbl_dPartner";
            this.lbl_dPartner.Size = new System.Drawing.Size(44, 13);
            this.lbl_dPartner.TabIndex = 7;
            this.lbl_dPartner.Text = "Partner:";
            // 
            // cmbx_p2OppList
            // 
            this.cmbx_p2OppList.FormattingEnabled = true;
            this.cmbx_p2OppList.Location = new System.Drawing.Point(74, 49);
            this.cmbx_p2OppList.Name = "cmbx_p2OppList";
            this.cmbx_p2OppList.Size = new System.Drawing.Size(290, 21);
            this.cmbx_p2OppList.TabIndex = 23;
            // 
            // lbl_sOpponent
            // 
            this.lbl_sOpponent.AutoSize = true;
            this.lbl_sOpponent.Location = new System.Drawing.Point(21, 53);
            this.lbl_sOpponent.Name = "lbl_sOpponent";
            this.lbl_sOpponent.Size = new System.Drawing.Size(48, 13);
            this.lbl_sOpponent.TabIndex = 21;
            this.lbl_sOpponent.Text = "Player 2:";
            // 
            // cmbx_partnerOppList
            // 
            this.cmbx_partnerOppList.FormattingEnabled = true;
            this.cmbx_partnerOppList.Location = new System.Drawing.Point(74, 51);
            this.cmbx_partnerOppList.Name = "cmbx_partnerOppList";
            this.cmbx_partnerOppList.Size = new System.Drawing.Size(290, 21);
            this.cmbx_partnerOppList.TabIndex = 27;
            // 
            // cmbx_p1OppList
            // 
            this.cmbx_p1OppList.FormattingEnabled = true;
            this.cmbx_p1OppList.Location = new System.Drawing.Point(74, 19);
            this.cmbx_p1OppList.Name = "cmbx_p1OppList";
            this.cmbx_p1OppList.Size = new System.Drawing.Size(290, 21);
            this.cmbx_p1OppList.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Player 1:";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtp_dGameDate);
            this.groupBox7.Location = new System.Drawing.Point(28, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(370, 66);
            this.groupBox7.TabIndex = 30;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select date";
            // 
            // dtp_dGameDate
            // 
            this.dtp_dGameDate.Location = new System.Drawing.Point(100, 27);
            this.dtp_dGameDate.Name = "dtp_dGameDate";
            this.dtp_dGameDate.Size = new System.Drawing.Size(188, 20);
            this.dtp_dGameDate.TabIndex = 34;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(77, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 13);
            this.lblName.TabIndex = 31;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblName);
            this.groupBox8.Controls.Add(this.cmbx_partnerOppList);
            this.groupBox8.Controls.Add(this.lbl_dPartner);
            this.groupBox8.Location = new System.Drawing.Point(12, 87);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(384, 84);
            this.groupBox8.TabIndex = 32;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "My team";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cmbx_p1OppList);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.cmbx_p2OppList);
            this.groupBox9.Controls.Add(this.lbl_sOpponent);
            this.groupBox9.Location = new System.Drawing.Point(12, 180);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(384, 84);
            this.groupBox9.TabIndex = 33;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Opposing team";
            // 
            // btn_dgetIt
            // 
            this.btn_dgetIt.Location = new System.Drawing.Point(141, 271);
            this.btn_dgetIt.Name = "btn_dgetIt";
            this.btn_dgetIt.Size = new System.Drawing.Size(45, 23);
            this.btn_dgetIt.TabIndex = 37;
            this.btn_dgetIt.Text = "go";
            this.btn_dgetIt.UseVisualStyleBackColor = true;
            this.btn_dgetIt.Click += new System.EventHandler(this.btn_dgetIt_Click_1);
            // 
            // txt_dsetsPlayed
            // 
            this.txt_dsetsPlayed.Location = new System.Drawing.Point(78, 272);
            this.txt_dsetsPlayed.Name = "txt_dsetsPlayed";
            this.txt_dsetsPlayed.Size = new System.Drawing.Size(59, 20);
            this.txt_dsetsPlayed.TabIndex = 36;
            // 
            // lbl_dsetPlayed
            // 
            this.lbl_dsetPlayed.AutoSize = true;
            this.lbl_dsetPlayed.Location = new System.Drawing.Point(13, 275);
            this.lbl_dsetPlayed.Name = "lbl_dsetPlayed";
            this.lbl_dsetPlayed.Size = new System.Drawing.Size(65, 13);
            this.lbl_dsetPlayed.TabIndex = 35;
            this.lbl_dsetPlayed.Text = "Sets played:";
            // 
            // newDGDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 462);
            this.Controls.Add(this.btn_dgetIt);
            this.Controls.Add(this.txt_dsetsPlayed);
            this.Controls.Add(this.lbl_dsetPlayed);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Name = "newDGDialog";
            this.Text = "newDGDialog";
            this.Load += new System.EventHandler(this.newDGDialog_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_dPartner;
        private System.Windows.Forms.ComboBox cmbx_p2OppList;
        private System.Windows.Forms.Label lbl_sOpponent;
        private System.Windows.Forms.ComboBox cmbx_partnerOppList;
        private System.Windows.Forms.ComboBox cmbx_p1OppList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.DateTimePicker dtp_dGameDate;
        private System.Windows.Forms.Button btn_dgetIt;
        private System.Windows.Forms.TextBox txt_dsetsPlayed;
        private System.Windows.Forms.Label lbl_dsetPlayed;
    }
}