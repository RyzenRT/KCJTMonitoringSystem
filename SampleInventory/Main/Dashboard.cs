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
using System.Runtime.InteropServices;

namespace SampleInventory
{
    public partial class Dashboard : Form
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

        public Dashboard()
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

        class CloseButton
        {
            private const int SC_CLOSE = 0xF060;
            private const int MF_GRAYED = 0x1;

            [DllImport("user32.dll")]
            private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

            [DllImport("user32.dll")]
            private static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

            public static void EnableDisable(Form form, bool isEnable)
            {
                EnableMenuItem(GetSystemMenu(form.Handle, isEnable), SC_CLOSE, MF_GRAYED);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            SQLLoad.con.Close();
            if (CatchData.USRLVL == "Administrator")
            {
                
            }
            else if (CatchData.USRLVL == "Encoder")
            {
                UsersBTN.Enabled = false;
            }
            else if (CatchData.USRLVL == "Employee")
            {
                UsersBTN.Enabled = false;
                PickupBTN.Enabled = false;
                SupplierBTN.Enabled = false;
                BackloadBTN.Enabled = false;
                ReturnBTN.Enabled = false;
            }
            else
            {
                UsersBTN.Enabled = false;
                PickupBTN.Enabled = false;
                SupplierBTN.Enabled = false;
                BackloadBTN.Enabled = false;
                ReturnBTN.Enabled = false;
            }
            CloseButton.EnableDisable(this, false);
            UserTXT.Text = "Welcome '" + CatchData.NAME + "'";
        }

        private void UsersBTN_Click(object sender, EventArgs e)
        {
            Users Users = new Users();
            Users.Show();
            this.Hide();
        }

        private void StocksBTN_Click(object sender, EventArgs e)
        {
            Stocks Stocks = new Stocks();
            Stocks.Show();
            this.Hide();
        }

        private void ReportsBTN_Click(object sender, EventArgs e)
        {
            Reports Reports = new Reports();
            Reports.Show();
            this.Hide();
        }

        private void SupplierBTN_Click(object sender, EventArgs e)
        {
            Supplier Supplier = new Supplier();
            Supplier.Show();
            this.Hide();
        }

        private void PickupBTN_Click(object sender, EventArgs e)
        {
            Pickup Pickup = new Pickup();
            Pickup.Show();
            this.Hide();
        }

        private void ReturnBTN_Click(object sender, EventArgs e)
        {
            Return Return = new Return();
            Return.Show();
            this.Hide();
        }

        private void BackloadBTN_Click(object sender, EventArgs e)
        {
            Backload Backload = new Backload();
            Backload.Show();
            this.Hide();
        }

        private void LogOutBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout?", "Message.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLLoad.con.Close();
                SQLLoad.con.Open();
                SqlCommand updatecmd = new SqlCommand("update UsersLog set TimeOUT = @TimeOUT where ID = @ID ", SQLLoad.con);
                updatecmd.Parameters.AddWithValue("@ID", CatchData.DTR.ToString());
                updatecmd.Parameters.AddWithValue("@TimeOUT", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                updatecmd.ExecuteNonQuery();
                SQLLoad.con.Close();

                CatchData.NAME = null;
                CatchData.USRLVL = null;
                CatchData.DTR = 0;

                Login Login = new Login();
                Login.Show();
                this.Hide();
            }
            else
            {

            }
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close Windows?", "Message.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLLoad.con.Close();
                SQLLoad.con.Open();
                SqlCommand updatecmd = new SqlCommand("update UsersLog set TimeOUT = @TimeOUT where ID = @ID", SQLLoad.con);
                updatecmd.Parameters.AddWithValue("@ID", CatchData.DTR.ToString());
                updatecmd.Parameters.AddWithValue("@TimeOUT", DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"));
                updatecmd.ExecuteNonQuery();
                SQLLoad.con.Close();

                CatchData.NAME = null;
                CatchData.USRLVL = null;
                CatchData.DTR = 0;

                Application.Exit();
            }
        }

        private void TimerDate_Tick(object sender, EventArgs e)
        {
            DateNTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
        }

        private void LeftPANEL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void FILLPANEL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MINBTN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TITLEPANEL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
