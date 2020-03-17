using System;
using System.Collections.Generic;

namespace vaow
{
    class Program
    {
        static void Main(string[] args)
        {
            //10 elemanlı diziye 1-200 arası rastgele sayılar atayıp (100den büyük sayıların sayısını, 150den küçük sayıların ortalamasını bulun , çift sayıların sayısını bulun)
            int[] rastdizi = new int[10];
            Random rast = new Random();
            for (int i = 0; i < 10; i++)
            {
                rastdizi[i] = rast.Next(200);
            }
            int count100 = 0;
            int count150 = 0;
            int countc = 0;
            int toplam = 0;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(rastdizi[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                if (rastdizi[i] > 100)
                {
                    count100++;
                }
                if (rastdizi[i] < 150)
                {
                    toplam += rastdizi[i];
                    count150++;
                }
                if (rastdizi[i] % 2 == 0)
                {
                    countc++;
                }

            }

            Console.WriteLine("100den büyük sayıların sayısı = " + count100);
            Console.WriteLine("150den kucuk sayıların ortalaması = " + (toplam / count150));
            Console.WriteLine("Çift olan sayıların sayısı = " + countc);

            Console.ReadLine();

        }
    }
}