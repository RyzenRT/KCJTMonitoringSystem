namespace SampleInventory
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.TimerDate = new System.Windows.Forms.Timer(this.components);
            this.Logo = new System.Windows.Forms.PictureBox();
            this.XBTN = new System.Windows.Forms.Button();
            this.LogOutBTN = new System.Windows.Forms.Button();
            this.UserTXT = new System.Windows.Forms.Label();
            this.LEFTTXT = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.MINBTN = new System.Windows.Forms.Button();
            this.ReturnBTN = new System.Windows.Forms.Button();
            this.DateNTime = new System.Windows.Forms.Label();
            this.RIGHTTXT = new System.Windows.Forms.Label();
            this.PickupBTN = new System.Windows.Forms.Button();
            this.BackloadBTN = new System.Windows.Forms.Button();
            this.UsersBTN = new System.Windows.Forms.Button();
            this.TITLETXT = new System.Windows.Forms.Label();
            this.SupplierBTN = new System.Windows.Forms.Button();
            this.StocksBTN = new System.Windows.Forms.Button();
            this.DateNTimeTTxt = new System.Windows.Forms.Label();
            this.ReportsBTN = new System.Windows.Forms.Button();
            this.VersionTXT = new System.Windows.Forms.Label();
            this.CENTERTXT = new System.Windows.Forms.Label();
            this.Panel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerDate
            // 
            this.TimerDate.Enabled = true;
            this.TimerDate.Tick += new System.EventHandler(this.TimerDate_Tick);
            // 
            // Logo
            // 
            this.Logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(285, 15);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(125, 125);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 36;
            this.Logo.TabStop = false;
            // 
            // XBTN
            // 
            this.XBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XBTN.BackColor = System.Drawing.Color.Transparent;
            this.XBTN.FlatAppearance.BorderSize = 0;
            this.XBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.XBTN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.XBTN.Location = new System.Drawing.Point(1310, 0);
            this.XBTN.Name = "XBTN";
            this.XBTN.Size = new System.Drawing.Size(50, 50);
            this.XBTN.TabIndex = 38;
            this.XBTN.Text = "X";
            this.XBTN.UseVisualStyleBackColor = false;
            this.XBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // LogOutBTN
            // 
            this.LogOutBTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogOutBTN.AutoSize = true;
            this.LogOutBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.LogOutBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LogOutBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogOutBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogOutBTN.Font = new System.Drawing.Font("Microsoft Uighur", 22F);
            this.LogOutBTN.ForeColor = System.Drawing.Color.White;
            this.LogOutBTN.Image = ((System.Drawing.Image)(resources.GetObject("LogOutBTN.Image")));
            this.LogOutBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LogOutBTN.Location = new System.Drawing.Point(466, 608);
            this.LogOutBTN.Name = "LogOutBTN";
            this.LogOutBTN.Size = new System.Drawing.Size(200, 52);
            this.LogOutBTN.TabIndex = 29;
            this.LogOutBTN.Text = "Logout";
            this.LogOutBTN.UseVisualStyleBackColor = false;
            this.LogOutBTN.Click += new System.EventHandler(this.LogOutBTN_Click);
            // 
            // UserTXT
            // 
            this.UserTXT.AutoSize = true;
            this.UserTXT.Font = new System.Drawing.Font("Microsoft Uighur", 22F);
            this.UserTXT.ForeColor = System.Drawing.Color.Black;
            this.UserTXT.Location = new System.Drawing.Point(12, 663);
            this.UserTXT.Name = "UserTXT";
            this.UserTXT.Size = new System.Drawing.Size(105, 40);
            this.UserTXT.TabIndex = 28;
            this.UserTXT.Text = "Welcome: ";
            // 
            // LEFTTXT
            // 
            this.LEFTTXT.AutoSize = true;
            this.LEFTTXT.Font = new System.Drawing.Font("Microsoft Uighur", 28F);
            this.LEFTTXT.Location = new System.Drawing.Point(100, 137);
            this.LEFTTXT.Name = "LEFTTXT";
            this.LEFTTXT.Size = new System.Drawing.Size(108, 51);
            this.LEFTTXT.TabIndex = 4;
            this.LEFTTXT.Text = "Manage";
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CloseBTN.AutoSize = true;
            this.CloseBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.CloseBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Microsoft Uighur", 22F);
            this.CloseBTN.ForeColor = System.Drawing.Color.White;
            this.CloseBTN.Image = ((System.Drawing.Image)(resources.GetObject("CloseBTN.Image")));
            this.CloseBTN.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseBTN.Location = new System.Drawing.Point(682, 608);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(200, 52);
            this.CloseBTN.TabIndex = 30;
            this.CloseBTN.Text = "Close";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // MINBTN
            // 
            this.MINBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MINBTN.BackColor = System.Drawing.Color.Transparent;
            this.MINBTN.FlatAppearance.BorderSize = 0;
            this.MINBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MINBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.MINBTN.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MINBTN.Location = new System.Drawing.Point(1257, 0);
            this.MINBTN.Name = "MINBTN";
            this.MINBTN.Size = new System.Drawing.Size(50, 50);
            this.MINBTN.TabIndex = 39;
            this.MINBTN.Text = "_";
            this.MINBTN.UseVisualStyleBackColor = false;
            this.MINBTN.Click += new System.EventHandler(this.MINBTN_Click);
            // 
            // ReturnBTN
            // 
            this.ReturnBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ReturnBTN.AutoSize = true;
            this.ReturnBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReturnBTN.BackgroundImage")));
            this.ReturnBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReturnBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReturnBTN.FlatAppearance.BorderSize = 0;
            this.ReturnBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReturnBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.ReturnBTN.ForeColor = System.Drawing.Color.White;
            this.ReturnBTN.Location = new System.Drawing.Point(1100, 196);
            this.ReturnBTN.Name = "ReturnBTN";
            this.ReturnBTN.Size = new System.Drawing.Size(200, 200);
            this.ReturnBTN.TabIndex = 34;
            this.ReturnBTN.Text = "Returns";
            this.ReturnBTN.UseVisualStyleBackColor = false;
            this.ReturnBTN.Click += new System.EventHandler(this.ReturnBTN_Click);
            // 
            // DateNTime
            // 
            this.DateNTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DateNTime.AutoSize = true;
            this.DateNTime.Font = new System.Drawing.Font("Microsoft Uighur", 22F);
            this.DateNTime.ForeColor = System.Drawing.Color.Black;
            this.DateNTime.Location = new System.Drawing.Point(686, 663);
            this.DateNTime.Name = "DateNTime";
            this.DateNTime.Size = new System.Drawing.Size(123, 40);
            this.DateNTime.TabIndex = 0;
            this.DateNTime.Text = "Date / Time:";
            // 
            // RIGHTTXT
            // 
            this.RIGHTTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RIGHTTXT.AutoSize = true;
            this.RIGHTTXT.Font = new System.Drawing.Font("Microsoft Uighur", 28F);
            this.RIGHTTXT.Location = new System.Drawing.Point(1150, 137);
            this.RIGHTTXT.Name = "RIGHTTXT";
            this.RIGHTTXT.Size = new System.Drawing.Size(106, 51);
            this.RIGHTTXT.TabIndex = 36;
            this.RIGHTTXT.Text = "Returns";
            // 
            // PickupBTN
            // 
            this.PickupBTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PickupBTN.AutoSize = true;
            this.PickupBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PickupBTN.BackgroundImage")));
            this.PickupBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PickupBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PickupBTN.FlatAppearance.BorderSize = 0;
            this.PickupBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PickupBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.PickupBTN.ForeColor = System.Drawing.Color.White;
            this.PickupBTN.Location = new System.Drawing.Point(682, 403);
            this.PickupBTN.Name = "PickupBTN";
            this.PickupBTN.Size = new System.Drawing.Size(200, 200);
            this.PickupBTN.TabIndex = 15;
            this.PickupBTN.Text = "Exporting\r\n⎯⎯⎯⎯⎯\r\nPickup/Delivery\r\n";
            this.PickupBTN.UseVisualStyleBackColor = false;
            this.PickupBTN.Click += new System.EventHandler(this.PickupBTN_Click);
            // 
            // BackloadBTN
            // 
            this.BackloadBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackloadBTN.AutoSize = true;
            this.BackloadBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BackloadBTN.BackgroundImage")));
            this.BackloadBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BackloadBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BackloadBTN.FlatAppearance.BorderSize = 0;
            this.BackloadBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackloadBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.BackloadBTN.ForeColor = System.Drawing.Color.White;
            this.BackloadBTN.Location = new System.Drawing.Point(1100, 403);
            this.BackloadBTN.Name = "BackloadBTN";
            this.BackloadBTN.Size = new System.Drawing.Size(200, 200);
            this.BackloadBTN.TabIndex = 26;
            this.BackloadBTN.Text = "Backload";
            this.BackloadBTN.UseVisualStyleBackColor = false;
            this.BackloadBTN.Click += new System.EventHandler(this.BackloadBTN_Click);
            // 
            // UsersBTN
            // 
            this.UsersBTN.AutoSize = true;
            this.UsersBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("UsersBTN.BackgroundImage")));
            this.UsersBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.UsersBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsersBTN.FlatAppearance.BorderSize = 0;
            this.UsersBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.UsersBTN.ForeColor = System.Drawing.Color.White;
            this.UsersBTN.Location = new System.Drawing.Point(50, 196);
            this.UsersBTN.Margin = new System.Windows.Forms.Padding(0);
            this.UsersBTN.Name = "UsersBTN";
            this.UsersBTN.Size = new System.Drawing.Size(200, 200);
            this.UsersBTN.TabIndex = 0;
            this.UsersBTN.Text = "Users";
            this.UsersBTN.UseVisualStyleBackColor = false;
            this.UsersBTN.Click += new System.EventHandler(this.UsersBTN_Click);
            // 
            // TITLETXT
            // 
            this.TITLETXT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TITLETXT.AutoSize = true;
            this.TITLETXT.BackColor = System.Drawing.Color.Transparent;
            this.TITLETXT.Font = new System.Drawing.Font("Microsoft YaHei", 36F);
            this.TITLETXT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TITLETXT.Location = new System.Drawing.Point(416, 17);
            this.TITLETXT.Name = "TITLETXT";
            this.TITLETXT.Size = new System.Drawing.Size(743, 124);
            this.TITLETXT.TabIndex = 37;
            this.TITLETXT.Text = "KCJT Group Inc.\r\nWarehouse Monitoring System\r\n";
            this.TITLETXT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SupplierBTN
            // 
            this.SupplierBTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SupplierBTN.AutoSize = true;
            this.SupplierBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SupplierBTN.BackgroundImage")));
            this.SupplierBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SupplierBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SupplierBTN.FlatAppearance.BorderSize = 0;
            this.SupplierBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SupplierBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.SupplierBTN.ForeColor = System.Drawing.Color.White;
            this.SupplierBTN.Location = new System.Drawing.Point(466, 403);
            this.SupplierBTN.Name = "SupplierBTN";
            this.SupplierBTN.Size = new System.Drawing.Size(203, 200);
            this.SupplierBTN.TabIndex = 14;
            this.SupplierBTN.Text = "Importing\r\n⎯⎯⎯⎯⎯\r\nSupplier/Parating";
            this.SupplierBTN.UseVisualStyleBackColor = false;
            this.SupplierBTN.Click += new System.EventHandler(this.SupplierBTN_Click);
            // 
            // StocksBTN
            // 
            this.StocksBTN.AutoSize = true;
            this.StocksBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StocksBTN.BackgroundImage")));
            this.StocksBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.StocksBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StocksBTN.FlatAppearance.BorderSize = 0;
            this.StocksBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StocksBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.StocksBTN.ForeColor = System.Drawing.Color.White;
            this.StocksBTN.Location = new System.Drawing.Point(50, 403);
            this.StocksBTN.Name = "StocksBTN";
            this.StocksBTN.Size = new System.Drawing.Size(200, 200);
            this.StocksBTN.TabIndex = 1;
            this.StocksBTN.Text = "Inventory\r\n⎯⎯⎯⎯⎯\r\nStocks";
            this.StocksBTN.UseVisualStyleBackColor = false;
            this.StocksBTN.Click += new System.EventHandler(this.StocksBTN_Click);
            // 
            // DateNTimeTTxt
            // 
            this.DateNTimeTTxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DateNTimeTTxt.AutoSize = true;
            this.DateNTimeTTxt.Font = new System.Drawing.Font("Microsoft Uighur", 22F);
            this.DateNTimeTTxt.ForeColor = System.Drawing.Color.Black;
            this.DateNTimeTTxt.Location = new System.Drawing.Point(543, 663);
            this.DateNTimeTTxt.Name = "DateNTimeTTxt";
            this.DateNTimeTTxt.Size = new System.Drawing.Size(123, 40);
            this.DateNTimeTTxt.TabIndex = 1;
            this.DateNTimeTTxt.Text = "Date / Time:";
            // 
            // ReportsBTN
            // 
            this.ReportsBTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ReportsBTN.AutoSize = true;
            this.ReportsBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReportsBTN.BackgroundImage")));
            this.ReportsBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ReportsBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReportsBTN.FlatAppearance.BorderSize = 0;
            this.ReportsBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportsBTN.Font = new System.Drawing.Font("Tahoma", 18F);
            this.ReportsBTN.ForeColor = System.Drawing.Color.White;
            this.ReportsBTN.Location = new System.Drawing.Point(575, 196);
            this.ReportsBTN.Name = "ReportsBTN";
            this.ReportsBTN.Size = new System.Drawing.Size(200, 200);
            this.ReportsBTN.TabIndex = 3;
            this.ReportsBTN.Text = "Reports";
            this.ReportsBTN.UseVisualStyleBackColor = false;
            this.ReportsBTN.Click += new System.EventHandler(this.ReportsBTN_Click);
            // 
            // VersionTXT
            // 
            this.VersionTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionTXT.AutoSize = true;
            this.VersionTXT.Font = new System.Drawing.Font("Microsoft Uighur", 22F);
            this.VersionTXT.ForeColor = System.Drawing.Color.Black;
            this.VersionTXT.Location = new System.Drawing.Point(1232, 662);
            this.VersionTXT.Name = "VersionTXT";
            this.VersionTXT.Size = new System.Drawing.Size(116, 40);
            this.VersionTXT.TabIndex = 27;
            this.VersionTXT.Text = "Version: 1.0";
            this.VersionTXT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CENTERTXT
            // 
            this.CENTERTXT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CENTERTXT.AutoSize = true;
            this.CENTERTXT.Font = new System.Drawing.Font("Microsoft Uighur", 28F);
            this.CENTERTXT.Location = new System.Drawing.Point(600, 137);
            this.CENTERTXT.Name = "CENTERTXT";
            this.CENTERTXT.Size = new System.Drawing.Size(159, 51);
            this.CENTERTXT.TabIndex = 32;
            this.CENTERTXT.Text = "Transactions";
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel.Controls.Add(this.Logo);
            this.Panel.Controls.Add(this.TITLETXT);
            this.Panel.Controls.Add(this.XBTN);
            this.Panel.Controls.Add(this.CENTERTXT);
            this.Panel.Controls.Add(this.LogOutBTN);
            this.Panel.Controls.Add(this.VersionTXT);
            this.Panel.Controls.Add(this.UserTXT);
            this.Panel.Controls.Add(this.ReportsBTN);
            this.Panel.Controls.Add(this.LEFTTXT);
            this.Panel.Controls.Add(this.DateNTimeTTxt);
            this.Panel.Controls.Add(this.CloseBTN);
            this.Panel.Controls.Add(this.StocksBTN);
            this.Panel.Controls.Add(this.MINBTN);
            this.Panel.Controls.Add(this.SupplierBTN);
            this.Panel.Controls.Add(this.ReturnBTN);
            this.Panel.Controls.Add(this.UsersBTN);
            this.Panel.Controls.Add(this.DateNTime);
            this.Panel.Controls.Add(this.BackloadBTN);
            this.Panel.Controls.Add(this.RIGHTTXT);
            this.Panel.Controls.Add(this.PickupBTN);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1360, 720);
            this.Panel.TabIndex = 41;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(1360, 720);
            this.Controls.Add(this.Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INVENTORY SYSTEM TEST - KCJT GROUP, INC";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer TimerDate;
        private System.Windows.Forms.Label RIGHTTXT;
        private System.Windows.Forms.Button UsersBTN;
        private System.Windows.Forms.Label DateNTimeTTxt;
        private System.Windows.Forms.Label CENTERTXT;
        private System.Windows.Forms.Button StocksBTN;
        private System.Windows.Forms.Button BackloadBTN;
        private System.Windows.Forms.Label DateNTime;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.Label LEFTTXT;
        private System.Windows.Forms.Button LogOutBTN;
        private System.Windows.Forms.Button MINBTN;
        private System.Windows.Forms.Button PickupBTN;
        private System.Windows.Forms.Label TITLETXT;
        private System.Windows.Forms.Button ReportsBTN;
        private System.Windows.Forms.Label VersionTXT;
        private System.Windows.Forms.Button SupplierBTN;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Button ReturnBTN;
        private System.Windows.Forms.Label UserTXT;
        private System.Windows.Forms.Button XBTN;
        private System.Windows.Forms.Panel Panel;
    }
}