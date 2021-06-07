using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App7
{
    public partial class MainPage : ContentPage
    {
        private RestClient client;

        public MainPage()
        {
            InitializeComponent();
            client = new RestClient("https://foxapi.ktos.dev/api");
            client.Authenticator = new HttpBasicAuthenticator("username", "password");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateList();
        }

        private void UpdateList()
        {
            var result = client.Get<List<FoxApiResult>>(new RestRequest("/fox"));
            if (result.IsSuccessful)
            {
                items.ItemsSource = result.Data;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            UpdateList();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var obj = ((sender as Button).BindingContext as FoxApiResult);

            var result = client.Put(new RestRequest("/fox/love/" + obj.id));
            if (result.IsSuccessful)
            {
                var fox = client.Get<FoxApiResult>(new RestRequest("/fox/" + obj.id));
                if (fox.IsSuccessful)
                {
                    obj.loves = fox.Data.loves;
                    obj.hates = fox.Data.hates;
                }
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            var obj = ((sender as Button).BindingContext as FoxApiResult);

            var result = client.Put(new RestRequest("/fox/hate/" + obj.id));
            if (result.IsSuccessful)
            {
                var fox = client.Get<FoxApiResult>(new RestRequest("/fox/" + obj.id));
                if (fox.IsSuccessful)
                {
                    obj.loves = fox.Data.loves;
                    obj.hates = fox.Data.hates;
                }
            }
        }
    }
}
