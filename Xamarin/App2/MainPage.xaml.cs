using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {

       
        private ObservableCollection<Fruit> fruits;

        private ObservableCollection<KilFruit> L;
        double total = 0;
        public MainPage()
        {
            
            InitializeComponent();
            fruits = new ObservableCollection<Fruit>();
            L = new ObservableCollection<KilFruit>();
            

            fruits.Add(new Fruit { Name = "Banana", Available = true, Price = 1.31, Counter = 10});
            fruits.Add(new Fruit { Name = "Apple", Available = true, Price = 0.79, Counter = 10 });
            fruits.Add(new Fruit { Name = "Grape", Available = true, Price = 3.36, Counter = 10 });
            fruits.Add(new Fruit { Name = "Orange", Available = true, Price = 2.99, Counter = 10 });
            fruits.Add(new Fruit { Name = "Cherry", Available = true, Price = 2.12, Counter = 10 });

            

            listView.ItemsSource = fruits;

            
        }
        public string Namee { get; set; }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(kilos.Text))
            {
                DisplayAlert("Error!", "Please write how many kilos do you want before!", "OK!");
            }
            else
            {
                if((Convert.ToInt32((e.SelectedItem as Fruit).Counter) - Convert.ToInt32(kilos.Text)) == 0)
                {
                    DisplayAlert("Selection", "You have selected " + (e.SelectedItem as Fruit).Name + " of " + kilos.Text + " kilos", "OK!");
                    L.Add(new KilFruit { Kiloo = kilos.Text.ToString(), Namee = (e.SelectedItem as Fruit).Name });

                    fruits.Remove((e.SelectedItem as Fruit));
                    total += (Convert.ToInt32(kilos.Text) * Convert.ToSingle((e.SelectedItem as Fruit).Price));
                    prays.Text = "Total Price is = " + total.ToString("0.00");
                }
                else if((e.SelectedItem as Fruit).Counter < Convert.ToInt32(kilos.Text))
                {
                    DisplayAlert("Error!", "Only " + (e.SelectedItem as Fruit).Counter + " kilos available. Please select this amount or select another item", "OK!");
                }
                else
                {
                    DisplayAlert("Selection", "You have selected " + (e.SelectedItem as Fruit).Name + " of " + kilos.Text + " kilos", "OK!");
                    
                    L.Add(new KilFruit { Kiloo = kilos.Text.ToString(), Namee = (e.SelectedItem as Fruit).Name });
                    
                    (e.SelectedItem as Fruit).Counter = Convert.ToInt32((e.SelectedItem as Fruit).Counter) - Convert.ToInt32(kilos.Text);
                    total += (Convert.ToInt32(kilos.Text) * Convert.ToSingle((e.SelectedItem as Fruit).Price));
                    prays.Text = "Total Price is = " + total.ToString("0.00");
                }
                
            }
            
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Selected", "You Have Selected: " + string.Join("\n ", L.Select(s => $"'{s.Kiloo} kilo of {s.Namee}'")), "OK!");
            listView.IsEnabled = false;
            Button2.IsEnabled = true;
            Button1.IsEnabled = false;
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
