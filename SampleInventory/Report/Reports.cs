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
using System.Text.RegularExpressions;

namespace SampleInventory
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }


        string ID, Name, Address, DT, DTSO, SODR, SODRL, SODRN, Notes, Employee, DR, Type;


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

        private void getData(AutoCompleteStringCollection dataCollection)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DBKCJTMSBETA;Integrated Security=True";
            string sql = "Select distinct [Name] from [Transaction]";
            connection = new SqlConnection(connetionString);
            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                adapter.Dispose();
                command.Dispose();
                connection.Close();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dataCollection.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Connect Database.");
            }
        }

        private void DropDownLoadData()
        {
            SqlDataAdapter t = new SqlDataAdapter("Select * from [Transaction]", SQLLoad.con);
            DataTable ts = new DataTable();
            t.Fill(ts);
            SQLLoad.con.Close();
            transactionBindingSource.DataSource = ts;
            ts.DefaultView.Sort = "ID";
            NameFIELD.AutoCompleteMode = AutoCompleteMode.Suggest;
            NameFIELD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            NameFIELD.AutoCompleteCustomSource = DataCollection;
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            try
            {
                // TODO: This line of code loads data into the 'sQLSERVERDS.Transaclist' table. You can move, or remove it, as needed.
                this.transaclistTableAdapter.Fill(this.sQLSERVERDS.Transaclist);
                // TODO: This line of code loads data into the 'sQLSERVERDS.Transaction' table. You can move, or remove it, as needed.
                this.transactionTableAdapter.Fill(this.sQLSERVERDS.Transaction);

                EditBTN.Enabled = false;
                ViewBTN.Enabled = false;
                ModifiedBTN.Enabled = false;

                if (CatchData.USRLVL == "Administrator")
                {

                }
                else
                {
                    ModifiedBTN.Visible = false;
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }

            PANEL2.Visible = false;

            EDITPANEL.Visible = false;
            EDITPANEL.Enabled = false;

            TIMEPANEL.Visible = false;
            TIMEPANEL.Enabled = false;

            LoadData();
            DropDownLoadData();
            IHGridView.AllowUserToAddRows = false;
            TGridView.AllowUserToAddRows = false;
            CloseButton.EnableDisable(this, false);
        }

        private void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from [Transaction] order by ID DESC", SQLLoad.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            TGridView.DataSource = dt;
            SQLLoad.con.Close();
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            NameFIELD.Text = null;
            TypeFIELD.Text = null;
            SODRFIELD.Text = null;
            DTFrom.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DTTo.Text = DateTime.Now.ToString("yyyy-MM-dd");

            EditBTN.Enabled = false;
            ViewBTN.Enabled = false;
            ModifiedBTN.Enabled = false;

            LoadData();
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            this.Hide();
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            try
            {
                SQLLoad.con.Open();
                SqlDataAdapter sdad = new SqlDataAdapter("select * from [Transaction] where Name like '%" + NameFIELD.Text.Replace("'", "''") + "%' and Type like '%" + TypeFIELD.Text + "%' and Reference like '%" + SODRFIELD.Text + "%' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' order by ID DESC ", SQLLoad.con);
                DataTable dtd = new DataTable();
                sdad.Fill(dtd);
                TGridView.DataSource = dtd;
                dtd.DefaultView.Sort = "DateR";
                SQLLoad.con.Close();
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
        }

        private void TGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string TREF;
                string TNAME;

                TREF = TGridView.CurrentRow.Cells[3].Value.ToString();
                TNAME = TGridView.CurrentRow.Cells[1].Value.ToString();


                SqlDataAdapter da = new SqlDataAdapter("Select * from [Transaction] where Reference = '" + TREF + "' and Name = '" + TNAME.Replace("'", "''") + "'  order by ID DESC ", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID = dt.Rows[0][0].ToString();
                Name = dt.Rows[0][1].ToString();
                Address = dt.Rows[0][2].ToString();
                SODR = dt.Rows[0][3].ToString();
                Employee = dt.Rows[0][4].ToString();
                DTSO = dt.Rows[0][5].ToString();
                DT = dt.Rows[0][6].ToString();
                DR = dt.Rows[0][7].ToString();
                Notes = dt.Rows[0][8].ToString(); 

                SODRL = Regex.Replace(SODR, "[^a-zA-Z]", "");

                string MyString = SODR;
                char[] MyChar = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',' '};
                string NewString = MyString.TrimStart(MyChar);

                SODRN = NewString.ToString();

                EditBTN.Enabled = true;
                ViewBTN.Enabled = true;
                ModifiedBTN.Enabled = true;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
        }

        private void DoneBTN_Click(object sender, EventArgs e)
        {
            PANEL1.Visible = true;

            PANEL2.Visible = false;

            CloseBTN.Enabled = true;

            SearchBTN.Enabled = true;

            TOPPANEL.Enabled = true;
        }

        private void NameFIELD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (NameFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from [Transaction] where Name like '%" + NameFIELD.Text.Replace("'", "''") + "%'  order by ID DESC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TGridView.DataSource = dt;
                    SQLLoad.con.Close();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
        }

        private void TypeFIELD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from [Transaction] where Type like '%" + TypeFIELD.Text + "%'  order by ID DESC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TGridView.DataSource = dt;
                    SQLLoad.con.Close();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
        }

        private void SODRFIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (SODRFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from [Transaction] where Reference like '%" + SODRFIELD.Text + "%'  order by ID DESC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TGridView.DataSource = dt;
                    SQLLoad.con.Close();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong with database. Check your record before you proceed", "Message");
            }
        }

        private void PrintBTN_Click(object sender, EventArgs e)
        {
            //Init print datagridview
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Transactions | " + Type;//Header

            printer.SubTitle = "ORDER ACKNOWLEDGEMENT";

            printer.SubTitle = "Customer: " + Name + " | S.O. : " + SODR + " | Date : " + DT;


            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "KCJT Group, Inc.";//Footer
            printer.FooterSpacing = 15;
            printer.PageSettings.Landscape = true;
            printer.PrintPreviewNoDisplay(IHGridView);
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            TGridView.Enabled = false;

            EditBTN.Enabled = false;
            ViewBTN.Enabled = false;
            ModifiedBTN.Enabled = false;

            EDITPANEL.Enabled = true;
            EDITPANEL.Visible = true;

            CloseBTN.Enabled = false;
            SearchBTN.Enabled = false;

            TOPPANEL.Enabled = false;


            NameEFIELD.Text = Name;
            AddressFIELD.Text = Address;
            NoteFIELD.Text = Notes;
            SPLRFIELD.Text = SODRL;
            SODREFIELD.Text = SODRN;
            DateFIELD.Text = DT;
            DateTFIELD.Text = DTSO;
            CheckedFIELD.Text = Employee;
        }

        private void DelBTN_Click(object sender, EventArgs e)
        {
            EditBTN.Enabled = false;
            ViewBTN.Enabled = false;
        }

        private void ViewBTN_Click(object sender, EventArgs e)
        {
            SqlDataAdapter pgv = new SqlDataAdapter("select * from Transaclist where TID = '" + ID + "'", SQLLoad.con);
            DataTable pdt = new DataTable();
            pgv.Fill(pdt);
            IHGridView.DataSource = pdt;
            SQLLoad.con.Close();

            EditBTN.Enabled = false;
            ViewBTN.Enabled = false;
            ModifiedBTN.Enabled = false;

            PANEL1.Visible = false;

            PANEL2.Visible = true;

            CloseBTN.Enabled = false;
            SearchBTN.Enabled = false;

            TOPPANEL.Enabled = false;
        }

        private void ModifiedBTN_Click(object sender, EventArgs e)
        {
            TGridView.Enabled = false;

            EditBTN.Enabled = false;
            ViewBTN.Enabled = false;
            ModifiedBTN.Enabled = false;

            TIMEPANEL.Enabled = true;
            TIMEPANEL.Visible = true;

            CloseBTN.Enabled = false;
            SearchBTN.Enabled = false;

            TOPPANEL.Enabled = false;

            DateRFIELD.Text = DR;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                SODR = SPLRFIELD.Text + SODREFIELD.Text;

                if (NameEFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Costumer / Supplier", "Message");
                }
                else if (AddressFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Address", "Message");
                }
                else if (NoteFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Note", "Message");
                }
                else if (SODREFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Reference #", "Message");
                }
                else if (CheckedFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Employee", "Message");
                }
                else
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    SqlCommand updatecmd = new SqlCommand("update [Transaction] set Name = @Name, Address = @Address, DateT = @DateT, DateSO = @DateSO, Reference = @Reference, Note = @Note, Employee = @Employee where ID = '" + ID + "' ", SQLLoad.con);
                    updatecmd.Parameters.AddWithValue("@Name", NameEFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@Address", AddressFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@DateSO", DateTFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@Reference", SODR.ToString());
                    updatecmd.Parameters.AddWithValue("@Note", NoteFIELD.Text);
                    updatecmd.Parameters.AddWithValue("@Employee", CheckedFIELD.Text);
                    updatecmd.ExecuteNonQuery();

                    SqlCommand updatecmdtl = new SqlCommand("update Transaclist set Name = @Name, DateSO = @DateSO, DateT = @DateT where TID = '" + ID + "' ", SQLLoad.con);
                    updatecmdtl.Parameters.AddWithValue("@Name", NameEFIELD.Text);
                    updatecmdtl.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                    updatecmdtl.Parameters.AddWithValue("@DateSO", DateTFIELD.Text);
                    updatecmdtl.ExecuteNonQuery();

                    SqlCommand updatecmdih = new SqlCommand("update ItemsHistory set Customer = @Customer, RefNumber = @RefNumber, DateSO = @DateSO, DateT = @DateT where TID = '" + ID + "' ", SQLLoad.con);
                    updatecmdih.Parameters.AddWithValue("@Customer", NameEFIELD.Text);
                    updatecmdih.Parameters.AddWithValue("@RefNumber", SODR.ToString());
                    updatecmdih.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                    updatecmdih.Parameters.AddWithValue("@DateSO", DateTFIELD.Text);
                    updatecmdih.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Update Successfully!", "Message");

                    LoadData();
                    ID = null;
                }

                TGridView.Enabled = true;

                EDITPANEL.Enabled = false;
                EDITPANEL.Visible = false;

                CloseBTN.Enabled = true;
                SearchBTN.Enabled = true;

                TOPPANEL.Enabled = true;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error!", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", "Message");
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            TGridView.Enabled = true;

            EDITPANEL.Enabled = false;
            EDITPANEL.Visible = false;

            CloseBTN.Enabled = true;
            SearchBTN.Enabled = true;

            TOPPANEL.Enabled = true;
        }

        private void EditTimeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                SQLLoad.con.Close();
                SQLLoad.con.Open();

                SQLLoad.con.Close();
                SQLLoad.con.Open();

                SqlCommand updatecmd = new SqlCommand("update [Transaction] set DateR = @DateR where ID = '" + ID + "' ", SQLLoad.con);
                updatecmd.Parameters.AddWithValue("@DateR", DateRFIELD.Text);
                updatecmd.ExecuteNonQuery();

                SqlCommand updatecmdtl = new SqlCommand("update Transaclist set DateR = @DateR where TID = '" + ID + "' ", SQLLoad.con);
                updatecmdtl.Parameters.AddWithValue("@DateR", DateRFIELD.Text);
                updatecmdtl.ExecuteNonQuery();

                SqlCommand updatecmdih = new SqlCommand("update ItemsHistory set DateR = @DateR where TID = '" + ID + "' ", SQLLoad.con);
                updatecmdih.Parameters.AddWithValue("@DateR", DateRFIELD.Text);
                updatecmdih.ExecuteNonQuery();
                SQLLoad.con.Close();

                MessageBox.Show("Update Successfully!", "Message");

                LoadData();
                ID = null;

                TGridView.Enabled = true;

                TIMEPANEL.Enabled = false;
                TIMEPANEL.Visible = false;

                CloseBTN.Enabled = true;
                SearchBTN.Enabled = true;

                TOPPANEL.Enabled = true;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error!", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!", "Message");
            }
        }

        private void CnclTimeBTN_Click(object sender, EventArgs e)
        {
            TGridView.Enabled = true;

            TIMEPANEL.Enabled = false;
            TIMEPANEL.Visible = false;

            CloseBTN.Enabled = true;
            SearchBTN.Enabled = true;

            TOPPANEL.Enabled = true;
        }

        private void TOPPANEL_MouseDown(object sender, MouseEventArgs e)
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
