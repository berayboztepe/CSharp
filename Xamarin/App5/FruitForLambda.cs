using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App5
{
    class FruitForLambda
    {
        public string Name { get; set; }
        public double Weight { get; set; }
    }


    class Program
    {
        public void Main(string[] args)
        {
            var fruit = new List<FruitForLambda>();

            fruit.Add(new FruitForLambda { Name = "Apple", Weight = 1.0 });
            fruit.Add(new FruitForLambda { Name = "Banana", Weight = 1.5 });
            fruit.Add(new FruitForLambda { Name = "Grape", Weight = 0.1 });
            fruit.Add(new FruitForLambda { Name = "Durian", Weight = 2.0 });
            fruit.Add(new FruitForLambda { Name = "Cherry", Weight = 0.5 });

            foreach (var item in fruit.Where(f => f.Name.Contains("e"))
                .Select(f => f.Weight)
                .OrderBy(f => f))
            {
                Console.WriteLine(item);
            }
        }
        

    }
}
