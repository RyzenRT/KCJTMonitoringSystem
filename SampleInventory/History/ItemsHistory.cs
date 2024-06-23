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
    public partial class ItemsHistory : Form
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

        public ItemsHistory()
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

        int DGV;
        string PENDING;

        int QTY;
        string Item, Customer, SODR;
        
        private void IH()
        {
            SQLLoad.con.Open();
            SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "'order by DateR DESC", SQLLoad.con);
            DataTable dt = new DataTable();
            igv.Fill(dt);
            ItemsHGV.DataSource = dt;
            SQLLoad.con.Close();
        }

        private void IA()
        {
            SQLLoad.con.Open();
            SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsAdjust where Item = '" + CatchData.ITEMSITEM + "' ", SQLLoad.con);
            DataTable dt = new DataTable();
            igv.Fill(dt);
            ItemsAGV.DataSource = dt;
            SQLLoad.con.Close();
        }


        private void PickupHistory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sQLSERVERDS.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.sQLSERVERDS.Items);
            CenterToScreen();
            try
            {
                // TODO: This line of code loads data into the 'sQLSERVERDS.ItemsHistory' table. You can move, or remove it, as needed.
                this.itemsHistoryTableAdapter.Fill(this.sQLSERVERDS.ItemsHistory);
                // TODO: This line of code loads data into the 'sQLSERVERDS.ItemsAdjust' table. You can move, or remove it, as needed.
                this.itemsAdjustTableAdapter.Fill(this.sQLSERVERDS.ItemsAdjust);
                DGV = 1;
                PENDING = "Pending";
                IH();
                IA();
                ItemsHGV.AllowUserToAddRows = false;
                ItemsAGV.AllowUserToAddRows = false;

                ItemsHGV.Visible = true;
                ItemsAGV.Visible = false;

                ItemTXT.Text = "Item: " + CatchData.ITEMSITEM;

                EDITPANEL.Visible = false;
                EDITPANEL.Enabled = false;

                CloseButton.EnableDisable(this, false);

                if (CatchData.USRLVL == "Administrator")
                {

                }
                else
                {
                    
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Check/Restart your Connection in Database!", "Message");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check/Restart your Connection in Database!", "Message");
            }
        }

        private void PrintBTN_Click(object sender, EventArgs e)
        {
            if (DGV == 1)
            {
                //Init print datagridview
                DGVPrinter printer = new DGVPrinter();
                printer.Title = CatchData.ITEMSITEM;//Header
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "KCJT Group, Inc.";//Footer
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(ItemsHGV);
            }
            else if (DGV == 2)
            {
                //Init print datagridview
                DGVPrinter printer = new DGVPrinter();
                printer.Title = CatchData.ITEMSITEM;//Header
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date.ToString("MM/dd/yyyy"));
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "KCJT Group, Inc.";//Footer
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(ItemsAGV);
            }
            else
            {

            }
        }
        private void NextBTN_Click(object sender, EventArgs e)
        {

        }

        private void PrevBTN_Click(object sender, EventArgs e)
        {

        }
        private void CloseBTN_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ItemsHGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                string ItemsCustomer, ItemsReference;

                ItemsCustomer = ItemsHGV.CurrentRow.Cells[3].Value.ToString();
                ItemsReference = ItemsHGV.CurrentRow.Cells[4].Value.ToString();

                SqlDataAdapter da = new SqlDataAdapter("Select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and Customer = '" + ItemsCustomer.Replace("'", "''") + "' and RefNumber = '" + ItemsReference + "'", SQLLoad.con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CatchData.TIDIH = int.Parse(dt.Rows[0][1].ToString());
                CatchData.QtyIH = dt.Rows[0][2].ToString();
                CatchData.RefQtyIH = dt.Rows[0][6].ToString();
                CatchData.BalQtyIH = dt.Rows[0][10].ToString();
                CatchData.RefBalQtyIH = dt.Rows[0][11].ToString();
                CatchData.NameIH = dt.Rows[0][9].ToString();
                CatchData.ReferenceIH = dt.Rows[0][12].ToString();
                CatchData.RemarksIH = dt.Rows[0][16].ToString();
                CatchData.CheckerIH = dt.Rows[0][17].ToString();

                ItemsFIELD.Text = CatchData.ITEMSITEM;
                QtyFIELD.Text = dt.Rows[0][2].ToString();
                RefQtyFIELD.Text = dt.Rows[0][6].ToString();
                BalQtyFIELD.Text = dt.Rows[0][10].ToString();
                RefBalQtyFIELD.Text = dt.Rows[0][11].ToString();
                NameFIELD.Text = dt.Rows[0][9].ToString();
                ReferenceFIELD.Text = dt.Rows[0][12].ToString();
                RemarksFIELD.Text = dt.Rows[0][16].ToString();
                CheckerFIELD.Text = dt.Rows[0][17].ToString();

                EDITPANEL.Visible = true;
                EDITPANEL.Enabled = true;

                ItemsHGV.Enabled = false;
                ItemsAGV.Enabled = false;
                TITLEPANEL.Enabled = false;
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

        private void Lbl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SQLLoad.con.Close();
                SQLLoad.con.Open();

                SqlCommand updatecmd = new SqlCommand("update ItemsHistory set Qty = @Qty, RefQty = @RefQty, Balance = @Balance, RefBalance = @RefBalance where Item = '" + CatchData.ITEMSITEM + "' and Customer = '" + CatchData.NameIH + "' and RefNumber = '" + CatchData.ReferenceIH + "'", SQLLoad.con);

                updatecmd.Parameters.AddWithValue("@Qty", QtyFIELD.Text);
                updatecmd.Parameters.AddWithValue("@RefQty", RefQtyFIELD.Text);
                updatecmd.Parameters.AddWithValue("@Balance", CatchData.BalQtyIH);
                updatecmd.Parameters.AddWithValue("@RefBalance", CatchData.RefBalQtyIH);
                updatecmd.ExecuteNonQuery();
                SQLLoad.con.Close();

                MessageBox.Show("Complete", "Message");

                IH();
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

        private void EditBTN_Click(object sender, EventArgs e)
        {
            try
            {
                SQLLoad.con.Close();
                SQLLoad.con.Open();

                SqlCommand updatecmdIH = new SqlCommand("update ItemsHistory set Item = @Item, RefItem = @RefItem, Qty = @Qty, RefQty = @RefQty, Balance = @Balance, RefBalance = @RefBalance, Checker = @Checker, Remarks = @Remarks where Item = '" + CatchData.ITEMSITEM + "' and Customer = '" + NameFIELD.Text.Replace("'", "''") + "' and RefNumber = '" + ReferenceFIELD.Text + "'", SQLLoad.con);

                updatecmdIH.Parameters.AddWithValue("@Item", ItemsFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@RefItem", RefFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@Qty", QtyFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@RefQty", RefQtyFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@Balance", BalQtyFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@RefBalance", RefBalQtyFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                updatecmdIH.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                updatecmdIH.ExecuteNonQuery();

                SqlCommand updatecmdTL = new SqlCommand("update Transaclist set Item = @Item, RefItem = @RefItem, Qty = @Qty, RefQty = @RefQty, Checker = @Checker, Remarks = @Remarks where Item = '" + CatchData.ITEMSITEM + "' and Name = '" + NameFIELD.Text.Replace("'", "''") + "' and TID = '" + CatchData.TIDIH + "'", SQLLoad.con);

                updatecmdTL.Parameters.AddWithValue("@Item", ItemsFIELD.Text);
                updatecmdTL.Parameters.AddWithValue("@RefItem", RefFIELD.Text);
                updatecmdTL.Parameters.AddWithValue("@Qty", QtyFIELD.Text);
                updatecmdTL.Parameters.AddWithValue("@RefQty", RefQtyFIELD.Text);
                updatecmdTL.Parameters.AddWithValue("@Checker", CheckerFIELD.Text);
                updatecmdTL.Parameters.AddWithValue("@Remarks", RemarksFIELD.Text);
                updatecmdTL.ExecuteNonQuery();
                SQLLoad.con.Close();

                MessageBox.Show("Edit Successfully Complete!", "Message");

                ItemsFIELD.Text = "";
                RefFIELD.Text = "";
                QtyFIELD.Text = "";
                RefQtyFIELD.Text = "";
                BalQtyFIELD.Text = "";
                RefBalQtyFIELD.Text = "";
                NameFIELD.Text = "";
                ReferenceFIELD.Text = "";
                RemarksFIELD.Text = "";

                EDITPANEL.Visible = false;
                EDITPANEL.Enabled = false;

                ItemsHGV.Enabled = true;
                ItemsAGV.Enabled = true;
                TITLEPANEL.Enabled = true;

                IH();
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

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            ItemsFIELD.Text = "";
            RefFIELD.Text = "";
            QtyFIELD.Text = "";
            RefQtyFIELD.Text = "";
            BalQtyFIELD.Text = "";
            RefBalQtyFIELD.Text = "";
            NameFIELD.Text = "";
            ReferenceFIELD.Text = "";
            RemarksFIELD.Text = "";

            EDITPANEL.Visible = false;
            EDITPANEL.Enabled = false;

            ItemsHGV.Enabled = true;
            ItemsAGV.Enabled = true;
            TITLEPANEL.Enabled = true;

            SQLLoad.con.Close();
            IH();
        }

        private void DTFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeFIELD.Text == "")
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' Order by DateR ASC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    igv.Fill(dt);
                    ItemsHGV.DataSource = dt;
                    SQLLoad.con.Close();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and Type = '" + TypeFIELD.Text + "' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' Order by DateR ASC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    igv.Fill(dt);
                    ItemsHGV.DataSource = dt;
                    SQLLoad.con.Close();
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

        private void DTTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeFIELD.Text == "")
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' Order by DateR ASC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    igv.Fill(dt);
                    ItemsHGV.DataSource = dt;
                    SQLLoad.con.Close();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and Type = '" + TypeFIELD.Text + "' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' Order by DateR ASC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    igv.Fill(dt);
                    ItemsHGV.DataSource = dt;
                    SQLLoad.con.Close();
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

        private void TypeFIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeFIELD.Text == "")
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' Order by DateR ASC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    igv.Fill(dt);
                    ItemsHGV.DataSource = dt;
                    SQLLoad.con.Close();
                }
                else
                {
                    SQLLoad.con.Open();
                    SqlDataAdapter igv = new SqlDataAdapter("select * from ItemsHistory where Item = '" + CatchData.ITEMSITEM + "' and Type = '" + TypeFIELD.Text + "' and DateR between '" + DTFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DTTo.Value.ToString("yyyy-MM-dd") + "' Order by DateR ASC ", SQLLoad.con);
                    DataTable dt = new DataTable();
                    igv.Fill(dt);
                    ItemsHGV.DataSource = dt;
                    SQLLoad.con.Close();
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

        private void TITLEPANEL_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void RefreshBTN_Click(object sender, EventArgs e)
        {
            ItemTXT.Text = "Item: " + CatchData.ITEMSITEM;

            ItemsFIELD.Text = "";
            RefFIELD.Text = "";
            QtyFIELD.Text = "";
            RefQtyFIELD.Text = "";
            BalQtyFIELD.Text = "";
            RefBalQtyFIELD.Text = "";
            NameFIELD.Text = "";
            ReferenceFIELD.Text = "";
            RemarksFIELD.Text = "";

            EDITPANEL.Visible = false;
            EDITPANEL.Enabled = false;

            ItemsHGV.Enabled = true;
            ItemsAGV.Enabled = true;
            TITLEPANEL.Enabled = true;

            SQLLoad.con.Close();
            IH();
        }

        private void MINBTN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void XBTN_Click(object sender, EventArgs e)
        {
            if (CloseBTN.Enabled == true)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please complete your task before closing this window.", "Message");
            }
        }

        private void ItemsFIELD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ItemsFIELD.Text == "")
                {

                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("Select * from Items where Item = '" + ItemsFIELD.Text + "'", SQLLoad.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    RefFIELD.Text = dt.Rows[0][7].ToString();

                    if (dt.Rows[0][7] == "")
                    {
                        RefFIELD.Text = "";
                    }
                    else
                    {
                        
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
    }
}
