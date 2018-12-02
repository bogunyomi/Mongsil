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
    public partial class monthlyEvent : Form
    {
        int numbPart, numbTeams, numbSetperGames;
        int xLocEven = 165, yLocEven = 20;
        int xLocOdd = 10, yLocOdd = 20;
        int dyEven = 0, dyOdd = 0, numbGames = 0;
        //int yDep;
        int dx = 0, dy = 0, x = 10, y = 20;

        public monthlyEvent()
        {
            InitializeComponent();
        }

        private void monthlyEvent_Load(object sender, EventArgs e)
        {
            numbPart = Main.mEvent.Participants.Count();
            numbTeams = (numbPart % 2 == 0) ? (numbPart / 2) : (numbPart / 2 + 1);
            GroupBox[] gbxTeams = new GroupBox[numbTeams];
            ComboBox[,] cmbxParts = new ComboBox[numbTeams, 2];

            GroupBox teamsBox = new GroupBox();
            teamsBox.Text = "Teams";
            teamsBox.Name = "teamsBox";
            teamsBox.Location = new Point(10, 10);
            teamsBox.AutoSize = true;

            Controls.Add(teamsBox);
            
            for (int i = 0; i < numbTeams; i++)
            {
                if (i % 2 == 0)
                {
                    gbxTeams[i] = new GroupBox();
                    gbxTeams[i].Text = "Team " + (i + 1);
                    gbxTeams[i].Name = "gbx_Team" + (i + 1);
                    gbxTeams[i].Location = new Point(xLocOdd, yLocOdd + dyOdd);
                    gbxTeams[i].Size = new Size(140, 80);

                    dyOdd = 90;
                    teamsBox.Controls.Add(gbxTeams[i]);
                }
                else if (i % 2 == 1)
                {
                    gbxTeams[i] = new GroupBox();
                    gbxTeams[i].Text = "Team " + (i + 1);
                    gbxTeams[i].Name = "gbx_Team" + (i + 1);
                    gbxTeams[i].Location = new Point(xLocEven, yLocEven + dyEven);
                    gbxTeams[i].Size = new Size(140, 80);

                    dyEven = 90;
                    teamsBox.Controls.Add(gbxTeams[i]);
                }

                for (int j = 0; j < 2; j++)
                {//for combobox

                    if (j == 0)
                    {
                        cmbxParts[i, j] = new ComboBox();
                        cmbxParts[i, j].FormattingEnabled = true;
                        cmbxParts[i, j].Name = "cmbx_Set" + i + j;
                        cmbxParts[i, j].DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbxParts[i, j].Location = new Point(10, 20);
                        cmbxParts[i, j].Size = new Size(120, 21);

                        foreach (Member memb in Main.mEvent.Participants)
                        {
                            cmbxParts[i, j].Items.Add(memb.Firstname + " " + memb.Lastname);
                        }
                    }
                    else if (j == 1)
                    {
                        cmbxParts[i, j] = new ComboBox();
                        cmbxParts[i, j].FormattingEnabled = true;
                        cmbxParts[i, j].Name = "cmbx_Set" + i + j;
                        cmbxParts[i, j].DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbxParts[i, j].Location = new Point(10, 50);
                        cmbxParts[i, j].Size = new Size(120, 21);

                        foreach (Member memb in Main.mEvent.Participants)
                        {
                            cmbxParts[i, j].Items.Add(memb.Firstname + " " + memb.Lastname);
                        }
                    }
                    gbxTeams[i].Controls.Add(cmbxParts[i, j]);
                }
            }

            var yL = teamsBox.Size.Height;

            Button cCancel = new Button();
            cCancel.Location = new Point(10, yL + 20);
            cCancel.Name = "cancelSave";
            cCancel.Text = "<- Back";
            cCancel.AutoSize = true;
            Controls.Add(cCancel);
            cCancel.Click += new EventHandler(cancelmEvents_Click);

            Button cSave = new Button();
            var xLo = cCancel.Size.Width;
            var xCan = cCancel.Location.X;
            cSave.Location = new Point(xCan + xLo + 10, yL + 20);
            cSave.Name = "goSave";
            cSave.Text = "Save teams";
            cSave.AutoSize = true;
            Controls.Add(cSave);
            cSave.Click += new EventHandler(saveTeams_Click);

            Button bEdit = new Button();
            var xSlo = cSave.Location.X;
            var xSize = cSave.Width;
            bEdit.Location = new Point(xSlo + xSize + 10, yL + 20);
            bEdit.Name = "editBtn";
            bEdit.Text = "Edit teams";
            bEdit.AutoSize = true;
            Controls.Add(bEdit);
            bEdit.Click += new EventHandler(editTeams_Click);

            Label setLabel = new Label();
            var ySlo = cCancel.Size.Height;
            setLabel.Location = new Point(10, yL + ySlo + 40);
            setLabel.Name = "sLabel";
            setLabel.Text = "Sets per match";
            setLabel.AutoSize = true;
            Controls.Add(setLabel);

            TextBox setTxt = new TextBox();
            var yS = setLabel.Location.Y;
            var xLab = setLabel.Width;
            var xLabP = setLabel.Location.X;
            setTxt.Location = new Point(xLabP + xLab + 5, yS);
            setTxt.Name = "seTxt";
            setTxt.Size = new Size(30, 20);
            Controls.Add(setTxt);

            Button btnSEvent = new Button();
            var xS = setTxt.Location.X;
            var xW = setTxt.Width;
            btnSEvent.Location = new Point(xS + xW + 10, yS);
            btnSEvent.Name = "sUPEvents";
            btnSEvent.Text = "Setup games";
            btnSEvent.AutoSize = true;
            Controls.Add(btnSEvent);
            btnSEvent.Click += new EventHandler(setUPEvents_Click);

            DateTime time = DateTime.Now;
            string monEventName = "monthlyEvent_" + time.ToString();
            Main.mEvent.title = monEventName;
            Main.mEvent.Date = time;

        }

        private void cancelmEvents_Click(object sender, EventArgs e)
        {
            LoginPage.sMain.Show();
            Main.mEvent.Participants.Clear();
        }

        private void saveTeams_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numbTeams; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    foreach (Control gbx_1 in Controls)
                    {
                        if (gbx_1 is GroupBox && string.Equals(gbx_1.Name, "teamsBox", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach (Control gbx_2 in gbx_1.Controls)
                            {
                                if (gbx_2 is GroupBox && string.Equals(gbx_2.Name, "gbx_Team" + (i + 1), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    foreach (Control cmbx in gbx_2.Controls)
                                    {
                                        if (cmbx is ComboBox && string.Equals(cmbx.Name, "cmbx_Set" + i + j, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            cmbx.Enabled = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            MessageBox.Show("The teams have been saved", "Teams saved");

        }

        private void editTeams_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numbTeams; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    foreach (Control gbx_1 in Controls)
                    {
                        if (gbx_1 is GroupBox && string.Equals(gbx_1.Name, "teamsBox", StringComparison.CurrentCultureIgnoreCase))
                        {
                            foreach (Control gbx_2 in gbx_1.Controls)
                            {
                                if (gbx_2 is GroupBox && string.Equals(gbx_2.Name, "gbx_Team" + (i + 1), StringComparison.CurrentCultureIgnoreCase))
                                {
                                    foreach (Control cmbx in gbx_2.Controls)
                                    {
                                        if (cmbx is ComboBox && string.Equals(cmbx.Name, "cmbx_Set" + i + j, StringComparison.CurrentCultureIgnoreCase))
                                        {
                                            cmbx.Enabled = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void setUPEvents_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < numbTeams; i++)
            {
                numbGames += i;
            }
            //MessageBox.Show(numbGames.ToString());

            foreach (Control txtBx in Controls)
            {
                if (txtBx is TextBox && string.Equals(txtBx.Name, "seTxt", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (string.IsNullOrEmpty(txtBx.Text))
                    {
                        MessageBox.Show("Please enter the number of sets played per game", "Caution");
                    }
                    else
                    {
                        if (!int.TryParse(txtBx.Text, out numbSetperGames))
                        {
                            MessageBox.Show("This a number only field, please enter a valid integer number");
                            return;
                        }
                    }
                    
                }
            }

            GroupBox scoresBox = new GroupBox();
            scoresBox.Text = "Scores";
            scoresBox.Name = "scoresBox";
            scoresBox.AutoSize = true;
            //scoresBox.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            Controls.Add(scoresBox);

            foreach (Control btn in Controls)
            {
                if (btn is Button && string.Equals(btn.Name, "sUPEvents", StringComparison.CurrentCultureIgnoreCase))
                {
                    var yDep = btn.Height + btn.Location.Y;
                    scoresBox.Location = new Point(10, 10 + yDep);
                }
            }

            GroupBox[] gbxGames = new GroupBox[numbGames];
            GroupBox[] gbxSets = new GroupBox[numbSetperGames + 1];
            ComboBox[,] cmbxSets = new ComboBox[numbTeams, 2];

            for (int i = 0; i < numbGames; i++)
            {
                gbxGames[i] = new GroupBox();
                gbxGames[i].Text = "Game " + (i + 1);
                gbxGames[i].Name = "gbx_Game" + (i + 1);
                gbxGames[i].Location = new Point(x, y + dy);
                gbxGames[i].Size = new Size(140, 80);

                dy = gbxGames[i].Location.Y + gbxGames[i].Height;
                y = 10;
                
                scoresBox.Controls.Add(gbxGames[i]);

                for (int n = 0; n < numbSetperGames + 1; n++)
                {
                    dy = 0;
                    if (n == 0)
                    {
                        gbxSets[n] = new GroupBox();
                        gbxSets[n].Text = "Teams";
                        gbxSets[n].Name = "Teams4Game" + (i + 1);
                        gbxSets[n].Location = new Point(x, y + dy);
                        gbxSets[n].Size = new Size(140, 80);

                        dy = gbxSets[n].Location.Y + gbxSets[n].Height;
                        y = 10;

                        gbxGames[i].Controls.Add(gbxSets[n]);
                    }
                    else
                    {
                        gbxSets[n] = new GroupBox();
                        gbxSets[n].Text = "Game " + (i + 1);
                        gbxSets[n].Name = "gbx_Game" + (i + 1);
                        gbxSets[n].Location = new Point(x, y + dy);
                        gbxSets[n].Size = new Size(140, 80);

                        dy = gbxSets[n].Location.Y + gbxSets[n].Height;
                        y = 10;

                        gbxGames[i].Controls.Add(gbxSets[n]);
                    }

                }
                /*
                for (int j = 0; j < 2; j++)
                {//for combobox

                    if (j == 0)
                    {
                        cmbxParts[i, j] = new ComboBox();
                        cmbxParts[i, j].FormattingEnabled = true;
                        cmbxParts[i, j].Name = "cmbx_Set" + i + j;
                        cmbxParts[i, j].DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbxParts[i, j].Location = new Point(10, 20);
                        cmbxParts[i, j].Size = new Size(120, 21);

                        foreach (Member memb in Main.mEvent.Participants)
                        {
                            cmbxParts[i, j].Items.Add(memb.Firstname + " " + memb.Lastname);
                        }
                    }
                    else if (j == 1)
                    {
                        cmbxParts[i, j] = new ComboBox();
                        cmbxParts[i, j].FormattingEnabled = true;
                        cmbxParts[i, j].Name = "cmbx_Set" + i + j;
                        cmbxParts[i, j].DropDownStyle = ComboBoxStyle.DropDownList;
                        cmbxParts[i, j].Location = new Point(10, 50);
                        cmbxParts[i, j].Size = new Size(120, 21);

                        foreach (Member memb in Main.mEvent.Participants)
                        {
                            cmbxParts[i, j].Items.Add(memb.Firstname + " " + memb.Lastname);
                        }
                    }
                    gbxTeams[i].Controls.Add(cmbxParts[i, j]);
                }*/
            }
            
        }
    }
}
