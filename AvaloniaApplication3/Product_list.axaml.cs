using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvaloniaApplication3;

public partial class Product_list : Window
{
    List<Product> productsName = new List<Product>();
    List<Product> values = new List<Product>();
    List<Product> editProd = new List<Product>();
    List<Product> deleteProd = new List<Product>();
    List<Product> valueshelp = new List<Product>();
    List<Product> proisvName = new List<Product>();
    List<Product> opisName = new List<Product>();
    List<Product> kolich = new List<Product>();
    List<string> proizv = new List<string>();
    int help = 0;
    int i = 0;
    int currentPage = 0;
    string s;
    int izmen = 0;
    public Product_list()
    {
        InitializeComponent();
    }
    public Product_list(int start, string fio)
    {
        InitializeComponent();
        if (start == 1 && fio == "admin")
        {
            star.IsEnabled = true;
        }
        else if (start == 2 || fio != "admin")
        {
            star.IsEnabled = false;
            
        }
        FIO.Text = fio;
    }

public Product_list(List<Product> names, List<Product> valuesTwo)
    {
        InitializeComponent();
        if (valuesTwo != null)
        {
            foreach (Product changing in valuesTwo)
            {
                values.Add(changing);
            }
        }
        foreach (Product changing in names)
        {
            productsName.Add(changing);
        }
        start2.ItemsSource = productsName.ToList();
        foreach (Product produc in productsName)
        {
            proizv.Add(produc.proisv);
        }
        proizv = proizv.Distinct().ToList();
        var comboBox = this.FindControl<ComboBox>("Combo");
        comboBox.Items.Add("Все производители");
        foreach (var item in proizv)
        {
            var comboBoxItem = new ComboBoxItem { Content = item };
            comboBox.Items.Add(comboBoxItem);
        }
    }
    public void ButtonPressed3(object sender, RoutedEventArgs e)
    {
        bool error = false;
        if (start2.SelectedItems != null)
        {
            foreach (Product strCol in start2.SelectedItems)
            {
                valueshelp.Add(strCol);
            }
            if (values.Count > 0)
            {
                foreach (Product c in valueshelp)
                {
                    foreach (Product ch in values)
                    {
                        if (c.PriceV == ch.PriceV && c.NameV == ch.NameV)
                        {
                            error = true;
                        }
                    }
                    if (error != true)
                    {
                        values.Add(c);
                    }
                    error = false;
                }
            }
            else
            {
                foreach (Product strCol in start2.SelectedItems)
                {
                    values.Add(strCol);
                }
            }
        }
        new Basket(values, productsName).Show();
        Close();
    }
    public void ButtonPressed2(object? sender, RoutedEventArgs e)
    {
        int selectEdit = (int)(sender as Button).Tag;
        foreach (Product c in productsName)
        {
            if (i == selectEdit)
            {
                editProd.Add(c);
                break;
            }
            i++;
        }
        i = 0;
        izmen = 1;
        new Sale(editProd, productsName, values, proisvName, opisName, kolich, izmen).Show();
        Close();
    }
    public void Del(object? sender, RoutedEventArgs e)
    {
        int selectDel = (int)(sender as Button).Tag;
        foreach (Product c in productsName)
        {
            if (i == selectDel)
            {
                deleteProd.Add(c);
                break;
            }
            i++;
        }
        i = 0;
        productsName.RemoveAt(selectDel);
        if (values.Count > 0)
        {
            foreach (Product chg in values)
            {
                foreach (Product c in deleteProd)
                {
                    if (chg.NameV == c.NameV && chg.PriceV == c.PriceV)
                    {
                        values.Remove(chg);
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
        foreach (Product chg in productsName)
        {
            if (chg.del > 0)
            {
                chg.del = chg.del - 1;
                chg.edit = chg.edit - 1;
            }
        }
        start2.ItemsSource = productsName.ToList();
    }
    public void ButtonPressed(object sender, RoutedEventArgs args)
    {
        new MainWindow().Show();
        Close();
    }
    public void ButtonPressed1(object sender, RoutedEventArgs args)
    {
        izmen = 2;
        new Sale(editProd, productsName, values, proisvName, opisName, kolich, izmen).Show();
        Close();
    }
    public void SearchList(object? sender, KeyEventArgs e)
    {
        Sear();
    }
    public void UpdateList()
    {
        int startIndex = currentPage * 2;
        start2.ItemsSource = productsName.Skip(startIndex).ToList();
    }
    public void Sear()
    {

        s = poisk.Text;
        foreach (Product chg in productsName)
        {
            if (chg.NameV == s)
            {
                i++;
                start2.ItemsSource = productsName.Skip(productsName.IndexOf(chg)).Take(1).ToList();
            }
        }
        if (i == 0)
        {
            UpdateList();
        }
        i = 0;
    }
    public void Sortupp(object sender, RoutedEventArgs e)
    {
        productsName.Sort((x, y) => x.PriceV.CompareTo(y.PriceV));
        foreach (Product chg in productsName)
        {
            chg.edit = productsName.IndexOf(chg);
            chg.del = productsName.IndexOf(chg);
        }
        UpdateList();
    }
    public void sortdown(object sender, RoutedEventArgs e)
    {
        productsName.Sort((x, y) => y.PriceV.CompareTo(x.PriceV));
        foreach (Product chg in productsName)
        {
            chg.edit = productsName.IndexOf(chg);
            chg.del = productsName.IndexOf(chg);
        }
        UpdateList();
    }
    public void SortAlf(object sender, RoutedEventArgs e)
    {
        productsName.Sort((x, y) => x.NameV.CompareTo(y.NameV));
        foreach (Product chg in productsName)
        {
            chg.edit = productsName.IndexOf(chg);
            chg.del = productsName.IndexOf(chg);
        }
        UpdateList();
    }
}