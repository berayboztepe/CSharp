using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDeneme
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            Random rast = new Random();
            int rand = rast.Next(3, 11);
            Com_Guess.Text = (rand*3 + 1).ToString();
            Clicked.IsVisible = false;
            Clicked2.IsVisible = true;
            Guess.IsVisible = true;
        }
        public void Button_Clicked2(object sender, EventArgs e)
        { 
            int rand;
            int gu = Convert.ToInt32(Guess.Text);
            if ((Convert.ToInt32(Com_Guess.Text) - Convert.ToInt32(Guess.Text)) < 2 |
                (Convert.ToInt32(Com_Guess.Text) - Convert.ToInt32(Guess.Text)) > 0 |
                (Convert.ToInt32(Com_Guess.Text) != Convert.ToInt32(Guess.Text)))
            {
                YourGuess.Text = "Tahmininiz = " + gu;
                Error_Guess.IsVisible = true;
                Error_Guess.Text = "Lütfen Ekrandaki Sayının 1 ya da 2 Eksiğini Girin!";
            }
            if (Convert.ToInt32(Guess.Text) <= 0)
            {
                Sonuc.Text = "Kaybettiniz. Ancak Kazanamazdınız :)";
                YourGuess.Text = "Tahmininiz = " + gu;
                Clicked2.IsVisible = false;
                Guess.IsVisible = false;
                Error_Guess.IsVisible = false;
                Basla.IsVisible = false;
                Com_Guess.IsVisible = false;
                Label2.IsVisible = false;
            }
            else
            {
                if ((Convert.ToInt32(Com_Guess.Text) - Convert.ToInt32(Guess.Text)) == 1)
                {
                    Com_Guess.Text = Guess.Text;
                    rand = Convert.ToInt32(Com_Guess.Text) - 2;
                    Com_Guess.Text = rand.ToString();
                    Error_Guess.IsVisible = false;
                    Guess.Text = string.Empty;
                    YourGuess.Text = "Tahmininiz = " + gu;
                }
                else if ((Convert.ToInt32(Com_Guess.Text) - Convert.ToInt32(Guess.Text)) == 2)
                {
                    Com_Guess.Text = Guess.Text;
                    rand = Convert.ToInt32(Com_Guess.Text) - 1;
                    Com_Guess.Text = rand.ToString();
                    Error_Guess.IsVisible = false;
                    Guess.Text = string.Empty;
                    YourGuess.Text = "Tahmininiz = " + gu;
                }
                if ((Convert.ToInt32(Com_Guess.Text) <= 0))
                {
                    Sonuc.Text = "Tebrikler Kazandınız. Nasıl Kazandın LAN! :)";
                    Clicked2.IsVisible = false;
                    Guess.IsVisible = false;
                    Error_Guess.IsVisible = false;
                    Basla.IsVisible = false;
                    Com_Guess.IsVisible = false;
                    Label2.IsVisible = false;
                }
            }
        }

        private void Guess_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Guess.Text) && float.TryParse(Guess.Text, out float _))
            {
                Clicked2.IsEnabled = true;
            }
        }
    }
    }

