namespace barmaster
{
    partial class PurchaseForm
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
            this.PurchaseLbl = new System.Windows.Forms.Label();
            this.customerComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.amountSelector = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.cancelBtn = new Guna.UI2.WinForms.Guna2Button();
            this.confirmBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.cocktailNameLabel = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // PurchaseLbl
            // 
            this.PurchaseLbl.AutoSize = true;
            this.PurchaseLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PurchaseLbl.Location = new System.Drawing.Point(50, 24);
            this.PurchaseLbl.Name = "PurchaseLbl";
            this.PurchaseLbl.Size = new System.Drawing.Size(381, 46);
            this.PurchaseLbl.TabIndex = 0;
            this.PurchaseLbl.Text = "Purchase Summary ";
            // 
            // customerComboBox
            // 
            this.customerComboBox.BackColor = System.Drawing.Color.Transparent;
            this.customerComboBox.BorderRadius = 15;
            this.customerComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.customerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.customerComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.customerComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.customerComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.customerComboBox.ItemHeight = 30;
            this.customerComboBox.Location = new System.Drawing.Point(40, 154);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(300, 36);
            this.customerComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(35, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Customer:";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.Controls.Add(this.amountSelector);
            this.guna2Panel1.Controls.Add(this.cancelBtn);
            this.guna2Panel1.Controls.Add(this.confirmBtn);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.priceLabel);
            this.guna2Panel1.Controls.Add(this.cocktailNameLabel);
            this.guna2Panel1.Controls.Add(this.PurchaseLbl);
            this.guna2Panel1.Controls.Add(this.customerComboBox);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(208, 27);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(498, 648);
            this.guna2Panel1.TabIndex = 3;
            // 
            // amountSelector
            // 
            this.amountSelector.BackColor = System.Drawing.Color.Transparent;
            this.amountSelector.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.amountSelector.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.amountSelector.Location = new System.Drawing.Point(162, 372);
            this.amountSelector.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.amountSelector.Name = "amountSelector";
            this.amountSelector.Size = new System.Drawing.Size(143, 60);
            this.amountSelector.TabIndex = 46;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelBtn.Animated = true;
            this.cancelBtn.BackColor = System.Drawing.Color.White;
            this.cancelBtn.BorderColor = System.Drawing.Color.Silver;
            this.cancelBtn.BorderRadius = 15;
            this.cancelBtn.BorderThickness = 1;
            this.cancelBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cancelBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cancelBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cancelBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cancelBtn.FillColor = System.Drawing.Color.White;
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cancelBtn.ForeColor = System.Drawing.Color.Black;
            this.cancelBtn.Location = new System.Drawing.Point(40, 515);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.ShadowDecoration.BorderRadius = 15;
            this.cancelBtn.Size = new System.Drawing.Size(143, 48);
            this.cancelBtn.TabIndex = 45;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmBtn.Animated = true;
            this.confirmBtn.BorderRadius = 15;
            this.confirmBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.confirmBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.confirmBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.confirmBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.confirmBtn.FillColor = System.Drawing.Color.SteelBlue;
            this.confirmBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.confirmBtn.ForeColor = System.Drawing.Color.White;
            this.confirmBtn.Location = new System.Drawing.Point(223, 515);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(226, 48);
            this.confirmBtn.TabIndex = 44;
            this.confirmBtn.Text = "Confirm Purchase";
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label4.Location = new System.Drawing.Point(44, 396);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Quantity : ";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.priceLabel.Location = new System.Drawing.Point(44, 299);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(74, 26);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price :";
            // 
            // cocktailNameLabel
            // 
            this.cocktailNameLabel.AutoSize = true;
            this.cocktailNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cocktailNameLabel.Location = new System.Drawing.Point(44, 215);
            this.cocktailNameLabel.Name = "cocktailNameLabel";
            this.cocktailNameLabel.Size = new System.Drawing.Size(99, 26);
            this.cocktailNameLabel.TabIndex = 3;
            this.cocktailNameLabel.Text = "Product :\r\n";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(962, 802);
            this.Controls.Add(this.guna2Panel1);
            this.MaximizeBox = false;
            this.Name = "PurchaseForm";
            this.Text = "PurchaseForm";
            this.Load += new System.EventHandler(this.PurchaseForm_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PurchaseLbl;
        private Guna.UI2.WinForms.Guna2ComboBox customerComboBox;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label cocktailNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label priceLabel;
        private Guna.UI2.WinForms.Guna2Button cancelBtn;
        private Guna.UI2.WinForms.Guna2Button confirmBtn;
        private Guna.UI2.WinForms.Guna2NumericUpDown amountSelector;
    }
}