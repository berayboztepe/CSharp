using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Clicked(object sender, EventArgs e)
        {
            if(DeviceInfo.Platform == DevicePlatform.Android)
            {
                battery.Text = Battery.ChargeLevel.ToString();
            }
            device.Text = $"Type: {DeviceInfo.DeviceType} Model: {DeviceInfo.Model} Manufacturer: {DeviceInfo.Manufacturer}";
            platform.Text = DeviceInfo.Platform.ToString();
            idiom.Text = DeviceInfo.Idiom.ToString();
            
            
        }
    }
}
