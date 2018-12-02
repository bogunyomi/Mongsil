using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using monGsilTennisLibrary;

namespace appTest
{
    public partial class clubPage : Form
    {
        private double bal;
        private SqlConnection caConnection = new SqlConnection();
        BindingSource membBinding = new BindingSource();

        public clubPage()
        {
            InitializeComponent();
            caConnection.ConnectionString = "Server = localhost\\SQLEXPRESS02; Database = master; Trusted_Connection = True";
        }

        private void clubPage_Load(object sender, EventArgs e)
        {
            membBinding.DataSource = Main.club.Members;
            lbx_clbMembers.DataSource = membBinding;
            lbx_clbMembers.DisplayMember = "Display";
            lbx_clbMembers.ValueMember = "Display";
            lbl_clBalance.Text = getClubBalance().ToString();
        }

        private double getClubBalance()
        {
            bal = 0;
            foreach (Member memb in Main.club.Members)
            {
                bal += memb.Balance;
            }
            return bal;
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            Member selectedMember = (Member)lbx_clbMembers.SelectedItem;
            selectedMember.payment(Convert.ToDouble(txt_Pay.Text));
            lbl_clBalance.Text = getClubBalance().ToString();
            txt_Pay.Clear();
            membBinding.ResetBindings(false);

            caConnection.Open();
            string ccString = "Update logs.dbo.MongSil_Data set Balance= @newBalance where Unique_ID = @searchKey";
            SqlCommand caCommand = new SqlCommand(ccString, caConnection);

            using (caCommand)
            {
                caCommand.Parameters.AddWithValue("@searchKey", selectedMember.MemberID);
                caCommand.Parameters.AddWithValue("@newBalance", selectedMember.Balance);
                caCommand.ExecuteNonQuery();
            }
            caConnection.Close();
        }

        private void btn_backMain_Click(object sender, EventArgs e)
        {
            Hide();
            LoginPage.sMain.Show();
        }
    }
}
