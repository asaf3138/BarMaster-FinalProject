using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace barmaster
{
    public partial class Customers : Form
    {
        private readonly INavigation _navigator;

        public Customers()
        {
            InitializeComponent();
            LoadCustomers();
            DGVcustomers.CellClick += DGVcustomers_CellClick;


            customerbtn.BackColor = Color.AliceBlue;
            customerbtn.ForeColor = Color.SteelBlue;

            // ניווט
            _navigator = new NavigationService();
            dashboardBtn.Click += (s, e) => _navigator.Navigate(this, new HomePage());
            inventorybtn.Click += (s, e) => _navigator.Navigate(this, new Inventory());
            customerbtn.Click += (s, e) => _navigator.Navigate(this, new Customers());
            cocktailsBtn.Click += (s, e) => _navigator.Navigate(this, new Cocktails());
            settingsBtn.Click += (s, e) => _navigator.Navigate(this, new Settings());
            salesBtn.Click += (s, e) => _navigator.Navigate(this, new Sales());
        }



        // טעינת כל הלקוחות
        private void LoadCustomers()
        {

            this.CustomerPanel.Hide(); // מסתיר את הפאנל בתחילה
            string connectionString = "Server=MAYAZARIA\\SQLEXPRESS;Database=Bar Master;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        string query = "SELECT * FROM Customers";
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        // הגדרות ל-DataGridView
                        DGVcustomers.AutoGenerateColumns = true;
                        DGVcustomers.DataSource = dataTable;
                        DGVcustomers.ColumnHeadersVisible = true;
                        DGVcustomers.Refresh();
                        DGVcustomers.EnableHeadersVisualStyles = false;
                        DGVcustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                        DGVcustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        DGVcustomers.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                        DGVcustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else
                    {
                        MessageBox.Show("חיבור לשרת נכשל!", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("שגיאת SQL:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("שגיאה כללית:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ניקוי הטופס
        private void ClearForm()
        {
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            IDTextBox.Text = "";
            EmailTextBox.Text = "";
            PhoneTextBox.Text = "";
            PurchaseAmountTextBox.Text = "";
            StatusComboBox.SelectedIndex = -1;
        }



        // לחיצה על כפתור הלחיצה Delete 
        private void deleteCustomerBtn_Click(object sender, EventArgs e)
        {
            CustomerPanel.Visible = true;
            PanelLbl.Text = "Delete Customer";
            SaveCustomerBtn.Text = "Delete Customer";
            this.EmailTextBox.Enabled = false;
            this.PhoneTextBox.Enabled = false;
            this.PurchaseAmountTextBox.Enabled = false;
            this.StatusComboBox.Enabled = false;
            SaveCustomerBtn.FillColor = Color.Crimson;
            this.CustomerPanel.BorderColor = Color.Crimson;
            this.PanelLbl.ForeColor = Color.Crimson;
            this.CustomerPanel.BringToFront();
        }



        // לחיצה על כפתור העדכון Update 
        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            CustomerPanel.Visible = true;
            this.PurchaseAmountTextBox.Enabled = true;
            this.FirstNameTextBox.Enabled = true;
            this.LastNameTextBox.Enabled = true;
            this.IDTextBox.Enabled = true;
            this.EmailTextBox.Enabled = true;
            this.PhoneTextBox.Enabled = true;
            this.StatusComboBox.Enabled = true;
            PanelLbl.Text = "Update Customer";
            SaveCustomerBtn.Text = "Update  Customer";
            SaveCustomerBtn.FillColor = Color.SteelBlue;
            this.CustomerPanel.BorderColor = Color.SteelBlue;
            this.PanelLbl.ForeColor = Color.SteelBlue;
            this.CustomerPanel.BringToFront();
        }


        // לחיצה על כפתור ההוספה Add 
        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            ClearForm();
            CustomerPanel.Visible = true;
            this.FirstNameTextBox.Enabled = true;
            this.LastNameTextBox.Enabled = true;
            this.IDTextBox.Enabled = true;
            this.EmailTextBox.Enabled = true;
            this.PhoneTextBox.Enabled = true;
            this.StatusComboBox.Enabled = true;
            this.PurchaseAmountTextBox.Enabled = true;
            PanelLbl.Text = "Add Customer";
            SaveCustomerBtn.Text = "Add  Customer";
            SaveCustomerBtn.FillColor = Color.LightGreen;
            this.CustomerPanel.BorderColor = Color.LightGreen;
            this.PanelLbl.ForeColor = Color.LightGreen;
            this.CustomerPanel.BringToFront();
        }


        // לחיצה על כפתור סגירת הפאנל 
        private void CloseCustomerPanelBtn_Click(object sender, EventArgs e)
        {
            this.DGVcustomers.Visible = true;
            this.CustomerPanel.Visible = false;
            this.addCustomerBtn.Visible = true;
            this.updateCustomerBtn.Visible = true;  
            this.deleteCustomerBtn.Visible = true;
            ClearForm();
        }

        private void ClosePanel()
        {
            this.CustomerPanel.Visible = false;
            this.DGVcustomers.Visible = true;
            this.addCustomerBtn.Visible = true;
            this.updateCustomerBtn.Visible = true;
            this.deleteCustomerBtn.Visible = true;
            ClearForm();
        }



        // פונקציה שמטפלת במקרה בו האפליקציה נסגרת
        private void Customers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }




        // --------------------------- פונקציה להוספת לקוח ---------------------------
        private void AddCustomer(string firstName, string lastName, string idNumber, string email, string phone, string purchaseCountStr, string status)
        {
            // בדיקה שהשדות מלאים
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                string.IsNullOrEmpty(idNumber) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(status))
            {
                MessageHelper.ShowWarning("All fields are required!");
                return;
            }

            // בדיקה שהכמות היא מספר
            if (!int.TryParse(purchaseCountStr, out int purchaseCount))
            {
                MessageHelper.ShowWarning("Purchase amount must be a number!");
                return;
            }

            // בדיקה אם הלקוח כבר קיים
            string checkQuery = $"SELECT COUNT(*) FROM Customers WHERE First_Name='{firstName}' AND Last_Name='{lastName}'";
            DataTable table = DataBase.select(checkQuery);

            if (table != null && table.Rows.Count > 0 && Convert.ToInt32(table.Rows[0][0]) > 0)
            {
                MessageHelper.ShowError("Customer already exists!");
                return;
            }

            // הוספת לקוח
            string sql = $"INSERT INTO Customers (First_Name, Last_Name, IDNumber, Phone, Email, PurchaseCount, Status) " +
                         $"VALUES ('{firstName}', '{lastName}', '{idNumber}', '{phone}', '{email}', {purchaseCount}, '{status}')";
            DataBase.send(sql);
            MessageHelper.ShowInfo("Customer added successfully!");

            LoadCustomers();    // טעינה מחדש
            ClosePanel();       // סגירת הפאנל
        }

        // --------------------------- פונקציה לעדכון לקוח ---------------------------
        private void UpdateCustomer(string firstName, string lastName, string idNumber, string email, string phone, string purchaseCountStr, string status)
        {
            // בדיקה שהשדות קיימים
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageHelper.ShowWarning("First Name and Last Name are required!");
                return;
            }

            if (!int.TryParse(purchaseCountStr, out int purchaseCount))
            {
                MessageHelper.ShowWarning("Purchase amount must be a number!");
                return;
            }

            // בדיקה אם הלקוח קיים
            string checkQuery = $"SELECT COUNT(*) FROM Customers WHERE First_Name='{firstName}' AND Last_Name='{lastName}'";
            DataTable table = DataBase.select(checkQuery);

            if (table == null || table.Rows.Count == 0 || Convert.ToInt32(table.Rows[0][0]) == 0)
            {
                MessageHelper.ShowError("Customer not found!");
                return;
            }

            // עדכון פרטי לקוח
            string sql = $"UPDATE Customers SET IDNumber='{idNumber}', Phone='{phone}', Email='{email}', " +
                         $"PurchaseCount={purchaseCount}, Status='{status}' WHERE First_Name='{firstName}' AND Last_Name='{lastName}'";
            DataBase.send(sql);
            MessageHelper.ShowInfo("Customer updated successfully!");

            LoadCustomers();    // טעינה מחדש
            ClosePanel();       // סגירת הפאנל
        }

        // --------------------------- פונקציה למחיקת לקוח ---------------------------
        private void DeleteCustomer(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                MessageHelper.ShowWarning("First Name and Last Name are required!");
                return;
            }

            DialogResult result = MessageHelper.ShowQuestion("Are you sure you want to delete this customer?");
            if (result != DialogResult.Yes)
                return;

            // בדיקה אם קיים
            string checkQuery = $"SELECT COUNT(*) FROM Customers WHERE First_Name='{firstName}' AND Last_Name='{lastName}'";
            DataTable table = DataBase.select(checkQuery);

            if (table == null || table.Rows.Count == 0 || Convert.ToInt32(table.Rows[0][0]) == 0)
            {
                MessageHelper.ShowError("Customer not found!");
                return;
            }

            // מחיקה
            string sql = $"DELETE FROM Customers WHERE First_Name='{firstName}' AND Last_Name='{lastName}'";
            DataBase.send(sql);
            MessageHelper.ShowInfo("Customer deleted successfully!");

            LoadCustomers();    // טעינה מחדש
            ClosePanel();       // סגירת הפאנל
        }










        // חיפוש לקוחות בזמן אמת
        private void FullNameSearchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = FirstNameSearchBar.Text.Trim();
            string connectionString = "Server=MAYAZARIA\\SQLEXPRESS;Database=Bar Master;Integrated Security=True;";

            string query = "SELECT * FROM Customers";

            if (!string.IsNullOrEmpty(searchText))
            {
                query = "SELECT * FROM Customers WHERE LOWER(First_Name) LIKE @search OR LOWER(Last_Name) LIKE @search";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (!string.IsNullOrEmpty(searchText))
                {
                    command.Parameters.AddWithValue("@search", searchText.ToLower() + "%");
                }

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DGVcustomers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error while searching:\n" + ex.Message);
                }
            }
        }



        // פונקציה לביצוע הוספה/עדכון/מחיקה
        private void SaveCustomerBtn_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTextBox.Text.Trim();
            string lastName = LastNameTextBox.Text.Trim();
            string idNumber = IDTextBox.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string phone = PhoneTextBox.Text.Trim();
            string purchaseCountStr = PurchaseAmountTextBox.Text.Trim();
            string status = StatusComboBox.Text.Trim();


            if (string.IsNullOrEmpty(firstName))
            {
                MessageHelper.ShowWarning("First Name is required!");
                return;
            }


            if (string.IsNullOrEmpty(lastName))
            {
                MessageHelper.ShowWarning("LastName Name is required!");
                return;
            }



            if (string.IsNullOrEmpty(idNumber))
            {
                MessageHelper.ShowWarning("Id is required!");
                return;
            }

            if (SaveCustomerBtn.Text.Contains("Add"))
            {
                AddCustomer(firstName, lastName, idNumber, email, phone, purchaseCountStr, status);
            }
            else if (SaveCustomerBtn.Text.Contains("Update"))
            {
                UpdateCustomer(firstName, lastName, idNumber, email, phone, purchaseCountStr, status);
            }
            else if (SaveCustomerBtn.Text.Contains("Delete"))
            {
                DeleteCustomer(firstName, lastName);
            }


            if (string.IsNullOrEmpty(email))
            {
                MessageHelper.ShowWarning("Email is required!");
                return;
            }


            if (string.IsNullOrEmpty(phone))
            {
                MessageHelper.ShowWarning("Phone Is required!");
                return;
            }
        

        }

        private void FirstNameSearchBar_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = FirstNameSearchBar.Text.Trim();
            string connectionString = "Server=MAYAZARIA\\SQLEXPRESS;Database=Bar Master;Integrated Security=True;";
            string query;

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT * FROM Customers"; // אם אין טקסט - טען את כל הלקוחות
            }
            else
            {
                query = $"SELECT * FROM Customers WHERE First_Name LIKE '{searchText}%'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                try
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    DGVcustomers.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Error while searching:\n" + ex.Message);
                }
            }
        }

        private void DGVcustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVcustomers.Rows[e.RowIndex];

                // מילוי הטופס
                FirstNameTextBox.Text = row.Cells["First_Name"].Value.ToString();
                LastNameTextBox.Text = row.Cells["Last_Name"].Value.ToString();
                IDTextBox.Text = row.Cells["IDNumber"].Value.ToString();
                EmailTextBox.Text = row.Cells["Email"].Value.ToString();
                PhoneTextBox.Text = row.Cells["Phone"].Value.ToString();
                PurchaseAmountTextBox.Text = row.Cells["PurchaseCount"].Value.ToString();
                StatusComboBox.Text = row.Cells["Status"].Value.ToString();
            }
        }


    }
}
