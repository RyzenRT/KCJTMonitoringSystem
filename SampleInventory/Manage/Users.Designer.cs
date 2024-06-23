namespace SampleInventory
{
    partial class Users
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.FILLPANEL = new System.Windows.Forms.Panel();
            this.ADDDOWNPANEL = new System.Windows.Forms.Panel();
            this.UserAddFIELD = new System.Windows.Forms.TextBox();
            this.BdayAddFIELD = new System.Windows.Forms.DateTimePicker();
            this.GenderAddFIELD = new System.Windows.Forms.ComboBox();
            this.UserlvlAddFIELD = new System.Windows.Forms.ComboBox();
            this.GenderAddTXT = new System.Windows.Forms.Label();
            this.BdayAddTXT = new System.Windows.Forms.Label();
            this.LNAddFIELD = new System.Windows.Forms.TextBox();
            this.LNAddTXT = new System.Windows.Forms.Label();
            this.FNAddFIELD = new System.Windows.Forms.TextBox();
            this.FNAddTXT = new System.Windows.Forms.Label();
            this.UserlvlAddTXT = new System.Windows.Forms.Label();
            this.PassAddFIELD = new System.Windows.Forms.TextBox();
            this.PassAddTXT = new System.Windows.Forms.Label();
            this.CancelAddBTN = new System.Windows.Forms.Button();
            this.SaveAddBTN = new System.Windows.Forms.Button();
            this.UserAddTXT = new System.Windows.Forms.Label();
            this.UsersGridView = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sQLSERVERDS = new SampleInventory.SQLSERVERDS();
            this.TOPPANEL = new System.Windows.Forms.Panel();
            this.XBTN = new System.Windows.Forms.Button();
            this.MINBTN = new System.Windows.Forms.Button();
            this.UserlvlFIELD = new System.Windows.Forms.ComboBox();
            this.TitleTXT = new System.Windows.Forms.Label();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.UserlevelTXT = new System.Windows.Forms.Label();
            this.CloseBTN = new System.Windows.Forms.Button();
            this.UserFIELD = new System.Windows.Forms.TextBox();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.UsernameTXT = new System.Windows.Forms.Label();
            this.EditBTN = new System.Windows.Forms.Button();
            this.AddBTN = new System.Windows.Forms.Button();
            this.usersTableAdapter = new SampleInventory.SQLSERVERDSTableAdapters.UsersTableAdapter();
            this.FILLPANEL.SuspendLayout();
            this.ADDDOWNPANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLSERVERDS)).BeginInit();
            this.TOPPANEL.SuspendLayout();
            this.SuspendLayout();
            // 
            // FILLPANEL
            // 
            this.FILLPANEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.FILLPANEL.Controls.Add(this.ADDDOWNPANEL);
            this.FILLPANEL.Controls.Add(this.UsersGridView);
            this.FILLPANEL.Controls.Add(this.TOPPANEL);
            this.FILLPANEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FILLPANEL.Font = new System.Drawing.Font("Ebrima", 8F);
            this.FILLPANEL.Location = new System.Drawing.Point(0, 0);
            this.FILLPANEL.Name = "FILLPANEL";
            this.FILLPANEL.Size = new System.Drawing.Size(1360, 720);
            this.FILLPANEL.TabIndex = 18;
            // 
            // ADDDOWNPANEL
            // 
            this.ADDDOWNPANEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(71)))), ((int)(((byte)(94)))));
            this.ADDDOWNPANEL.Controls.Add(this.UserAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.BdayAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.GenderAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.UserlvlAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.GenderAddTXT);
            this.ADDDOWNPANEL.Controls.Add(this.BdayAddTXT);
            this.ADDDOWNPANEL.Controls.Add(this.LNAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.LNAddTXT);
            this.ADDDOWNPANEL.Controls.Add(this.FNAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.FNAddTXT);
            this.ADDDOWNPANEL.Controls.Add(this.UserlvlAddTXT);
            this.ADDDOWNPANEL.Controls.Add(this.PassAddFIELD);
            this.ADDDOWNPANEL.Controls.Add(this.PassAddTXT);
            this.ADDDOWNPANEL.Controls.Add(this.CancelAddBTN);
            this.ADDDOWNPANEL.Controls.Add(this.SaveAddBTN);
            this.ADDDOWNPANEL.Controls.Add(this.UserAddTXT);
            this.ADDDOWNPANEL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ADDDOWNPANEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ADDDOWNPANEL.ForeColor = System.Drawing.Color.White;
            this.ADDDOWNPANEL.Location = new System.Drawing.Point(0, 555);
            this.ADDDOWNPANEL.Name = "ADDDOWNPANEL";
            this.ADDDOWNPANEL.Size = new System.Drawing.Size(1360, 165);
            this.ADDDOWNPANEL.TabIndex = 0;
            // 
            // UserAddFIELD
            // 
            this.UserAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.UserAddFIELD.Location = new System.Drawing.Point(99, 13);
            this.UserAddFIELD.Name = "UserAddFIELD";
            this.UserAddFIELD.Size = new System.Drawing.Size(500, 22);
            this.UserAddFIELD.TabIndex = 0;
            // 
            // BdayAddFIELD
            // 
            this.BdayAddFIELD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BdayAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.BdayAddFIELD.Location = new System.Drawing.Point(846, 69);
            this.BdayAddFIELD.Name = "BdayAddFIELD";
            this.BdayAddFIELD.Size = new System.Drawing.Size(500, 22);
            this.BdayAddFIELD.TabIndex = 5;
            // 
            // GenderAddFIELD
            // 
            this.GenderAddFIELD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenderAddFIELD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.GenderAddFIELD.FormattingEnabled = true;
            this.GenderAddFIELD.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.GenderAddFIELD.Location = new System.Drawing.Point(846, 97);
            this.GenderAddFIELD.Name = "GenderAddFIELD";
            this.GenderAddFIELD.Size = new System.Drawing.Size(500, 24);
            this.GenderAddFIELD.TabIndex = 6;
            // 
            // UserlvlAddFIELD
            // 
            this.UserlvlAddFIELD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserlvlAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.UserlvlAddFIELD.FormattingEnabled = true;
            this.UserlvlAddFIELD.Items.AddRange(new object[] {
            "Administrator",
            "Encoder",
            "Employee"});
            this.UserlvlAddFIELD.Location = new System.Drawing.Point(99, 69);
            this.UserlvlAddFIELD.Name = "UserlvlAddFIELD";
            this.UserlvlAddFIELD.Size = new System.Drawing.Size(500, 24);
            this.UserlvlAddFIELD.TabIndex = 2;
            // 
            // GenderAddTXT
            // 
            this.GenderAddTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenderAddTXT.AutoSize = true;
            this.GenderAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenderAddTXT.ForeColor = System.Drawing.Color.White;
            this.GenderAddTXT.Location = new System.Drawing.Point(781, 100);
            this.GenderAddTXT.Name = "GenderAddTXT";
            this.GenderAddTXT.Size = new System.Drawing.Size(59, 16);
            this.GenderAddTXT.TabIndex = 14;
            this.GenderAddTXT.Text = "Gender:";
            this.GenderAddTXT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BdayAddTXT
            // 
            this.BdayAddTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BdayAddTXT.AutoSize = true;
            this.BdayAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BdayAddTXT.ForeColor = System.Drawing.Color.White;
            this.BdayAddTXT.Location = new System.Drawing.Point(765, 72);
            this.BdayAddTXT.Name = "BdayAddTXT";
            this.BdayAddTXT.Size = new System.Drawing.Size(75, 16);
            this.BdayAddTXT.TabIndex = 12;
            this.BdayAddTXT.Text = "Birth Date:";
            this.BdayAddTXT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LNAddFIELD
            // 
            this.LNAddFIELD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LNAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.LNAddFIELD.Location = new System.Drawing.Point(846, 41);
            this.LNAddFIELD.Name = "LNAddFIELD";
            this.LNAddFIELD.Size = new System.Drawing.Size(500, 22);
            this.LNAddFIELD.TabIndex = 4;
            // 
            // LNAddTXT
            // 
            this.LNAddTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LNAddTXT.AutoSize = true;
            this.LNAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LNAddTXT.ForeColor = System.Drawing.Color.White;
            this.LNAddTXT.Location = new System.Drawing.Point(761, 44);
            this.LNAddTXT.Name = "LNAddTXT";
            this.LNAddTXT.Size = new System.Drawing.Size(79, 16);
            this.LNAddTXT.TabIndex = 10;
            this.LNAddTXT.Text = "Last Name:";
            this.LNAddTXT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FNAddFIELD
            // 
            this.FNAddFIELD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FNAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.FNAddFIELD.Location = new System.Drawing.Point(846, 13);
            this.FNAddFIELD.Name = "FNAddFIELD";
            this.FNAddFIELD.Size = new System.Drawing.Size(500, 22);
            this.FNAddFIELD.TabIndex = 3;
            // 
            // FNAddTXT
            // 
            this.FNAddTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FNAddTXT.AutoSize = true;
            this.FNAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FNAddTXT.ForeColor = System.Drawing.Color.White;
            this.FNAddTXT.Location = new System.Drawing.Point(760, 16);
            this.FNAddTXT.Name = "FNAddTXT";
            this.FNAddTXT.Size = new System.Drawing.Size(80, 16);
            this.FNAddTXT.TabIndex = 8;
            this.FNAddTXT.Text = "First Name:";
            this.FNAddTXT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UserlvlAddTXT
            // 
            this.UserlvlAddTXT.AutoSize = true;
            this.UserlvlAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserlvlAddTXT.ForeColor = System.Drawing.Color.White;
            this.UserlvlAddTXT.Location = new System.Drawing.Point(22, 72);
            this.UserlvlAddTXT.Name = "UserlvlAddTXT";
            this.UserlvlAddTXT.Size = new System.Drawing.Size(71, 16);
            this.UserlvlAddTXT.TabIndex = 6;
            this.UserlvlAddTXT.Text = "Userlevel:";
            // 
            // PassAddFIELD
            // 
            this.PassAddFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.PassAddFIELD.Location = new System.Drawing.Point(99, 41);
            this.PassAddFIELD.Name = "PassAddFIELD";
            this.PassAddFIELD.Size = new System.Drawing.Size(500, 22);
            this.PassAddFIELD.TabIndex = 1;
            // 
            // PassAddTXT
            // 
            this.PassAddTXT.AutoSize = true;
            this.PassAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassAddTXT.ForeColor = System.Drawing.Color.White;
            this.PassAddTXT.Location = new System.Drawing.Point(20, 44);
            this.PassAddTXT.Name = "PassAddTXT";
            this.PassAddTXT.Size = new System.Drawing.Size(73, 16);
            this.PassAddTXT.TabIndex = 4;
            this.PassAddTXT.Text = "Password:";
            // 
            // CancelAddBTN
            // 
            this.CancelAddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelAddBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.CancelAddBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.CancelAddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelAddBTN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelAddBTN.ForeColor = System.Drawing.Color.White;
            this.CancelAddBTN.Location = new System.Drawing.Point(1256, 127);
            this.CancelAddBTN.Name = "CancelAddBTN";
            this.CancelAddBTN.Size = new System.Drawing.Size(90, 30);
            this.CancelAddBTN.TabIndex = 8;
            this.CancelAddBTN.Text = "Cancel";
            this.CancelAddBTN.UseVisualStyleBackColor = false;
            this.CancelAddBTN.Click += new System.EventHandler(this.CancelAddBTN_Click);
            // 
            // SaveAddBTN
            // 
            this.SaveAddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveAddBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.SaveAddBTN.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.SaveAddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveAddBTN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveAddBTN.ForeColor = System.Drawing.Color.White;
            this.SaveAddBTN.Location = new System.Drawing.Point(1160, 127);
            this.SaveAddBTN.Name = "SaveAddBTN";
            this.SaveAddBTN.Size = new System.Drawing.Size(90, 30);
            this.SaveAddBTN.TabIndex = 7;
            this.SaveAddBTN.Text = "Save";
            this.SaveAddBTN.UseVisualStyleBackColor = false;
            this.SaveAddBTN.Click += new System.EventHandler(this.SaveAddBTN_Click);
            // 
            // UserAddTXT
            // 
            this.UserAddTXT.AutoSize = true;
            this.UserAddTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserAddTXT.ForeColor = System.Drawing.Color.White;
            this.UserAddTXT.Location = new System.Drawing.Point(17, 16);
            this.UserAddTXT.Name = "UserAddTXT";
            this.UserAddTXT.Size = new System.Drawing.Size(76, 16);
            this.UserAddTXT.TabIndex = 0;
            this.UserAddTXT.Text = "Username:";
            // 
            // UsersGridView
            // 
            this.UsersGridView.AutoGenerateColumns = false;
            this.UsersGridView.BackgroundColor = System.Drawing.Color.White;
            this.UsersGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UsersGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.UsersGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Ebrima", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.UsersGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.UsersGridView.ColumnHeadersHeight = 30;
            this.UsersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UsersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.UsersGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.UsersGridView.DataSource = this.usersBindingSource;
            this.UsersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersGridView.EnableHeadersVisualStyles = false;
            this.UsersGridView.GridColor = System.Drawing.Color.White;
            this.UsersGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UsersGridView.Location = new System.Drawing.Point(0, 170);
            this.UsersGridView.Name = "UsersGridView";
            this.UsersGridView.ReadOnly = true;
            this.UsersGridView.RowHeadersVisible = false;
            this.UsersGridView.RowHeadersWidth = 50;
            this.UsersGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.UsersGridView.Size = new System.Drawing.Size(1360, 550);
            this.UsersGridView.TabIndex = 2;
            this.UsersGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersGridView_CellContentClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "Action";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Select.Text = "Select";
            this.Select.ToolTipText = "Select";
            this.Select.UseColumnTextForButtonValue = true;
            this.Select.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Username";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Level";
            this.dataGridViewTextBoxColumn2.HeaderText = "Userlevel";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FN";
            this.dataGridViewTextBoxColumn3.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 275;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "LN";
            this.dataGridViewTextBoxColumn4.HeaderText = "Last Name";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 275;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "BDAY";
            this.dataGridViewTextBoxColumn5.HeaderText = "Birthday";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Gender";
            this.dataGridViewTextBoxColumn6.HeaderText = "Gender";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 160;
            // 
            // usersBindingSource
            // 
            this.usersBindingSource.DataMember = "Users";
            this.usersBindingSource.DataSource = this.sQLSERVERDS;
            // 
            // sQLSERVERDS
            // 
            this.sQLSERVERDS.DataSetName = "SQLSERVERDS";
            this.sQLSERVERDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TOPPANEL
            // 
            this.TOPPANEL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(140)))), ((int)(((byte)(200)))));
            this.TOPPANEL.Controls.Add(this.XBTN);
            this.TOPPANEL.Controls.Add(this.MINBTN);
            this.TOPPANEL.Controls.Add(this.UserlvlFIELD);
            this.TOPPANEL.Controls.Add(this.TitleTXT);
            this.TOPPANEL.Controls.Add(this.RefreshBTN);
            this.TOPPANEL.Controls.Add(this.UserlevelTXT);
            this.TOPPANEL.Controls.Add(this.CloseBTN);
            this.TOPPANEL.Controls.Add(this.UserFIELD);
            this.TOPPANEL.Controls.Add(this.DeleteBTN);
            this.TOPPANEL.Controls.Add(this.UsernameTXT);
            this.TOPPANEL.Controls.Add(this.EditBTN);
            this.TOPPANEL.Controls.Add(this.AddBTN);
            this.TOPPANEL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOPPANEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TOPPANEL.Location = new System.Drawing.Point(0, 0);
            this.TOPPANEL.Name = "TOPPANEL";
            this.TOPPANEL.Size = new System.Drawing.Size(1360, 170);
            this.TOPPANEL.TabIndex = 1;
            this.TOPPANEL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TOPPANEL_MouseDown);
            // 
            // XBTN
            // 
            this.XBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XBTN.FlatAppearance.BorderSize = 0;
            this.XBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.XBTN.ForeColor = System.Drawing.Color.White;
            this.XBTN.Location = new System.Drawing.Point(1310, 1);
            this.XBTN.Name = "XBTN";
            this.XBTN.Size = new System.Drawing.Size(50, 50);
            this.XBTN.TabIndex = 1;
            this.XBTN.Text = "X";
            this.XBTN.UseVisualStyleBackColor = true;
            this.XBTN.Click += new System.EventHandler(this.XBTN_Click);
            // 
            // MINBTN
            // 
            this.MINBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MINBTN.FlatAppearance.BorderSize = 0;
            this.MINBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MINBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.MINBTN.ForeColor = System.Drawing.Color.White;
            this.MINBTN.Location = new System.Drawing.Point(1262, 1);
            this.MINBTN.Name = "MINBTN";
            this.MINBTN.Size = new System.Drawing.Size(50, 50);
            this.MINBTN.TabIndex = 0;
            this.MINBTN.Text = "_";
            this.MINBTN.UseVisualStyleBackColor = true;
            this.MINBTN.Click += new System.EventHandler(this.MINBTN_Click);
            // 
            // UserlvlFIELD
            // 
            this.UserlvlFIELD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserlvlFIELD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UserlvlFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.UserlvlFIELD.FormattingEnabled = true;
            this.UserlvlFIELD.Items.AddRange(new object[] {
            "Administrator",
            "Encoder",
            "Employee"});
            this.UserlvlFIELD.Location = new System.Drawing.Point(846, 140);
            this.UserlvlFIELD.Name = "UserlvlFIELD";
            this.UserlvlFIELD.Size = new System.Drawing.Size(500, 24);
            this.UserlvlFIELD.TabIndex = 8;
            this.UserlvlFIELD.SelectedIndexChanged += new System.EventHandler(this.UserlvlFIELD_SelectedIndexChanged);
            this.UserlvlFIELD.SelectedValueChanged += new System.EventHandler(this.UserlvlFIELD_SelectedValueChanged);
            // 
            // TitleTXT
            // 
            this.TitleTXT.AutoSize = true;
            this.TitleTXT.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTXT.ForeColor = System.Drawing.Color.White;
            this.TitleTXT.Location = new System.Drawing.Point(2, 0);
            this.TitleTXT.Name = "TitleTXT";
            this.TitleTXT.Size = new System.Drawing.Size(159, 32);
            this.TitleTXT.TabIndex = 9;
            this.TitleTXT.Text = "User Section";
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.AutoSize = true;
            this.RefreshBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("RefreshBTN.BackgroundImage")));
            this.RefreshBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RefreshBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshBTN.FlatAppearance.BorderSize = 0;
            this.RefreshBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshBTN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshBTN.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.RefreshBTN.Location = new System.Drawing.Point(7, 57);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(80, 75);
            this.RefreshBTN.TabIndex = 2;
            this.RefreshBTN.Text = "Refresh";
            this.RefreshBTN.UseVisualStyleBackColor = false;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            // 
            // UserlevelTXT
            // 
            this.UserlevelTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserlevelTXT.AutoSize = true;
            this.UserlevelTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserlevelTXT.ForeColor = System.Drawing.Color.White;
            this.UserlevelTXT.Location = new System.Drawing.Point(772, 145);
            this.UserlevelTXT.Name = "UserlevelTXT";
            this.UserlevelTXT.Size = new System.Drawing.Size(71, 16);
            this.UserlevelTXT.TabIndex = 11;
            this.UserlevelTXT.Text = "Userlevel:";
            this.UserlevelTXT.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CloseBTN
            // 
            this.CloseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBTN.AutoSize = true;
            this.CloseBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CloseBTN.BackgroundImage")));
            this.CloseBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseBTN.FlatAppearance.BorderSize = 0;
            this.CloseBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseBTN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseBTN.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.CloseBTN.Location = new System.Drawing.Point(1263, 57);
            this.CloseBTN.Name = "CloseBTN";
            this.CloseBTN.Size = new System.Drawing.Size(80, 75);
            this.CloseBTN.TabIndex = 6;
            this.CloseBTN.Text = "Return";
            this.CloseBTN.UseVisualStyleBackColor = false;
            this.CloseBTN.Click += new System.EventHandler(this.CloseBTN_Click);
            // 
            // UserFIELD
            // 
            this.UserFIELD.Font = new System.Drawing.Font("Arial", 9.75F);
            this.UserFIELD.Location = new System.Drawing.Point(85, 142);
            this.UserFIELD.Name = "UserFIELD";
            this.UserFIELD.Size = new System.Drawing.Size(500, 22);
            this.UserFIELD.TabIndex = 7;
            this.UserFIELD.TextChanged += new System.EventHandler(this.UserFIELD_TextChanged);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.AutoSize = true;
            this.DeleteBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DeleteBTN.BackgroundImage")));
            this.DeleteBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DeleteBTN.FlatAppearance.BorderSize = 0;
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBTN.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DeleteBTN.Location = new System.Drawing.Point(280, 57);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(80, 75);
            this.DeleteBTN.TabIndex = 5;
            this.DeleteBTN.Text = "Remove";
            this.DeleteBTN.UseVisualStyleBackColor = false;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // UsernameTXT
            // 
            this.UsernameTXT.AutoSize = true;
            this.UsernameTXT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTXT.ForeColor = System.Drawing.Color.White;
            this.UsernameTXT.Location = new System.Drawing.Point(7, 145);
            this.UsernameTXT.Name = "UsernameTXT";
            this.UsernameTXT.Size = new System.Drawing.Size(76, 16);
            this.UsernameTXT.TabIndex = 10;
            this.UsernameTXT.Text = "Username:";
            // 
            // EditBTN
            // 
            this.EditBTN.AutoSize = true;
            this.EditBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("EditBTN.BackgroundImage")));
            this.EditBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EditBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditBTN.FlatAppearance.BorderSize = 0;
            this.EditBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditBTN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBTN.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EditBTN.Location = new System.Drawing.Point(189, 57);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(80, 75);
            this.EditBTN.TabIndex = 4;
            this.EditBTN.Text = "Edit";
            this.EditBTN.UseVisualStyleBackColor = false;
            this.EditBTN.Click += new System.EventHandler(this.EditBTN_Click);
            // 
            // AddBTN
            // 
            this.AddBTN.AutoSize = true;
            this.AddBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBTN.BackgroundImage")));
            this.AddBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddBTN.FlatAppearance.BorderSize = 0;
            this.AddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBTN.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddBTN.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AddBTN.Location = new System.Drawing.Point(98, 57);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(80, 75);
            this.AddBTN.TabIndex = 3;
            this.AddBTN.Text = "New";
            this.AddBTN.UseVisualStyleBackColor = false;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // usersTableAdapter
            // 
            this.usersTableAdapter.ClearBeforeFill = true;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(43)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1360, 720);
            this.Controls.Add(this.FILLPANEL);
            this.Font = new System.Drawing.Font("Ebrima", 15F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Users";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KCJT Group Inc. Warehouse Monitoring System - USER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Users_FormClosed);
            this.Load += new System.EventHandler(this.Users_Load);
            this.FILLPANEL.ResumeLayout(false);
            this.ADDDOWNPANEL.ResumeLayout(false);
            this.ADDDOWNPANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sQLSERVERDS)).EndInit();
            this.TOPPANEL.ResumeLayout(false);
            this.TOPPANEL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bDAYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel FILLPANEL;
        private SQLSERVERDS sQLSERVERDS;
        private System.Windows.Forms.BindingSource usersBindingSource;
        private SQLSERVERDSTableAdapters.UsersTableAdapter usersTableAdapter;
        private System.Windows.Forms.Panel TOPPANEL;
        private System.Windows.Forms.ComboBox UserlvlFIELD;
        private System.Windows.Forms.Button RefreshBTN;
        private System.Windows.Forms.Label UserlevelTXT;
        private System.Windows.Forms.Button CloseBTN;
        private System.Windows.Forms.TextBox UserFIELD;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Label UsernameTXT;
        private System.Windows.Forms.Button EditBTN;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Label TitleTXT;
        private System.Windows.Forms.DataGridView UsersGridView;
        private System.Windows.Forms.Panel ADDDOWNPANEL;
        private System.Windows.Forms.TextBox UserAddFIELD;
        private System.Windows.Forms.DateTimePicker BdayAddFIELD;
        private System.Windows.Forms.ComboBox GenderAddFIELD;
        private System.Windows.Forms.ComboBox UserlvlAddFIELD;
        private System.Windows.Forms.Label GenderAddTXT;
        private System.Windows.Forms.Label BdayAddTXT;
        private System.Windows.Forms.TextBox LNAddFIELD;
        private System.Windows.Forms.Label LNAddTXT;
        private System.Windows.Forms.TextBox FNAddFIELD;
        private System.Windows.Forms.Label FNAddTXT;
        private System.Windows.Forms.Label UserlvlAddTXT;
        private System.Windows.Forms.TextBox PassAddFIELD;
        private System.Windows.Forms.Label PassAddTXT;
        private System.Windows.Forms.Button CancelAddBTN;
        private System.Windows.Forms.Button SaveAddBTN;
        private System.Windows.Forms.Label UserAddTXT;
        private System.Windows.Forms.Button XBTN;
        private System.Windows.Forms.Button MINBTN;
        private System.Windows.Forms.DataGridViewButtonColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}