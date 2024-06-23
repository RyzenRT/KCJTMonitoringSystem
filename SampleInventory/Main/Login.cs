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
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;
using RavSoft;


namespace SampleInventory
{
    public partial class Login : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x30000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        int IDDTR;
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 0, 0));
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Login_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            UserField.Text = "Administrator";
            PassField.Text = "Test123";
            CueProvider.SetCue(UserField, "Username");
            CueProvider.SetCue(PassField, "Password");
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserField.Text == "" && PassField.Text == "")
                {
                    MessageBox.Show("Please Fill up the Username or Password");
                }
                else if (UserField.Text == "")
                {
                    MessageBox.Show("Please Fill up the Username");
                }
                else if (PassField.Text == "")
                {
                    MessageBox.Show("Please Fill up the Password");
                }
                else
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();
                    string LoginStr = ("Select count (*) from Users where Name = @Name and Pass = @Pass");
                    SqlCommand LoginCmd = new SqlCommand(LoginStr, SQLLoad.con);
                    LoginCmd.Parameters.AddWithValue("Name", UserField.Text);
                    LoginCmd.Parameters.AddWithValue("Pass", PassField.Text);


                    int ctr = Convert.ToInt32(LoginCmd.ExecuteScalar().ToString());

                    if (ctr == 1)
                    {

                        SqlDataAdapter da = new SqlDataAdapter("Select * from Users where Name = '" + UserField.Text + "' and Pass = '" + PassField.Text + "'", SQLLoad.con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        CatchData.NAME = dt.Rows[0][1].ToString();
                        CatchData.USRLVL = dt.Rows[0][3].ToString();


                        MessageBox.Show("Login Successfully! Welcome " + CatchData.NAME + "!", "Success!");

                        SqlDataAdapter dtr = new SqlDataAdapter("SELECT top 1 * FROM UsersLog order by ID Desc", SQLLoad.con);
                        DataTable dtl = new DataTable();
                        dtr.Fill(dtl);

                        if (dtl.Rows.Count > 0 && dtl.Rows != null)
                        {
                            int DTR = int.Parse(dtl.Rows[0][0].ToString());

                            IDDTR = DTR + 1;
                            CatchData.DTR = DTR + 1;
                        }
                        else
                        {
                            IDDTR = 1;
                            CatchData.DTR = 1;
                        }

                        string savestr = "SET IDENTITY_INSERT UsersLog ON insert into UsersLog (ID, Name, Level, TimeIN) values (@ID, @Name, @Level, @TimeIN)";
                        SqlCommand savecmd = new SqlCommand(savestr, SQLLoad.con);

                        savecmd.Parameters.AddWithValue("@ID", IDDTR.ToString());
                        savecmd.Parameters.AddWithValue("@Name", dt.Rows[0][1].ToString());
                        savecmd.Parameters.AddWithValue("@Level", dt.Rows[0][3].ToString());
                        savecmd.Parameters.AddWithValue("@TimeIN", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));

                        savecmd.ExecuteNonQuery();
                        SQLLoad.con.Close();

                        Dashboard Dashboard = new Dashboard();
                        Dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed. Invalid Username or Password. Please try again.", "Error!");
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error!", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check your connections on Database / Error.", "Message");
            } 
        }

        private void GuestBTN_Click(object sender, EventArgs e)
        {
            CatchData.USRLVL = "Guest";

            MessageBox.Show("You're in Guest Mode", "Message.");

            SQLLoad.con.Close();
            SQLLoad.con.Open();
            SqlDataAdapter dtr = new SqlDataAdapter("SELECT top 1 * FROM UsersLog order by ID Desc", SQLLoad.con);
            DataTable dtl = new DataTable();
            dtr.Fill(dtl);

            if (dtl.Rows.Count > 0 && dtl.Rows != null)
            {
                int DTR = int.Parse(dtl.Rows[0][0].ToString());

                IDDTR = DTR + 1;
                CatchData.DTR = DTR + 1;
            }
            else
            {
                IDDTR = 1;
                CatchData.DTR = 1;
            }

            CatchData.NAME = "Guest";
            CatchData.USRLVL = "Guest";

            string savestr = "SET IDENTITY_INSERT UsersLog ON insert into UsersLog (ID, Name, Level, TimeIN) values (@ID, @Name, @Level, @TimeIN)";
            SqlCommand savecmd = new SqlCommand(savestr, SQLLoad.con);

            savecmd.Parameters.AddWithValue("@ID", CatchData.DTR.ToString());
            savecmd.Parameters.AddWithValue("@Name", CatchData.NAME.ToString());
            savecmd.Parameters.AddWithValue("@Level", CatchData.USRLVL.ToString());
            savecmd.Parameters.AddWithValue("@TimeIN", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));

            savecmd.ExecuteNonQuery();
            SQLLoad.con.Close();

            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            this.Hide();
        }

        private void XBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MINBTN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Loading_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {

        }
    }
}
