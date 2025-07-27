using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace barmaster
{
    public partial class Cocktails : Form
    {

        private string selectedCocktailName;
        private double selectedCocktailPrice;


        private readonly INavigation _navigator;
        private int ingredientCounter = 1;
        private List<Guna2ComboBox> productComboBoxes = new List<Guna2ComboBox>();
        private List<Guna2TextBox> amountTextBoxes = new List<Guna2TextBox>();

        // שמירה על המיקומים המקוריים
        private int originalPlusBtnY;
        private int originalImgBoxY;
        private int originalAddBtnY;
        private int originalPanelHeight;

        public Cocktails()
        {
            InitializeComponent();
            this.previewPanel.Visible = false; // ודא שהפאנל מוסתר בהתחלה
            this.CocktailPanel.Visible = false;
            LoadProducts();
            LoadCocktails();
            cocktailsBtn.BackColor = Color.AliceBlue;
            cocktailsBtn.ForeColor = Color.SteelBlue;

            // הפעלת גלילה בפאנל
            CocktailPanel.AutoScroll = true;

            // שמירה על מיקומים התחלתיים
            originalPlusBtnY = PlusBtn.Location.Y;
            originalImgBoxY = ImgBox.Location.Y;
            originalAddBtnY = AddBtn.Location.Y;
            originalPanelHeight = CocktailPanel.Height;

            // מימוש ממשק הניווט
            _navigator = new NavigationService();
            dashboardBtn.Click += (s, e) => _navigator.Navigate(this, new HomePage());
            inventorybtn.Click += (s, e) => _navigator.Navigate(this, new Inventory());
            customerbtn.Click += (s, e) => _navigator.Navigate(this, new Customers());
            cocktailsBtn.Click += (s, e) => _navigator.Navigate(this, new Cocktails());
            settingsBtn.Click += (s, e) => _navigator.Navigate(this, new Settings());
            salesBtn.Click += (s, e) => _navigator.Navigate(this, new Sales());
        }


        // טעינת המוצרים 
        private void LoadProducts()
        {
            string sql = "SELECT Name FROM Products";
            DataTable dt = DataBase.select(sql);

            if (dt != null)
            {
                productComboBox.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    productComboBox.Items.Add(row["Name"].ToString());
                }
            }
        }


        // פונקציה לסימון קוקטייל כאשר אין את המצרכים הנדרשים במלאי 
        public static void MarkPictureBoxAsSoldOut(PictureBox picBox)
        {
            if (picBox.Image == null)
                return;

            // יצירת עותק מהתמונה המקורית
            Bitmap bmp = new Bitmap(picBox.Image.Width, picBox.Image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // הפיכת צבעים לאפור
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0},
                    new float[] {0.59f, 0.59f, 0.59f, 0, 0},
                    new float[] {0.11f, 0.11f, 0.11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(colorMatrix);

                g.DrawImage(picBox.Image,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, bmp.Width, bmp.Height,
                    GraphicsUnit.Pixel, attributes);

                // ציור האייקון במרכז
                string iconPath = Path.Combine(Application.StartupPath, "Picture", "soldout.jpeg");
                if (File.Exists(iconPath))
                {
                    using (Image icon = Image.FromFile(iconPath))
                    {
                        int iconSize = (int)(bmp.Width * 0.5); // חצי מהרוחב
                        int x = (bmp.Width - iconSize) / 2;
                        int y = (bmp.Height - iconSize) / 2;

                        // שקיפות של 50%
                        ColorMatrix alphaMatrix = new ColorMatrix();
                        alphaMatrix.Matrix33 = 0.5f;

                        ImageAttributes alphaAttributes = new ImageAttributes();
                        alphaAttributes.SetColorMatrix(alphaMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                        g.DrawImage(icon,
                            new Rectangle(x, y, iconSize, iconSize),
                            0, 0, icon.Width, icon.Height,
                            GraphicsUnit.Pixel,
                            alphaAttributes);
                    }
                }
                else
                {
                    MessageBox.Show("לא נמצא קובץ אייקון:\n" + iconPath);
                }
            }

            // החלפת התמונה המעודכנת
            picBox.Image = bmp;
            picBox.Enabled = false;
        }


        // טעינת הקוקטיילים 
        private void LoadCocktails()
        {
            string sql = "SELECT * FROM Cocktails";
            DataTable dt = DataBase.select(sql);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageHelper.ShowInfo("No cocktails found!");
                return;
            }

            cocktailsFlowLayoutPanel.Controls.Clear(); // מנקה קודם כדי למנוע כפילויות

            foreach (DataRow row in dt.Rows)
            {
                Guna2Panel cocktailPanel = new Guna2Panel
                {
                    Size = ImagePanel.Size,
                    BorderRadius = ImagePanel.BorderRadius,
                    BorderColor = ImagePanel.BorderColor,
                    BorderThickness = ImagePanel.BorderThickness,
                    FillColor = ImagePanel.FillColor,
                    ShadowDecoration = { Enabled = false, BorderRadius = 15 },
                    Margin = new Padding(10)
                };

                Guna2PictureBox cocktailImage = new Guna2PictureBox
                {
                    Size = ImagPictureBox.Size,
                    Location = ImagPictureBox.Location,
                    BorderRadius = ImagPictureBox.BorderRadius,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    FillColor = ImagPictureBox.FillColor,
                    Tag = row
                };

                string imagePath = row["Image"].ToString();
                if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
                {
                    using (var bmpTemp = new Bitmap(imagePath))
                        cocktailImage.Image = new Bitmap(bmpTemp);
                }

                else
                {
                    cocktailImage.FillColor = Color.LightGray;
                }

                string ingredients = row["Ingredients"].ToString();
                bool hasStock = CheckIngredientsAvailable(ingredients, 1);
                // בדיקה לכמות 1

                if (!hasStock)
                {
                    // הפוך לאפורה, הוסף טקסט SOLD OUT
                    MarkPictureBoxAsSoldOut(cocktailImage);
                }



                // חיבור לאירוע לחיצה
                cocktailImage.Tag = row;
                cocktailImage.Click += ImagPictureBox_Click;

                Guna2HtmlLabel nameLabel = new Guna2HtmlLabel
                {
                    Text = row["Name"].ToString(),
                    Size = NameLbl.Size,
                    Location = NameLbl.Location,
                    Font = NameLbl.Font,
                    ForeColor = NameLbl.ForeColor
                };

                Guna2HtmlLabel priceLabel = new Guna2HtmlLabel
                {
                    Text = "Price : " + row["Price"].ToString() + " $",
                    Size = PriceLabel.Size,
                    Location = PriceLabel.Location,
                    Font = PriceLabel.Font,
                    ForeColor = PriceLabel.ForeColor
                };

                cocktailPanel.Controls.Add(cocktailImage);
                cocktailPanel.Controls.Add(nameLabel);
                cocktailPanel.Controls.Add(priceLabel);
                cocktailsFlowLayoutPanel.Controls.Add(cocktailPanel);
            }
        }


        // בדיקה אם המצרכים קיימים במלאי 
        private bool CheckIngredientsAvailable(string ingredients, int quantity)
        {
            string[] parts = ingredients.Split(',');

            foreach (string item in parts)
            {
                string[] split = item.Split('=');
                string product = split[0];
                double required = double.Parse(split[1]) * quantity;

                DataTable inv = DataBase.select($"SELECT Amount FROM Products WHERE Name = '{product}'");

                if (inv == null || inv.Rows.Count == 0)
                    return false;

                double available = double.Parse(inv.Rows[0]["Amount"].ToString());

                if (available < required)
                    return false;
            }

            return true;
        }





        //פונקציה שמטפלת במקרה בו האפליקציה נסגרת
        private void Cocktails_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        // לחיצה על כפתור ההוספת קוקטייל  
        private void addCocktails_Click(object sender, EventArgs e)
        {
            this.CocktailPanel.Visible = true;
        }


        // לחיצה על כפתור סגירת הפאנל
        private void ClosePanelBtn_Click(object sender, EventArgs e)
        {
            ResetCocktailPanel();
            this.CocktailPanel.Visible = false;
        }


        // לחיצה על כפתור הפלוס שמוסיף עוד מקום להוספת מצרך נוסף 
        private void PlusBtn_Click(object sender, EventArgs e)
        {
            ingredientCounter++;

            Guna2ComboBox newProductComboBox = new Guna2ComboBox
            {
                Name = "productComboBox" + ingredientCounter,
                Size = productComboBox.Size,
                Location = new Point(productComboBox.Location.X, PlusBtn.Location.Y),
                BorderRadius = 10,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            Guna2TextBox newAmountTextBox = new Guna2TextBox
            {
                Name = "amountTxtBox" + ingredientCounter,
                Size = amountTxtBox.Size,
                Location = new Point(amountTxtBox.Location.X, PlusBtn.Location.Y),
                PlaceholderText = "amount (ml/g)",
                BorderRadius = 10,
            };

            // טעינת כל המוצרים ל-ComboBox
            string sql = @"SELECT Name FROM Products";
            DataTable dt = DataBase.select(sql);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    newProductComboBox.Items.Add(row[0].ToString());
                }
            }

            CocktailPanel.Controls.Add(newProductComboBox);
            CocktailPanel.Controls.Add(newAmountTextBox);

            productComboBoxes.Add(newProductComboBox);
            amountTextBoxes.Add(newAmountTextBox);

            // עדכון מיקומים
            PlusBtn.Location = new Point(PlusBtn.Location.X, newProductComboBox.Location.Y + 50);
            ImgBox.Location = new Point(ImgBox.Location.X, PlusBtn.Location.Y + 40);
            AddBtn.Location = new Point(AddBtn.Location.X, ImgBox.Location.Y + ImgBox.Height + 20);

            CocktailPanel.Height = AddBtn.Location.Y + AddBtn.Height + 20;
        }


        // לחיצה על כפתור ההוספה של הקוקטייל החדש לאחר הוספת הקלט הנדרש 
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string name = CocktailNametxtbox.Text.Trim();
            string price = cocktailsPriceTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageHelper.ShowWarning("Cocktail Name is required!");
                return;
            }

            if (string.IsNullOrEmpty(price) || !double.TryParse(price, out double priceValue) || priceValue <= 0)
            {
                MessageHelper.ShowWarning("Valid Price is required!");
                return;
            }

            if (string.IsNullOrEmpty(ImgBox.Text))
            {
                MessageHelper.ShowWarning("Image path is required!");
                return;
            }

            if (string.IsNullOrEmpty(productComboBox.Text) || string.IsNullOrEmpty(amountTxtBox.Text))
            {
                MessageHelper.ShowWarning("At least one ingredient is required!");
                return;
            }

            // ✅ בדיקה אם הקוקטייל כבר קיים במסד הנתונים
            string checkQuery = $"SELECT COUNT(*) FROM Cocktails WHERE Name = N'{name}'";
            DataTable result = DataBase.select(checkQuery);
            if (result != null && Convert.ToInt32(result.Rows[0][0]) > 0)
            {
                MessageHelper.ShowWarning("A cocktail with this name already exists!");
                return;
            }

            List<string> ingredients = new List<string>();

            if (!string.IsNullOrEmpty(productComboBox.Text) && !string.IsNullOrEmpty(amountTxtBox.Text))
                ingredients.Add($"{productComboBox.Text}={amountTxtBox.Text}");

            for (int i = 0; i < productComboBoxes.Count; i++)
            {
                if (!string.IsNullOrEmpty(productComboBoxes[i].Text) && !string.IsNullOrEmpty(amountTextBoxes[i].Text))
                {
                    ingredients.Add($"{productComboBoxes[i].Text}={amountTextBoxes[i].Text}");
                }
            }

            if (ingredients.Count == 0)
            {
                MessageHelper.ShowWarning("At least one valid ingredient is required!");
                return;
            }

            string ingredientsStr = string.Join(",", ingredients);
            string imagePath = ImgBox.Text.Trim();

            string sql = $@"INSERT INTO Cocktails (Name, Price, Ingredients, Image)
                            VALUES (N'{name}', '{priceValue}', N'{ingredientsStr}', N'{imagePath}')";

            DataBase.send(sql);

            MessageHelper.ShowInfo("Cocktail added successfully!");

            ClearForm();
            LoadCocktails();
            ResetCocktailPanel();
            CocktailPanel.Visible = false;
        }



        // אתחול הטקסט בכול האלמטנים שנמצאים בפאנל 
        private void ResetCocktailPanel()
        {
            CocktailNametxtbox.Text = "";
            cocktailsPriceTextBox.Text = "";
            productComboBox.SelectedIndex = -1;
            amountTxtBox.Text = "";
            ImgBox.Text = "";

            foreach (var comboBox in productComboBoxes)
                CocktailPanel.Controls.Remove(comboBox);

            foreach (var textBox in amountTextBoxes)
                CocktailPanel.Controls.Remove(textBox);

            productComboBoxes.Clear();
            amountTextBoxes.Clear();

            PlusBtn.Location = new Point(PlusBtn.Location.X, originalPlusBtnY);
            ImgBox.Location = new Point(ImgBox.Location.X, originalImgBoxY);
            AddBtn.Location = new Point(AddBtn.Location.X, originalAddBtnY);

            CocktailPanel.Height = originalPanelHeight;

            ingredientCounter = 1;
        }


        // אתחול העמוד מחדש 
        private void ClearForm()
        {
            this.CocktailNametxtbox.Text = "";
            this.cocktailsPriceTextBox.Text = "";
            this.amountTxtBox.Text = "";
            this.ImgBox.Text = "";
        }



        // אירוע לחיצה כאשר לוחצים על תמונת הקוקטייל 
        private void ImgBox_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImgBox.Text = filePath; // שמור את הנתיב בתוך התיבה
                    MessageHelper.ShowInfo("Image path selected successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowError("Error selecting image:\n" + ex.Message);
            }
        }



        // טעינת קוקטיילים מפולטרים 
        private void LoadFilteredCocktails(string sql)
        {
            cocktailsFlowLayoutPanel.Controls.Clear();
            DataTable dt = DataBase.select(sql);

            if (dt == null || dt.Rows.Count == 0)
                return;

            foreach (DataRow row in dt.Rows)
            {
            
                Guna2Panel cocktailPanel = new Guna2Panel
                {
                    Size = ImagePanel.Size,
                    BorderRadius = ImagePanel.BorderRadius,
                    BorderColor = ImagePanel.BorderColor,
                    BorderThickness = ImagePanel.BorderThickness,
                    FillColor = ImagePanel.FillColor,
                    ShadowDecoration = { Enabled = false, BorderRadius = 15 },
                    Margin = new Padding(10)
                };

                Guna2PictureBox cocktailImage = new Guna2PictureBox
                {
                    Size = ImagPictureBox.Size,
                    Location = ImagPictureBox.Location,
                    BorderRadius = ImagPictureBox.BorderRadius,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    FillColor = ImagPictureBox.FillColor,
                    Tag = row
                };

                string imagePath = row["Image"].ToString();
                if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
                {
                    using (var bmpTemp = new Bitmap(imagePath))
                        cocktailImage.Image = new Bitmap(bmpTemp);
                }

                cocktailImage.Click += ImagPictureBox_Click;

                Guna2HtmlLabel nameLabel = new Guna2HtmlLabel
                {
                    Text = row["Name"].ToString(),
                    Size = NameLbl.Size,
                    Location = NameLbl.Location,
                    Font = NameLbl.Font,
                    ForeColor = NameLbl.ForeColor
                };

                Guna2HtmlLabel priceLabel = new Guna2HtmlLabel
                {
                    Text = "Price : " + row["Price"].ToString() + " $",
                    Size = PriceLabel.Size,
                    Location = PriceLabel.Location,
                    Font = PriceLabel.Font,
                    ForeColor = PriceLabel.ForeColor
                };

                cocktailPanel.Controls.Add(cocktailImage);
                cocktailPanel.Controls.Add(nameLabel);
                cocktailPanel.Controls.Add(priceLabel);
                cocktailsFlowLayoutPanel.Controls.Add(cocktailPanel);
                ClosePanelBtn2.BringToFront();
            }
        }





        // פונקציה 
        private async Task ShowPreview(string name, string price, string ingredients, string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                MessageHelper.ShowWarning("Image not found.");
                return;
            }

            selectedCocktailName = name;
            double.TryParse(price, out selectedCocktailPrice);

            previewPanel.Visible = true;
            previewPanel.BringToFront();
            previewPanel.BackColor = Color.White;

            // מיקום כפתור סגירה (שלא יעלה על התמונה)
            ClosePanelBtn2.BringToFront();
            ClosePanelBtn2.Location = new Point(previewPanel.Width - ClosePanelBtn2.Width - 10, 10);

            // תמונה
            previewImage.SizeMode = PictureBoxSizeMode.Zoom;
            previewImage.Size = new Size(300, 200);

            using (var bmpTemp = new Bitmap(imagePath))
            {
                previewImage.Image = new Bitmap(bmpTemp);
            }

            previewIngredientsLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            previewIngredientsLabel.TextAlign = ContentAlignment.MiddleCenter;
            previewIngredientsLabel.Text = $"{name}\n\nIngredients:\n{ingredients}";
            previewIngredientsLabel.Size = new Size(previewPanel.Width - 40, 60);
            previewIngredientsLabel.Location = new Point(
                (previewPanel.Width - previewIngredientsLabel.Width) / 2,
                previewImage.Bottom + 10
            );

            BuyBtn.Text = "Buy";
            BuyBtn.Size = new Size(120, 40);
            BuyBtn.Location = new Point(
                (previewPanel.Width - BuyBtn.Width) / 2,
                previewIngredientsLabel.Bottom + 20
            );

            await AnimateZoomIn(previewImage);
        }



        private async Task AnimateZoomIn(Control ctrl)
        {
            ctrl.Size = new Size(30, 20);
            ctrl.Location = new Point((previewPanel.Width - ctrl.Width) / 2, 20);

            for (int i = 0; i <= 10; i++)
            {
                int width = 30 + i * 27;  // עד 300
                int height = 20 + i * 18; // עד 200
                ctrl.Size = new Size(width, height);
                ctrl.Location = new Point((previewPanel.Width - width) / 2, 20);
                await Task.Delay(5);
            }
        }






        private void SearchProduct_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchProduct.Text.Trim();

            string sql;
            if (string.IsNullOrEmpty(keyword))
            {
                sql = "SELECT * FROM Cocktails";
            }
            else
            {
                sql = $"SELECT * FROM Cocktails WHERE Name LIKE N'{keyword}%'";
            }

            LoadFilteredCocktails(sql);
            
            
        }


        private async void ClosePanelBtn2_Click(object sender, EventArgs e)
        {
            for (int alpha = 255; alpha >= 0; alpha -= 20)
            {
                previewPanel.BackColor = Color.FromArgb(alpha, previewPanel.BackColor.R, previewPanel.BackColor.G, previewPanel.BackColor.B);
                await Task.Delay(10);
            }

            previewPanel.Visible = false;
            previewImage.Image = null;
        }
        private async void ImagPictureBox_Click(object sender, EventArgs e)
        {
            if (sender is Guna2PictureBox picture && picture.Tag is DataRow row)
            {
                string name = row["Name"].ToString();
                string price = row["Price"].ToString();
                string ingredients = row["Ingredients"].ToString();
                string imagePath = row["Image"].ToString();

                await ShowPreview(name, price, ingredients, imagePath);
            }
        }

        private void BuyBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCocktailName) || selectedCocktailPrice <= 0)
            {
                MessageBox.Show("No cocktail selected.");
                return;
            }

            PurchaseForm form = new PurchaseForm(selectedCocktailName, selectedCocktailPrice);
            form.ShowDialog();
        }

    }
}
