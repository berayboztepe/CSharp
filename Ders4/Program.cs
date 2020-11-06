using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders4
{
    //Extension denemesi
    //This anahtar sözcüğü eklenmeden önce: True ya da false değer veriyor.
    //Extension metodu haline getirirsek, textin kullanabileceği bir method haline gelir.
    static class StringExtensions
    {
        public static bool IsValidPostalCode(this string value)
        {
            return value.Length == 5 || value.Length == 9;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //gönderdiğimiz parametrelere göre karmaşık sayı oluşturuyor ve yazdırıyor.
            //2 parametre = sanal ve gerçek, hiç parametre = 0 + 0i, tek parametre = sadece daha önce oluşturduğumuz bir nesneyi gönderebiliyoruz.

            //yani KarmasikSayi k = new KarmasikSayi(-5, 4);
            //KarmasikSayi k1 = new KarmasikSayi(k);
            //k.yaz();
            //k1.yaz(); gönderirsek yazacağı çıktılar aynı olacaktır.

            KarmasikSayiCalistir();

            KarmasikSayiTopla();

            KarmasikSayiIleGercekSayiTopla();

            GercekSayiIleKarmasikSayiTopla();

            string text = "43.31";
            //var data = StringExtensions.IsValidPostalCode(text); before this
            //Extension methodlarının görünümünde aşağıya doğru bakan ok gözükür**
            var data = text.IsValidPostalCode();//parametre koymaya da gerek kalmadı**
            Console.WriteLine(data);

        }


        static void KarmasikSayiCalistir()
        {
            KarmasikSayi k = new KarmasikSayi(-5, 4);
            k.yaz();
        }

        static void KarmasikSayiTopla()
        {
            KarmasikSayi k = new KarmasikSayi(-5, 4);
            KarmasikSayi k1 = new KarmasikSayi(2, 6);
            KarmasikSayi k3 = k + k1;
            k3.yaz();
        }

        static void KarmasikSayiIleGercekSayiTopla()
        {
            KarmasikSayi k6 = new KarmasikSayi(2, 1);
            KarmasikSayi k7 = k6 + 10;
            k7.yaz();
        }
        static void GercekSayiIleKarmasikSayiTopla()
        {
            KarmasikSayi k4 = new KarmasikSayi(1, -5);
            KarmasikSayi k5 = 7 + k4;
            k5.yaz();
        }


    }
}
