using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barmaster
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }


        //פונקציה שמקבלת מחרוזת ומחזירה את המחרוזת בפונקציה חד כיוונית
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



        // הוספת משתמש חדש למערכת 
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string fullName = this.FullName.Text.Trim();
            string phone = this.PhoneNumber.Text.Trim();
            string email = this.Email.Text.Trim();
            string ID = this.ID.Text.Trim();
            string password = this.Password.Text.Trim();
            string confirmPassword = this.confirmPassword.Text.Trim();
            string role = this.roleComboBox.Text.Trim(); // שדה חדש

            if (fullName.Length < 5 /*Minimum Length*/ || fullName.Contains(" ") == false)
            {
                MessageHelper.ShowError("Invalid Name! Please Enter your full name");
                return;
            }
            if (phone.Length != 10 || phone.StartsWith("05") == false || phone.All(char.IsDigit) == false)
            {
                MessageHelper.ShowError("Invalid Phone Number! Please Enter your moblie Number");
                return;
            }
            if (ID.Length != 9 || ID.All(char.IsDigit) == false)
            {
                MessageHelper.ShowError("Invalid ID Number! Please Enter ID");
                return;
            }
            if (email.Length == 0 || Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") == false)
            {
                MessageHelper.ShowError("Invalid Email! Please Enter your Email");
                return;
            }
            if (password.Length < 8 || password.Any(char.IsDigit) == false || password.Any(char.IsLetter) == false)
            {
                MessageHelper.ShowError("Invalid Password ! The password must contain at least 8 characters, at least one of which is a letter and one of which is a number.");
                return;
            }
            if (password != confirmPassword)
            {
                MessageHelper.ShowError("Confirm Password should be equal to password");
                return;
            }
       


            



            // בדיקת ייחודיות
            string query = $"SELECT * FROM Users WHERE UserID = '{ID}'";
            DataTable dt = DataBase.select(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                MessageHelper.ShowWarning("This user has already registered with this ID !");
                return;
            }

            // הצפנה
            password = ComputeSHA256Hash(password);

            // הכנסת משתמש
            query = $@"
                    INSERT INTO Users (UserID, FullName, Phone, Email, Password, Role)
                    VALUES ('{ID}', '{fullName}', '{phone}', '{email}', '{password}', '{role}')
                    ";
            DataBase.send(query);

            MessageHelper.Succsessfully("User registered successfully!");
            new HomePage().Show();
            this.Hide();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            //הסתרת התווים בסיסמה
            this.Password.PasswordChar = '*';
            this.Password.UseSystemPasswordChar = true;
            this.confirmPassword.PasswordChar = '*';
            this.confirmPassword.UseSystemPasswordChar = true;
        }
    }
}
