using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using monGsilTennisLibrary;

namespace appTest
{
    public partial class Main : Form
    {
        public Member currentUser = new Member();
        private SqlConnection caConnection = new SqlConnection();
        public static Club club = new Club();
       
        double mEventCharge;

        public static MonthlyEvents mEvent = new MonthlyEvents();
        BindingSource memberBinding = new BindingSource();
        BindingSource participantBinding = new BindingSource();

        public Main()
        {
            InitializeComponent();
            caConnection.ConnectionString = "Server = localhost\\SQLEXPRESS02; Database = master; Trusted_Connection = True";
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string searchKey = LoginPage.dataKey;
            string cCommandString = "select Firstname, Lastname, Balance, Telephone_No, AdminRights, Unique_ID from logs.dbo.MongSil_Data where Username=@Username";
            SqlCommand caCommand = new SqlCommand(cCommandString, caConnection);
            caCommand.Parameters.AddWithValue("@Username", searchKey);
            caConnection.Open();
            using (SqlDataReader reader = caCommand.ExecuteReader())           
            {
                while (reader.Read())
                {
                    currentUser.Username = searchKey;
                    currentUser.Firstname = reader["Firstname"].ToString();
                    currentUser.Lastname = reader["Lastname"].ToString();
                    currentUser.Balance = Convert.ToDouble(reader["Balance"].ToString());
                    currentUser.FoneNumber = reader["Telephone_No"].ToString();
                    currentUser.Status = (currentUser.Balance >= 0) ? "Active" : "Not active";
                    currentUser.AdminRights = reader["AdminRights"].ToString();
                    currentUser.MemberID = reader["Unique_ID"].ToString();
                    
                }
                reader.Close();
            }
            caConnection.Close();
            tabPage2.Enabled = (string.Equals(currentUser.AdminRights, "Yes", StringComparison.CurrentCultureIgnoreCase)) ? true: false;
            lbl_mName.Text = currentUser.Firstname + " " + currentUser.Lastname;
            lbl_mBal.Text = currentUser.Balance.ToString();
            lbl_mStatus.Text = currentUser.Status;

            string gameType_1 = "Singles";
            cbx_Games.Items.Add(gameType_1);
            string gameType_2 = "Doubles";
            cbx_Games.Items.Add(gameType_2);
            
            caConnection.Close();
            setData();
            memberBinding.DataSource = club.Members;
            lbx_ClubMembers.DataSource = memberBinding;

            lbx_ClubMembers.DisplayMember = "Display";
            lbx_ClubMembers.ValueMember = "Display";

            participantBinding.DataSource = mEvent.Participants;
            lbx_Participants.DataSource = participantBinding;

            lbx_Participants.DisplayMember = "Display";
            lbx_Participants.ValueMember = "Display";

            gRightData();
        }

        private void setData()
        {
            if (string.Equals(currentUser.AdminRights, "Yes", StringComparison.CurrentCultureIgnoreCase))
                {
                    string mCommandString = "select * from logs.dbo.MongSil_Data";
                    SqlCommand mCommand = new SqlCommand(mCommandString, caConnection);
                    caConnection.Open();
                    
                    using (SqlDataReader reader = mCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                club.Members.Add(new Member
                                {
                                    Firstname = reader["Firstname"].ToString(),
                                    Lastname = reader["Lastname"].ToString(),
                                    Balance = Convert.ToDouble(reader["Balance"].ToString()),
                                    FoneNumber = reader["Telephone_No"].ToString(),
                                    Status = (currentUser.Balance >= 0) ? "Active" : "Not active",
                                    AdminRights = reader["AdminRights"].ToString(),
                                    MemberID = reader["Unique_ID"].ToString()

                                });
                            
                            }
                        }

                        reader.Close();

                    }

