using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2
{
    class KilFruit : INotifyPropertyChanged
    {
        private string namee;
        public string Namee
        {
            get { return namee; }
            set
            {
                if (value != namee)
                {
                    namee = value;
                    OnPropertyChanged();
                }
            }
        }
        private string kiloo;
        public string Kiloo
        {
            get { return kiloo; }
            set
            {
                if (value != kiloo)
                {
                    kiloo = value;
                    OnPropertyChanged();
                }
            }
        }
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
