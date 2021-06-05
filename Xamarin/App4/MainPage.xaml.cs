using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App4
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            Accelerometer.ReadingChanged += HandleReadingChanged;
            Gyroscope.ReadingChanged += Gyroscope_ReadingChanged;
            Magnetometer.ReadingChanged += Magnetometer_ReadingChanged;
            Compass.ReadingChanged += Compass_ReadingChanged;
         
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {
            compass.Text = "Compass = " + e.Reading.HeadingMagneticNorth.ToString();
        }

        protected override void OnAppearing()
        {
            Accelerometer.Start(SensorSpeed.UI);
            Gyroscope.Start(SensorSpeed.UI);
            Magnetometer.Start(SensorSpeed.UI);
            Compass.Start(SensorSpeed.UI);
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Accelerometer.Stop();
            Gyroscope.Stop();
            Magnetometer.Stop();
            Compass.Stop();
            base.OnDisappearing();
        }

        private void Magnetometer_ReadingChanged(object sender, MagnetometerChangedEventArgs e)
        {
            magneto.Text = "Magnetometer X, Y, Z = " + e.Reading.MagneticField.ToString();
        }

        private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
        {
            rotation.Text = "Gyroscope X, Y, Z = " + e.Reading.AngularVelocity.ToString();
        }

        private void HandleReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            AccelX.Text = "Accelerometer X = " + e.Reading.Acceleration.X.ToString();
            AccelY.Text = "Accelerometer Y = " + e.Reading.Acceleration.Y.ToString();
            AccelZ.Text = "Accelerometer Z = " + e.Reading.Acceleration.Z.ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var result = await Geolocation.GetLocationAsync();
            location.Text = $"Longitude = {result.Longitude} Latitude = {result.Latitude} Altitude = {result.Altitude}";
        }
    }
}
