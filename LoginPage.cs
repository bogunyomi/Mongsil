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
    public partial class LoginPage : Form
    {
        private SqlConnection myConnection = new SqlConnection();
        public static string dataKey;
        public static Main sMain = new Main();

        public LoginPage()
        {
            InitializeComponent();
            myConnection.ConnectionString = "Server = localhost\\SQLEXPRESS02; Database = master; Trusted_Connection = True";
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = "select Username, Password from logs.dbo.MongSil_Data where Username='" + txt_Username.Text +
                                    "' and Password='" + txt_Password.Text + "'";
            SqlDataReader myReader = myCommand.ExecuteReader();
            
            if (myReader.Read())
            {
                if (txt_Username.Text == myReader[0].ToString() && txt_Password.Text == myReader[1].ToString())
                {
                    dataKey = txt_Username.Text;
                    txt_Username.Clear();
                    txt_Username.Clear();
                    Hide();
                    sMain.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password");
                    txt_Username.Clear();
                    txt_Password.Clear();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
                txt_Username.Clear();
                txt_Password.Clear();
            }
            myReader.Close();
            myConnection.Close();
        }

        private void btn_createAcct_Click(object sender, EventArgs e)
        {
            Hide();
            createNewAccount cAcct = new createNewAccount();
            cAcct.Show();
        }
    }
}
