using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaApplication3;

public partial class Basket : Window
{

    public float sum = 0;
    List<Product> namesTwo = new List<Product>();
    List<Product> valuesTwo = new List<Product>();
    List<Product> kolT = new List<Product>();

    public int kol = 1;
    public int help;
    public string Bask { get; set; }
    public string KolTwo { get; set; }
    int i = 0;


    public Basket()
    {
        InitializeComponent();
    }
    public Basket(List<Product> values, List<Product> names)
    {
        InitializeComponent();

        foreach (Product c in values)
        {
            kolT.Add(
                new Product()
                {
                    NameV = c.NameV,
                    PriceV = c.PriceV,
                    proisv = c.proisv,
                    opis = c.opis,
                    kolprod = c.kolprod,
                    fileName = c.fileName,
                    DobProd = new TextBox(),
                    Sum = c.Sum,
                    id = kolT.Count,
                    idKol = kolT.Count,
                });
        }

        korzina.ItemsSource = kolT.ToList();
        foreach (Product c in values)
        {
            valuesTwo.Add(c);
        }

        foreach (Product strCol in names)
        {
            namesTwo.Add(strCol);
        }
        ClickHandler();

    }
    public void ClickHandler()
    {
        foreach (Product chg in kolT)
        {
            sum = sum + Convert.ToInt32(chg.Sum) * Convert.ToInt32(chg.PriceV);
        }
        SumF.Text = Convert.ToString(sum);
        sum = 0;
        valuesTwo.Clear();
        foreach (Product strCol in kolT)
        {
            valuesTwo.Add(
                new Product()
                {
                    NameV = strCol.NameV,
                    PriceV = strCol.PriceV,
                    Sum = strCol.Sum,
                    fileName = strCol.fileName,
                });
        }
    }
    public void Back(object sender, RoutedEventArgs e)
    {
        ClickHandler();
        new Product_list(namesTwo, valuesTwo).Show();
        Close();
    }
    public void Delete(object sender, RoutedEventArgs e)
    {
        int selectId = (int)(sender as Button).Tag;

        kolT.RemoveAt(selectId);
        valuesTwo.Clear();
        foreach (Product c in kolT)
        {
            valuesTwo.Add(
                new Product()
                {
                    NameV = c.NameV,
                    PriceV = c.PriceV,
                    Sum = c.Sum,
                    fileName = c.fileName,
                }
                );
        }
        foreach (Product chg in kolT)
        {
            if (chg.id > 0)
            {
                chg.id = chg.id - 1;
            }
        }
        korzina.ItemsSource = kolT.ToList();
        ClickHandler();
    }
    public void Kol(object sender, RoutedEventArgs e)
    {
        int selectId = (int)(sender as Button).Tag;
        foreach (Product chg in kolT)
        {
            if (selectId == i)
            {
                chg.Sum++;
                break;
            }
            i++;
        }
        i = 0;
        korzina.ItemsSource = kolT.ToList();
        ClickHandler();
    }
    public void KolM(object sender, RoutedEventArgs e)
    {
        int selectId = (int)(sender as Button).Tag;
        foreach (Product chg in kolT)
        {
            if (selectId == i)
            {
                if (sum > 1)
                {
                    chg.Sum--;
                    break;
                }
            }
            i++;
        }
        i = 0;
        korzina.ItemsSource = kolT.ToList();
        ClickHandler();
    }
}