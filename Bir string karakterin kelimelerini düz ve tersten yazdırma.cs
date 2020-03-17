using System;
using System.Collections.Generic;

namespace vaow
{
    class Program
    {
        static void Main(string[] args)
        {
            //Girilen bir kelimeyi harf harf alt alta yazdıran program
            Console.WriteLine("Bir kelime giriniz:");
            string kelime = Console.ReadLine();

            foreach (char karakter in kelime)
            {
                Console.WriteLine(karakter);
            }
            //Girilen bir metni tersten yazdıran program
            Console.WriteLine("Bir kelime giriniz:");
            string kelime1 = Console.ReadLine();

            for (int i = kelime1.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(kelime1[i]);
            }




            Console.ReadLine();
        }
    }
}