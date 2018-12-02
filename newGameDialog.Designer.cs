namespace appTest
{
    partial class newGameDialog
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
            this.lbl_gameDate = new System.Windows.Forms.Label();
            this.lbl_sOpponent = new System.Windows.Forms.Label();
            this.cmbx_oppList = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dtp_dGameDate = new System.Windows.Forms.DateTimePicker();
            this.lbl_setPlayed = new System.Windows.Forms.Label();
            this.txt_setsPlayed = new System.Windows.Forms.TextBox();
            this.btn_getIt = new System.Windows.Forms.Button();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_gameDate
            // 
            this.lbl_gameDate.AutoSize = true;
            this.lbl_gameDate.Location = new System.Drawing.Point(85, 12);
            this.lbl_gameDate.Name = "lbl_gameDate";
            this.lbl_gameDate.Size = new System.Drawing.Size(0, 13);
            this.lbl_gameDate.TabIndex = 0;
            // 
            // lbl_sOpponent
            // 
            this.lbl_sOpponent.AutoSize = true;
            this.lbl_sOpponent.Location = new System.Drawing.Point(15, 90);
            this.lbl_sOpponent.Name = "lbl_sOpponent";
            this.lbl_sOpponent.Size = new System.Drawing.Size(57, 13);
            this.lbl_sOpponent.TabIndex = 2;
            this.lbl_sOpponent.Text = "Opponent:";
            // 
            // cmbx_oppList
            // 
            this.cmbx_oppList.FormattingEnabled = true;
            this.cmbx_oppList.Location = new System.Drawing.Point(80, 87);
            this.cmbx_oppList.Name = "cmbx_oppList";
            this.cmbx_oppList.Size = new System.Drawing.Size(319, 21);
            this.cmbx_oppList.TabIndex = 5;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dtp_dGameDate);
            this.groupBox7.Location = new System.Drawing.Point(15, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(384, 66);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Select date";
            // 
            // dtp_dGameDate
            // 
            this.dtp_dGameDate.Location = new System.Drawing.Point(101, 29);
            this.dtp_dGameDate.Name = "dtp_dGameDate";
            this.dtp_dGameDate.Size = new System.Drawing.Size(188, 20);
            this.dtp_dGameDate.TabIndex = 34;
            // 
            // lbl_setPlayed
            // 
            this.lbl_setPlayed.AutoSize = true;
            this.lbl_setPlayed.Location = new System.Drawing.Point(15, 120);
            this.lbl_setPlayed.Name = "lbl_setPlayed";
            this.lbl_setPlayed.Size = new System.Drawing.Size(65, 13);
            this.lbl_setPlayed.TabIndex = 32;
            this.lbl_setPlayed.Text = "Sets played:";
            // 
            // txt_setsPlayed
            // 
            this.txt_setsPlayed.Location = new System.Drawing.Point(80, 117);
            this.txt_setsPlayed.Name = "txt_setsPlayed";
            this.txt_setsPlayed.Size = new System.Drawing.Size(59, 20);
            this.txt_setsPlayed.TabIndex = 33;
            // 
            // btn_getIt
            // 
            this.btn_getIt.Location = new System.Drawing.Point(143, 116);
            this.btn_getIt.Name = "btn_getIt";
            this.btn_getIt.Size = new System.Drawing.Size(45, 23);
            this.btn_getIt.TabIndex = 34;
            this.btn_getIt.Text = "go";
            this.btn_getIt.UseVisualStyleBackColor = true;
            this.btn_getIt.Click += new System.EventHandler(this.btn_getIt_Click);
            // 
            // newGameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 307);
            this.Controls.Add(this.btn_getIt);
            this.Controls.Add(this.txt_setsPlayed);
            this.Controls.Add(this.lbl_setPlayed);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.cmbx_oppList);
            this.Controls.Add(this.lbl_sOpponent);
            this.Controls.Add(this.lbl_gameDate);
            this.Name = "newGameDialog";
            this.Text = "newGameDialog";
            this.Load += new System.EventHandler(this.newGameDialog_Load);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_gameDate;
        private System.Windows.Forms.Label lbl_sOpponent;
        private System.Windows.Forms.ComboBox cmbx_oppList;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DateTimePicker dtp_dGameDate;
        private System.Windows.Forms.Label lbl_setPlayed;
        private System.Windows.Forms.TextBox txt_setsPlayed;
        private System.Windows.Forms.Button btn_getIt;
    }
}