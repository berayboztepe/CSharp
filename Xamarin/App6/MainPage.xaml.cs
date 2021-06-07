using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App6
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            countries_add.IsVisible = false;
            activity.IsVisible = true;
            activity.IsRunning = true;
            string country_name = CountryPicker.SelectedItem.ToString().ToLower().Replace(' ', '-');

            var hc = new HttpClient();
            var result = await hc.GetAsync("https://api.covid19api.com/live/country/" + country_name + "/status/confirmed");
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();

                var stats = JsonConvert.DeserializeObject<List<CovidCases>>(json);
                if(stats.Count == 0)
                {
                    activecases.Text = "Unknown";
                }
                else
                {
                    activecases.Text = stats[stats.Count - 1].Active.ToString();
                }
                
            }
            // We can also create the same thing with using RestSharp. It will make the code less complex and do some of the parts instead of us.
            /* var client = new RestClient("https://api.covid19api.com/live/country/" + country_name + "/status/confirmed");
             client.Timeout = -1;
             var request = new RestRequest(Method.GET);
             var response = client.Get<List<CovidCases>>(request);
             if(response.IsSuccessful)
             {
                var stats = response.Data;
                cases.Text = stats[stats.Count - 1].Active.ToString();
             }
            */

            activity.IsVisible = false;
            activity.IsRunning = false;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            // https://api.covid19api.com/countries
            var hc = new HttpClient();
            var result_countries = await hc.GetAsync("https://api.covid19api.com/countries");
            if (result_countries.IsSuccessStatusCode)
            {
                var json_countries = await result_countries.Content.ReadAsStringAsync();

                var countries = JsonConvert.DeserializeObject<List<CovidCases>>(json_countries);
                foreach (var item in countries.Select(f => f.Country).OrderBy(f => f))
                {
                    CountryPicker.Items.Add(item);
                }
            }
            countries_add.Text = "Countries Added";
            countries_add.IsVisible = true;
        }
    }
}
