using System;
using System.Collections.Generic;

namespace vaow
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sayilar = new List<int>();
            sayilar.Add(5);
            sayilar.Add(3);
            sayilar.Add(2);
            sayilar.Add(9);
            sayilar.Add(7);
            sayilar.Add(15);

            Console.WriteLine(sayilar[2]);
            sayilar.Remove(2);
            Console.WriteLine(sayilar[2]);


            //belirtlien indexteki sayıyı atmak için
            sayilar.RemoveAt(2);
            Console.WriteLine(sayilar[2]);

            //uzunluk bulmak için
            int uzunluk = sayilar.Count;
            Console.WriteLine("Uzunluk = " + uzunluk);

            //listenin içinde belirtilen sayı var mı yok mu bulmak için
            Console.WriteLine(sayilar.Contains(15));

            //listenin tamamını temizlemek
            sayilar.Clear();
            Console.ReadLine();

        }
    }
}
