using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5
{
    class Fruit
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public bool IsSweet { get; set; }

    }
}
