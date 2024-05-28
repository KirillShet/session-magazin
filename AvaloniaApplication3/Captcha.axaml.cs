using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaApplication3;

public partial class Captcha : Window
{
    string[] numbers = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    string[] bukvi = new string[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"};
    string[] bukvi2 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    string[] capt = new string[6];
    string zaput = "";
    int osh = 0;

    private void slovo()
    {
        for (int i = 0; i < capt.Length; i++)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 3);
            if (randomNumber == 1)
            {
                int randchis = rnd.Next(0, 8);
                capt[i] = numbers[randchis];
            }
            else if (randomNumber == 2)
                {
                randomNumber = rnd.Next(0, 25);
                capt[i] = bukvi[randomNumber];
            }
            else if (randomNumber == 3)
            {
                randomNumber = rnd.Next(0, 25);
                capt[i] = bukvi2[randomNumber];
            }
        }
        for (int i = 0; i < capt.Length; i++)
        {
            zaput += capt[i];
        }
    }
    public Captcha()
    {
        InitializeComponent();
    }
    public async void ButtonPressed1(object sender, RoutedEventArgs args)
    {
        zaput = "";
        Cuper.Text = "";
        cozdat.IsEnabled = false;
        slovo();
        Cuper.Text = zaput;
        osh++;
        await Task.Delay(1500);
        cozdat.IsEnabled = true;
    }
    public async void ButtonPressed(object sender, RoutedEventArgs args)
    {
        if (osh == 0)
        {
            zaput = "";
            Cuper.Text = null;
            slovo();
        }
        Cuper.Text = zaput;
        if (Vvod.Text != Cuper.Text)
        {
            Vvod.Background = Brushes.Red;
            osh = 0;
            Return.IsEnabled = false;
        }
        await Task.Delay(1500);
        Return.IsEnabled = true;
        Vvod.Background = Brushes.White;
        if (Vvod.Text == Cuper.Text)
        {
            Close();
        }
    }
}