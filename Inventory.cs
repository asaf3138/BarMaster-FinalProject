using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace barmaster
{
    public partial class Inventory : Form
    {

        private readonly INavigation _navigator;
        public Inventory()
        {

            InitializeComponent();
            LoadData();
            DGVinventory.CellClick += DGVinventory_CellClick;
            inventorybtn.BackColor = Color.AliceBlue;
            inventorybtn.ForeColor = Color.SteelBlue;

            // מימוש ממשק הניווט INvaigation עם פונקציית navigate 
            _navigator = new NavigationService();
            dashboardBtn.Click += (s, e) => _navigator.Navigate(this, new HomePage());
            inventorybtn.Click += (s, e) => _navigator.Navigate(this, new Inventory());
            customerbtn.Click += (s, e) => _navigator.Navigate(this, new Customers());
            cocktailsBtn.Click += (s, e) => _navigator.Navigate(this, new Cocktails());
            settingsBtn.Click += (s, e) => _navigator.Navigate(this, new Settings());
            salesBtn.Click += (s, e) => _navigator.Navigate(this, new Sales());
        }


        private void ClearForm()
        {
            this.productTextBox.Text = "";
            this.priceTextBox.Text = "";
            this.amountTextBox.Text = "";
        }
        private void LoadData()
        {
            this.panel.Hide();
            string connectionString = "Server=MAYAZARIA\\SQLEXPRESS;Database=Bar Master;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // ננסה לפתוח את החיבור
                    if (connection.State == ConnectionState.Open)
                    {
                        string query = "SELECT * FROM Products"; // שאילתת שליפה

                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);

                        // הגדרות ל-DataGridView
                        DGVinventory.AutoGenerateColumns = true;
                        DGVinventory.DataSource = dataTable;
                        DGVinventory.ColumnHeadersVisible = true;
                        DGVinventory.Refresh();
                        DGVinventory.EnableHeadersVisualStyles = false;
                        DGVinventory.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                        DGVinventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                        DGVinventory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                        DGVinventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        // לחיצה על כפתור המחיקה Delete
        private void deleteButton_Click(object sender, EventArgs e)
        {
            typeDropDown.Items.Insert(0, "Type");
            typeDropDown.SelectedIndex = 0;
            panel.Visible = true;
            label6.Text = "Delete Product";
            button.Text = "Delete Product";
            this.priceTextBox.Enabled = false;
            this.typeDropDown.Enabled = false;
            this.amountTextBox.Enabled = false;
            button.FillColor = Color.Crimson;
            this.panel.BorderColor = Color.Crimson;
            this.label6.ForeColor = Color.Crimson;
            this.panel.BringToFront();

        }


        // לחיצה על כפתור ההוספה Add
        private void addButton_Click(object sender, EventArgs e)
        {
            ClearForm();
            typeDropDown.SelectedIndex = 0;
            this.priceTextBox.Enabled = true;
            this.amountTextBox.Enabled = true;
            this.typeDropDown.Enabled = true;
            this.priceTextBox.Enabled = true;
            panel.Visible = true;
            label6.Text = "Add Product";
            button.Text = "Add Product";
            button.FillColor = Color.LightGreen;
            this.panel.BorderColor = Color.LightGreen;
            this.label6.ForeColor = Color.LightGreen;
            this.panel.BringToFront();


        }


        // לחיצה על כפתור העדכון Update 
        private void updateButton_Click(object sender, EventArgs e)
        {
            typeDropDown.SelectedIndex = 0;
            this.priceTextBox.Enabled = true;
            this.amountTextBox.Enabled = true;
            this.typeDropDown.Enabled = true;
            this.priceTextBox.Enabled = true;
            panel.Visible = true;
            label6.Text = "Update Product";
            button.Text = "Update Product";
            button.FillColor = Color.SteelBlue;
            this.panel.BorderColor = Color.SteelBlue;
            this.label6.ForeColor = Color.SteelBlue;
            this.panel.BringToFront();
        }


        // פונקציה שמטפלת במקרה בו האפליקציה נסגרת
        private void InventoryManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void button_Click(object sender, EventArgs e)
        {
            string productName = productTextBox.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageHelper.ShowWarning("Product Name is required!");
                return;
            }

            if (button.Text.Contains("Add"))
            {
                AddProduct(productName);
            }
            else if (button.Text.Contains("Update"))
            {
                UpdateProduct(productName);
            }
            else if (button.Text.Contains("Delete"))
            {
                DeleteProduct(productName);
            }
        }

        // --------------------------- פונקציה להוספת מוצר ---------------------------
        private void AddProduct(string productName)
        {
            string amountStr = amountTextBox.Text.Trim();
            string priceStr = priceTextBox.Text.Trim();
            string category = typeDropDown.Text.Trim();

            if (string.IsNullOrEmpty(amountStr) || string.IsNullOrEmpty(priceStr) || category == "Type")
            {
                MessageHelper.ShowWarning("All fields are required!");
                return;
            }

            if (!int.TryParse(amountStr, out int amount) || !double.TryParse(priceStr, out double price))
            {
                MessageHelper.ShowWarning("Amount must be an integer and Price must be a number!");
                return;
            }

            if (amount <= 0 || price <= 0)
            {
                MessageHelper.ShowWarning("Amount and Price must be positive numbers!");
                return;
            }

            string checkQuery = $"SELECT COUNT(*) FROM Products WHERE Name='{productName}'";
            DataTable table = DataBase.select(checkQuery);

            if (table != null && table.Rows.Count > 0 && Convert.ToInt32(table.Rows[0][0]) > 0)
            {
                MessageHelper.ShowError("Product already exists!");
                return;
            }

            string sql = $"INSERT INTO Products (Name, Amount, Price, Category) VALUES ('{productName}', {amount}, {price}, '{category}')";
            DataBase.send(sql);
            MessageHelper.ShowInfo("Product added successfully!");

            LoadData();
            ClosePanelBtn_Click(null, null);
            ClearForm();
        }

        // --------------------------- פונקציה לעדכון מוצר ---------------------------
        private void UpdateProduct(string productName)
        {
            string amountStr = amountTextBox.Text.Trim();
            string priceStr = priceTextBox.Text.Trim();
            string category = typeDropDown.Text.Trim();

            if (string.IsNullOrEmpty(amountStr) || string.IsNullOrEmpty(priceStr) || category == "Type")
            {
                MessageHelper.ShowWarning("All fields are required!");
                return;
            }

            if (!int.TryParse(amountStr, out int amount) || !double.TryParse(priceStr, out double price))
            {
                MessageHelper.ShowWarning("Amount must be an integer and Price must be a number!");
                return;
            }

            if (amount <= 0 || price <= 0)
            {
                MessageHelper.ShowWarning("Amount and Price must be positive numbers!");
                return;
            }

            string checkQuery = $"SELECT COUNT(*) FROM Products WHERE Name='{productName}'";
            DataTable table = DataBase.select(checkQuery);

            if (table == null || table.Rows.Count == 0 || Convert.ToInt32(table.Rows[0][0]) == 0)
            {
                MessageHelper.ShowError("Product not found!");
                return;
            }

            string sql = $"UPDATE Products SET Amount = {amount}, Price = {price}, Category = '{category}' WHERE Name = '{productName}'";
            DataBase.send(sql);
            MessageHelper.ShowInfo("Product updated successfully!");

            LoadData();
            ClosePanelBtn_Click(null, null);
            ClearForm();
        }

        // --------------------------- פונקציה למחיקת מוצר ---------------------------
        private void DeleteProduct(string productName)
        {
            DialogResult result = MessageHelper.ShowQuestion("Are you sure you want to delete this product?");
            if (result != DialogResult.Yes)
                return;

            string checkQuery = $"SELECT COUNT(*) FROM Products WHERE Name='{productName}'";
            DataTable table = DataBase.select(checkQuery);

            if (table == null || table.Rows.Count == 0 || Convert.ToInt32(table.Rows[0][0]) == 0)
            {
                MessageHelper.ShowError("Product not found!");
                return;
            }

            string sql = $"DELETE FROM Products WHERE Name='{productName}'";
            DataBase.send(sql);
            MessageHelper.ShowQuestion("Product deleted successfully!");

            LoadData();
            ClosePanelBtn_Click(null, null);
            ClearForm();
        
        }


        // פונקציית לחיפוש המוצרים ב Search Bar
        private void SearchProduct_TextChanged(object sender, EventArgs e)
        {
            string searchText = SearchProduct.Text.Trim();

            string connectionString = "Server=MAYAZARIA\\SQLEXPRESS;Database=Bar Master;Integrated Security=True;";
            string query;

            if (string.IsNullOrEmpty(searchText))
            {
                query = "SELECT * FROM Products"; // אם אין טקסט - נטען הכול
            }
            else
            {
                query = $"SELECT * FROM Products WHERE Name LIKE '{searchText}%'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                DGVinventory.DataSource = dataTable;
            }
        }

        private void DGVinventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = DGVinventory.Rows[e.RowIndex];

                // מילוי הטופס מהשורה שנבחרה
                productTextBox.Text = row.Cells["Name"].Value.ToString();
                amountTextBox.Text = row.Cells["Amount"].Value.ToString();
                priceTextBox.Text = row.Cells["Price"].Value.ToString();
                typeDropDown.Text = row.Cells["Category"].Value.ToString();
            }
        }


        private void ClosePanelBtn_Click(object sender, EventArgs e)
        {
            this.DGVinventory.Visible = true;
            this.panel.Visible = false;
            this.addButton.Visible = true;
            this.updateButton.Visible = true;
            this.deleteButton.Visible = true;
        }
    }
}   


