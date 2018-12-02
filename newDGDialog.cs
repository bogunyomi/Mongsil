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
    public partial class newDGDialog : Form
    {
        private SqlConnection score_DConn = new SqlConnection();
        
        public newDGDialog()
        {
            InitializeComponent();
            score_DConn.ConnectionString = "Server = localhost\\SQLEXPRESS02; Database = master; Trusted_Connection = True";
        }

        private void newDGDialog_Load(object sender, EventArgs e)
        {
            lbl_Name();
            gDMemberData();
        }

        private void lbl_Name()
        {
            foreach (Member memb in Main.club.Members)
            {
                if (memb.MemberID == "MT-0001")
                {
                    lblName.Text = memb.Firstname + " " + memb.Lastname;
                }

            }
        }

        private void gDMemberData()
        {
            cmbx_partnerOppList.Items.Add(" ");
            cmbx_p1OppList.Items.Add(" ");
            cmbx_p2OppList.Items.Add(" ");

            foreach (Member opponents in Main.club.Members)
            {
                if (!string.Equals(opponents.MemberID, "MT-0001", StringComparison.CurrentCultureIgnoreCase))
                {
                    cmbx_partnerOppList.Items.Add(opponents.Firstname + " " + opponents.Lastname);
                    cmbx_p1OppList.Items.Add(opponents.Firstname + " " + opponents.Lastname);
                    cmbx_p2OppList.Items.Add(opponents.Firstname + " " + opponents.Lastname);
                }
            }
        }
        
        private void cancelSave_Click(object sender, EventArgs e)
        {
            Hide();
            LoginPage.sMain.Show();
        }

        private void goSave_Click(object sender, EventArgs e)
        {
            Hide();
            updateDoublesScores();
            MessageBox.Show("Your game record has been updated");
            LoginPage.sMain.Show();
        }

        private void btn_dgetIt_Click_1(object sender, EventArgs e)
        {
            FlowLayoutPanel flow = new FlowLayoutPanel();
            flow.Name = "flow";
            flow.Location = new Point(15, 309);
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
            cCancel.Location = new Point(271, 427);
            cCancel.Name = "cancelSave";
            cCancel.Text = "Cancel";
            cCancel.Size = new Size(58, 22);
            cCancel.Click += new EventHandler(cancelSave_Click);

            Button cSave = new Button();
            cSave.Location = new Point(338, 427);
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

            int setIndex = Convert.ToInt32(txt_dsetsPlayed.Text);
            GroupBox[] gbxArray = new GroupBox[setIndex];
            ComboBox[,] cmbxArray = new ComboBox[setIndex, 2];

            for (int i = 0; i < setIndex; i++)
            {//for group box
                int xLoc = xLocation + dX;
                int yLoc = yLocation + dY;

                gbxArray[i] = new GroupBox();
                gbxArray[i].Text = "Set " + (i + 1);
                gbxArray[i].Name = "gbx_Set" + (i + 1);
                gbxArray[i].Location = new Point(xLoc, yLoc);
                gbxArray[i].Size = new Size(56, 72);
                //gbxArray[i].AutoSize = true;
                dX += 65;
                dY += 0;

                for (int j = 0; j < 2; j++)
                {//for combobox

                    if (j == 0)
                    {//even
                        int xLoc1 = 8;
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
                        int xLoc2 = 8;
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

        private void updateDoublesScores()
        {
            int sIndex = Convert.ToInt32(txt_dsetsPlayed.Text);
            string[,] gameScores = new string[sIndex, 2];
            string[] setScores = new string[sIndex];
            string gScores = "";
            int pMe = 0, pOpp = 0;

            for (int i = 0; i < sIndex; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    foreach (Control cbx in Controls)
                    {
                        if (cbx is FlowLayoutPanel && string.Equals(cbx.Name, "flow", StringComparison.CurrentCultureIgnoreCase))
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

            string oppNames = cmbx_p1OppList.Text.ToString() + " & " + cmbx_p2OppList.Text.ToString();
            string teamNames = LoginPage.dataKey + " & " + cmbx_partnerOppList.Text.ToString();
            string Uname = LoginPage.dataKey;
            string Loser = (pMe < pOpp) ? teamNames : oppNames;
            string Winner = (pMe > pOpp) ? teamNames : oppNames;

            score_DConn.Open();
            using (SqlCommand dScoreCommand = new SqlCommand("insert into logs.dbo.doublesGameRecord Values(" +
                                          "@Date, @Member, @Patner, @Opponent_1, @Opponent_2, @Loser, @Winner, @Scores)", score_DConn))

            {
                dScoreCommand.Parameters.AddWithValue("@Date", dtp_dGameDate.Value.ToShortDateString());
                dScoreCommand.Parameters.AddWithValue("@Member", Uname);
                dScoreCommand.Parameters.AddWithValue("@Patner", cmbx_partnerOppList.Text.ToString());
                dScoreCommand.Parameters.AddWithValue("@Opponent_1", cmbx_p1OppList.Text.ToString());
                dScoreCommand.Parameters.AddWithValue("@Opponent_2", cmbx_p2OppList.Text.ToString());
                dScoreCommand.Parameters.AddWithValue("@Loser", Loser);
                dScoreCommand.Parameters.AddWithValue("@Winner", Winner);
                dScoreCommand.Parameters.AddWithValue("@Scores", gScores.TrimStart(','));

                int rows = dScoreCommand.ExecuteNonQuery();
            }
            score_DConn.Close();
        }
    }
}
