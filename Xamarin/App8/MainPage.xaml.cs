using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App8
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
            //string pick = PickerCulture.SelectedItem.ToString();
            
            labelDate.Text = string.Format(AppResources.Today, DateTime.Now);
            labelNumber.Text = (3.14).ToString("F2");
            labelCurrency.Text = string.Format(AppResources.Currency, (2.15).ToString("C"));

            

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(PickerCulture.SelectedItem != null)
            {
                var pick = PickerCulture.SelectedItem.ToString();


                CultureInfo cli = new CultureInfo(pick);
                AppResources.Culture = cli;
                Thread.CurrentThread.CurrentCulture = AppResources.Culture;
                Thread.CurrentThread.CurrentUICulture = AppResources.Culture;

                labelError.IsVisible = false;
                labelWelcome.IsVisible = true;
                labelDate.IsVisible = true;
                labelNumber.IsVisible = true;
                labelCurrency.IsVisible = true;
            }
            else
            {
                labelError.Text = "Please Select a Country First";
                labelError.IsVisible = true;
            }
        }

        private void labelRefresh_Clicked(object sender, EventArgs e)
        {
            labelWelcome.Text = AppResources.Hello;
            labelDate.Text = string.Format(AppResources.Today, DateTime.Now);
            labelNumber.Text = (3.14).ToString("F2");
            labelCurrency.Text = string.Format(AppResources.Currency, (2.15).ToString("C"));
        }
    }
}
