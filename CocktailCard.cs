using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace barmaster
{
    public class CocktailCard : Guna2Panel
    {
        public string CocktailName { get; private set; }
        public decimal Price { get; private set; }
        public string ImagePath { get; private set; }
        public Image CocktailImage { get; private set; }

        public CocktailCard(string name, decimal price, Image image,
                    Size panelSize, int borderRadius, Color borderColor, int borderThickness,
                    Size imgSize, Point imgLocation, int imgRadius, Color imgFill,
                    Size nameSize, Point nameLocation, Font nameFont, Color nameColor,
                    Size priceSize, Point priceLocation, Font priceFont, Color priceColor)
        {
            this.Size = panelSize;
            this.BorderRadius = borderRadius;
            this.BorderColor = borderColor;
            this.BorderThickness = borderThickness;
            this.FillColor = Color.White;
            this.ShadowDecoration.Enabled = true;
            this.Margin = new Padding(10);

            var pic = new Guna2PictureBox
            {
                Size = imgSize,
                Location = imgLocation,
                BorderRadius = imgRadius,
                SizeMode = PictureBoxSizeMode.Zoom,
                FillColor = imgFill,
                Image = image
            };

            var nameLbl = new Guna2HtmlLabel
            {
                Text = name,
                Size = nameSize,
                Location = nameLocation,
                Font = nameFont,
                ForeColor = nameColor,
                BackColor = Color.Transparent
            };

            var priceLbl = new Guna2HtmlLabel

            {
                Text = "Price : " + price.ToString("0.00") + " $",
                Size = priceSize,
                Location = priceLocation,
                Font = priceFont,
                ForeColor = priceColor,
                BackColor = Color.Transparent
            };

            this.Controls.Add(pic);
            this.Controls.Add(nameLbl);
            this.Controls.Add(priceLbl);
        }
    }
}
