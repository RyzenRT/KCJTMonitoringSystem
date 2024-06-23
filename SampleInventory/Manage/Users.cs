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
    public partial class Users : Form
    {
        int IDNG;
        string ID;
        string Name;
        string Pass;
        string Level;
        string FN;
        string LN;
        string BDAY;
        string Gender;

        public Users()
        {
            InitializeComponent();
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

        private const int WS_SYSMENU = 0x80000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        private void ClearFIELDADD()
        {
            UserAddFIELD.Text = null;
            PassAddFIELD.Text = null;
            UserlvlAddFIELD.Text = null;
            FNAddFIELD.Text = null;
            LNAddFIELD.Text = null;
            BdayAddFIELD.Text = null;
            GenderAddFIELD.Text = null;
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Users", SQLLoad.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            UsersGridView.DataSource = dt;
            SQLLoad.con.Close();
        }

        private void NullID()
        {
            if (ID == null)
            {
                EditBTN.Enabled = false;
                DeleteBTN.Enabled = false;
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            // TODO: This line of code loads data into the 'sQLSERVERDS.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sQLSERVERDS.Users);
            // TODO: This line of code loads data into the 'sQLSERVERDS.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sQLSERVERDS.Users);
            if (CatchData.USRLVL == "Administrator")
            {

            }
            else
            {
                AddBTN.Enabled = false;
                EditBTN.Enabled = false;
                DeleteBTN.Enabled = false;
                CloseBTN.Enabled = false;
                AddBTN.Visible = false;
                EditBTN.Visible = false;
                DeleteBTN.Visible = false;
                CloseBTN.Visible = false;
            }

            ADDDOWNPANEL.Visible = false;
            LoadData();
            NullID();
            ClearFIELDADD();
            UsersGridView.AllowUserToAddRows = false;

            CloseButton.EnableDisable(this, false);
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            LoadData();
            UserFIELD.Text = null;
            UserlvlFIELD.Text = null;
            ID = null;
            NullID();
        }

        private void AddBTN_Click(object sender, EventArgs e)
        {
            ADDDOWNPANEL.Visible = true;

            AddBTN.Enabled = false;
            EditBTN.Enabled = false;

            DeleteBTN.Enabled = false;
            CloseBTN.Enabled = false;

            UserFIELD.Enabled = false;
            UserlvlFIELD.Enabled = false;

            UsersGridView.Enabled = false;
            ClearFIELDADD();

            if (UsersGridView.Rows.Count > 0 && UsersGridView.Rows != null)
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM Users order by ID Desc", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int ID = int.Parse(dt.Rows[0][0].ToString());

                IDNG = ID + 1;
            }
            else
            {
                IDNG = 1;
            }
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            ADDDOWNPANEL.Visible = true;

            AddBTN.Enabled = false;
            EditBTN.Enabled = false;

            DeleteBTN.Enabled = false;
            CloseBTN.Enabled = false;

            UserFIELD.Enabled = false;
            UserlvlFIELD.Enabled = false;

            UsersGridView.Enabled = false;

            ClearFIELDADD();

            UserAddFIELD.Enabled = false;
            UserAddFIELD.Text = Name.ToString();
            PassAddFIELD.Text = Pass.ToString();
            UserlvlAddFIELD.Text = Level.ToString();
            FNAddFIELD.Text = FN.ToString();
            LNAddFIELD.Text = LN.ToString();
            BdayAddFIELD.Text = BDAY.ToString();
            GenderAddFIELD.Text = Gender.ToString();
            SaveAddBTN.Text = "Update";
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            if (CatchData.NAME == Name)
            {
                MessageBox.Show("You cannot delete.", "Message");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete " + Name + " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    SqlCommand cmdDelete = new SqlCommand("delete from Users where ID = @ID", SQLLoad.con);
                    cmdDelete.Parameters.AddWithValue("ID", ID);
                    cmdDelete.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Delete Successfully!", "Message");
                    LoadData();
                    ID = null;
                    NullID();
                }
            }
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            this.Hide();
        }

        private void SaveAddBTN_Click(object sender, EventArgs e)
        {
            if (SaveAddBTN.Text == "Save")

            {
                if (UserAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Username", "Message");
                }
                else if (PassAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Password", "Message");
                }
                else if (UserlvlAddFIELD.Text == "")
                {
                    MessageBox.Show("Please select Userlevel", "Message");
                }
                else if (FNAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the First name", "Message");
                }
                else if (LNAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the last name", "Message");
                }
                else if (BdayAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the birthdate", "Message");
                }
                else if (GenderAddFIELD.Text == "")
                {
                    MessageBox.Show("Please Select Gender", "Message");
                }
                else
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();
                    string CountStr = "Select count(*) from Users where [Name] = @Name";
                    SqlCommand CountCmd = new SqlCommand(CountStr, SQLLoad.con);
                    CountCmd.CommandText = CountStr;
                    CountCmd.Parameters.Clear();
                    CountCmd.Parameters.AddWithValue("@Name", UserAddFIELD.Text);
                    int numRecords = (int)CountCmd.ExecuteScalar();


                    if (numRecords == 0)
                    {
                        string savestr = "insert into Users (ID, Name, Pass, Level, FN, LN, BDAY, Gender) values (@ID, @Name, @Pass, @Level, @FN, @LN, @BDAY, @Gender)";
                        SqlCommand savecmd = new SqlCommand(savestr, SQLLoad.con);

                        savecmd.Parameters.AddWithValue("@ID", IDNG.ToString());
                        savecmd.Parameters.AddWithValue("@Name", UserAddFIELD.Text);
                        savecmd.Parameters.AddWithValue("@Pass", PassAddFIELD.Text);
                        savecmd.Parameters.AddWithValue("@Level", UserlvlAddFIELD.Text);
                        savecmd.Parameters.AddWithValue("@FN", FNAddFIELD.Text);
                        savecmd.Parameters.AddWithValue("@LN", LNAddFIELD.Text);
                        savecmd.Parameters.AddWithValue("@BDAY", BdayAddFIELD.Value.ToString("yyyy-MM-dd"));
                        savecmd.Parameters.AddWithValue("@Gender", GenderAddFIELD.Text);

                        savecmd.ExecuteNonQuery();
                        SQLLoad.con.Close();

                        MessageBox.Show("Save Successfully!", "Message");

                        ADDDOWNPANEL.Visible = false;

                        AddBTN.Enabled = true;
                        CloseBTN.Enabled = true;

                        AddBTN.Visible = true;
                        EditBTN.Visible = true;

                        DeleteBTN.Visible = true;
                        CloseBTN.Visible = true;

                        UserFIELD.Enabled = true;
                        UserlvlFIELD.Enabled = true;

                        UsersGridView.Enabled = true;

                        ClearFIELDADD();
                        LoadData();
                        ID = null;
                        NullID();
                    }
                    else
                    {
                        MessageBox.Show("The Username is already exists.", "Message");
                    }
                }
            }

            else if (SaveAddBTN.Text == "Update")

            {
                if (UserAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Username", "Message");
                }
                else if (PassAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Password", "Message");
                }
                else if (UserlvlAddFIELD.Text == "")
                {
                    MessageBox.Show("Please select Userlevel", "Message");
                }
                else if (FNAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the First name", "Message");
                }
                else if (LNAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the last name", "Message");
                }
                else if (BdayAddFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the birthdate", "Message");
                }
                else if (GenderAddFIELD.Text == "")
                {
                    MessageBox.Show("Please Select Gender", "Message");
                }
                else
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    SqlCommand updatecmd = new SqlCommand("update Users set Name = @Name, Pass = @Pass, Level = @Level, FN = @FN, LN = @LN, BDAY = @BDAY, Gender = @Gender where ID = @ID ", SQLLoad.con);
                    updatecmd.Parameters.AddWithValue("@ID", ID.ToString());
                    updatecmd.Parameters.AddWithValue("@Name", UserAddFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@Pass", PassAddFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@Level", UserlvlAddFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@FN", FNAddFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@LN", LNAddFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@BDAY", BdayAddFIELD.Value.ToString("yyyy-MM-dd"));
                    updatecmd.Parameters.AddWithValue("@Gender", GenderAddFIELD.Text);
                    updatecmd.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Update Successfully!", "Message");

                    ADDDOWNPANEL.Visible = false;

                    AddBTN.Enabled = true;
                    CloseBTN.Enabled = true;

                    AddBTN.Visible = true;
                    EditBTN.Visible = true;

                    DeleteBTN.Visible = true;
                    CloseBTN.Visible = true;

                    UserFIELD.Enabled = true;
                    UserlvlFIELD.Enabled = true;

                    UsersGridView.Enabled = true;
                    UserAddFIELD.Enabled = true;

                    ClearFIELDADD();
                    LoadData();
                    ID = null;
                    NullID();
                }
            }

            SaveAddBTN.Text = "Save";
        }

        private void CancelAddBTN_Click(object sender, EventArgs e)
        {
            ADDDOWNPANEL.Visible = false;

            AddBTN.Enabled = true;
            CloseBTN.Enabled = true;

            AddBTN.Visible = true;
            EditBTN.Visible = true;

            DeleteBTN.Visible = true;
            CloseBTN.Visible = true;

            UserFIELD.Enabled = true;
            UserlvlFIELD.Enabled = true;

            UsersGridView.Enabled = true;

            UserAddFIELD.Enabled = true;

            ClearFIELDADD();
            ID = null;
            NullID();
            SaveAddBTN.Text = "Save";
        }

        private void UserFIELD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (UserFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Users where Name like '%" + UserFIELD.Text.Replace("'", "''") + "%' ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    UsersGridView.DataSource = dt;
                    SQLLoad.con.Close();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Check connection. Error.", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check connection. Error.", "Message");
            }
        }

        private void UserlvlFIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserlvlFIELD.Text == null)
            {
                LoadData();
            }
            else
            {
                SQLLoad.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Users where Level like '%" + UserlvlFIELD.Text + "%' ", SQLLoad.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                UsersGridView.DataSource = dt;
                SQLLoad.con.Close();
            }
        }

        private void UsersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ID == null)
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Users where Name = '" + UsersGridView.CurrentRow.Cells[1].Value.ToString() + "'", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID = dt.Rows[0][0].ToString();
                Name = dt.Rows[0][1].ToString();
                Pass = dt.Rows[0][2].ToString();
                Level = dt.Rows[0][3].ToString();
                FN = dt.Rows[0][4].ToString();
                LN = dt.Rows[0][5].ToString();
                BDAY = dt.Rows[0][6].ToString();
                Gender = dt.Rows[0][7].ToString();
                EditBTN.Enabled = true;
                DeleteBTN.Enabled = true;
            }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Users where Name = '" + UsersGridView.CurrentRow.Cells[1].Value.ToString() + "'", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID = dt.Rows[0][0].ToString();
                Name = dt.Rows[0][1].ToString();
                Pass = dt.Rows[0][2].ToString();
                Level = dt.Rows[0][3].ToString();
                FN = dt.Rows[0][4].ToString();
                LN = dt.Rows[0][5].ToString();
                BDAY = dt.Rows[0][6].ToString();
                Gender = dt.Rows[0][7].ToString();
                EditBTN.Enabled = true;
                DeleteBTN.Enabled = true;
            }
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void UserlvlFIELD_SelectedValueChanged(object sender, EventArgs e)
        {
            if (UserlvlFIELD.Text == null)
            {
                LoadData();
            }
            else
            {
                SQLLoad.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from Users where Level like '%" + UserlvlFIELD.Text + "%' ", SQLLoad.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                UsersGridView.DataSource = dt;
                SQLLoad.con.Close();
            }
        }

        private void TITLEPANEL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void TOPPANEL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ADDDOWNPANEL_MouseDown(object sender, MouseEventArgs e)
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

        private void XBTN_Click(object sender, EventArgs e)
        {
            if (CloseBTN.Enabled == true)
            {
                Dashboard Dashboard = new Dashboard();
                Dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please complete your task before closing this window.", "Message");
            }
        }
    }
}
