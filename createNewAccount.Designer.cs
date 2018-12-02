namespace appTest
{
    partial class createNewAccount
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
            this.lbl_firstname = new System.Windows.Forms.Label();
            this.lbl_Lastname = new System.Windows.Forms.Label();
            this.lbl_PhoneNum = new System.Windows.Forms.Label();
            this.txt_Ca_Firstname = new System.Windows.Forms.TextBox();
            this.txt_Ca_TelNum = new System.Windows.Forms.TextBox();
            this.txt_Ca_Lastname = new System.Windows.Forms.TextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.txt_Ca_Username = new System.Windows.Forms.TextBox();
            this.txt_Ca_Password = new System.Windows.Forms.TextBox();
            this.lbl_Ca_Password = new System.Windows.Forms.Label();
            this.lbl_Ca_Username = new System.Windows.Forms.Label();
            this.gbx_CA = new System.Windows.Forms.GroupBox();
            this.gbx_CA.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_firstname
            // 
            this.lbl_firstname.AutoSize = true;
            this.lbl_firstname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_firstname.Location = new System.Drawing.Point(17, 44);
            this.lbl_firstname.Name = "lbl_firstname";
            this.lbl_firstname.Size = new System.Drawing.Size(78, 18);
            this.lbl_firstname.TabIndex = 0;
            this.lbl_firstname.Text = "Firstname";
            // 
            // lbl_Lastname
            // 
            this.lbl_Lastname.AutoSize = true;
            this.lbl_Lastname.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Lastname.Location = new System.Drawing.Point(17, 81);
            this.lbl_Lastname.Name = "lbl_Lastname";
            this.lbl_Lastname.Size = new System.Drawing.Size(77, 18);
            this.lbl_Lastname.TabIndex = 1;
            this.lbl_Lastname.Text = "Lastname";
            // 
            // lbl_PhoneNum
            // 
            this.lbl_PhoneNum.AutoSize = true;
            this.lbl_PhoneNum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PhoneNum.Location = new System.Drawing.Point(17, 118);
            this.lbl_PhoneNum.Name = "lbl_PhoneNum";
            this.lbl_PhoneNum.Size = new System.Drawing.Size(103, 18);
            this.lbl_PhoneNum.TabIndex = 2;
            this.lbl_PhoneNum.Text = "Telephone No";
            // 
            // txt_Ca_Firstname
            // 
            this.txt_Ca_Firstname.Location = new System.Drawing.Point(143, 41);
            this.txt_Ca_Firstname.Name = "txt_Ca_Firstname";
            this.txt_Ca_Firstname.Size = new System.Drawing.Size(203, 30);
            this.txt_Ca_Firstname.TabIndex = 3;
            this.txt_Ca_Firstname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Ca_Firstname_KeyPress);
            // 
            // txt_Ca_TelNum
            // 
            this.txt_Ca_TelNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Ca_TelNum.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_Ca_TelNum.Location = new System.Drawing.Point(143, 113);
            this.txt_Ca_TelNum.Name = "txt_Ca_TelNum";
            this.txt_Ca_TelNum.Size = new System.Drawing.Size(203, 26);
            this.txt_Ca_TelNum.TabIndex = 4;
            this.txt_Ca_TelNum.Text = "xxx-xxx-xxxx";
            this.txt_Ca_TelNum.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_Ca_TelNum_MouseClick);
            // 
            // txt_Ca_Lastname
            // 
            this.txt_Ca_Lastname.Location = new System.Drawing.Point(143, 77);
            this.txt_Ca_Lastname.Name = "txt_Ca_Lastname";
            this.txt_Ca_Lastname.Size = new System.Drawing.Size(203, 30);
            this.txt_Ca_Lastname.TabIndex = 5;
            this.txt_Ca_Lastname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Ca_Lastname_KeyPress);
            // 
            // btn_create
            // 
            this.btn_create.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_create.Location = new System.Drawing.Point(256, 221);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(90, 31);
            this.btn_create.TabIndex = 6;
            this.btn_create.Text = "Create";
            this.btn_create.UseVisualStyleBackColor = false;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // txt_Ca_Username
            // 
            this.txt_Ca_Username.Location = new System.Drawing.Point(143, 149);
            this.txt_Ca_Username.MaxLength = 8;
            this.txt_Ca_Username.Name = "txt_Ca_Username";
            this.txt_Ca_Username.Size = new System.Drawing.Size(203, 30);
            this.txt_Ca_Username.TabIndex = 10;
            // 
            // txt_Ca_Password
            // 
            this.txt_Ca_Password.Location = new System.Drawing.Point(143, 185);
            this.txt_Ca_Password.MaxLength = 8;
            this.txt_Ca_Password.Name = "txt_Ca_Password";
            this.txt_Ca_Password.Size = new System.Drawing.Size(203, 30);
            this.txt_Ca_Password.TabIndex = 9;
            // 
            // lbl_Ca_Password
            // 
            this.lbl_Ca_Password.AutoSize = true;
            this.lbl_Ca_Password.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ca_Password.Location = new System.Drawing.Point(17, 192);
            this.lbl_Ca_Password.Name = "lbl_Ca_Password";
            this.lbl_Ca_Password.Size = new System.Drawing.Size(78, 18);
            this.lbl_Ca_Password.TabIndex = 8;
            this.lbl_Ca_Password.Text = "Password";
            // 
            // lbl_Ca_Username
            // 
            this.lbl_Ca_Username.AutoSize = true;
            this.lbl_Ca_Username.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Ca_Username.Location = new System.Drawing.Point(17, 155);
            this.lbl_Ca_Username.Name = "lbl_Ca_Username";
            this.lbl_Ca_Username.Size = new System.Drawing.Size(80, 18);
            this.lbl_Ca_Username.TabIndex = 7;
            this.lbl_Ca_Username.Text = "Username";
            // 
            // gbx_CA
            // 
            this.gbx_CA.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbx_CA.Controls.Add(this.txt_Ca_Username);
            this.gbx_CA.Controls.Add(this.txt_Ca_Password);
            this.gbx_CA.Controls.Add(this.lbl_Ca_Password);
            this.gbx_CA.Controls.Add(this.lbl_Ca_Username);
            this.gbx_CA.Controls.Add(this.btn_create);
            this.gbx_CA.Controls.Add(this.txt_Ca_Lastname);
            this.gbx_CA.Controls.Add(this.txt_Ca_TelNum);
            this.gbx_CA.Controls.Add(this.txt_Ca_Firstname);
            this.gbx_CA.Controls.Add(this.lbl_PhoneNum);
            this.gbx_CA.Controls.Add(this.lbl_Lastname);
            this.gbx_CA.Controls.Add(this.lbl_firstname);
            this.gbx_CA.Font = new System.Drawing.Font("Comic Sans MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbx_CA.Location = new System.Drawing.Point(12, 12);
            this.gbx_CA.Name = "gbx_CA";
            this.gbx_CA.Size = new System.Drawing.Size(361, 268);
            this.gbx_CA.TabIndex = 11;
            this.gbx_CA.TabStop = false;
            this.gbx_CA.Text = "Create Acccount";
            // 
            // createNewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 292);
            this.Controls.Add(this.gbx_CA);
            this.Name = "createNewAccount";
            this.Text = "createNewAccount";
            this.gbx_CA.ResumeLayout(false);
            this.gbx_CA.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_firstname;
        private System.Windows.Forms.Label lbl_Lastname;
        private System.Windows.Forms.Label lbl_PhoneNum;
        private System.Windows.Forms.TextBox txt_Ca_Firstname;
        private System.Windows.Forms.TextBox txt_Ca_TelNum;
        private System.Windows.Forms.TextBox txt_Ca_Lastname;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.TextBox txt_Ca_Username;
        private System.Windows.Forms.TextBox txt_Ca_Password;
        private System.Windows.Forms.Label lbl_Ca_Password;
        private System.Windows.Forms.Label lbl_Ca_Username;
        private System.Windows.Forms.GroupBox gbx_CA;
    }
}