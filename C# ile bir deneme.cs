using System;

namespace hadiyav
{
    class Program
    {
        static void Main(string[] args)

        {
            //kullanıcıdan girdi alıp karesini, faktoriyelini, küpünü ve 3n+1 ini bulan program
            Console.WriteLine("Bir sayı giriniz:");
            string girdi = Console.ReadLine();
            //int girdi = Convert.ToInt32(Console.ReadLine()); aynısı

            int kare = Convert.ToInt32(girdi) * Convert.ToInt32(girdi);
            Console.WriteLine("Sayının karesi = ");
            Console.WriteLine(kare);


            int fakt = 1;
            int i = 1;
            while(i <= Convert.ToInt32(girdi))
            {
                fakt *= i;
                i++;
            }
            Console.WriteLine("Sayının faktoriyeli = ");
            Console.WriteLine(fakt);


            int kup = Convert.ToInt32(girdi) * Convert.ToInt32(girdi) * Convert.ToInt32(girdi);
            Console.WriteLine("Sayının küpü = ");
            Console.WriteLine(kup);


            int n = (3 * Convert.ToInt32(girdi)) + 1;
            Console.WriteLine("Sayının 3n+1'i = ");
            Console.WriteLine(n);

            Console.ReadLine();
        }
    }
}
