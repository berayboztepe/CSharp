using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            try {
                float h = Convert.ToSingle(Height.Text);
                float w = Convert.ToSingle(Weight.Text);

                if(h > 10)
                {
                    h = h / 100;
                }

                float bmi = w / (h * h);

                WelcomeText.Text = bmi.ToString();
                if(bmi < 18.5)
                {
                    FatOrThin.Text = "You are too thin!";
                    GainOrLose.Text = "You have to gain some kilos!";
                }
                else if (bmi > 18.5 && bmi < 24.9)
                {
                    FatOrThin.Text = "You are normal!";
                    GainOrLose.Text = "Keep staying like that!";
                }
                else if (bmi > 25 && bmi < 29.9)
                {
                    FatOrThin.Text = "You are overweight!";
                    GainOrLose.Text = "You have to do exercise!";
                }
                else
                {
                    FatOrThin.Text = "You are obese!";
                    GainOrLose.Text = "You have to lose some kilos!";
                }
            }
            catch (FormatException)
            {
                WelcomeText.Text = "Wrong Number Provided!";
            }
            }

        private void HeWe_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.IsNullOrEmpty(Height.Text) && !string.IsNullOrEmpty(Weight.Text) 
                && float.TryParse(Height.Text, out float _) 
                && float.TryParse(Weight.Text, out float _))
            {
                CalculateBMI.IsEnabled = true;
            }
            else
            {
                CalculateBMI.IsEnabled = false;
            }
        }
    }
}
