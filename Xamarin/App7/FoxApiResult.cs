
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace App7
{

    public class FoxApiResult : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string imageUrl { get; set; }
        public string name { get; set; }

        private int _loves;
        private int _hates;

        public int loves
        {
            get
            {
                return _loves;
            }

            set
            {
                _loves = value;
                OnPropertyChanged();
            }
        }
        public int hates
        {
            get
            {
                return _hates;
            }

            set
            {
                _hates = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}
