using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.Interfaces;
using Guna.Charts.WinForms;

namespace barmaster
{
    public partial class Sales : Form
    {
        private readonly INavigation _navigator;
        string ID = "";
        public Sales()
        {

            InitializeComponent();

            salesBtn.BackColor = Color.AliceBlue;
            salesBtn.ForeColor = Color.SteelBlue;

            // מימוש ממשק הניווט INvaigation עם פונקציית navigate 
            _navigator = new NavigationService();
            dashboardBtn.Click += (s, e) => _navigator.Navigate(this, new HomePage());
            inventorybtn.Click += (s, e) => _navigator.Navigate(this, new Inventory());
            customerbtn.Click += (s, e) => _navigator.Navigate(this, new Customers());
            cocktailsBtn.Click += (s, e) => _navigator.Navigate(this, new Cocktails());
            settingsBtn.Click += (s, e) => _navigator.Navigate(this, new Settings());
            salesBtn.Click += (s, e) => _navigator.Navigate(this, new Sales());
            LoadSalesTable();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            LoadSalesChart();
            LoadTotalSalesSummary();
            LoadMonthlySalesChart();
        }

        private void LoadTotalSalesSummary()
        {
            string sql = @"
            SELECT 
            SUM(CAST(Amount AS INT)) AS TotalUnits, 
            SUM(CAST(Amount AS FLOAT) * CAST(Price AS FLOAT)) AS TotalRevenue
            FROM Sales
            ";

            DataTable dt = DataBase.select(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                // יחידות
                var units = dt.Rows[0]["TotalUnits"] != DBNull.Value ? dt.Rows[0]["TotalUnits"].ToString() : "0";
                totalUnitsLabel.Text = $"Total Units Sold: {units}";

                // הכנסות
                double revenue = dt.Rows[0]["TotalRevenue"] != DBNull.Value ? Convert.ToDouble(dt.Rows[0]["TotalRevenue"]) : 0.0;
                totalRevenueLabel.Text = $"Total Revenue: {revenue:0.00} $";
            }
            else
            {
                totalUnitsLabel.Text = "Total Units Sold: 0";
                totalRevenueLabel.Text = "Total Revenue: 0.00 $";
            }
        }



        private void LoadSalesTable()
        {
            string sql = "SELECT ID, CustomerID, CocktailName, Price, Amount, CreatedAt FROM Sales ORDER BY CreatedAt DESC";
            DataTable dt = DataBase.select(sql);

            if (dt != null && dt.Rows.Count > 0)
            {
                SalesDataGridView.DataSource = dt;
            }
            else
            {
                MessageHelper.ShowInfo("No sales records found.");
            }
        }


        private void LoadSalesChart()
        {
            string sql = @"
                SELECT CocktailName, SUM(CAST(Amount AS INT)) AS TotalAmount
                FROM Sales
                GROUP BY CocktailName
    ";

            DataTable dt = DataBase.select(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageHelper.ShowInfo("No sales data available.");
                return;
            }

            // יצירת dataset חדש
            GunaBarDataset dataset = new GunaBarDataset();
            dataset.Label = "Total Sales";

            // טעינת הנתונים
            foreach (DataRow row in dt.Rows)
            {
                string cocktailName = row["CocktailName"].ToString();
                int totalAmount = Convert.ToInt32(row["TotalAmount"]);
                dataset.DataPoints.Add(cocktailName, totalAmount);
            }

            // איפוס הגרף
            salesChart.Datasets.Clear();
            salesChart.Datasets.Add(dataset);
            salesChart.Update(); // רענון התצוגה
        }


        private void LoadMonthlySalesChart()
        {
            string sql = @"
        SELECT 
            FORMAT(CreatedAt, 'yyyy-MM') AS Month,
            SUM(CAST(Amount AS FLOAT) * CAST(Price AS FLOAT)) AS Revenue
        FROM Sales
        GROUP BY FORMAT(CreatedAt, 'yyyy-MM')
        ORDER BY Month
    ";

            DataTable dt = DataBase.select(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageHelper.ShowInfo("No monthly sales data available.");
                return;
            }

            // יצירת dataset חדש לגרף
            GunaBarDataset dataset = new GunaBarDataset
            {
                Label = "Monthly Revenue"
            };

            foreach (DataRow row in dt.Rows)
            {
                string month = row["Month"].ToString();
                double revenue = Convert.ToDouble(row["Revenue"]);
                dataset.DataPoints.Add(month, revenue);
            }

            // הגדרת הגרף
            totalSaleChart.Datasets.Clear();
            totalSaleChart.Datasets.Add(dataset);
            totalSaleChart.YAxes.GridLines.Display = false;
            totalSaleChart.XAxes.GridLines.Display = false;
            totalSaleChart.Update();
        }







    }
}
