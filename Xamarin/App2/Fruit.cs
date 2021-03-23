using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2
{
    class Fruit : INotifyPropertyChanged
    {
        private string name;
        public string Name 
        { get { return name; } 
            set 
            {
                if(value != name)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool available;
        public bool Available
        {
            get { return available; }
            set
            {
                if (value != available)
                {
                    available = value;
                    OnPropertyChanged();
                }
            }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                if (value != price)
                {
                    price = value;
                    OnPropertyChanged();
                }
            }
        }
        private double counter;
        public double Counter
        {
            get { return counter; }
            set
            {
                if (value != counter)
                {
                    counter = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName]string name = null)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
