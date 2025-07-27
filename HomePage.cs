using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;

namespace barmaster
{
    public partial class HomePage : Form
    {
        private readonly INavigation _navigator;
        string ID = "";
        public HomePage()
        {
            InitializeComponent();
            dashboardBtn.BackColor = Color.AliceBlue;
            dashboardBtn.ForeColor = Color.SteelBlue;

            // מימוש ממשק הניווט INvaigation עם פונקציית navigate 
            _navigator = new NavigationService();
            dashboardBtn.Click += (s, e) => _navigator.Navigate(this, new HomePage());
            inventorybtn.Click += (s, e) => _navigator.Navigate(this, new Inventory());
            customerbtn.Click += (s, e) => _navigator.Navigate(this, new Customers());
            cocktailsBtn.Click += (s, e) => _navigator.Navigate(this, new Cocktails());
            settingsBtn.Click += (s, e) => _navigator.Navigate(this, new Settings());
            salesBtn.Click += (s, e) => _navigator.Navigate(this, new Sales());

            LoadTopCocktailsChart();
            LoadTopCustomersChart();
            LoadShortageProducts();
        }


        // טעינת גרף הקוקטיילים הפופולרים 
        private void LoadTopCocktailsChart()
        {
            string sql = @"
                SELECT TOP 5 CocktailName, SUM(CAST(Amount AS INT)) AS TotalAmount
                FROM Sales
                GROUP BY CocktailName
                ORDER BY TotalAmount DESC
                ";

            DataTable dt = DataBase.select(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageHelper.ShowInfo("No cocktail sales data.");
                return;
            }

            GunaBarDataset dataset = new GunaBarDataset();
            dataset.Label = "Top Cocktails";

            foreach (DataRow row in dt.Rows)
            {
                string name = row["CocktailName"].ToString();
                int total = Convert.ToInt32(row["TotalAmount"]);
                dataset.DataPoints.Add(name, total);
            }

            TopCocktailsChart.Datasets.Clear();
            TopCocktailsChart.Datasets.Add(dataset);
            TopCocktailsChart.Update();
        }


        // טעינת גרף הלקוחות הפופולרים 
        private void LoadTopCustomersChart()
        {
            string sql = @"
                SELECT TOP 5 C.First_Name + ' ' + C.Last_Name AS FullName, SUM(CAST(S.Amount AS INT)) AS TotalPurchases
                FROM Sales S
                JOIN Customers C ON S.CustomerID = C.ID
                GROUP BY C.First_Name, C.Last_Name
                ORDER BY TotalPurchases DESC
                ";

            DataTable dt = DataBase.select(sql);
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageHelper.ShowInfo("No customer purchase data.");
                return;
            }

            GunaBarDataset dataset = new GunaBarDataset();
            dataset.Label = "Top Customers";

            foreach (DataRow row in dt.Rows)
            {
                string name = row["FullName"].ToString();
                int total = Convert.ToInt32(row["TotalPurchases"]);
                dataset.DataPoints.Add(name, total);
            }

            TopCustomersChart.Datasets.Clear();
            TopCustomersChart.Datasets.Add(dataset);
            TopCustomersChart.Update();
        }




        private void LoadShortageProducts()
        {
            string sql = "SELECT Name, Amount FROM Products WHERE Amount <= 10";
            DataTable dt = DataBase.select(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                shortageGrid.DataSource = null;
                MessageHelper.ShowInfo("No shortage products found.");
                return;
            }

            shortageGrid.DataSource = dt;
        }
    }
}
