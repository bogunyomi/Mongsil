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

namespace appTest
{
    public partial class createNewAccount : Form
    {
        private SqlConnection caConnection = new SqlConnection();

        public createNewAccount()
        {
            InitializeComponent();
            caConnection.ConnectionString = "Server = localhost\\SQLEXPRESS02; Database = master; Trusted_Connection = True";
        }

        private int UniqueID()
        {
            int min = 1000;
            int max = 9999;
            Random rdm = new Random();
            return rdm.Next(min, max);
        }
        
        private void txt_Ca_Firstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Only accepts texts");
                txt_Ca_Firstname.Clear();
            }
        }
        
        private void txtBxClear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only accepts texts");
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            caConnection.Open();
            using (SqlCommand caCommand = new SqlCommand("insert into logs.dbo.MongSil_Data Values(" +
                                          "@Firstname, @Lastname, @Telephone_No, @Username, @Password, @Unique_ID, @Balance, @AdminRights)", caConnection))
            {
                caCommand.Parameters.AddWithValue("@Firstname", txt_Ca_Firstname.Text);
                caCommand.Parameters.AddWithValue("@Lastname", txt_Ca_Lastname.Text);
                caCommand.Parameters.AddWithValue("@Telephone_No", txt_Ca_TelNum.Text);
                caCommand.Parameters.AddWithValue("@Username", txt_Ca_Username.Text);
                caCommand.Parameters.AddWithValue("@Password", txt_Ca_Password.Text);
                string id = "MT-" + UniqueID().ToString();
                caCommand.Parameters.AddWithValue("@Unique_ID", id);
                caCommand.Parameters.AddWithValue("@Balance", 0);
                caCommand.Parameters.AddWithValue("@AdminRights", "No");
                try
                {
                    int rows = caCommand.ExecuteNonQuery();
                    MessageBox.Show("Congratulations! Your account has been created");
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("The Username you chose is already taken, please change it and proceed.");
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            caConnection.Close();

            Hide();
            LoginPage loginPg = new LoginPage();
            loginPg.Show();
        }

        private void txt_Ca_TelNum_MouseClick(object sender, MouseEventArgs e)
        {
            if(txt_Ca_TelNum.Text == "xxx-xxx-xxxx")
            {
                txt_Ca_TelNum.Clear();
            }
        }

        private void txt_Ca_Lastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("Only accepts texts");
                txt_Ca_Lastname.Clear();
            }
        }
    }
}
