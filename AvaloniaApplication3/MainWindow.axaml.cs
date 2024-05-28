using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaApplication3
{
    public partial class MainWindow : Window
    {
        List<Product> product = new List<Product>();
        List<Product> bask = new List<Product>();
        private int osh = 0;
        string fio;
        int start = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(List<Product> productsName, List<Product> values)
        {
            InitializeComponent();
            foreach (Product person in productsName)
            {
                product.Add(person);
            }
            foreach (Product product in values)
            {
                bask.Add(product);
            }
        }
        public async void ButtonPressed(object sender, RoutedEventArgs args)
        {
            One.IsEnabled = false;
            if(Login.Text == null || Password.Text == null || Login.Text == "" || Password.Text == "")
            {
                Login.Background = Brushes.Red;
                Password.Background = Brushes.Red;
                Oshib1.Text = "Вы не ввели логин или пароль.";
            }
            if (Login.Text != null && Password.Text != null && Login.Text != Password.Text && Login.Text != "" && Password.Text != "")
            {
                Login.Background = Brushes.Red;
                Password.Background = Brushes.Red;
                Oshib1.Text = "Вы ввели неправильно логин или пароль.";
            }
            await Task.Delay(1000);
            One.IsEnabled = true;
            Login.Background = Brushes.White;
            Password.Background = Brushes.White;
            Oshib1.Text = "";            
            if (Login.Text == Password.Text && Login.Text != null && Password.Text != null)
            {
                fio = Login.Text;
                start = 1;
                new Product_list(start, fio).Show();
                Close();
            }
            else if (osh >= 1)
            {
                this.IsEnabled = false;
                var captcha = new Captcha();
                captcha.Closed += CaptchaWindow_Closed;
                captcha.Show();
            }
            osh++;
        }

        private void CaptchaWindow_Closed(object? sender, EventArgs e)
        {
            this.IsEnabled = true;
        }
        public void ButtonPressed1(object sender, RoutedEventArgs args)
        {
            start = 2;
            fio = "Гость";
            new Product_list(start, fio).Show();
            Close();
        }
    }
}