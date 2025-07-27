namespace barmaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.deleteUserBtn = new Guna.UI2.WinForms.Guna2Button();
            this.addUserBtn = new Guna.UI2.WinForms.Guna2Button();
            this.updateUserBtn = new Guna.UI2.WinForms.Guna2Button();
            this.UsersDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.returnBtn = new Guna.UI2.WinForms.Guna2Button();
            this.EditUserPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.CloseEditPanelBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SaveuserBtn = new Guna.UI2.WinForms.Guna2Button();
            this.RoleComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.PhoneTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EmailTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.IDTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.FullNameTextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.EditPanelLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            this.EditUserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.Animated = true;
            this.deleteUserBtn.AnimatedGIF = true;
            this.deleteUserBtn.BorderColor = System.Drawing.Color.Transparent;
            this.deleteUserBtn.BorderRadius = 15;
            this.deleteUserBtn.BorderThickness = 1;
            this.deleteUserBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.deleteUserBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.deleteUserBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.deleteUserBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.deleteUserBtn.FillColor = System.Drawing.Color.Crimson;
            this.deleteUserBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.deleteUserBtn.ForeColor = System.Drawing.Color.White;
            this.deleteUserBtn.HoverState.BorderColor = System.Drawing.Color.Crimson;
            this.deleteUserBtn.HoverState.FillColor = System.Drawing.Color.White;
            this.deleteUserBtn.HoverState.ForeColor = System.Drawing.Color.Black;
            this.deleteUserBtn.HoverState.Image = global::barmaster.Properties.Resources.deleteGif;
            this.deleteUserBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.deleteUserBtn.Location = new System.Drawing.Point(289, 116);
            this.deleteUserBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(223, 48);
            this.deleteUserBtn.TabIndex = 31;
            this.deleteUserBtn.Text = "Delete User";
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // addUserBtn
            // 
            this.addUserBtn.Animated = true;
            this.addUserBtn.AnimatedGIF = true;
            this.addUserBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addUserBtn.BorderRadius = 15;
            this.addUserBtn.BorderThickness = 1;
            this.addUserBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addUserBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addUserBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addUserBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addUserBtn.FillColor = System.Drawing.Color.LightGreen;
            this.addUserBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addUserBtn.ForeColor = System.Drawing.Color.White;
            this.addUserBtn.HoverState.BorderColor = System.Drawing.Color.LightGreen;
            this.addUserBtn.HoverState.FillColor = System.Drawing.Color.White;
            this.addUserBtn.HoverState.ForeColor = System.Drawing.Color.Black;
            this.addUserBtn.HoverState.Image = global::barmaster.Properties.Resources.addGif;
            this.addUserBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.addUserBtn.Location = new System.Drawing.Point(906, 116);
            this.addUserBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(214, 48);
            this.addUserBtn.TabIndex = 32;
            this.addUserBtn.Text = "Add User";
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // updateUserBtn
            // 
            this.updateUserBtn.Animated = true;
            this.updateUserBtn.AnimatedGIF = true;
            this.updateUserBtn.BorderColor = System.Drawing.Color.Transparent;
            this.updateUserBtn.BorderRadius = 15;
            this.updateUserBtn.BorderThickness = 1;
            this.updateUserBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.updateUserBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.updateUserBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.updateUserBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.updateUserBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.updateUserBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.updateUserBtn.ForeColor = System.Drawing.Color.White;
            this.updateUserBtn.HoverState.BorderColor = System.Drawing.Color.SteelBlue;
            this.updateUserBtn.HoverState.FillColor = System.Drawing.Color.White;
            this.updateUserBtn.HoverState.ForeColor = System.Drawing.Color.Black;
            this.updateUserBtn.HoverState.Image = global::barmaster.Properties.Resources.updateGif;
            this.updateUserBtn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.updateUserBtn.Location = new System.Drawing.Point(608, 116);
            this.updateUserBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateUserBtn.Name = "updateUserBtn";
            this.updateUserBtn.Size = new System.Drawing.Size(207, 48);
            this.updateUserBtn.TabIndex = 33;
            this.updateUserBtn.Text = "Edit User";
            this.updateUserBtn.Click += new System.EventHandler(this.updateUserBtn_Click);
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.AllowUserToAddRows = false;
            this.UsersDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.UsersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UsersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UsersDataGridView.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UsersDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.UsersDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.UsersDataGridView.Location = new System.Drawing.Point(59, 253);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.ReadOnly = true;
            this.UsersDataGridView.RowHeadersVisible = false;
            this.UsersDataGridView.RowHeadersWidth = 62;
            this.UsersDataGridView.RowTemplate.Height = 28;
            this.UsersDataGridView.Size = new System.Drawing.Size(1287, 563);
            this.UsersDataGridView.TabIndex = 34;
            this.UsersDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.UsersDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.UsersDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.UsersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.UsersDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.UsersDataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.UsersDataGridView.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.UsersDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.UsersDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.UsersDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UsersDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.UsersDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UsersDataGridView.ThemeStyle.HeaderStyle.Height = 30;
            this.UsersDataGridView.ThemeStyle.ReadOnly = true;
            this.UsersDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.UsersDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.UsersDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UsersDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.UsersDataGridView.ThemeStyle.RowsStyle.Height = 28;
            this.UsersDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.UsersDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(560, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 37);
            this.label1.TabIndex = 35;
            this.label1.Text = "Users in the system";
            // 
            // returnBtn
            // 
            this.returnBtn.Animated = true;
            this.returnBtn.AnimatedGIF = true;
            this.returnBtn.AutoRoundedCorners = true;
            this.returnBtn.BackColor = System.Drawing.Color.Transparent;
            this.returnBtn.BorderRadius = 32;
            this.returnBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.returnBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.returnBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.returnBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.returnBtn.FillColor = System.Drawing.Color.Transparent;
            this.returnBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.returnBtn.ForeColor = System.Drawing.Color.White;
            this.returnBtn.Image = global::barmaster.Properties.Resources.icons8_back;
            this.returnBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.returnBtn.IndicateFocus = true;
            this.returnBtn.Location = new System.Drawing.Point(12, 9);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(84, 66);
            this.returnBtn.TabIndex = 36;
            this.returnBtn.UseTransparentBackground = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // EditUserPanel
            // 
            this.EditUserPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.EditUserPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EditUserPanel.BorderRadius = 26;
            this.EditUserPanel.BorderThickness = 1;
            this.EditUserPanel.Controls.Add(this.CloseEditPanelBtn);
            this.EditUserPanel.Controls.Add(this.SaveuserBtn);
            this.EditUserPanel.Controls.Add(this.RoleComboBox);
            this.EditUserPanel.Controls.Add(this.PhoneTextBox);
            this.EditUserPanel.Controls.Add(this.EmailTextBox);
            this.EditUserPanel.Controls.Add(this.IDTextBox);
            this.EditUserPanel.Controls.Add(this.FullNameTextBox);
            this.EditUserPanel.Controls.Add(this.EditPanelLbl);
            this.EditUserPanel.Location = new System.Drawing.Point(438, 172);
            this.EditUserPanel.Name = "EditUserPanel";
            this.EditUserPanel.Size = new System.Drawing.Size(538, 611);
            this.EditUserPanel.TabIndex = 37;
            // 
            // CloseEditPanelBtn
            // 
            this.CloseEditPanelBtn.Animated = true;
            this.CloseEditPanelBtn.AnimatedGIF = true;
            this.CloseEditPanelBtn.AutoRoundedCorners = true;
            this.CloseEditPanelBtn.BackColor = System.Drawing.Color.Transparent;
            this.CloseEditPanelBtn.BorderRadius = 33;
            this.CloseEditPanelBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseEditPanelBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.CloseEditPanelBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.CloseEditPanelBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.CloseEditPanelBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.CloseEditPanelBtn.FillColor = System.Drawing.Color.Transparent;
            this.CloseEditPanelBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CloseEditPanelBtn.ForeColor = System.Drawing.Color.Transparent;
            this.CloseEditPanelBtn.Image = global::barmaster.Properties.Resources.closeicon1;
            this.CloseEditPanelBtn.ImageSize = new System.Drawing.Size(40, 40);
            this.CloseEditPanelBtn.Location = new System.Drawing.Point(449, 18);
            this.CloseEditPanelBtn.Name = "CloseEditPanelBtn";
            this.CloseEditPanelBtn.PressedColor = System.Drawing.Color.Transparent;
            this.CloseEditPanelBtn.Size = new System.Drawing.Size(70, 68);
            this.CloseEditPanelBtn.TabIndex = 47;
            this.CloseEditPanelBtn.Click += new System.EventHandler(this.CloseEditPanelBtn_Click);
            // 
            // SaveuserBtn
            // 
            this.SaveuserBtn.Animated = true;
            this.SaveuserBtn.BorderRadius = 15;
            this.SaveuserBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SaveuserBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SaveuserBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SaveuserBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SaveuserBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.SaveuserBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveuserBtn.ForeColor = System.Drawing.Color.White;
            this.SaveuserBtn.Location = new System.Drawing.Point(129, 542);
            this.SaveuserBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SaveuserBtn.Name = "SaveuserBtn";
            this.SaveuserBtn.Size = new System.Drawing.Size(280, 48);
            this.SaveuserBtn.TabIndex = 46;
            this.SaveuserBtn.Text = "Save Changes ";
            this.SaveuserBtn.Click += new System.EventHandler(this.SaveuserBtn_Click);
            // 
            // RoleComboBox
            // 
            this.RoleComboBox.BackColor = System.Drawing.Color.Transparent;
            this.RoleComboBox.BorderRadius = 10;
            this.RoleComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.RoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RoleComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RoleComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RoleComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.RoleComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.RoleComboBox.ItemHeight = 30;
            this.RoleComboBox.Items.AddRange(new object[] {
            "Manager\t",
            "Barmen"});
            this.RoleComboBox.Location = new System.Drawing.Point(62, 449);
            this.RoleComboBox.Name = "RoleComboBox";
            this.RoleComboBox.Size = new System.Drawing.Size(402, 36);
            this.RoleComboBox.StartIndex = 0;
            this.RoleComboBox.TabIndex = 45;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Animated = true;
            this.PhoneTextBox.BorderColor = System.Drawing.Color.Gray;
            this.PhoneTextBox.BorderRadius = 15;
            this.PhoneTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PhoneTextBox.DefaultText = "";
            this.PhoneTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.PhoneTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.PhoneTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PhoneTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.PhoneTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PhoneTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PhoneTextBox.ForeColor = System.Drawing.Color.Black;
            this.PhoneTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PhoneTextBox.Location = new System.Drawing.Point(62, 373);
            this.PhoneTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.PlaceholderText = "Phone";
            this.PhoneTextBox.SelectedText = "";
            this.PhoneTextBox.Size = new System.Drawing.Size(402, 55);
            this.PhoneTextBox.TabIndex = 43;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.Animated = true;
            this.EmailTextBox.BorderColor = System.Drawing.Color.Gray;
            this.EmailTextBox.BorderRadius = 15;
            this.EmailTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EmailTextBox.DefaultText = "";
            this.EmailTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.EmailTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.EmailTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.EmailTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.EmailTextBox.ForeColor = System.Drawing.Color.Black;
            this.EmailTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.EmailTextBox.Location = new System.Drawing.Point(62, 288);
            this.EmailTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.PlaceholderText = "Email";
            this.EmailTextBox.SelectedText = "";
            this.EmailTextBox.Size = new System.Drawing.Size(402, 55);
            this.EmailTextBox.TabIndex = 42;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Animated = true;
            this.IDTextBox.BorderColor = System.Drawing.Color.Gray;
            this.IDTextBox.BorderRadius = 15;
            this.IDTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.IDTextBox.DefaultText = "";
            this.IDTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.IDTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.IDTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.IDTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.IDTextBox.Enabled = false;
            this.IDTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.IDTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.IDTextBox.ForeColor = System.Drawing.Color.Black;
            this.IDTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.IDTextBox.Location = new System.Drawing.Point(62, 208);
            this.IDTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.PlaceholderText = "ID";
            this.IDTextBox.ReadOnly = true;
            this.IDTextBox.SelectedText = "";
            this.IDTextBox.Size = new System.Drawing.Size(402, 55);
            this.IDTextBox.TabIndex = 41;
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Animated = true;
            this.FullNameTextBox.BorderColor = System.Drawing.Color.Gray;
            this.FullNameTextBox.BorderRadius = 15;
            this.FullNameTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FullNameTextBox.DefaultText = "";
            this.FullNameTextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.FullNameTextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.FullNameTextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.FullNameTextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.FullNameTextBox.Enabled = false;
            this.FullNameTextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FullNameTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FullNameTextBox.ForeColor = System.Drawing.Color.Black;
            this.FullNameTextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.FullNameTextBox.Location = new System.Drawing.Point(62, 128);
            this.FullNameTextBox.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.PlaceholderText = "Full Name";
            this.FullNameTextBox.ReadOnly = true;
            this.FullNameTextBox.SelectedText = "";
            this.FullNameTextBox.Size = new System.Drawing.Size(402, 55);
            this.FullNameTextBox.TabIndex = 39;
            // 
            // EditPanelLbl
            // 
            this.EditPanelLbl.AutoSize = true;
            this.EditPanelLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditPanelLbl.ForeColor = System.Drawing.Color.SteelBlue;
            this.EditPanelLbl.Location = new System.Drawing.Point(204, 48);
            this.EditPanelLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EditPanelLbl.Name = "EditPanelLbl";
            this.EditPanelLbl.Size = new System.Drawing.Size(126, 30);
            this.EditPanelLbl.TabIndex = 35;
            this.EditPanelLbl.Text = "Edit User ";
            this.EditPanelLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1403, 832);
            this.Controls.Add(this.EditUserPanel);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsersDataGridView);
            this.Controls.Add(this.updateUserBtn);
            this.Controls.Add(this.addUserBtn);
            this.Controls.Add(this.deleteUserBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Users";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.Users_Load);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            this.EditUserPanel.ResumeLayout(false);
            this.EditUserPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button deleteUserBtn;
        private Guna.UI2.WinForms.Guna2Button addUserBtn;
        private Guna.UI2.WinForms.Guna2Button updateUserBtn;
        private Guna.UI2.WinForms.Guna2DataGridView UsersDataGridView;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button returnBtn;
        private Guna.UI2.WinForms.Guna2Panel EditUserPanel;
        private Guna.UI2.WinForms.Guna2Button CloseEditPanelBtn;
        private Guna.UI2.WinForms.Guna2Button SaveuserBtn;
        private Guna.UI2.WinForms.Guna2ComboBox RoleComboBox;
        private Guna.UI2.WinForms.Guna2TextBox PhoneTextBox;
        private Guna.UI2.WinForms.Guna2TextBox EmailTextBox;
        private Guna.UI2.WinForms.Guna2TextBox IDTextBox;
        private Guna.UI2.WinForms.Guna2TextBox FullNameTextBox;
        private System.Windows.Forms.Label EditPanelLbl;
    }
}