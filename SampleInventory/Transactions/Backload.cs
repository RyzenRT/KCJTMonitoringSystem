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
    public partial class Backload : Form
    {
        // ID PICK //
        string ID, IDs, TID, BID;

        // ID GENERATED FROM DT //
        int IDTT, IDTL, IDIH, IDTR;

        // GET S.O. / D.R. / P.R. / C.M. //
        string SODR;

        // GET QUANTITY //
        int Qty, RQty, SrvQty, BlnQty, ProductQty, ProductRQty, RefQTY;

        // GET INFO ITEMS //
        string ItemHistory, ProductUnit, ProductItem, ProductRUnit, ProductRItem, Ref;

        // GET DATA FROM TRANSACTION DT //
        string GETTID, GETQuantity, GETUnit, GETItem, GETReference, GETRefQuantity, GETRefUnit, GETRefItem, GETName;
        string GETRemarks, GETChecker, GETIDTT, GETIDTL, GETIDIH;

        // BALANCE QUANTITY //
        int Balance, Balance2, Balance3;

        // UPDATE ITEMS //
        string EDIT, REMOVE;

        public Backload()
        {
            InitializeComponent();
        }

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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

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

        // CLEAR DATA ///////////////////////
        private void ClearItemFIELD()
        {
            ItemFIELD.Text = null;
            RefItemFIELD.Text = null;
            QTYFIELD.Text = "0";
            RefQTYFIELD.Text = "0";
            RemarksFIELD.Text = null;
            CheckerFIELD.Text = null;
        }
        private void ClearFIELD()
        {
            NameFIELD.Text = null;
            AddressFIELD.Text = null;
            DateFIELD.Text = null;
            DateSOFIELD.Text = null;
            SPLRFIELD.Text = null;
            SODRFIELD.Text = null;

            NoteFIELD.Text = null;
            ReportFIELD.Text = null;
        }
        // SWITCHING ////////////////////////
        private void OFFFIELD()
        {
            NameFIELD.Enabled = false;
            AddressFIELD.Enabled = false;
            DateFIELD.Enabled = false;
            DateSOFIELD.Enabled = false;
            SPLRFIELD.Enabled = false;
            YEARFIELD.Enabled = false;
            SODRFIELD.Enabled = false;

            CreateBTN.Enabled = true;
            CloseBTN.Enabled = true;
            EditBTN.Enabled = false;
            DelBTN.Enabled = false;

            InfoSaveBTN.Enabled = false;
            InfoCancelBTN.Enabled = false;
        }
        private void ONFIELD()
        {
            NameFIELD.Enabled = true;
            AddressFIELD.Enabled = true;
            DateFIELD.Enabled = true;
            DateSOFIELD.Enabled = true;
            SPLRFIELD.Enabled = true;
            YEARFIELD.Enabled = true;
            SODRFIELD.Enabled = true;

            CreateBTN.Enabled = false;
            CloseBTN.Enabled = false;
            EditBTN.Enabled = false;
            DelBTN.Enabled = false;

            InfoSaveBTN.Enabled = true;
            InfoCancelBTN.Enabled = true;
        }
        // FILTER DATA ///////////////////////////////////////////////////////
        private void BoxgetData(AutoCompleteStringCollection dataCollection2)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DBKCJTMSBETA;Integrated Security=True";
            string sql = "Select distinct [Name] from [Transaction] where Type = 'Export'";
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
                    dataCollection2.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Connect Database.");
            }
        }
        private void BoxLoadData()
        {
            SqlDataAdapter t = new SqlDataAdapter("Select * from [Transaction]", SQLLoad.con);
            DataTable ts = new DataTable();
            t.Fill(ts);
            SQLLoad.con.Close();
            BKLDbindingSource.DataSource = ts;
            ts.DefaultView.Sort = "ID";
            NameFIELD.AutoCompleteMode = AutoCompleteMode.Suggest;
            NameFIELD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            BoxgetData(DataCollection);
            NameFIELD.AutoCompleteCustomSource = DataCollection;
        }
        // FILTER ITEM DATA /////////////////////////////////////////////
        private void getData(AutoCompleteStringCollection dataCollection)
        {
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            connetionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DBKCJTMSBETA;Integrated Security=True";
            string sql = "Select distinct [Item] from [Items]";
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
            SqlDataAdapter t = new SqlDataAdapter("Select * from [Items]", SQLLoad.con);
            DataTable ts = new DataTable();
            t.Fill(ts);
            SQLLoad.con.Close();
            itemsBindingSource.DataSource = ts;
            ts.DefaultView.Sort = "ID";
            ItemFIELD.AutoCompleteMode = AutoCompleteMode.Suggest;
            ItemFIELD.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            getData(DataCollection);
            ItemFIELD.AutoCompleteCustomSource = DataCollection;
        }

        // LOAD DATA //////////////
        private void LoadDataBLID()
        {
            SQLLoad.con.Close();
            SQLLoad.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from TransacTemp where TID = '" + TID + "'", SQLLoad.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PickupGridView.DataSource = dt;

            SqlDataAdapter sda2 = new SqlDataAdapter("select * from ItemsHistory where Item = '" + ItemHistory + "' order by ID DESC ", SQLLoad.con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            ItemHGridView.DataSource = dt2;
            SQLLoad.con.Close();
        }
        private void LoadDataBLZERO()
        {
            string BLANK = "Null";
            SQLLoad.con.Close();
            SQLLoad.con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select * from TransacTemp where TID = '" + 0 + "'", SQLLoad.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PickupGridView.DataSource = dt;

            SqlDataAdapter sda2 = new SqlDataAdapter("select * from ItemsHistory where Item = '" + BLANK + "'", SQLLoad.con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            ItemHGridView.DataSource = dt2;
            SQLLoad.con.Close();
        }
        private void LoadDataIH()
        {
            SqlDataAdapter sda2 = new SqlDataAdapter("select * from ItemsHistory where Item = '" + ItemHistory + "' order by ID DESC ", SQLLoad.con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            ItemHGridView.DataSource = dt2;
            SQLLoad.con.Close();
        }

        // NUMBER ONLY ////////////////////////////////////////////////////////////
        private void SODRFIELD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one line point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }
        private void QTYFIELD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void RefQTYFIELD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        // GENERATED ID ////////////////////////////////////////////////////////////
        private void RNGTT()
        {
            try
            {
                if (PickupGridView.Rows.Count > 0 && PickupGridView.Rows != null)
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM TransacTemp order by ID Desc", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int TTID = int.Parse(dt.Rows[0][0].ToString());

                    IDTT = TTID + 1;
                }
                else
                {
                    IDTT = 1;
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
        private void RNGTL()
        {
            try
            {
                string CountSTRTL = "Select count(*) from Transaclist";
                SqlCommand CountCMDTL = new SqlCommand(CountSTRTL, SQLLoad.con);
                int RNG = Convert.ToInt32(CountCMDTL.ExecuteScalar().ToString());
                if (RNG == 0)
                {
                    IDTL = RNG + 1;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM Transaclist order by ID Desc", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int IHID = int.Parse(dt.Rows[0][0].ToString());

                    IDTL = IHID + 1;
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
        private void RNGIH()
        {
            try
            {
                string CountSTRIH = "Select count(*) from ItemsHistory";
                SqlCommand CountCMDIH = new SqlCommand(CountSTRIH, SQLLoad.con);
                int RNG = Convert.ToInt32(CountCMDIH.ExecuteScalar().ToString());
                if (RNG == 0)
                {
                    IDIH = RNG + 1;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM ItemsHistory order by ID Desc", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int IHID = int.Parse(dt.Rows[0][0].ToString());

                    IDIH = IHID + 1;
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
        private void RNGTR()
        {
            try
            {
                string CountSTRTR = "Select count(*) from [Transaction]";
                SqlCommand CountCMDTR = new SqlCommand(CountSTRTR, SQLLoad.con);
                int RNG = Convert.ToInt32(CountCMDTR.ExecuteScalar().ToString());
                if (RNG == 0)
                {
                    IDTR = RNG + 1;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM [Transaction] order by ID Desc", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int TRID = int.Parse(dt.Rows[0][0].ToString());

                    IDTR = TRID + 1;
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

        // START LOADING BACKLOAD ////////////////////////////
        private void Backload_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            // TODO: This line of code loads data into the 'sQLSERVERDS.Transaction' table. You can move, or remove it, as needed.
            this.transactionTableAdapter.Fill(this.sQLSERVERDS.Transaction);
            // TODO: This line of code loads data into the 'sQLSERVERDS.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.sQLSERVERDS.Items);
            // TODO: This line of code loads data into the 'sQLSERVERDS.ItemsHistory' table. You can move, or remove it, as needed.
            this.itemsHistoryTableAdapter.Fill(this.sQLSERVERDS.ItemsHistory);
            // TODO: This line of code loads data into the 'sQLSERVERDS.Transaclist' table. You can move, or remove it, as needed.
            this.transaclistTableAdapter.Fill(this.sQLSERVERDS.Transaclist);

            RefreshBTN.Enabled = false;
            EditBTN.Enabled = false;
            DelBTN.Enabled = false;
            LOWPANEL.Enabled = false;
            LOWPANEL.Visible = false;
            OFFFIELD();

            PickupGridView.AllowUserToAddRows = false;
            ItemHGridView.AllowUserToAddRows = false;

            LoadDataBLZERO();
            BoxLoadData();
            DropDownLoadData();

            SQLLoad.con.Close();
            CloseButton.EnableDisable(this, false);
        }

        /// <summary>
        /// LEFTPANEL
        /// </summary>
        /// <param name="TOPPANEL"></param>
        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            LoadDataBLID();
            DelBTN.Enabled = false;
            EditBTN.Enabled = false;

            GETTID = null;
            GETQuantity = null;
            GETUnit = null;
            GETItem = null;
            GETReference = null;
            GETRefQuantity = null;
            GETRefUnit = null;
            GETRefItem = null;
            GETName = null;
            GETRemarks = null;
            GETChecker = null;
            ItemHistory = null;

            LoadDataIH();
            ClearItemFIELD();
            ItemHTXT.Text = "Item:";
        }

        private void CreateBTN_Click(object sender, EventArgs e)
        {
            SQLLoad.con.Close();
            SQLLoad.con.Open();

            RNGTR();

            TID = IDTR.ToString();

            ONFIELD();

            SqlCommand cmdDeleteTL = new SqlCommand("delete from Transaclist where @TID = TID", SQLLoad.con);
            cmdDeleteTL.Parameters.AddWithValue("TID", TID.ToString());
            cmdDeleteTL.ExecuteNonQuery();

            SqlCommand cmdDeleteTT = new SqlCommand("delete from TransacTemp where @TID = TID", SQLLoad.con);
            cmdDeleteTT.Parameters.AddWithValue("TID", TID.ToString());
            cmdDeleteTT.ExecuteNonQuery();

            SqlCommand cmdDeleteIH = new SqlCommand("delete from ItemsHistory where TID = @TID", SQLLoad.con);
            cmdDeleteIH.Parameters.AddWithValue("TID", TID.ToString());
            cmdDeleteIH.ExecuteNonQuery();

            SQLLoad.con.Close();
        }

        private void InfoSaveBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (SPLRFIELD.Text == "CM")
                {
                    SODR = SPLRFIELD.Text + YEARFIELD.Text + "-" + SODRFIELD.Text;
                }
                else
                {
                    SODR = "CM" + YEARFIELD.Text + "-" + SODRFIELD.Text + "-" + SPLRFIELD.Text;
                }

                SQLLoad.con.Close();
                SQLLoad.con.Open();
                string CountStr = "Select count(*) from [Transaction] where [Name] = @Customer and [Reference] = @Reference";
                SqlCommand CountCmd = new SqlCommand(CountStr, SQLLoad.con);
                CountCmd.CommandText = CountStr;
                CountCmd.Parameters.Clear();
                CountCmd.Parameters.AddWithValue("@Customer", NameFIELD.Text);
                CountCmd.Parameters.AddWithValue("@Reference", SODR.ToString());
                int numRecords = (int)CountCmd.ExecuteScalar();

                if (numRecords == 0)
                {
                    if (NameFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Name/Description.", "Message");
                    }
                    else if (AddressFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Address.", "Message");
                    }
                    else if (DateFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Date.", "Message");
                    }
                    else if (SODRFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the S.O./D.R. .", "Message");
                    }
                    else
                    {
                        RefreshBTN.Enabled = true;

                        NameFIELD.Enabled = false;
                        AddressFIELD.Enabled = false;
                        DateFIELD.Enabled = false;
                        DateSOFIELD.Enabled = false;
                        SPLRFIELD.Enabled = false;
                        YEARFIELD.Enabled = false;
                        SODRFIELD.Enabled = false;

                        InfoSaveBTN.Enabled = false;
                        InfoCancelBTN.Enabled = false;
                        LOWPANEL.Enabled = true;
                        LOWPANEL.Visible = true;

                        ClearItemFIELD();
                    }
                }
                else
                {
                    MessageBox.Show("The Record are already exist.", "Message");
                }
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
        private void InfoCancelBTN_Click(object sender, EventArgs e)
        {
            ID = null;
            TID = null;
            OFFFIELD();
            ClearItemFIELD();
            ClearFIELD();
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            AddBTN.Text = "Update";
            UCancelBTN.Enabled = true;

            RefreshBTN.Enabled = false;

            EditBTN.Enabled = false;
            DelBTN.Enabled = false;

            SaveBTN.Enabled = false;
            CancelBTN.Enabled = false;

            PickupGridView.Enabled = false;

            ItemFIELD.Text = GETItem.ToString();
            QTYFIELD.Text = GETQuantity.ToString();
            UnitFIELD.Text = GETUnit.ToString();

            RefItemFIELD.Text = GETRefItem.ToString();
            RefQTYFIELD.Text = GETRefQuantity.ToString();
            RefUnitFIELD.Text = GETRefUnit.ToString();

            CheckerFIELD.Text = GETChecker.ToString();

            RemarksFIELD.Text = GETRemarks.ToString();
        }

        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete " + GETItem + " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    SqlCommand cmdDeleteTL = new SqlCommand("delete from Transaclist where Item = @Item and TID = @TID", SQLLoad.con);
                    cmdDeleteTL.Parameters.AddWithValue("TID", GETTID.ToString());
                    cmdDeleteTL.Parameters.AddWithValue("Item", PickupGridView.CurrentRow.Cells[3].Value.ToString());
                    cmdDeleteTL.ExecuteNonQuery();

                    SqlCommand cmdDeleteTT = new SqlCommand("delete from TransacTemp where Item = @Item and TID = @TID", SQLLoad.con);
                    cmdDeleteTT.Parameters.AddWithValue("TID", GETTID.ToString());
                    cmdDeleteTT.Parameters.AddWithValue("Item", PickupGridView.CurrentRow.Cells[3].Value.ToString());
                    cmdDeleteTT.ExecuteNonQuery();

                    SqlCommand cmdDeleteIH = new SqlCommand("delete from ItemsHistory where Item = @Item and TID = @TID", SQLLoad.con);
                    cmdDeleteIH.Parameters.AddWithValue("TID", GETTID.ToString());
                    cmdDeleteIH.Parameters.AddWithValue("Item", PickupGridView.CurrentRow.Cells[3].Value.ToString());
                    cmdDeleteIH.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Delete Successfully!", "Message");
                    LoadDataBLID();

                    EditBTN.Enabled = false;
                    DelBTN.Enabled = false;
                }
                else
                {

                }
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

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            this.Hide();
        }

        /// <summary>
        /// LEFTPANEL
        /// </summary>
        /// <param name="LOWPANEL"></param>
        private void AddBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (AddBTN.Text == "Add")
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();
                    string CountItems = "Select count(*) from Items where [Item] = @Item";
                    SqlCommand CountICmd = new SqlCommand(CountItems, SQLLoad.con);
                    CountICmd.CommandText = CountItems;
                    CountICmd.Parameters.Clear();
                    CountICmd.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                    int Records = (int)CountICmd.ExecuteScalar();

                    if (Records == 0)
                    {
                        MessageBox.Show("The Item Description does not exists.", "Message");
                    }
                    else
                    {
                        if (ItemFIELD.Text == "")
                        {
                            MessageBox.Show("Please fill the Item Description", "Message");
                        }
                        else if (QTYFIELD.Text == "")
                        {
                            MessageBox.Show("Please fill the Quantity", "Message");
                        }
                        else if (QTYFIELD.Text == "0")
                        {
                            MessageBox.Show("Please enter the correct Quantity", "Message");
                        }
                        else
                        {
                            string CountStr = "Select count(*) from TransacTemp where [Item] = @Item and [TID] = @TID";
                            SqlCommand CountCmd = new SqlCommand(CountStr, SQLLoad.con);
                            CountCmd.CommandText = CountStr;
                            CountCmd.Parameters.Clear();
                            CountCmd.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                            CountCmd.Parameters.AddWithValue("@TID", TID.ToString());
                            int numRecords = (int)CountCmd.ExecuteScalar();


                            if (numRecords == 0)
                            {
                                Qty = int.Parse(QTYFIELD.Text);

                                SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                ProductUnit = dt.Rows[0][1].ToString();
                                ProductQty = int.Parse(dt.Rows[0][3].ToString());
                                ProductItem = dt.Rows[0][6].ToString();

                                if (RefItemFIELD.Text == "")
                                {

                                }
                                else
                                {
                                    RQty = int.Parse(RefQTYFIELD.Text);

                                    SqlDataAdapter darf = new SqlDataAdapter("Select * from Items where Item = '" + RefItemFIELD.Text + "'", SQLLoad.con);
                                    DataTable dtrf = new DataTable();
                                    darf.Fill(dtrf);

                                    ProductRUnit = dtrf.Rows[0][1].ToString();
                                    ProductRQty = int.Parse(dtrf.Rows[0][3].ToString());
                                    ProductRItem = dtrf.Rows[0][6].ToString();
                                }

                                Balance = ProductQty + Qty;
                                Balance2 = ProductRQty + RQty;

                                RNGTT();
                                string savestrTR = "insert into TransacTemp (ID, TID, Qty, Unit, Item, Reference, RefQty, RefUnit, RefItem, Name, DateSO, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @RefUnit, @RefItem, @Name, @DateSO, @DateR, @DateT, @Remarks, @Checker, @Type)";
                                SqlCommand savecmdTR = new SqlCommand(savestrTR, SQLLoad.con);

                                savecmdTR.Parameters.AddWithValue("@ID", IDTT.ToString());
                                savecmdTR.Parameters.AddWithValue("@TID", TID.ToString());

                                savecmdTR.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Item", ItemFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    savecmdTR.Parameters.AddWithValue("@Reference", "No");
                                    savecmdTR.Parameters.AddWithValue("@RefQty", "");
                                    savecmdTR.Parameters.AddWithValue("@RefUnit", "");
                                    savecmdTR.Parameters.AddWithValue("@RefItem", "");
                                }
                                else
                                {
                                    savecmdTR.Parameters.AddWithValue("@Reference", "Yes");
                                    savecmdTR.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    savecmdTR.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    savecmdTR.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                }

                                savecmdTR.Parameters.AddWithValue("@Name", NameFIELD.Text);

                                savecmdTR.Parameters.AddWithValue("@DateSO", DateSOFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                                savecmdTR.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Type", "Backload");
                                savecmdTR.ExecuteNonQuery();

                                RNGTL();
                                string savestrTL = "insert into Transaclist (ID, TID, Qty, Unit, Item, Reference, RefQty, RefUnit, RefItem, Name, DateSO, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @RefUnit, @RefItem, @Name, @DateSO, @DateR, @DateT, @Remarks, @Checker, @Type)";
                                SqlCommand savecmdTL = new SqlCommand(savestrTL, SQLLoad.con);

                                savecmdTL.Parameters.AddWithValue("@ID", IDTL.ToString());
                                savecmdTL.Parameters.AddWithValue("@TID", TID.ToString());

                                savecmdTL.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Item", ItemFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    savecmdTL.Parameters.AddWithValue("@Reference", "No");
                                    savecmdTL.Parameters.AddWithValue("@RefQty", "");
                                    savecmdTL.Parameters.AddWithValue("@RefUnit", "");
                                    savecmdTL.Parameters.AddWithValue("@RefItem", "");
                                }
                                else
                                {
                                    savecmdTL.Parameters.AddWithValue("@Reference", "Yes");
                                    savecmdTL.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    savecmdTL.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    savecmdTL.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                }

                                savecmdTL.Parameters.AddWithValue("@Name", NameFIELD.Text);

                                savecmdTL.Parameters.AddWithValue("@DateSO", DateSOFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                                savecmdTL.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Type", "Backload");
                                savecmdTL.ExecuteNonQuery();

                                RNGIH();
                                string savestrIH = "insert into ItemsHistory (ID, TID, Qty, Unit, Item, Reference, RefQty, RefUnit, RefItem, Customer, Balance, RefBalance, RefNumber, DateSO, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @RefUnit, @RefItem, @Customer, @Balance, @RefBalance, @RefNumber, @DateSO, @DateR, @DateT, @Remarks, @Checker, @Type)";
                                SqlCommand savecmdIH = new SqlCommand(savestrIH, SQLLoad.con);

                                savecmdIH.Parameters.AddWithValue("@ID", IDIH.ToString());
                                savecmdIH.Parameters.AddWithValue("@TID", TID.ToString());

                                savecmdIH.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Balance", Balance.ToString());

                                if (RefItemFIELD.Text == "")
                                {
                                    savecmdIH.Parameters.AddWithValue("@Reference", "No");
                                    savecmdIH.Parameters.AddWithValue("@RefQty", "");
                                    savecmdIH.Parameters.AddWithValue("@RefUnit", "");
                                    savecmdIH.Parameters.AddWithValue("@RefItem", "");
                                    savecmdIH.Parameters.AddWithValue("@RefBalance", "");
                                }
                                else
                                {
                                    savecmdIH.Parameters.AddWithValue("@Reference", "Yes");
                                    savecmdIH.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    savecmdIH.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    savecmdIH.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                    savecmdIH.Parameters.AddWithValue("@RefBalance", Balance2.ToString());
                                }

                                savecmdIH.Parameters.AddWithValue("@Customer", NameFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@RefNumber", SODR.ToString());

                                savecmdIH.Parameters.AddWithValue("@DateSO", DateSOFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                                savecmdIH.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Type", "Backload");
                                savecmdIH.ExecuteNonQuery();

                                SqlCommand updatecmdI = new SqlCommand("update Items set Unit = @Unit where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                                updatecmdI.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                updatecmdI.ExecuteNonQuery();

                                MessageBox.Show("Add Successfully!", "Message");

                                RefreshBTN.Enabled = true;

                                ItemHistory = ItemFIELD.Text;
                                ItemHTXT.Text = "Item: " + ItemHistory.ToString();
                                ItemFIELD.Enabled = true;
                                LoadDataBLID();
                                ClearItemFIELD();
                            }
                            else
                            {
                                MessageBox.Show("The Item Description is already exists.", "Message");
                            }
                        }
                    }
                }
                else if (AddBTN.Text == "Update")
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();
                    string CountItems = "Select count(*) from Items where [Item] = @Item";
                    SqlCommand CountICmd = new SqlCommand(CountItems, SQLLoad.con);
                    CountICmd.CommandText = CountItems;
                    CountICmd.Parameters.Clear();
                    CountICmd.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                    int Records = (int)CountICmd.ExecuteScalar();

                    if (Records == 0)
                    {
                        MessageBox.Show("The Item Description does not exists.", "Message");
                    }
                    else
                    {
                        if (ItemFIELD.Text == "")
                        {
                            MessageBox.Show("Please fill the Item Description", "Message");
                        }
                        else if (QTYFIELD.Text == "")
                        {
                            MessageBox.Show("Please fill the Quantity", "Message");
                        }
                        else if (QTYFIELD.Text == "0")
                        {
                            MessageBox.Show("Please enter the correct Quantity", "Message");
                        }
                        else
                        {
                            string CountStr = "Select count(*) from TransacTemp where [Item] = @Item and [TID] = @TID";
                            SqlCommand CountCmd = new SqlCommand(CountStr, SQLLoad.con);
                            CountCmd.CommandText = CountStr;
                            CountCmd.Parameters.Clear();
                            CountCmd.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                            CountCmd.Parameters.AddWithValue("@TID", TID.ToString());
                            int numRecords = (int)CountCmd.ExecuteScalar();


                            if (numRecords == 0)
                            {
                                SqlCommand cmdDeleteTL = new SqlCommand("delete from Transaclist where Item = @Item and TID = @TID", SQLLoad.con);
                                cmdDeleteTL.Parameters.AddWithValue("TID", TID.ToString());
                                cmdDeleteTL.Parameters.AddWithValue("Item", PickupGridView.CurrentRow.Cells[3].Value.ToString());
                                cmdDeleteTL.ExecuteNonQuery();

                                SqlCommand cmdDeleteTT = new SqlCommand("delete from TransacTemp where Item = @Item and TID = @TID", SQLLoad.con);
                                cmdDeleteTT.Parameters.AddWithValue("TID", TID.ToString());
                                cmdDeleteTT.Parameters.AddWithValue("Item", PickupGridView.CurrentRow.Cells[3].Value.ToString());
                                cmdDeleteTT.ExecuteNonQuery();

                                SqlCommand cmdDeleteIH = new SqlCommand("delete from ItemsHistory where Item = @Item and TID = @TID", SQLLoad.con);
                                cmdDeleteIH.Parameters.AddWithValue("TID", TID.ToString());
                                cmdDeleteIH.Parameters.AddWithValue("Item", PickupGridView.CurrentRow.Cells[3].Value.ToString());
                                cmdDeleteIH.ExecuteNonQuery();

                                Qty = int.Parse(QTYFIELD.Text);

                                SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                ProductUnit = dt.Rows[0][1].ToString();
                                ProductQty = int.Parse(dt.Rows[0][3].ToString());
                                ProductItem = dt.Rows[0][6].ToString();

                                if (RefItemFIELD.Text == "")
                                {

                                }
                                else
                                {
                                    RQty = int.Parse(RefQTYFIELD.Text);

                                    SqlDataAdapter darf = new SqlDataAdapter("Select * from Items where Item = '" + RefItemFIELD.Text + "'", SQLLoad.con);
                                    DataTable dtrf = new DataTable();
                                    darf.Fill(dtrf);

                                    ProductRUnit = dtrf.Rows[0][1].ToString();
                                    ProductRQty = int.Parse(dtrf.Rows[0][3].ToString());
                                    ProductRItem = dtrf.Rows[0][6].ToString();
                                }

                                Balance = ProductQty + Qty;
                                Balance2 = ProductRQty + RQty;

                                RNGTT();
                                string savestrTR = "insert into TransacTemp (ID, TID, Qty, Unit, Item, Reference, RefQty, RefUnit, RefItem, Name, DateSO, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @RefUnit, @RefItem, @Name, @DateSO, @DateR, @DateT, @Remarks, @Checker, @Type)";
                                SqlCommand savecmdTR = new SqlCommand(savestrTR, SQLLoad.con);

                                savecmdTR.Parameters.AddWithValue("@ID", GETIDTT.ToString());
                                savecmdTR.Parameters.AddWithValue("@TID", TID.ToString());

                                savecmdTR.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Item", ItemFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    savecmdTR.Parameters.AddWithValue("@Reference", "No");
                                    savecmdTR.Parameters.AddWithValue("@RefQty", "");
                                    savecmdTR.Parameters.AddWithValue("@RefUnit", "");
                                    savecmdTR.Parameters.AddWithValue("@RefItem", "");
                                }
                                else
                                {
                                    savecmdTR.Parameters.AddWithValue("@Reference", "Yes");
                                    savecmdTR.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    savecmdTR.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    savecmdTR.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                }

                                savecmdTR.Parameters.AddWithValue("@Name", NameFIELD.Text);

                                savecmdTR.Parameters.AddWithValue("@DateSO", DateSOFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                                savecmdTR.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                                savecmdTR.Parameters.AddWithValue("@Type", "Backload");
                                savecmdTR.ExecuteNonQuery();

                                RNGTL();
                                string savestrTL = "insert into Transaclist (ID, TID, Qty, Unit, Item, Reference, RefQty, RefUnit, RefItem, Name, DateSO, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @RefUnit, @RefItem, @Name, @DateSO, @DateR, @DateT, @Remarks, @Checker, @Type)";
                                SqlCommand savecmdTL = new SqlCommand(savestrTL, SQLLoad.con);

                                savecmdTL.Parameters.AddWithValue("@ID", GETIDTL.ToString());
                                savecmdTL.Parameters.AddWithValue("@TID", TID.ToString());

                                savecmdTL.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Item", ItemFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    savecmdTL.Parameters.AddWithValue("@Reference", "No");
                                    savecmdTL.Parameters.AddWithValue("@RefQty", "");
                                    savecmdTL.Parameters.AddWithValue("@RefUnit", "");
                                    savecmdTL.Parameters.AddWithValue("@RefItem", "");
                                }
                                else
                                {
                                    savecmdTL.Parameters.AddWithValue("@Reference", "Yes");
                                    savecmdTL.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    savecmdTL.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    savecmdTL.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                }

                                savecmdTL.Parameters.AddWithValue("@Name", NameFIELD.Text);

                                savecmdTL.Parameters.AddWithValue("@DateSO", DateSOFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                                savecmdTL.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                                savecmdTL.Parameters.AddWithValue("@Type", "Backload");
                                savecmdTL.ExecuteNonQuery();

                                RNGIH();
                                string savestrIH = "insert into ItemsHistory (ID, TID, Qty, Unit, Item, Reference, RefQty, RefUnit, RefItem, Customer, Balance, RefBalance, RefNumber, DateSO, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @RefUnit, @RefItem, @Customer, @Balance, @RefBalance, @RefNumber, @DateSO, @DateR, @DateT, @Remarks, @Checker, @Type)";
                                SqlCommand savecmdIH = new SqlCommand(savestrIH, SQLLoad.con);

                                savecmdIH.Parameters.AddWithValue("@ID", GETIDIH.ToString());
                                savecmdIH.Parameters.AddWithValue("@TID", TID.ToString());

                                savecmdIH.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Balance", Balance.ToString());

                                if (RefItemFIELD.Text == "")
                                {
                                    savecmdIH.Parameters.AddWithValue("@Reference", "No");
                                    savecmdIH.Parameters.AddWithValue("@RefQty", "");
                                    savecmdIH.Parameters.AddWithValue("@RefUnit", "");
                                    savecmdIH.Parameters.AddWithValue("@RefItem", "");
                                    savecmdIH.Parameters.AddWithValue("@RefBalance", "");
                                }
                                else
                                {
                                    savecmdIH.Parameters.AddWithValue("@Reference", "Yes");
                                    savecmdIH.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    savecmdIH.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    savecmdIH.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                    savecmdIH.Parameters.AddWithValue("@RefBalance", Balance2.ToString());
                                }

                                savecmdIH.Parameters.AddWithValue("@Customer", NameFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@RefNumber", SODR.ToString());

                                savecmdIH.Parameters.AddWithValue("@DateSO", DateSOFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                                savecmdIH.Parameters.AddWithValue("@DateT", DateFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                                savecmdIH.Parameters.AddWithValue("@Type", "Backload");
                                savecmdIH.ExecuteNonQuery();

                                SqlCommand updatecmdI = new SqlCommand("update Items set Unit = @Unit where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                                updatecmdI.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                updatecmdI.ExecuteNonQuery();

                                MessageBox.Show("Update Successfully!", "Message");
                                AddBTN.Text = "Add";

                                UCancelBTN.Enabled = false;
                                SaveBTN.Enabled = true;
                                CancelBTN.Enabled = true;

                                PickupGridView.Enabled = true;

                                RefreshBTN.Enabled = true;

                                ItemHistory = ItemFIELD.Text;
                                ItemHTXT.Text = "Item: " + ItemHistory.ToString();
                                ItemFIELD.Enabled = true;
                                LoadDataBLID();
                                ClearItemFIELD();
                            }
                            else
                            {
                                Qty = int.Parse(QTYFIELD.Text);

                                SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                                DataTable dt = new DataTable();
                                da.Fill(dt);

                                ProductUnit = dt.Rows[0][1].ToString();
                                ProductQty = int.Parse(dt.Rows[0][3].ToString());
                                ProductItem = dt.Rows[0][8].ToString();

                                if (RefItemFIELD.Text == "")
                                {

                                }
                                else
                                {
                                    RQty = int.Parse(RefQTYFIELD.Text);

                                    SqlDataAdapter darf = new SqlDataAdapter("Select * from Items where Item = '" + RefItemFIELD.Text + "'", SQLLoad.con);
                                    DataTable dtrf = new DataTable();
                                    darf.Fill(dtrf);

                                    ProductRUnit = dtrf.Rows[0][1].ToString();
                                    ProductRQty = int.Parse(dtrf.Rows[0][3].ToString());
                                    ProductRItem = dtrf.Rows[0][6].ToString();
                                }

                                Balance = ProductQty + Qty;
                                Balance2 = ProductRQty + RQty;

                                SqlCommand updatecmdTR = new SqlCommand("update TransacTemp set Qty = @Qty, Unit = @Unit, Item = @Item, RefQty = @RefQty, RefUnit = @RefUnit, RefItem = @RefItem, Remarks = @Remarks, Checker = @Checker where Item = @Item and TID = '" + GETTID + "'", SQLLoad.con);
                                updatecmdTR.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                updatecmdTR.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                updatecmdTR.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                                updatecmdTR.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                updatecmdTR.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    updatecmdTR.Parameters.AddWithValue("@RefQty", "0");
                                    updatecmdTR.Parameters.AddWithValue("@RefUnit", "");
                                    updatecmdTR.Parameters.AddWithValue("@RefItem", "");
                                }
                                else
                                {
                                    updatecmdTR.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    updatecmdTR.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    updatecmdTR.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                }
                                updatecmdTR.ExecuteNonQuery();

                                SqlCommand updatecmdTL = new SqlCommand("update Transaclist set Qty = @Qty, Unit = @Unit, Item = @Item, RefQty = @RefQty, RefUnit = @RefUnit, RefItem = @RefItem, Remarks = @Remarks, Checker = @Checker where Item = @Item and TID = '" + GETTID + "'", SQLLoad.con);
                                updatecmdTL.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                updatecmdTL.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                updatecmdTL.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                                updatecmdTL.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                updatecmdTL.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    updatecmdTL.Parameters.AddWithValue("@RefQty", "0");
                                    updatecmdTL.Parameters.AddWithValue("@RefUnit", "");
                                    updatecmdTL.Parameters.AddWithValue("@RefItem", "");
                                }
                                else
                                {
                                    updatecmdTL.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    updatecmdTL.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    updatecmdTL.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                }
                                updatecmdTL.ExecuteNonQuery();

                                SqlCommand updatecmdIH = new SqlCommand("update ItemsHistory set Qty = @Qty, Unit = @Unit, Item = @Item, RefQty = @RefQty, RefUnit = @RefUnit, RefItem = @RefItem, Balance = @Balance, RefBalance = @RefBalance, Remarks = @Remarks, Checker = @Checker where Item = @Item and TID = '" + GETTID + "'", SQLLoad.con);
                                updatecmdIH.Parameters.AddWithValue("@Qty", QTYFIELD.Text);
                                updatecmdIH.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                updatecmdIH.Parameters.AddWithValue("@Item", ItemFIELD.Text);
                                updatecmdIH.Parameters.AddWithValue("@Balance", Balance.ToString());
                                updatecmdIH.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                                updatecmdIH.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);

                                if (RefItemFIELD.Text == "")
                                {
                                    updatecmdIH.Parameters.AddWithValue("@RefQty", "0");
                                    updatecmdIH.Parameters.AddWithValue("@RefUnit", "");
                                    updatecmdIH.Parameters.AddWithValue("@RefItem", "");
                                    updatecmdIH.Parameters.AddWithValue("@RefBalance", "0");
                                }
                                else
                                {
                                    updatecmdIH.Parameters.AddWithValue("@RefQty", RefQTYFIELD.Text);
                                    updatecmdIH.Parameters.AddWithValue("@RefUnit", RefUnitFIELD.Text);
                                    updatecmdIH.Parameters.AddWithValue("@RefItem", RefItemFIELD.Text);
                                    updatecmdIH.Parameters.AddWithValue("@RefBalance", Balance2.ToString());
                                }
                                updatecmdIH.ExecuteNonQuery();

                                SqlCommand updatecmdI = new SqlCommand("update Items set Unit = @Unit where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                                updatecmdI.Parameters.AddWithValue("@Unit", UnitFIELD.Text);
                                updatecmdI.ExecuteNonQuery();

                                MessageBox.Show("Update Successfully!", "Message");
                                AddBTN.Text = "Add";

                                UCancelBTN.Enabled = false;
                                SaveBTN.Enabled = true;
                                CancelBTN.Enabled = true;

                                PickupGridView.Enabled = true;

                                RefreshBTN.Enabled = true;

                                ItemHistory = ItemFIELD.Text;
                                ItemHTXT.Text = "Item: " + ItemHistory.ToString();
                                ItemFIELD.Enabled = true;
                                LoadDataBLID();
                                ClearItemFIELD();
                            }
                        }
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                
            }
            catch (Exception ex)
            {
                
            }
        }

        private void UCancelBTN_Click(object sender, EventArgs e)
        {
            LoadDataBLID();
            ClearItemFIELD();

            ItemHTXT.Text = "Item: ";
            AddBTN.Text = "Add";

            RefreshBTN.Enabled = true;

            UCancelBTN.Enabled = false;
            SaveBTN.Enabled = true;
            CancelBTN.Enabled = true;

            PickupGridView.Enabled = true;
            ItemFIELD.Enabled = true;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Proceed to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (NoteFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Note / Remarks.", "Message");
                    }
                    else if (ReportFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Report by.", "Message");
                    }
                    else
                    {
                        if (PickupGridView.Rows.Count > 0 && PickupGridView.Rows != null)
                        {
                            SQLLoad.con.Close();
                            SQLLoad.con.Open();

                            string savestr = "insert into [Transaction] (ID, Name, Address, Reference, Employee, DateSO, DateT, DateR, Note, Type) values (@ID, @Name, @Address, @Reference, @Employee, @DateSO, @DateT, @DateR, @Note, @Type)";
                            SqlCommand savecmd = new SqlCommand(savestr, SQLLoad.con);

                            savecmd.Parameters.AddWithValue("@ID", IDTR.ToString());
                            savecmd.Parameters.AddWithValue("@Name", NameFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Address", AddressFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Reference", SODR.ToString());
                            savecmd.Parameters.AddWithValue("@Employee", ReportFIELD.Text);
                            savecmd.Parameters.AddWithValue("@DateSO", DateSOFIELD.Value.ToString("yyyy-MM-dd"));
                            savecmd.Parameters.AddWithValue("@DateT", DateFIELD.Value.ToString("yyyy-MM-dd"));
                            savecmd.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                            savecmd.Parameters.AddWithValue("@Note", NoteFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Type", "Backload");
                            savecmd.ExecuteNonQuery();

                            SQLLoad.con.Close();

                            MultipleAdd();
                            LoadDataBLZERO();

                            ItemHistory = null;
                            CatchData.REPID = TID;
                            CatchData.REPNAME = NameFIELD.Text;
                            CatchData.REPSODR = SODR.ToString();
                            CatchData.REPEMPLOYEE = ReportFIELD.Text;
                            CatchData.REPDATE = DateFIELD.Text;

                            TID = null;

                            ItemHTXT.Text = "Item:";

                            if (MessageBox.Show("Continue?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                SQLLoad.con.Close();
                                SQLLoad.con.Open();

                                RNGTR();
                                TID = IDTR.ToString();

                                ONFIELD();

                                SODRFIELD.Text = "";

                                SQLLoad.con.Close();

                                ClearItemFIELD();

                                LOWPANEL.Enabled = false;
                                LOWPANEL.Visible = false;
                            }
                            else
                            {
                                OFFFIELD();

                                ClearItemFIELD();
                                ClearFIELD();

                                RefreshBTN.Enabled = false;

                                LOWPANEL.Enabled = false;
                                LOWPANEL.Visible = false;
                            }
                            CatchData.REPID = null;
                            CatchData.REPNAME = null;
                            CatchData.REPSODR = null;
                            CatchData.REPEMPLOYEE = null;
                            CatchData.REPDATE = null;
                        }
                        else
                        {
                            MessageBox.Show("Your data is empty.", "Message");
                        }
                    }
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Error! #1", "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error! #2", "Message");
                }
            }
            else
            {
                MessageBox.Show("Make sure the item you input was correct!", "Message");
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RefreshBTN.Enabled = false;

                CancelDel();
                OFFFIELD();
                ClearItemFIELD();
                ClearFIELD();
                LOWPANEL.Enabled = false;
                LOWPANEL.Visible = false;
                LoadDataBLZERO();
                SQLLoad.con.Close();
            }
            else
            {

            }
        }

        private void MultipleAdd()
        {
            try
            {
                if (PickupGridView.Rows.Count > 0 && PickupGridView.Rows != null)
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    ProductQty = int.Parse(PickupGridView.CurrentRow.Cells[1].Value.ToString());
                    ProductRQty = int.Parse(PickupGridView.CurrentRow.Cells[5].Value.ToString());

                    Ref = PickupGridView.CurrentRow.Cells[4].Value.ToString();

                    SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + PickupGridView.CurrentRow.Cells[3].Value.ToString() + "'", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    Qty = int.Parse(dt.Rows[0][3].ToString());

                    ProductItem = dt.Rows[0][6].ToString();

                    Balance = Qty + ProductQty;

                    SqlCommand updatecmd = new SqlCommand("update Items set Qty = @Qty where Item = '" + PickupGridView.CurrentRow.Cells[3].Value.ToString() + "'", SQLLoad.con);
                    updatecmd.Parameters.AddWithValue("@Qty", Balance.ToString());
                    updatecmd.ExecuteNonQuery();

                    if (Ref == "Yes")
                    {
                        SqlDataAdapter darf = new SqlDataAdapter("Select * from Items where Item = '" + PickupGridView.CurrentRow.Cells[7].Value.ToString() + "'", SQLLoad.con);
                        DataTable dtrf = new DataTable();
                        darf.Fill(dtrf);

                        RQty = int.Parse(dtrf.Rows[0][3].ToString());

                        ProductRItem = dtrf.Rows[0][6].ToString();

                        Balance2 = RQty + ProductRQty;

                        SqlCommand updatecmdrf = new SqlCommand("update Items set Qty = @Qty where Item = '" + PickupGridView.CurrentRow.Cells[7].Value.ToString() + "'", SQLLoad.con);
                        updatecmdrf.Parameters.AddWithValue("@Qty", Balance2.ToString());
                        updatecmdrf.ExecuteNonQuery();
                    }
                    else
                    {

                    }

                    SqlCommand cmdDelete = new SqlCommand("delete from TransacTemp where Item = '" + PickupGridView.CurrentRow.Cells[3].Value.ToString() + "'", SQLLoad.con);
                    cmdDelete.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    LoadDataBLID();
                    MultipleAdd();
                }
                else
                {
                    MessageBox.Show("Save Successfully!", "Message");
                }
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

        private void CancelDel()
        {
            try
            {
                SQLLoad.con.Close();
                SQLLoad.con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from TransacTemp where TID = '" + TID + "' ", SQLLoad.con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                PickupGridView.DataSource = dt;

                SqlCommand cmdDeleteTL = new SqlCommand("delete from Transaclist where TID = @TID", SQLLoad.con);
                cmdDeleteTL.Parameters.AddWithValue("@TID", TID.ToString());
                cmdDeleteTL.ExecuteNonQuery();

                SqlCommand cmdDeleteTT = new SqlCommand("delete from TransacTemp where TID = @TID", SQLLoad.con);
                cmdDeleteTT.Parameters.AddWithValue("@TID", TID.ToString());
                cmdDeleteTT.ExecuteNonQuery();

                SqlCommand cmdDeleteIH = new SqlCommand("delete from ItemsHistory where TID = @TID", SQLLoad.con);
                cmdDeleteIH.Parameters.AddWithValue("@TID", TID.ToString());
                cmdDeleteIH.ExecuteNonQuery();
                SQLLoad.con.Close();
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

        private void PickupGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ID == null)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Select * from TransacTemp where Item = '" + PickupGridView.CurrentRow.Cells[3].Value.ToString() + "'", SQLLoad.con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    GETTID = dt1.Rows[0][1].ToString();
                    GETQuantity = dt1.Rows[0][2].ToString();
                    GETUnit = dt1.Rows[0][3].ToString();
                    GETItem = dt1.Rows[0][4].ToString();
                    GETReference = dt1.Rows[0][5].ToString();
                    GETRefQuantity = dt1.Rows[0][6].ToString();
                    GETRefUnit = dt1.Rows[0][7].ToString();
                    GETRefItem = dt1.Rows[0][8].ToString();
                    GETName = dt1.Rows[0][9].ToString();
                    GETRemarks = dt1.Rows[0][13].ToString();
                    GETChecker = dt1.Rows[0][14].ToString();

                    GETIDTT = dt1.Rows[0][0].ToString();

                    ItemHistory = dt1.Rows[0][4].ToString();

                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from Transaclist where Item = '" + ItemHistory + "' and TID = '" + GETTID + "'", SQLLoad.con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    GETIDTL = dt2.Rows[0][0].ToString();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from ItemsHistory where Item = '" + ItemHistory + "' and TID = '" + GETTID + "'", SQLLoad.con);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);

                    GETIDIH = dt3.Rows[0][0].ToString();

                    DelBTN.Enabled = true;
                    EditBTN.Enabled = true;

                    LoadDataIH();
                    ItemHTXT.Text = "Item: " + ItemHistory.ToString();
                }
                else
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("Select * from TransacTemp where Item = '" + PickupGridView.CurrentRow.Cells[3].Value.ToString() + "'", SQLLoad.con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    GETTID = dt1.Rows[0][1].ToString();
                    GETQuantity = dt1.Rows[0][2].ToString();
                    GETUnit = dt1.Rows[0][3].ToString();
                    GETItem = dt1.Rows[0][4].ToString();
                    GETReference = dt1.Rows[0][5].ToString();
                    GETRefQuantity = dt1.Rows[0][6].ToString();
                    GETRefUnit = dt1.Rows[0][7].ToString();
                    GETRefItem = dt1.Rows[0][8].ToString();
                    GETName = dt1.Rows[0][9].ToString();
                    GETRemarks = dt1.Rows[0][13].ToString();
                    GETChecker = dt1.Rows[0][14].ToString();

                    GETIDTT = dt1.Rows[0][0].ToString();

                    ItemHistory = dt1.Rows[0][4].ToString();

                    SqlDataAdapter da2 = new SqlDataAdapter("Select * from Transaclist where Item = '" + ItemHistory + "' and TID = '" + GETTID + "'", SQLLoad.con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    GETIDTL = dt2.Rows[0][0].ToString();

                    SqlDataAdapter da3 = new SqlDataAdapter("Select * from ItemsHistory where Item = '" + ItemHistory + "' and TID = '" + GETTID + "'", SQLLoad.con);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);

                    GETIDIH = dt3.Rows[0][0].ToString();

                    DelBTN.Enabled = true;
                    EditBTN.Enabled = true;

                    LoadDataIH();
                    ItemHTXT.Text = "Item: " + ItemHistory.ToString();
                }
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

        private void ItemFIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItemFIELD.Text == "")
                {

                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + ItemFIELD.Text + "'", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    UnitFIELD.Text = dt.Rows[0][1].ToString();
                    RefUnitFIELD.Text = dt.Rows[0][2].ToString();
                    RefQTYFIELD.Text = dt.Rows[0][4].ToString();
                    RefItemFIELD.Text = dt.Rows[0][7].ToString();

                    RefQTY = int.Parse(dt.Rows[0][4].ToString());

                    if (RefItemFIELD.Text == "")
                    {
                        RefUnitFIELD.Enabled = false;
                        RefQTYFIELD.Enabled = false;
                    }
                    else
                    {
                        RefUnitFIELD.Enabled = true;
                        RefQTYFIELD.Enabled = true;
                    }
                }
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

        private void QTYFIELD_TextChanged(object sender, EventArgs e)
        {
            if (RefQTYFIELD.Enabled == true)
            {
                int a, b;

                bool isAValid = int.TryParse(QTYFIELD.Text, out a);
                bool isBValid = int.TryParse(RefQTY.ToString(), out b);

                if (isAValid && isBValid)
                {
                    if (UnitFIELD.Text == "PC"
                        || UnitFIELD.Text == "KG"
                        || UnitFIELD.Text == "PAIR"
                        || UnitFIELD.Text == "ROLL"
                        || UnitFIELD.Text == "METER"
                        || UnitFIELD.Text == "TUBE")
                    {
                        RefQTYFIELD.Text = (a / b).ToString();
                    }
                    else
                    {
                        RefQTYFIELD.Text = (a * b).ToString();
                    }
                }
                else
                {
                    RefQTYFIELD.Text = RefQTYFIELD.ToString();
                }
            }
            else
            {

            }
        }
    }
}
