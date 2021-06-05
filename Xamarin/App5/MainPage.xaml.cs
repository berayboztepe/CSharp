using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public partial class MainPage : ContentPage
    {
        private SQLiteConnection conn;

        public MainPage()
        {
            InitializeComponent();
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db");
            conn = new SQLiteConnection(path);

            conn.CreateTable<Fruit>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var names = new string[] {"Apple", "Banana", "Cherry", "Dorian", "Grape"};
            var random = new Random();

            conn.Insert(new Fruit { Name = names[random.Next(names.Length)], Weight = random.NextDouble(), IsSweet = random.NextDouble() < 0.5});

        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            listview.ItemsSource = conn.Table<Fruit>().ToList();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            listview.ItemsSource = conn.Table<Fruit>().Where(f => f.IsSweet == true).ToList();
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            var list = conn.Table<Fruit>().ToList();
            var random = new Random();

            var elem = list[random.Next(list.Count)];

            conn.Delete(elem);
        }
    }
}
