using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barmaster
{
    public partial class Loginpage : Form
    {
        public Loginpage()
        {
            InitializeComponent();
        }



        // טעינת המסך עם חיבור למסד הנתונים 
        private void Loginpage_Load(object sender, EventArgs e)
        {
            DataBase.GetOpenConnection();
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.UseSystemPasswordChar = true;
        }



        // פונקציה שמקבלת מחרוזת ומחזירה פונקציה חד כיוונית 
        // פונקציית גיבוב להצפנת הסיסמא SHA256Hash  
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
        public static class Session
        {
            public static string CurrentUserID;
            public static string Role;
        }



        // פונקציית ההרשמה הכוללת בתוכה את כול הבדיקות הרלוונטיות לכול הקלט שנקלט מהמשתמש
        private void SignInButton_Click(object sender, EventArgs e)
        {
            //string email = this.EmailTextBox.Text.Trim();
            //string password = this.PasswordTextBox.Text.Trim();
            //string ID = this.IDTextBox.Text.Trim();

            //if (ID.Length == 0)
            //{
            //    MessageHelper.ShowError("ID is required!");
            //    return;
            //}
            //if (email.Length == 0)
            //{
            //    MessageHelper.ShowError("Email is required!");
            //    return;
            //}
            //if (password.Length == 0)
            //{
            //    MessageHelper.ShowError("Password is required!");
            //    return;
            //}


            //// גיבוב הסיסמה לפני שליחה למסד הנתונים
            //string hashedPassword = ComputeSHA256Hash(password);



            //// שאילתתSQL למניעת sql incetion  והשוואת הנתונים ממסד הנתונים 
            //string query = "SELECT * FROM Users WHERE UserID = @ID AND Email = @Email AND Password = @Password";



            //using (SqlCommand cmd = new SqlCommand(query, DataBase.GetOpenConnection()))
            //{
            //    cmd.Parameters.AddWithValue("@ID", ID);
            //    cmd.Parameters.AddWithValue("@Email", email);
            //    cmd.Parameters.AddWithValue("@Password", hashedPassword); //hashedPassword

            //    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            //    {
            //        DataTable dataTable = new DataTable();
            //        adapter.Fill(dataTable);

            //        if (dataTable.Rows.Count == 0)
            //        {
            //            MessageHelper.ShowError("One of the details you entered is incorrect!");
            //            return;
            //        }

            //        // הצלחה - כניסה למערכת
            //        new HomePage().Show();
            //        this.Hide();
            //    }
            //}
            new HomePage().Show();
            this.Hide();
        }

    }
}

