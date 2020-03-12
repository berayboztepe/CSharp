using System;

namespace Consoletry
{
    class Program
    {
        static void Main(string[] args)
        {
            //çıktı yazdırmak için kullanılır..
            Console.WriteLine("Hello World!");
            //bir tuşa basana kadar konsolu açık tutması için kullanılır..
            // Console.ReadLine();

            string a = "3";
            string b = "5";
            string c = "5";
            Console.WriteLine(a + b + c);

            // sayıları string olarak girmişken integera çevirdik...
            int d = Convert.ToInt32(a) + Convert.ToInt32(b) + Convert.ToInt32(c);
            Console.WriteLine(d);





            Console.ReadLine();
        }
    }
}
