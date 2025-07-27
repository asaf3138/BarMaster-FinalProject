using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace barmaster
{
    public partial class Users : Form
    {
        private readonly INavigation _navigator;
        public Users()
        {
            InitializeComponent();
            EditUserPanel.Visible = false;
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            new AddUser().Show();
            this.Close();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
            
        }

        private void LoadUsers()
        {
            string sql = "SELECT UserID, FullName, Phone, Email, Role FROM Users"; // שים לב לשמות העמודות
            DataTable dt = DataBase.select(sql);
            if (dt != null)
            {
                UsersDataGridView.DataSource = dt;
            }
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Settings().Show();
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (UsersDataGridView.SelectedRows.Count == 0)
            {
                MessageHelper.ShowWarning("Please select a user to delete.");
                return;
            }

            string role = UsersDataGridView.SelectedRows[0].Cells["Role"].Value?.ToString();
            string userID = UsersDataGridView.SelectedRows[0].Cells["UserID"].Value.ToString();

            if (role == "admin")
            {
                MessageHelper.ShowError("Admin user cannot be deleted.");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string sql = $"DELETE FROM Users WHERE UserID = '{userID}'";
                DataBase.send(sql);
                MessageHelper.ShowInfo("User deleted successfully.");
                LoadUsers(); // רענון טבלה
            }
        }

        private void updateUserBtn_Click(object sender, EventArgs e)
        {
            if (UsersDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = UsersDataGridView.SelectedRows[0];
                string userID = row.Cells["UserID"].Value.ToString();

                if (userID == "1") // חסימת עדכון למשתמש admin
                {
                    MessageHelper.ShowWarning("Cannot update the admin user.");
                    EditUserPanel.Visible = false;
                    return;
                }
                EditUserPanel.Visible = true;

                // מילוי הפאנל
                IDTextBox.Text = userID;
                FullNameTextBox.Text = row.Cells["FullName"].Value.ToString();
                EmailTextBox.Text = row.Cells["Email"].Value.ToString();
                PhoneTextBox.Text = row.Cells["Phone"].Value.ToString();
                RoleComboBox.Text = row.Cells["Role"].Value.ToString();

                EditUserPanel.Visible = true;
                EditUserPanel.BringToFront();
            }

        }

        private void CloseEditPanelBtn_Click(object sender, EventArgs e)
        {
            EditUserPanel.Hide();
        }

        private void SaveuserBtn_Click(object sender, EventArgs e)
        {
            string userID = IDTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string role = RoleComboBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(role))
            {
                MessageHelper.ShowError("Please fill all editable fields.");
                return;
            }

            string updateSql = $@"
                UPDATE Users
                SET Email = '{email}', Phone = '{phone}', Role = '{role}'
                WHERE UserID = '{userID}'
                ";

            DataBase.send(updateSql);
            MessageHelper.Succsessfully("User updated successfully.");

            EditUserPanel.Visible = false;
            LoadUsers(); // רענון הטבלה
        }

    }
}
