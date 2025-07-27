using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static barmaster.Loginpage;

namespace barmaster
{
    public partial class Settings : Form
    {
        private readonly INavigation _navigator;
        public Settings()
        {
            InitializeComponent();
            ChangePasswordPanel.Visible = false;
            settingsBtn.BackColor = Color.AliceBlue;
            settingsBtn.ForeColor = Color.SteelBlue;

            // מימוש ממשק הניווט INvaigation עם פונקציית navigate 
            _navigator = new NavigationService();
            dashboardBtn.Click += (s, e) => _navigator.Navigate(this, new HomePage());
            inventorybtn.Click += (s, e) => _navigator.Navigate(this, new Inventory());
            customerbtn.Click += (s, e) => _navigator.Navigate(this, new Customers());
            cocktailsBtn.Click += (s, e) => _navigator.Navigate(this, new Cocktails());
            settingsBtn.Click += (s, e) => _navigator.Navigate(this, new Settings());
            salesBtn.Click += (s, e) => _navigator.Navigate(this, new Sales());
        }

        private void usersBtn_Click(object sender, EventArgs e)
        {
            new Users().Show();
            this.Close();
        }

        private void ClosePanelBtn_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Hide();
        }

        private void ChangePasswordbtn_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Visible = true;
            ChangePasswordPanel.BringToFront();

        }

        private void SavePasswordBtn_Click(object sender, EventArgs e)
        {
            string currentPassword = CurrentPasswordTextBox.Text.Trim();
            string newPassword = NewPasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();

            if (newPassword.Length < 8 || !newPassword.Any(char.IsDigit) || !newPassword.Any(char.IsLetter))
            {
                MessageHelper.ShowError("Password must be at least 8 characters, with letters and digits.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageHelper.ShowError("New password and confirmation do not match.");
                return;
            }

            string hashedCurrent = ComputeSHA256Hash(currentPassword);
            string hashedNew = ComputeSHA256Hash(newPassword);

            string sql = $"SELECT * FROM Users WHERE UserID = '{Session.CurrentUserID}' AND Password = '{hashedCurrent}'";
            DataTable dt = DataBase.select(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Current password is incorrect.");
                return;
            }

            string updateSql = $"UPDATE Users SET Password = '{hashedNew}' WHERE UserID = '{Session.CurrentUserID}'";
            DataBase.send(updateSql);

            MessageHelper.Succsessfully("Password changed successfully!");
            this.Close();
        }
        public String ComputeSHA256Hash(String input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {

                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));


                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageHelper.ShowQuestion("Are you sure you want to log out ?", "Log Out");
            if (result != DialogResult.Yes)
            {
                //new Loginpage.Show();
                //this.Close();
            }
                return;
        }
    }
}
