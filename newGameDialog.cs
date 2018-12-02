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
    public partial class newGameDialog : Form
    {
        private SqlConnection score_SConn = new SqlConnection();

        public newGameDialog()
        {
            InitializeComponent();
            score_SConn.ConnectionString = "Server = localhost\\SQLEXPRESS02; Database = master; Trusted_Connection = True";

        }

        private void newGameDialog_Load(object sender, EventArgs e)
        {
            gMemberData();
        }

        private void gMemberData()
        {
            cmbx_oppList.Items.Add(" ");

            foreach (Member opponents in Main.club.Members)
            {
                if (!string.Equals(opponents.MemberID, "MT-0001", StringComparison.CurrentCultureIgnoreCase))
                {
                    cmbx_oppList.Items.Add(opponents.Firstname + " " + opponents.Lastname);
                }
                
            }

        }

        private void btn_getIt_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Name = "flow";
            flow.Location = new Point(15, 140);
            flow.AutoSize = true;

            GroupBox setGroup = new GroupBox();
            setGroup.Text = "Enter scores";
            setGroup.Name = "setScores";
            setGroup.Location = new Point(3, 3);
            setGroup.Size = new Size(384, 106);
            setGroup.AutoSize = true;

            Label Me = new Label();
            Me.Location = new Point(6, 36);
            Me.Size = new Size(57, 13);
            Me.Text = "Me:";

            Label Opp = new Label();
            Opp.Location = new Point(6, 62);
            Opp.Size = new Size(57, 13);
            Opp.Text = "Opponent:";

            Button cCancel = new Button();
            cCancel.Location = new Point(277, 261);
            cCancel.Name = "cancelSave";
            cCancel.Text = "Cancel";
            cCancel.Size = new Size(58,22);
            cCancel.Click += new EventHandler(cancelSave_Click); 

            Button cSave = new Button();
            cSave.Location = new Point(341, 261);
            cSave.Name = "goSave";
            cSave.Text = "Save";
            cSave.Size = new Size(58, 22);
            cSave.Click += new EventHandler(goSave_Click);

            Controls.Add(flow);
            Controls.Add(cCancel);
            Controls.Add(cSave);

            flow.Controls.Add(setGroup);

            setGroup.Controls.Add(Me);
            setGroup.Controls.Add(Opp);

            int xLocation = 65;
            int yLocation = 16;
            int dX = 0;
            int dY = 0;

            int setIndex = Convert.ToInt32(txt_setsPlayed.Text);
            GroupBox[] gbxArray = new GroupBox[setIndex];
            ComboBox[,] cmbxArray = new ComboBox[setIndex, 2];
            
            for (int i = 0; i < setIndex ; i++)
            {//for group box
                int xLoc = xLocation + dX;
                int yLoc = yLocation + dY;

                gbxArray[i] = new GroupBox();
                gbxArray[i].Text = "Set " + (i+1);
                gbxArray[i].Name = "gbx_Set" + (i+1);
                gbxArray[i].Location = new Point(xLoc, yLoc);
                gbxArray[i].Size = new Size(56, 72);
                //gbxArray[i].AutoSize = true;
                dX += 65;
                dY += 0;

                for (int j = 0; j < 2 ; j++)
                {//for combobox

                    if (j == 0)
                    {//even
                        int xLoc1 =  8;
                        int yLoc1 = 15;

                        cmbxArray[i, j] = new ComboBox();
                        cmbxArray[i, j].FormattingEnabled = true;
                        cmbxArray[i, j].Name = "cmbx_Set" + i + j;
                        cmbxArray[i, j].Location = new Point(xLoc1, yLoc1);
                        cmbxArray[i, j].Size = new Size(40, 20);

                        for (int gameScore = 0; gameScore <= 7; gameScore++)
                        {
                            cmbxArray[i, j].Items.Add(gameScore);
                        }
                    }
                    else if (j == 1)
                    {//odd
                        int xLoc2 =  8;
                        int yLoc2 = 41;

                        cmbxArray[i, j] = new ComboBox();
                        cmbxArray[i, j].FormattingEnabled = true;
                        cmbxArray[i, j].Name = "cmbx_Set" + i + j;
                        cmbxArray[i, j].Location = new Point(xLoc2, yLoc2);
                        cmbxArray[i, j].Size = new Size(40, 20);

                        for (int gameScore = 0; gameScore <= 7; gameScore++)
                        {
                            cmbxArray[i, j].Items.Add(gameScore);
                        }
                    }
                    gbxArray[i].Controls.Add(cmbxArray[i, j]);
                }
                setGroup.Controls.Add(gbxArray[i]);
            }
        }

        private void cancelSave_Click(object sender, EventArgs e)
        {
            Hide();
            //Close();
            LoginPage.sMain.Show();
        }

        private void goSave_Click(object sender, EventArgs e)
        {
            Hide();
            updateSinglesScores();
            MessageBox.Show("Your game record has been updated");
            LoginPage.sMain.Show();
        }

        private void updateSinglesScores()
        {
            int sIndex = Convert.ToInt32(txt_setsPlayed.Text);
            string[,] gameScores = new string[sIndex, 2];
            string[] setScores = new string[sIndex];
            string gScores = "";
            int pMe = 0, pOpp =0;

            for (int i = 0; i < sIndex; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    foreach (Control cbx in Controls)
                    {
                        if(cbx is FlowLayoutPanel && string.Equals(cbx.Name, "flow", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach (Control cb in cbx.Controls)
                            {
                                if (cb is GroupBox && string.Equals(cb.Name, "setScores", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    foreach (Control gbx in cb.Controls)
                                    {
                                        if (gbx is GroupBox && string.Equals(gbx.Name, "gbx_Set" + (i + 1), StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            foreach (Control cmbx in gbx.Controls)
                                            {
                                                if (cmbx is ComboBox && string.Equals(cmbx.Name, "cmbx_Set" + i + j, StringComparison.CurrentCultureIgnoreCase))
                                                {
                                                    if (j == 0)
                                                    {
                                                        gameScores[i, j] = cmbx.Text;
                                                    }
                                                    else if (j == 1)
                                                    {
                                                        gameScores[i, j] = cmbx.Text;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                setScores[i] = string.Format("{0}{1} - {2}", ", ", gameScores[i, 0], gameScores[i, 1]);
                gScores += setScores[i];

                if (Convert.ToInt32(gameScores[i, 0]) > Convert.ToInt32(gameScores[i, 1])) 
                {
                    pMe++;
                }
                else if (Convert.ToInt32(gameScores[i, 0]) < Convert.ToInt32(gameScores[i, 1]))
                {
                    pOpp++;
                }
            }

            string Uname  = LoginPage.dataKey;
            string Loser  = (pMe < pOpp) ? Uname : cmbx_oppList.Text.ToString();
            string Winner = (pMe > pOpp) ? Uname : cmbx_oppList.Text.ToString();
            
            score_SConn.Open();
            using (SqlCommand sScoreCommand = new SqlCommand("insert into logs.dbo.singlesGameRecord Values(" +
                                          "@Username, @Date, @Opponent, @Scores, @Loser, @Winner)", score_SConn))

            {
                sScoreCommand.Parameters.AddWithValue("@Username", Uname);
                sScoreCommand.Parameters.AddWithValue("@Date", dtp_dGameDate.Value.ToShortDateString());
                sScoreCommand.Parameters.AddWithValue("@Opponent", cmbx_oppList.Text.ToString());
                sScoreCommand.Parameters.AddWithValue("@Scores", gScores.TrimStart(','));
                sScoreCommand.Parameters.AddWithValue("@Loser", Loser);
                sScoreCommand.Parameters.AddWithValue("@Winner", Winner);

                int rows = sScoreCommand.ExecuteNonQuery();
            }
            score_SConn.Close();
        }

        private void btn_cancelGameSave_Click(object sender, EventArgs e)
        {
            Hide();
            LoginPage.sMain.Show();
        }
    }
}
