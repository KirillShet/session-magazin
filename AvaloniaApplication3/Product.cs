using Avalonia.Controls;
using System.Collections.Generic;
using Bitmap = Avalonia.Media.Imaging.Bitmap;

namespace AvaloniaApplication3
{
    public class Product
    {
        public string NameV { get; set; }
        public string PriceV { get; set; }
        public int del { get; set; }
        public int id { get; set; }
        public int edit { get; set; }
        public TextBox DobProd { get; set; }
        public float Sum { get; set; }
        public int idKol { get; set; }
        public int idKolM { get; set; }
        public string fileName { get; set; }
        public string opis { get; set; }
        public string proisv { get; set; }
        public string kolprod { get; set; }
        public Bitmap ProductImage
        {
            get
            {
                return new Bitmap(fileName);
            }
            set { }
        }
    }

    public class Shop
    {
        public List<Product> shop = new List<Product>();
    }
}
