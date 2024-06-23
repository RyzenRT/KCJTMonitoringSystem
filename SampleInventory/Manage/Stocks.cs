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
    public partial class Stocks : Form
    {
        // ID //
        int IDSTK, IDNG, IDAJ, IDIH;

        // Selecting Record //
        string ID, Unit, RUnit, Code, Item, RItem, Category, Group, Brand, Remarks;

        // Quantities //
        int Qty, RQty;

        // Balance //
        int Balance;
        int Balance2;
        int AdjQty;

        // Adjustment //
        string REFID;

        public Stocks()
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

        // Clearing Data //

        private void ClearFIELDADD()
        {
            // Add - Update Item //
            UnitAddFIELD.Text = null;
            CodeAddFIELD.Text = null;
            ItemAddFIELD.Text = null;
            CategoryAddFIELD.Text = null;
            GroupAddFIELD.Text = null;
            BrandAddFIELD.Text = null;
            ItemRefAddFIELD.Text = null;
            UnitAddFIELD.Text = null;
            RUnitAddFIELD.Text = null;
            RQTYFIELD.Text = null;
            RemarksAddFIELD.Text = null;


            // Adjust Item Qty //
            NameFIELD.Text = null;
            QtyAdjFIELD.Text = null;
            UnitAdjFIELD.Text = null;
            DTAdjust.Text = null;
            AdjustTypeFIELD.Text = null;
            ReasonAdjFIELD.Text = null;

            // Update Item Qty //
            EditQtyFIELD.Text = null;
        }
        private void NullID()
        {
            if (ID == null)
            {
                EditBTN.Enabled = false;
                DelBTN.Enabled = false;
                HistoryBTN.Enabled = false;
                QuantityBTN.Enabled = false;
                ADJBTN.Enabled = false;
            }
        }
        // Data Load //

        private void LoadData()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Items order by Item ASC", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                StockGridView.DataSource = dt;
                SQLLoad.con.Close();
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
        private void DropdownData()
        {
            try
            {
                SqlDataAdapter ddl = new SqlDataAdapter("Select DISTINCT (Category) from Items order by Category ASC", SQLLoad.con);
                DataTable ddlt = new DataTable();
                ddl.Fill(ddlt);
                CategoryFIELD.DataSource = ddlt;
                SQLLoad.con.Close();

                SqlDataAdapter ddg = new SqlDataAdapter("Select DISTINCT ([Group]) from Items order by [Group] ASC", SQLLoad.con);
                DataTable ddgt = new DataTable();
                ddg.Fill(ddgt);
                GroupAddFIELD.DataSource = ddgt;
                SQLLoad.con.Close();

                SqlDataAdapter ddl2 = new SqlDataAdapter("Select DISTINCT (Category) from Items order by Category ASC", SQLLoad.con);
                DataTable ddlt2 = new DataTable();
                ddl2.Fill(ddlt2);
                CategoryAddFIELD.DataSource = ddlt2;
                SQLLoad.con.Close();
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

        private void QtyAdjFIELD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void QtyAddFIELD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void RQTYFIELD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one line point
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }
        }

        // NUMBER GENERATED //

        private void RNGAJ()
        {
            try
            {
                string CountSTRAJ = "Select count(*) from ItemsAdjust";
                SqlCommand CountCMDAJ = new SqlCommand(CountSTRAJ, SQLLoad.con);
                int RNG = Convert.ToInt32(CountCMDAJ.ExecuteScalar().ToString());
                if (RNG == 0)
                {
                    IDAJ = RNG + 1;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM ItemsAdjust order by ID Desc", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int AJID = int.Parse(dt.Rows[0][0].ToString());

                    IDAJ = AJID + 1;
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

        // Select Adjustment //

        private void ADJUSTTYPE()
        {
            if (AdjustTypeFIELD.Text == "ADD")
            {
                QtyAdjFIELD.Enabled = true;
                QtyAdjFIELD.Text = null;
            }
            else if (AdjustTypeFIELD.Text == "LESS")
            {
                QtyAdjFIELD.Enabled = true;
                QtyAdjFIELD.Text = null;
            }
            else if (AdjustTypeFIELD.Text == "RESET")
            {
                QtyAdjFIELD.Enabled = false;
                QtyAdjFIELD.Text = Qty.ToString();
            }
        }

        // Load //

        private void Stocks_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            try
            {
                // TODO: This line of code loads data into the 'sQLSERVERDS.Items' table. You can move, or remove it, as needed.
                this.itemsTableAdapter.Fill(this.sQLSERVERDS.Items);
                if (CatchData.USRLVL == "Administrator")
                {

                }
                else if (CatchData.USRLVL == "Encoder")
                {

                }
                else
                {
                    AddBTN.Enabled = false;
                    EditBTN.Enabled = false;
                    DelBTN.Enabled = false;
                    HistoryBTN.Enabled = false;
                    QuantityBTN.Enabled = false;
                    ADJBTN.Enabled = false;
                }

                ADDDOWNPANEL.Visible = false;
                ADJDOWNPANEL.Visible = false;
                ADJQTYPANEL.Visible = false;
                DropdownData();
                LoadData();
                NullID();
                ClearFIELDADD();
                StockGridView.AllowUserToAddRows = false;
                CloseButton.EnableDisable(this, false);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Check Connections on Database. Error!", "Message");

                AddBTN.Enabled = false;
                EditBTN.Enabled = false;
                DelBTN.Enabled = false;
                HistoryBTN.Enabled = false;
                ADJBTN.Enabled = false;

                ADDDOWNPANEL.Visible = false;
                ADJDOWNPANEL.Visible = false;
                DropdownData();
                LoadData();
                NullID();
                ClearFIELDADD();
                StockGridView.AllowUserToAddRows = false;
                CloseButton.EnableDisable(this, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check Connections on Database. Error!", "Message");

                AddBTN.Enabled = false;
                EditBTN.Enabled = false;
                DelBTN.Enabled = false;
                HistoryBTN.Enabled = false;
                ADJBTN.Enabled = false;

                ADDDOWNPANEL.Visible = false;
                ADJDOWNPANEL.Visible = false;
                DropdownData();
                LoadData();
                NullID();
                ClearFIELDADD();
                StockGridView.AllowUserToAddRows = false;
                CloseButton.EnableDisable(this, false);
            }
            SQLLoad.con.Close();
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            ItemFIELD.Text = null;
            CategoryFIELD.Text = null;
            ID = null;
            NullID();

            EditBTN.Enabled = false;
            DelBTN.Enabled = false;
            HistoryBTN.Enabled = false;
            QuantityBTN.Enabled = false;
            ADJBTN.Enabled = false;

            LoadData();
        }

        private void CloseBTN_Click(object sender, EventArgs e)
        {
            Dashboard Dashboard = new Dashboard();
            Dashboard.Show();
            this.Hide();
        }
        private void ItemFIELD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItemFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Items where Item like '%" + ItemFIELD.Text.Replace("'", "''") + "%' order by Item ASC", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    StockGridView.DataSource = dt;
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
        private void AdjustTypeFIELD_TextChanged(object sender, EventArgs e)
        {
            ADJUSTTYPE();
        }
        private void AdjustTypeFIELD_SelectedValueChanged(object sender, EventArgs e)
        {
            ADJUSTTYPE();
        }
        private void AddBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ADDDOWNPANEL.Visible = true;

                RefreshBTN.Enabled = false;

                AddBTN.Enabled = false;
                EditBTN.Enabled = false;

                DelBTN.Enabled = false;
                CloseBTN.Enabled = false;

                HistoryBTN.Enabled = false;
                QuantityBTN.Enabled = false;
                ADJBTN.Enabled = false;

                ItemFIELD.Enabled = false;
                CategoryFIELD.Enabled = false;

                StockGridView.Enabled = false;

                ClearFIELDADD();

                SQLLoad.con.Open();

                string CountSTRTR = "Select count(*) from [Items]";
                SqlCommand CountCMDTR = new SqlCommand(CountSTRTR, SQLLoad.con);
                int RNG = Convert.ToInt32(CountCMDTR.ExecuteScalar().ToString());

                if (RNG == 0)
                {
                    IDNG = RNG + 1;
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT top 1 * FROM [Items] order by ID Desc", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    int STID = int.Parse(dt.Rows[0][0].ToString());

                    IDNG = STID + 1;
                }

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

        private void EditBTN_Click(object sender, EventArgs e)
        {
            SaveAddBTN.Text = "Update";
            ADDDOWNPANEL.Visible = true;

            RefreshBTN.Enabled = false;

            AddBTN.Enabled = false;
            EditBTN.Enabled = false;

            DelBTN.Enabled = false;
            CloseBTN.Enabled = false;

            HistoryBTN.Enabled = false;
            QuantityBTN.Enabled = false;
            ADJBTN.Enabled = false;

            ItemFIELD.Enabled = false;
            CategoryFIELD.Enabled = false;

            StockGridView.Enabled = false;

            ClearFIELDADD();

            UnitAddFIELD.Text = Unit.ToString();
            CodeAddFIELD.Text = Code.ToString();
            ItemAddFIELD.Text = Item.ToString();
            ItemRefAddFIELD.Text = RItem.ToString();
            RQTYFIELD.Text = RQty.ToString();
            RUnitAddFIELD.Text = RUnit.ToString();
            CategoryAddFIELD.Text = Category.ToString();
            GroupAddFIELD.Text = Group.ToString();
            BrandAddFIELD.Text = Brand.ToString();
            RemarksAddFIELD.Text = Remarks.ToString();
        }

        private void DelBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete " + Item + " ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    SqlCommand cmdDelete = new SqlCommand("delete from Items where ID = @ID", SQLLoad.con);
                    cmdDelete.Parameters.AddWithValue("@ID", ID);
                    cmdDelete.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Delete Successfully!", "Message");
                    LoadData();
                    ID = null;
                    NullID();
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

        private void SaveAddBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveAddBTN.Text == "Save")
                {
                    if (ItemAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Item Description", "Message");
                    }
                    else if (CodeAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Code", "Message");
                    }
                    else if (BrandAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Brand", "Message");
                    }
                    else if (CategoryAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Category", "Message");
                    }
                    else
                    {
                        SQLLoad.con.Close();
                        SQLLoad.con.Open();
                        string CountStr = "Select count(*) from Items where [Item] = @Item";
                        SqlCommand CountCmd = new SqlCommand(CountStr, SQLLoad.con);
                        CountCmd.CommandText = CountStr;
                        CountCmd.Parameters.Clear();
                        CountCmd.Parameters.AddWithValue("@Item", ItemAddFIELD.Text);
                        int numRecords = (int)CountCmd.ExecuteScalar();


                        if (numRecords == 0)
                        {
                            string savestr = "insert into Items (ID, Unit, RefUnit, Qty, RefQty, Code, Item, ItemRef, Category, [Group], Brand, Remarks) values (@ID, @Unit, @RefUnit, @Qty, @RefQty, @Code, @Item, @ItemRef, @Category, @Group, @Brand, @Remarks)";
                            SqlCommand savecmd = new SqlCommand(savestr, SQLLoad.con);

                            savecmd.Parameters.AddWithValue("@ID", IDNG.ToString());
                            savecmd.Parameters.AddWithValue("@Unit", UnitAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@RefUnit", RUnitAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Qty", "0");
                            savecmd.Parameters.AddWithValue("@RefQty", RQTYFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Code", CodeAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Item", ItemAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@ItemRef", ItemRefAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Category", CategoryAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Group", GroupAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Brand", BrandAddFIELD.Text);
                            savecmd.Parameters.AddWithValue("@Remarks", RemarksAddFIELD.Text);

                            savecmd.ExecuteNonQuery();
                            SQLLoad.con.Close();

                            MessageBox.Show("Save Successfully!", "Message");

                            ADDDOWNPANEL.Visible = false;

                            RefreshBTN.Enabled = true;

                            AddBTN.Enabled = true;
                            CloseBTN.Enabled = true;

                            AddBTN.Visible = true;
                            EditBTN.Visible = true;

                            HistoryBTN.Enabled = true;
                            QuantityBTN.Enabled = true;
                            ADJBTN.Enabled = true;

                            DelBTN.Visible = true;
                            CloseBTN.Visible = true;

                            ItemFIELD.Enabled = true;
                            CategoryFIELD.Enabled = true;

                            StockGridView.Enabled = true;

                            ClearFIELDADD();
                            LoadData();
                            ID = null;
                            NullID();
                        }
                        else
                        {
                            MessageBox.Show("The Item is already exists.", "Message");
                        }
                    }
                }
                else if (SaveAddBTN.Text == "Update")
                {
                    if (ItemAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Item Description", "Message");
                    }
                    else if (CodeAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Code", "Message");
                    }
                    else if (BrandAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Brand", "Message");
                    }
                    else if (CategoryAddFIELD.Text == "")
                    {
                        MessageBox.Show("Please fill the Category", "Message");
                    }
                    else
                    {
                        SQLLoad.con.Close();
                        SQLLoad.con.Open();

                        SqlCommand updatecmd = new SqlCommand("update Items set Unit = @Unit, RefUnit = @RefUnit, RefQty = @RefQty, Code = @Code, Item = @Item, ItemRef = @ItemRef, Category = @Category, [Group] = @Group, Brand = @Brand, Remarks = @Remarks where ID = '" + ID.ToString() + "'", SQLLoad.con);

                        updatecmd.Parameters.AddWithValue("@Unit", UnitAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@RefUnit", RUnitAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@RefQty", RQTYFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@Code", CodeAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@Item", ItemAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@ItemRef", ItemRefAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@Category", CategoryAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@Group", GroupAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@Brand", BrandAddFIELD.Text);
                        updatecmd.Parameters.AddWithValue("@Remarks", RemarksAddFIELD.Text);
                        updatecmd.ExecuteNonQuery();

                        SqlCommand update2cmd = new SqlCommand("update Transaclist set Unit = @Unit, RefUnit = @RefUnit, Item = @Item where Item = '" + Item + "'", SQLLoad.con);
                        update2cmd.Parameters.AddWithValue("@Unit", UnitAddFIELD.Text);
                        update2cmd.Parameters.AddWithValue("@RefUnit", RUnitAddFIELD.Text);
                        update2cmd.Parameters.AddWithValue("@Item", ItemAddFIELD.Text);
                        update2cmd.ExecuteNonQuery();

                        SqlCommand update3cmd = new SqlCommand("update ItemsHistory set Unit = @Unit, RefUnit = @RefUnit, Item = @Item where Item = '" + Item + "'", SQLLoad.con);
                        update3cmd.Parameters.AddWithValue("@Unit", UnitAddFIELD.Text);
                        update3cmd.Parameters.AddWithValue("@RefUnit", RUnitAddFIELD.Text);
                        update3cmd.Parameters.AddWithValue("@Item", ItemAddFIELD.Text);
                        update3cmd.ExecuteNonQuery();

                        SqlCommand update4cmd = new SqlCommand("update ItemsAdjust set Unit = @Unit, Item = @Item where Item = '" + Item + "'", SQLLoad.con);
                        update4cmd.Parameters.AddWithValue("@Unit", UnitAddFIELD.Text);
                        update4cmd.Parameters.AddWithValue("@Item", ItemAddFIELD.Text);
                        update4cmd.ExecuteNonQuery();

                        SQLLoad.con.Close();

                        MessageBox.Show("Update Successfully!", "Message");

                        ADDDOWNPANEL.Visible = false;

                        RefreshBTN.Enabled = true;

                        AddBTN.Enabled = true;
                        CloseBTN.Enabled = true;

                        AddBTN.Visible = true;
                        EditBTN.Visible = true;

                        HistoryBTN.Enabled = true;
                        QuantityBTN.Enabled = true;
                        ADJBTN.Enabled = true;

                        DelBTN.Visible = true;
                        CloseBTN.Visible = true;

                        ItemFIELD.Enabled = true;
                        CategoryFIELD.Enabled = true;

                        StockGridView.Enabled = true;

                        ClearFIELDADD();
                        LoadData();
                        ID = null;
                        NullID();

                        ItemAddFIELD.Enabled = true;
                        SaveAddBTN.Text = "Save";
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

        private void CancelAddBTN_Click(object sender, EventArgs e)
        {
            ADDDOWNPANEL.Visible = false;

            RefreshBTN.Enabled = true;

            AddBTN.Enabled = true;

            CloseBTN.Enabled = true;
            AddBTN.Visible = true;

            EditBTN.Visible = true;
            DelBTN.Visible = true;

            HistoryBTN.Enabled = true;
            QuantityBTN.Enabled = true;
            ADJBTN.Enabled = true;

            CloseBTN.Visible = true;
            SaveAddBTN.Visible = true;

            ItemFIELD.Enabled = true;
            CategoryFIELD.Enabled = true;

            StockGridView.Enabled = true;

            ClearFIELDADD();
            ID = null;
            NullID();
            SaveAddBTN.Text = "Save";

            ItemAddFIELD.Enabled = true;
        }

        private void HistoryBTN_Click(object sender, EventArgs e)
        {
            ItemsHistory ItemsHistory = new ItemsHistory();
            ItemsHistory.Show();
        }

        private void StockGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + StockGridView.CurrentRow.Cells[1].Value.ToString() + "'", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ID = dt.Rows[0][0].ToString();
                Unit = dt.Rows[0][1].ToString();
                RUnit = dt.Rows[0][2].ToString();
                Qty = int.Parse(dt.Rows[0][3].ToString());
                RQty = int.Parse(dt.Rows[0][4].ToString());
                Code = dt.Rows[0][5].ToString();
                Item = dt.Rows[0][6].ToString();
                RItem = dt.Rows[0][7].ToString();
                Category = dt.Rows[0][8].ToString();
                Group = dt.Rows[0][9].ToString();
                Brand = dt.Rows[0][10].ToString();
                Remarks = dt.Rows[0][11].ToString();

                CatchData.ITEMSITEM = Item;
                CatchData.ITEMSRITEM = RItem;

                if (CatchData.USRLVL == "Administrator")
                {
                    EditBTN.Enabled = true;
                    DelBTN.Enabled = true;
                    HistoryBTN.Enabled = true;
                    QuantityBTN.Enabled = true;
                    ADJBTN.Enabled = true;
                }
                else if (CatchData.USRLVL == "Encoder")
                {
                    EditBTN.Enabled = true;
                    DelBTN.Enabled = true;
                    HistoryBTN.Enabled = true;
                    QuantityBTN.Enabled = true;
                    ADJBTN.Enabled = true;
                }
                else
                {
                    HistoryBTN.Enabled = true;
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

        private void ADJBTN_Click(object sender, EventArgs e)
        {
            ADJDOWNPANEL.Visible = true;

            RefreshBTN.Enabled = false;

            AddBTN.Enabled = false;
            EditBTN.Enabled = false;

            DelBTN.Enabled = false;
            CloseBTN.Enabled = false;

            HistoryBTN.Enabled = false;
            QuantityBTN.Enabled = false;
            ADJBTN.Enabled = false;

            ItemFIELD.Enabled = false;
            CategoryFIELD.Enabled = false;

            StockGridView.Enabled = false;

            ClearFIELDADD();

            UnitAdjFIELD.Text = Unit.ToString(); 
        }

        private void AddABTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Name or Customer", "Message");
                }
                else if (QtyAdjFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Quantity", "Message");
                }
                else if (QtyAdjFIELD.Text == "0")
                {
                    MessageBox.Show("Please enter the correct Quantity", "Message");
                }
                else if (ReasonAdjFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Reason", "Message");
                }
                else
                {
                    AdjQty = int.Parse(QtyAdjFIELD.Text);


                    if (AdjustTypeFIELD.Text == "ADD")
                    {
                        Balance = Qty + AdjQty;
                    }
                    else if (AdjustTypeFIELD.Text == "LESS")
                    {
                        Balance = Qty - AdjQty;
                    }
                    else if (AdjustTypeFIELD.Text == "RESET")
                    {
                        Balance = 0;
                    }

                    SQLLoad.con.Close();
                    SQLLoad.con.Open();
                    RNGAJ();
                    RNGIH();

                    REFID = "AD" + DateTime.Now.ToString("yy") + "-" + IDAJ.ToString();

                    string savestria = "insert into ItemsAdjust (ID, Date, DateA, Qty, Unit, Item, Balance, Adjust, Reason, Reference) values (@ID, @Date, @DateA, @Qty, @Unit, @Item, @Balance, @Adjust, @Reason, @Reference)";
                    SqlCommand savecmdia = new SqlCommand(savestria, SQLLoad.con);

                    savecmdia.Parameters.AddWithValue("@ID", IDAJ.ToString());
                    savecmdia.Parameters.AddWithValue("@Date", DateTime.Now.ToString("yyyy-MM-dd"));
                    savecmdia.Parameters.AddWithValue("@DateA", DTAdjust.Value.ToString("yyyy-MM-dd"));
                    savecmdia.Parameters.AddWithValue("@Qty", QtyAdjFIELD.Text);
                    savecmdia.Parameters.AddWithValue("@Unit", UnitAdjFIELD.Text);
                    savecmdia.Parameters.AddWithValue("@Item", Item.ToString());
                    savecmdia.Parameters.AddWithValue("@Balance", Balance.ToString());
                    savecmdia.Parameters.AddWithValue("@Adjust", AdjustTypeFIELD.Text);
                    savecmdia.Parameters.AddWithValue("@Reason", ReasonAdjFIELD.Text);
                    savecmdia.Parameters.AddWithValue("@Reference", REFID.ToString());
                    savecmdia.ExecuteNonQuery();

                    string savestrih = "insert into ItemsHistory (ID, TID, Qty, Unit, Item, Reference, RefQty, Customer, Balance, RefBalance, RefNumber, DateR, DateT, Remarks, Checker, Type) values (@ID, @TID, @Qty, @Unit, @Item, @Reference, @RefQty, @Customer, @Balance, @RefBalance, @RefNumber, @DateR, @DateT, @Remarks, @Checker, @Type)";
                    SqlCommand savecmdih = new SqlCommand(savestrih, SQLLoad.con);

                    savecmdih.Parameters.AddWithValue("@ID", IDIH.ToString());
                    savecmdih.Parameters.AddWithValue("@TID", "0");
                    savecmdih.Parameters.AddWithValue("@Qty", QtyAdjFIELD.Text);
                    savecmdih.Parameters.AddWithValue("@Unit", UnitAdjFIELD.Text);
                    savecmdih.Parameters.AddWithValue("@Item", Item.ToString());
                    savecmdih.Parameters.AddWithValue("@Reference", "No");
                    savecmdih.Parameters.AddWithValue("@RefQty", "0");
                    savecmdih.Parameters.AddWithValue("@Customer", NameFIELD.Text);
                    savecmdih.Parameters.AddWithValue("@Balance", Balance.ToString());
                    savecmdih.Parameters.AddWithValue("@RefBalance", "0");
                    savecmdih.Parameters.AddWithValue("@RefNumber", REFID.ToString());
                    savecmdih.Parameters.AddWithValue("@DateR", DateTime.Now.ToString("yyyy-MM-dd"));
                    savecmdih.Parameters.AddWithValue("@DateT", DTAdjust.Value.ToString("yyyy-MM-dd"));
                    savecmdih.Parameters.AddWithValue("@Remarks", ReasonAdjFIELD.Text);
                    savecmdih.Parameters.AddWithValue("@Checker", "NONE");
                    savecmdih.Parameters.AddWithValue("@Type", "Adjustment");
                    savecmdih.ExecuteNonQuery();

                    SqlCommand updatecmd = new SqlCommand("update Items set Qty = @Qty where Item = '" + Item.ToString() + "'", SQLLoad.con);
                    updatecmd.Parameters.AddWithValue("@Qty", Balance.ToString());
                    updatecmd.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Adjustment Successfully!", "Message");

                    ADDDOWNPANEL.Visible = false;
                    ADJDOWNPANEL.Visible = false;

                    RefreshBTN.Enabled = true;

                    AddBTN.Enabled = true;
                    CloseBTN.Enabled = true;

                    AddBTN.Visible = true;
                    EditBTN.Visible = true;

                    DelBTN.Visible = true;
                    CloseBTN.Visible = true;

                    HistoryBTN.Enabled = true;
                    QuantityBTN.Enabled = true;
                    ADJBTN.Enabled = true;

                    ItemFIELD.Enabled = true;
                    CategoryFIELD.Enabled = true;

                    StockGridView.Enabled = true;

                    ClearFIELDADD();
                    LoadData();
                    ID = null;
                    NullID();
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

        private void CancelABTN_Click(object sender, EventArgs e)
        {
            ADDDOWNPANEL.Visible = false;
            ADJDOWNPANEL.Visible = false;

            RefreshBTN.Enabled = true;

            AddBTN.Enabled = true;
            CloseBTN.Enabled = true;

            AddBTN.Visible = true;
            EditBTN.Visible = true;

            DelBTN.Visible = true;
            CloseBTN.Visible = true;

            HistoryBTN.Enabled = true;
            QuantityBTN.Enabled = true;
            ADJBTN.Enabled = true;

            SaveAddBTN.Visible = true;

            ItemFIELD.Enabled = true;
            CategoryFIELD.Enabled = true;

            StockGridView.Enabled = true;

            ClearFIELDADD();
            ID = null;
            NullID();
        }

        private void QuantityBTN_Click(object sender, EventArgs e)
        {
            ADJQTYPANEL.Visible = true;

            RefreshBTN.Enabled = false;

            AddBTN.Enabled = false;
            EditBTN.Enabled = false;

            DelBTN.Enabled = false;
            CloseBTN.Enabled = false;

            HistoryBTN.Enabled = false;
            QuantityBTN.Enabled = false;
            ADJBTN.Enabled = false;

            ItemFIELD.Enabled = false;
            CategoryFIELD.Enabled = false;

            StockGridView.Enabled = false;

            ClearFIELDADD();

            EditQtyFIELD.Text = Qty.ToString();
        }

        private void EditQtyBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditQtyFIELD.Text == "")
                {
                    MessageBox.Show("Please fill the Quantity.", "Message");
                }
                else
                {
                    SQLLoad.con.Close();
                    SQLLoad.con.Open();

                    SqlCommand updatecmd = new SqlCommand("update Items set Qty = @Qty where Item = '" + Item.ToString() + "'", SQLLoad.con);
                    updatecmd.Parameters.AddWithValue("@Qty", EditQtyFIELD.Text);
                    updatecmd.ExecuteNonQuery();
                    SQLLoad.con.Close();

                    MessageBox.Show("Update Quantity Successfully!", "Message");

                    ADJQTYPANEL.Visible = false;

                    RefreshBTN.Enabled = true;

                    AddBTN.Enabled = true;
                    CloseBTN.Enabled = true;

                    AddBTN.Visible = true;
                    EditBTN.Visible = true;

                    HistoryBTN.Enabled = true;
                    QuantityBTN.Enabled = true;
                    ADJBTN.Enabled = true;

                    DelBTN.Visible = true;
                    CloseBTN.Visible = true;

                    ItemFIELD.Enabled = true;
                    CategoryFIELD.Enabled = true;

                    StockGridView.Enabled = true;

                    ClearFIELDADD();
                    LoadData();
                    ID = null;
                    NullID();
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

        private void CnclQtyBTN_Click(object sender, EventArgs e)
        {
            ADJQTYPANEL.Visible = false;

            RefreshBTN.Enabled = true;

            AddBTN.Enabled = true;
            CloseBTN.Enabled = true;

            AddBTN.Visible = true;
            EditBTN.Visible = true;

            HistoryBTN.Enabled = true;
            QuantityBTN.Enabled = true;
            ADJBTN.Enabled = true;

            DelBTN.Visible = true;
            CloseBTN.Visible = true;

            ItemFIELD.Enabled = true;
            CategoryFIELD.Enabled = true;

            StockGridView.Enabled = true;

            ClearFIELDADD();
            ID = null;
            NullID();
        }

        private void CategoryFIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItemFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Items where Category like '%" + CategoryFIELD.Text + "%' order by Item ASC", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    StockGridView.DataSource = dt;
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

        private void CategoryFIELD_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItemFIELD.Text == null)
                {
                    LoadData();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from Items where Category like '%" + CategoryFIELD.Text + "%' order by Item ASC", SQLLoad.con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    StockGridView.DataSource = dt;
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
