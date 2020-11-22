using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders7
{
    class Program
    {

        class MathOperations
        {
            public static double Multiply2(double x)
            {
                return x * 2;
            }
            public static double Square(double x)
            {
                return x * x;
            }
        }

        delegate double Math(double x);


        static void Main(string[] args)
        {
            Mainislem();
            //Görüldüğü gibi delegate, double türünden değişken alan tüm metotlara işaret ediyor!
            //aynı ana class içerisinde farklı subclasslarda bile olsalar delegate işaret edebilir.
            //ama aynı ana classta olmalı!!
            Math[] operations =
            {
                MathOperations.Multiply2,
                MathOperations.Square
            };
            //Burada yaptığımız şey, bir diziye 2 metod ataması yaptık. () kullanmadık çünkü adresine işaret edeceğiz!
            //0. indeksteki eleman 2 ile çarpılma metodunu gösterdiği için parantez içinde girdiğimiz değeri o metoda götürecek
            //1. indeksteki eleman kare metodunu gösteriyor!
            Console.WriteLine("2 ile çarpılmış hali = " + operations[0](8));
            Console.WriteLine("Karesi = " + operations[1](8));
            //burada metod parametre olarak başka bir metod alıyor! operaitons[0](8) işleminin aynısı!
            Fonksiyonparametre(operations[0], 8);

            //Kolayca delegate tanımlama. Geriye bir şey return ettirmek istersek kullanabiliriz!
            //int değer alan, geriye int değer döndüren Metot2 metodu
            //aldığı parametrenin ismi x, döndürdüğü değer 10(x'e hangi değer gönderilirse gönderilsin 10'u döndürür!)
            Func<int, int> Metod2 = (x) => 10;
            Func<int, int> Metod3 = (x) => x;//x'i döndürür!

            Console.WriteLine("Sadece 10 döndüren metod = " + Metod2(42));
            Console.WriteLine("X döndüren metod = " + Metod3(42));

            Func<int, int, int> Metod4 = (x, y) => x * y;//2 parametre alıp çarpımlarını döndüren delegate
            Console.WriteLine("x * y döndüren metod = " + Metod4(7,5));
            //=> den sonra gelen kısım fonksiyonun gövdesi. Yani oraya kodlar yazabiliriz!
            Func<string, string, int> Metot5 = (x, y) =>
            {
                return String.Compare(x, y);
            };
            Console.WriteLine("Metod 5'in çıktısı = " + Metot5("5", "10"));

            //action ise geriye bir şey döndürmeyeceğimiz zaman kullanabileceğimiz bir metod! (void işlevi görür)
            //parametre alabilir!
            Action<int> Metod6 = x => Console.WriteLine("Metod6'nın çıktısı = " + x);
            Metod6(42);
        }


        public delegate string Deneme();
        public delegate string Deneme1(string a, string b);

        //biz buraya parametre alacağımızı söylesek kod hata verir.
        //public delegate string Deneme(string a, string b);
        //ama böyle yapsak:
        static string Metot1(string a, string b)
        {
            return "Bilgisayar";
        }
        //Deneme Getstring3 = Metot1; yaptığımızda hata almayız!
        static void Mainislem()
        {
            int x = 42;
            Deneme GetString = new Deneme(x.ToString);
            //bu şekilde de oluşturabiliriz. Yine () olmayacak!!
            Deneme GetString2 = x.ToString;
            Console.WriteLine("Değişken = {0}", GetString2());
            //Deneme GetString = new Deneme(x.ToString()) böyle yapamayız!!! Çünkü delegate ile metodun adresini işaret etmemiz gerek
            //() koyduğumuz taktirde adresine işaret edemeyiz!!
            Console.WriteLine("Değişken = {0}", GetString());
            //veya
            Console.WriteLine("Değişken = {0}", GetString.Invoke());
            Deneme1 Getstring3 = Metot1;
        }

        //Bir metod parametre olarak başka metod alabilir! Burada parametre olarak aldığı metod delegate metodu
        static void Fonksiyonparametre(Math math, double x)
        {
            double result = math(x);
            Console.WriteLine("Gönderilen değerin işlem sonucu = " + result);
        }
    }
}
