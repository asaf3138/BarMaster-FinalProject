using System;
using System.Data;
using System.Windows.Forms;

namespace barmaster
{
    public partial class PurchaseForm : Form
    {
        private readonly string _cocktailName;
        private readonly double _price;

        public PurchaseForm(string cocktailName, double price)
        {
            InitializeComponent();
            _cocktailName = cocktailName;
            _price = price;
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            cocktailNameLabel.Text = "Product: " + _cocktailName;
            priceLabel.Text = "Price: " + _price.ToString("0.00") + " $";
        }

        private void LoadCustomers()
        {
            string sql = "SELECT ID, First_Name + ' ' + Last_Name AS Name FROM Customers";
            DataTable dt = DataBase.select(sql);
            if (dt == null || dt.Rows.Count == 0) return;

            customerComboBox.DisplayMember = "Name";
            customerComboBox.ValueMember = "ID";
            customerComboBox.DataSource = dt;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (customerComboBox.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Please select a customer.");
                return;
            }

            int customerId = (int)customerComboBox.SelectedValue;
            int amount = (int)amountSelector.Value;

            if (amount <= 0)
            {
                MessageHelper.ShowWarning("Please select a valid quantity.");
                return;
            }

            // שלב בדיקה: מספיק מלאי לכל מרכיב?
            string ingredientSql = $"SELECT Ingredients FROM Cocktails WHERE Name = N'{_cocktailName}'";
            DataTable dt = DataBase.select(ingredientSql);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageHelper.ShowError("Ingredients not found for this cocktail.");
                return;
            }

            string[] ingredients = dt.Rows[0]["Ingredients"].ToString().Split(',');

            foreach (string item in ingredients)
            {
                string[] split = item.Split('=');
                if (split.Length != 2) continue;

                string productName = split[0];
                if (!double.TryParse(split[1], out double requiredPerUnit)) continue;

                double totalRequired = requiredPerUnit * amount;

                string stockSql = $"SELECT Amount FROM Products WHERE Name = N'{productName}'";
                DataTable stockDt = DataBase.select(stockSql);

                if (stockDt == null || stockDt.Rows.Count == 0)
                {
                    MessageHelper.ShowWarning($"Product '{productName}' does not exist in inventory.");
                    return;
                }

                double currentAmount = Convert.ToDouble(stockDt.Rows[0]["Amount"]);
                if (currentAmount < totalRequired)
                {
                    MessageHelper.ShowWarning($"Not enough stock for '{productName}'. Needed: {totalRequired}, Available: {currentAmount}");
                    return;
                }
            }

            // שלב 1: הכנסת רכישה
            string insertSql = $@"
                INSERT INTO Sales (CustomerID, CocktailName, Price, Amount)
                VALUES ({customerId}, N'{_cocktailName}', '{_price}', '{amount}')
                ";
            DataBase.send(insertSql);

            // שלב 2: עדכון כמות רכישות
            string updateCountSql = $@"
                UPDATE Customers
                SET PurchaseCount = PurchaseCount + 1
                WHERE ID = {customerId}
                ";
            DataBase.send(updateCountSql);

            // שלב 3: עדכון סטטוס
            string statusUpdateSql = $@"
                UPDATE Customers
                SET Status = CASE
                WHEN PurchaseCount >= 36 THEN 'Platinum'
                WHEN PurchaseCount >= 16 THEN 'Gold'
                ELSE 'Silver'
                END
                WHERE ID = {customerId}
                ";
            DataBase.send(statusUpdateSql);

            // שלב 4: הורדה מהמלאי
            foreach (string item in ingredients)
            {
                string[] split = item.Split('=');
                if (split.Length != 2) continue;

                string productName = split[0];
                if (!double.TryParse(split[1], out double requiredPerUnit)) continue;

                double totalRequired = requiredPerUnit * amount;

                string updateInventorySql = $@"
            UPDATE Products
            SET Amount = Amount - {totalRequired}
            WHERE Name = N'{productName}'
        ";
                DataBase.send(updateInventorySql);
            }

            MessageHelper.ShowInfo("Purchase recorded and inventory updated!");
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageHelper.ShowQuestion("Are you sure you want to cancel?");
            if (result == DialogResult.Yes)
            { 
                this.Close();
            }
        }
    }
}
