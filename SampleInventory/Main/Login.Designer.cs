namespace SampleInventory
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gradientPanel = new SampleInventory.Classes.GradientPanel();
            this.GuestBTN = new SampleInventory.Classes.RoundedButtonV2();
            this.LoginBTN = new SampleInventory.Classes.RoundedButtonV2();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.PLOGO = new System.Windows.Forms.PictureBox();
            this.XBTN = new System.Windows.Forms.Button();
            this.ULOGO = new System.Windows.Forms.PictureBox();
            this.TitleTXT = new System.Windows.Forms.Label();
            this.MINBTN = new System.Windows.Forms.Button();
            this.UserField = new System.Windows.Forms.TextBox();
            this.PassField = new System.Windows.Forms.TextBox();
            this.gradientPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLOGO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Location = new System.Drawing.Point(109, 265);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 2);
            this.panel1.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Location = new System.Drawing.Point(110, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 2);
            this.panel2.TabIndex = 11;
            // 
            // gradientPanel
            // 
            this.gradientPanel.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.gradientPanel.ColorTop = System.Drawing.Color.DarkOrchid;
            this.gradientPanel.Controls.Add(this.GuestBTN);
            this.gradientPanel.Controls.Add(this.LoginBTN);
            this.gradientPanel.Controls.Add(this.Logo);
            this.gradientPanel.Controls.Add(this.PLOGO);
            this.gradientPanel.Controls.Add(this.XBTN);
            this.gradientPanel.Controls.Add(this.ULOGO);
            this.gradientPanel.Controls.Add(this.TitleTXT);
            this.gradientPanel.Controls.Add(this.MINBTN);
            this.gradientPanel.Controls.Add(this.UserField);
            this.gradientPanel.Controls.Add(this.PassField);
            this.gradientPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel.Name = "gradientPanel";
            this.gradientPanel.Size = new System.Drawing.Size(400, 450);
            this.gradientPanel.TabIndex = 21;
            // 
            // GuestBTN
            // 
            this.GuestBTN.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.GuestBTN.BackgroundColor = System.Drawing.SystemColors.MenuHighlight;
            this.GuestBTN.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.GuestBTN.BorderRadius = 0;
            this.GuestBTN.BorderSize = 0;
            this.GuestBTN.FlatAppearance.BorderSize = 0;
            this.GuestBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GuestBTN.Font = new System.Drawing.Font("Microsoft Uighur", 15F);
            this.GuestBTN.ForeColor = System.Drawing.Color.White;
            this.GuestBTN.Location = new System.Drawing.Point(80, 386);
            this.GuestBTN.Name = "GuestBTN";
            this.GuestBTN.Size = new System.Drawing.Size(241, 40);
            this.GuestBTN.TabIndex = 24;
            this.GuestBTN.Text = "GUEST";
            this.GuestBTN.TextColor = System.Drawing.Color.White;
            this.GuestBTN.UseVisualStyleBackColor = false;
            this.GuestBTN.Click += new System.EventHandler(this.GuestBTN_Click);
            // 
            // LoginBTN
            // 
            this.LoginBTN.BackColor = System.Drawing.Color.MidnightBlue;
            this.LoginBTN.BackgroundColor = System.Drawing.Color.MidnightBlue;
            this.LoginBTN.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.LoginBTN.BorderRadius = 0;
            this.LoginBTN.BorderSize = 0;
            this.LoginBTN.FlatAppearance.BorderSize = 0;
            this.LoginBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBTN.Font = new System.Drawing.Font("Microsoft Uighur", 15F);
            this.LoginBTN.ForeColor = System.Drawing.Color.White;
            this.LoginBTN.Location = new System.Drawing.Point(80, 330);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(240, 40);
            this.LoginBTN.TabIndex = 23;
            this.LoginBTN.Text = "LOGIN";
            this.LoginBTN.TextColor = System.Drawing.Color.White;
            this.LoginBTN.UseVisualStyleBackColor = false;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(140, 27);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(125, 125);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 18;
            this.Logo.TabStop = false;
            // 
            // PLOGO
            // 
            this.PLOGO.BackColor = System.Drawing.Color.Transparent;
            this.PLOGO.Image = ((System.Drawing.Image)(resources.GetObject("PLOGO.Image")));
            this.PLOGO.Location = new System.Drawing.Point(75, 274);
            this.PLOGO.Name = "PLOGO";
            this.PLOGO.Size = new System.Drawing.Size(30, 30);
            this.PLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PLOGO.TabIndex = 15;
            this.PLOGO.TabStop = false;
            // 
            // XBTN
            // 
            this.XBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.XBTN.BackColor = System.Drawing.Color.Transparent;
            this.XBTN.FlatAppearance.BorderSize = 0;
            this.XBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.XBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.XBTN.ForeColor = System.Drawing.Color.White;
            this.XBTN.Location = new System.Drawing.Point(351, 0);
            this.XBTN.Name = "XBTN";
            this.XBTN.Size = new System.Drawing.Size(50, 50);
            this.XBTN.TabIndex = 6;
            this.XBTN.Text = "X";
            this.XBTN.UseVisualStyleBackColor = false;
            this.XBTN.Click += new System.EventHandler(this.XBTN_Click);
            // 
            // ULOGO
            // 
            this.ULOGO.BackColor = System.Drawing.Color.Transparent;
            this.ULOGO.Image = ((System.Drawing.Image)(resources.GetObject("ULOGO.Image")));
            this.ULOGO.Location = new System.Drawing.Point(75, 234);
            this.ULOGO.Name = "ULOGO";
            this.ULOGO.Size = new System.Drawing.Size(30, 30);
            this.ULOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ULOGO.TabIndex = 14;
            this.ULOGO.TabStop = false;
            // 
            // TitleTXT
            // 
            this.TitleTXT.AutoSize = true;
            this.TitleTXT.BackColor = System.Drawing.Color.Transparent;
            this.TitleTXT.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTXT.ForeColor = System.Drawing.Color.White;
            this.TitleTXT.Location = new System.Drawing.Point(49, 156);
            this.TitleTXT.Name = "TitleTXT";
            this.TitleTXT.Size = new System.Drawing.Size(308, 54);
            this.TitleTXT.TabIndex = 20;
            this.TitleTXT.Text = "KCJT Group Inc.\r\nWarehouse Monitoring System";
            this.TitleTXT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MINBTN
            // 
            this.MINBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MINBTN.BackColor = System.Drawing.Color.Transparent;
            this.MINBTN.FlatAppearance.BorderSize = 0;
            this.MINBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MINBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.MINBTN.ForeColor = System.Drawing.Color.White;
            this.MINBTN.Location = new System.Drawing.Point(302, 0);
            this.MINBTN.Name = "MINBTN";
            this.MINBTN.Size = new System.Drawing.Size(50, 50);
            this.MINBTN.TabIndex = 5;
            this.MINBTN.Text = "_";
            this.MINBTN.UseVisualStyleBackColor = false;
            this.MINBTN.Click += new System.EventHandler(this.MINBTN_Click);
            // 
            // UserField
            // 
            this.UserField.BackColor = System.Drawing.Color.WhiteSmoke;
            this.UserField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserField.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.UserField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserField.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.UserField.ForeColor = System.Drawing.Color.Black;
            this.UserField.Location = new System.Drawing.Point(110, 234);
            this.UserField.Name = "UserField";
            this.UserField.Size = new System.Drawing.Size(210, 27);
            this.UserField.TabIndex = 0;
            // 
            // PassField
            // 
            this.PassField.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PassField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PassField.Font = new System.Drawing.Font("Microsoft YaHei", 15F);
            this.PassField.ForeColor = System.Drawing.Color.Black;
            this.PassField.Location = new System.Drawing.Point(110, 274);
            this.PassField.Name = "PassField";
            this.PassField.PasswordChar = '•';
            this.PassField.Size = new System.Drawing.Size(210, 27);
            this.PassField.TabIndex = 1;
            this.PassField.Tag = "";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(400, 450);
            this.Controls.Add(this.gradientPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Loading_MouseDown);
            this.gradientPanel.ResumeLayout(false);
            this.gradientPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PLOGO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ULOGO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox UserField;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.Button XBTN;
        private System.Windows.Forms.Button MINBTN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ULOGO;
        private System.Windows.Forms.PictureBox PLOGO;
        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.Label TitleTXT;
        private Classes.GradientPanel gradientPanel;
        private Classes.RoundedButtonV2 GuestBTN;
        private Classes.RoundedButtonV2 LoginBTN;
    }
}

