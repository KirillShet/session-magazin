using Avalonia.Controls;
using System;
using System.Collections.Generic;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
namespace AvaloniaApplication3;

public partial class Sale : Window
{
    List<Product> values = new List<Product>();
    List<Product> val = new List<Product>();
    List<Product> names = new List<Product>();
    List<Product> valuest = new List<Product>();
    List<Product> opist = new List<Product>();
    List<Product> proisvt = new List<Product>();
    List<Product> kolprodt = new List<Product>();
    int help = 0;
    int helpTwo = 0;
    string file = "";
    int helpThree = 0;
    string fileName = "";
    private string _photo = "";

    public Sale()
    {
        InitializeComponent();
    }
    public Sale(List<Product> valuesT, List<Product> productsName, List<Product> valuest, List<Product> proisvName, List<Product> opisName, List<Product> kolich, int izmen)
    {
        InitializeComponent();
        if (izmen == 2)
        {
            dobav.IsVisible = true;
            zamena.IsVisible = false;
            aplicate.IsVisible = false;
            oplicate.IsVisible = true;
            foreach (Product strCol in productsName)
            {
                names.Add(strCol);
            }
            foreach (Product strCol in values)
            {
                valuest.Add(strCol);
            }
            foreach (Product strCol in proisvName)
            {
                proisvt.Add(strCol);
            }
            foreach (Product strCol in opisName)
            {
                opist.Add(strCol);
            }
            foreach (Product strCol in kolich)
            {
                kolprodt.Add(strCol);
            }
        }
        else if (izmen == 1)
        {
            dobav.IsVisible = false;
            zamena.IsVisible = true;
            aplicate.IsVisible = true;
            oplicate.IsVisible = false;
            foreach (Product c in valuesT)
            {
                prodName.Text = c.NameV;
                priceName.Text = c.PriceV;
                manufacturer.Text = c.proisv;
                description.Text = c.opis;
                quantity.Text = c.kolprod;
                values.Add(c);
            }
            foreach (Product c in productsName)
            {
                names.Add(c);
            }
            foreach (Product c in valuest)
            {
                val.Add(c);
            }
            foreach (Product c in opisName)
            {
                opist.Add(c);
            }
            foreach (Product c in proisvName)
            {
                proisvt.Add(c);
            }
            foreach (Product c in kolich)
            {
                kolprodt.Add(c);
            }
            helpThree = 0;
        }
    }
    public void EditB(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (values.Count > 0)
        {
            foreach (Product changing in values)
            {
                foreach (Product c in val)
                {
                    if (changing.PriceV == c.PriceV && changing.NameV == c.NameV && changing.opis == c.opis && changing.proisv == c.proisv && changing.kolprod == c.kolprod)
                    {
                        helpTwo++;
                    }
                }
            }
        }
        if (helpTwo > 0)
        {
            foreach (Product changing in names)
            {
                foreach (Product c in values)
                {
                    foreach (Product c2 in val)
                    {
                        if (changing.PriceV == c.PriceV && changing.NameV == c.NameV && changing.opis == c.opis && changing.proisv == c.proisv && changing.kolprod == c.kolprod)
                        {
                            changing.PriceV = priceName.Text;
                            changing.NameV = prodName.Text;
                            changing.opis = description.Text;
                            changing.proisv = manufacturer.Text;
                            changing.kolprod = quantity.Text;
                            if (helpThree > 0)
                            {
                                changing.fileName = file;
                            }
                            else
                            {
                                changing.fileName = changing.fileName;
                            }
                            c.PriceV = priceName.Text;
                            c.NameV = prodName.Text;
                            c.opis = description.Text;
                            c.proisv = manufacturer.Text;
                            c.kolprod = quantity.Text;
                            if (helpThree > 0)
                            {
                                c.fileName = file;
                            }
                            else
                            {
                                c.fileName = c.fileName;
                            }
                            c2.PriceV = priceName.Text;
                            c2.NameV = prodName.Text;
                            c2.opis = description.Text;
                            c2.proisv = manufacturer.Text;
                            c2.kolprod = quantity.Text;
                            if (helpThree > 0)
                            {
                                c2.fileName = file;
                            }
                            else
                            {
                                c2.fileName = c2.fileName;
                            }
                            break;
                        }
                    }
                    if (help > 0)
                    {
                        break;
                    }

                }
                if (help > 0)
                {
                    break;
                }
            }
        }
        else if (helpTwo == 0)
        {
            foreach (Product changing in names)
            {
                foreach (Product c in values)
                {
                    if (changing.PriceV == c.PriceV && changing.NameV == c.NameV && changing.opis == c.opis && changing.proisv == c.proisv && changing.kolprod == c.kolprod)
                    {

                        changing.PriceV = priceName.Text;
                        changing.NameV = prodName.Text;
                        changing.opis = description.Text;
                        changing.proisv = manufacturer.Text;
                        changing.kolprod = quantity.Text;
                        if (helpThree > 0)
                        {
                            changing.fileName = file;
                        }
                        else
                        {
                            changing.fileName = changing.fileName;
                        }
                        c.PriceV = priceName.Text;
                        c.NameV = prodName.Text;
                        c.opis = description.Text;
                        c.proisv = manufacturer.Text;
                        c.kolprod = quantity.Text;
                        if (helpThree > 0)
                        {
                            c.fileName = file;
                        }
                        else
                        {
                            c.fileName = c.fileName;
                        }
                        help++;
                        break;
                    }
                }
                if (help > 0)
                {
                    break;
                }
            }
        }
        new Product_list(names, val).Show();
        Close();
    }


    private void ButtonPressed1(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        names.Add(new Product()
        {
            NameV = prodName.Text,
            PriceV = priceName.Text,
            proisv = manufacturer.Text,
            opis = description.Text,
            kolprod = quantity.Text,
            fileName = fileName,
            Sum = 1,
            del = names.Count,
            edit = names.Count,
            idKol = names.Count,
        });
        new Product_list(names, valuest).Show();
        Close();

    }
    public async void Pictt(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        helpThree++;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var top = await openFileDialog.ShowAsync(this);
        file = String.Join("", top);
        Random random = new Random();
        string photo = "photo" + random.Next(1, 10000) + ".jpg";
        _photo = photo;
    }
    public async void Pict(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        var topLevel = await openFileDialog.ShowAsync(this);
        fileName = String.Join("", topLevel);
        Random random = new Random();
        string photo = "photo" + random.Next(1, 10000) + ".jpg";
        _photo = photo;
        pic.Source = new Bitmap(fileName);
    }
}