                    caConnection.Close();
                    
                }
        }

        private void btn_AddParticitants_Click(object sender, EventArgs e)
        {
            
            Member selectedMember = (Member)lbx_ClubMembers.SelectedItem;
            mEvent.Participants.Add(selectedMember);
            participantBinding.ResetBindings(false);

        }

        private void btn_cEvent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mE_Fee.Text))
            {
                MessageBox.Show("No monthly event fee was entered, please update it and proceed", "Caution");
            }
            else
            {
                if(!double.TryParse(txt_mE_Fee.Text, out mEventCharge))
                {
                    MessageBox.Show("This a number only field, please enter a valid number");
                    return;
                }
            }

            if (mEvent.Participants.Count() != 0)
            {
                foreach (Member m in mEvent.Participants)
                {
                    m.charge(mEventCharge);
                    mEvent.Funds += mEventCharge;

                    double newBalance = m.Balance;
                    string searchKey = m.MemberID;
                    caConnection.Open();

                    string ccString = "Update logs.dbo.MongSil_Data set Balance= @newBalance where Unique_ID = @searchKey";
                    SqlCommand caCommand = new SqlCommand(ccString, caConnection);

                    using (caCommand)
                    {
                        caCommand.Parameters.AddWithValue("@searchKey", searchKey);
                        caCommand.Parameters.AddWithValue("@newBalance", newBalance);
                        caCommand.ExecuteNonQuery();
                    }
                    caConnection.Close();
                }
            }
            else if (mEvent.Participants.Count() == 0)
            {
                MessageBox.Show("Participant list is empty, please add participants for the event");
            }
            lbl_meFunds.Text = Convert.ToString(mEvent.Funds);

            Hide();
            monthlyEvent mthEvent = new monthlyEvent();
            mthEvent.Show();

            //mEvent.Participants.Clear();
            memberBinding.ResetBindings(false);
            participantBinding.ResetBindings(false);
        }

        private void gRightData()
        {
            cmb_adminRights.Items.Add(" ");
            foreach (Member memb in club.Members)
            {
                if (string.Equals(memb.AdminRights, "no", StringComparison.CurrentCultureIgnoreCase))
                {
                    cmb_adminRights.Items.Add(memb.Firstname + " " + memb.Lastname);
                }
                
            }

        }

        private void btn_gRights_Click(object sender, EventArgs e)
        {
            string[] sData = cmb_adminRights.Text.Split(' ');
            string searchKey_1 = sData[0];
            string searchKey_2 = sData[1];

            caConnection.Open();

            string cString = "Update logs.dbo.MongSil_Data set AdminRights= @newAdminRights where Firstname = @searchKey_1 and Lastname = @searchKey_2";
            SqlCommand caCommand = new SqlCommand(cString, caConnection);
            string newAdminRights = "yes";
            using (caCommand)
            {
                caCommand.Parameters.AddWithValue("@searchKey_1", searchKey_1);
                caCommand.Parameters.AddWithValue("@searchKey_2", searchKey_2);
                caCommand.Parameters.AddWithValue("@newAdminRights", newAdminRights);
                caCommand.ExecuteNonQuery();
            }
            caConnection.Close();
            cmb_adminRights.SelectedIndex = -1;
        }

        private void btn_rRights_Click(object sender, EventArgs e)
        {
            string[] sData = cmb_adminRights.Text.Split(' ');
            string searchKey_1 = sData[0];
            string searchKey_2 = sData[1];

            caConnection.Open();

            string cString = "Update logs.dbo.MongSil_Data set AdminRights= @newAdminRights where Firstname = @searchKey_1 and Lastname = @searchKey_2";
            SqlCommand caCommand = new SqlCommand(cString, caConnection);
            string newAdminRights = "no";
            using (caCommand)
            {
                caCommand.Parameters.AddWithValue("@searchKey_1", searchKey_1);
                caCommand.Parameters.AddWithValue("@searchKey_2", searchKey_2);
                caCommand.Parameters.AddWithValue("@newAdminRights", newAdminRights);
                caCommand.ExecuteNonQuery();
            }
            caConnection.Close();
            cmb_adminRights.SelectedIndex = -1;
        }

        private void btn_cGame_Click(object sender, EventArgs e)
        {
            if (rbtn_singlesGame.Checked)
            {
                Hide();
                newGameDialog newSGDialog = new newGameDialog();
                newSGDialog.Show();
                rbtn_singlesGame.Checked = false;
            }

            if (rbtn_doublesGame.Checked)
            {
                Hide();
                newDGDialog newDGDialog = new newDGDialog();
                newDGDialog.Show();
                rbtn_doublesGame.Checked = false;
            }

        }
        
        private void btn_gGames_Click(object sender, EventArgs e)
        {
            if (string.Equals(cbx_Games.Text, "Singles", StringComparison.CurrentCultureIgnoreCase))
            {
                string cCommandString = "select top (5) Username, Date, Opponent, Scores, Loser, Winner from logs.dbo.singlesGameRecord where Username=@Username order by Date desc";
                SqlCommand caCommand = new SqlCommand(cCommandString, caConnection);
                caCommand.Parameters.AddWithValue("@Username", currentUser.Username.ToString());
                caConnection.Open();

                DataTable dTable = new DataTable();
                dTable.TableName = "last5Data";
                dTable.Columns.Add("Date");
                dTable.Columns.Add("Opponent");
                dTable.Columns.Add("Scores");
                dTable.Columns.Add("Winner");

                using (SqlDataReader reader = caCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dTable.Rows.Add(new object[] {  reader["Date"].ToString(),
                                                        reader["Opponent"].ToString(),
                                                        reader["Scores"].ToString(),
                                                        reader["Winner"].ToString()
                                                  });

                    }
                    reader.Close();
                }
                caConnection.Close();
                dgv_l5Games.DataSource = dTable;
            }
            else if (string.Equals(cbx_Games.Text, "Doubles", StringComparison.CurrentCultureIgnoreCase))
            {
                string cCommandString = "select top (5) Date, Username, Partner, Opponent_1, Opponent_2, Scores, Loser, Winner from logs.dbo.doublesGameRecord where Username=@Username order by Date desc";
                SqlCommand caCommand = new SqlCommand(cCommandString, caConnection);
                caCommand.Parameters.AddWithValue("@Username", currentUser.Username.ToString());
                caConnection.Open();

                DataTable dTable = new DataTable();
                dTable.TableName = "last5Data";
                dTable.Columns.Add("Date");
                dTable.Columns.Add("Opponent");
                dTable.Columns.Add("Scores");
                dTable.Columns.Add("Winner");

                using (SqlDataReader reader = caCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dTable.Rows.Add(new object[] {  reader["Date"].ToString(),
                                                        reader["Opponent_1"].ToString() + " & " + reader["Opponent_2"].ToString(),
                                                        reader["Scores"].ToString(),
                                                        reader["Winner"].ToString()
                                                  });

                    }
                    reader.Close();
                }
                caConnection.Close();
                dgv_l5Games.DataSource = dTable;
            }
            else
            {
                MessageBox.Show("Only accepts texts, Singles or Doubles");
            }
        }

        private void btn_getDues_Click(object sender, EventArgs e)
        {
            Hide();
            clubPage clubPg = new clubPage();
            clubPg.Show();
        }
        /*
private void CreateDatabase(DatabaseParam DBParam)
{
System.Data.SqlClient.SqlConnection tmpConn;
string sqlCreateDBQuery;
tmpConn = new SqlConnection();
tmpConn.ConnectionString = "SERVER = " + "BABAFEMIOGUFA90\\SQLEXPRESS02" +
               "; DATABASE = master; User ID = sa; Pwd = sa";
sqlCreateDBQuery = " CREATE DATABASE "
             + DBParam.DatabaseName
             + " ON PRIMARY "
             + " (NAME = " + DBParam.DataFileName + ", "
             + " FILENAME = '" + DBParam.DataPathName + "', "
             + " SIZE = 2MB,"
             + " FILEGROWTH =" + DBParam.DataFileGrowth + ") "
             + " LOG ON (NAME =" + DBParam.LogFileName + ", "
             + " FILENAME = '" + DBParam.LogPathName + "', "
             + " SIZE = 1MB, "
             + " FILEGROWTH =" + DBParam.LogFileGrowth + ") ";
SqlCommand myCommand = new SqlCommand(sqlCreateDBQuery, tmpConn);
try
{
tmpConn.Open();
MessageBox.Show(sqlCreateDBQuery);
myCommand.ExecuteNonQuery();
MessageBox.Show("Database has been created successfully!",
                "Create Database", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
}
catch (System.Exception ex)
{
MessageBox.Show(ex.ToString(), "Create Database",
                          MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
}
finally
{
tmpConn.Close();
}
return;
}*/



    }

}