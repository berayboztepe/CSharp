using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders5
{
    class Lambda
    {
        //name beray'a eşitse True döndür
        //predicate = c#'da geriye bool ifade döndüren metodlara verilen isim
        public static bool FindBeray(Employee e)
        {
            return e.Name == "Beray";
        }
        static void Main(string[] args)
        {
            //Employee sınıfından bir dizi oluşturuyoruz. İşçilerin isimleri ve ID'leri var burada
            //illa dizi olmasına gerek yok. SQL olabilir XML olabilir. Her türlü sorgu yapılabilir.
            Employee[] calisanlar = new Employee[]
            {
                new Employee{ Name = "Beray", ID = 1 },
                new Employee{ Name = "Emre", ID = 2},
                new Employee{ Name = "Emel", ID = 3},
                new Employee{ Name = "Ümit", ID = 4},
                new Employee{ Name = "Cemre", ID = 5},
                new Employee{ Name = "Dilay", ID = 6}
            };
            //Alternatif 1
            //kendi ismimizi bulan bir fonksiyon yazdık, onu çalıştıralım. calisanlar üzerinde sorgulama yapacağız. bu isimli metod örneği
            //hangi array üzerinde çalışacak=calisanlar, hangi fonksiyon üzerinde çalışacak=FindBeray
            //Array.find = aranacak dizi üzerinde geriye True ya da False ifade döndüren metodlar(predicate) parametre istiyor.
            //Eğer ifade yoksa yazdıramayız, hata verir(beray'ı silersek**)
            var query1 = Array.Find(calisanlar, FindBeray);
            Console.WriteLine(query1.ID + " " + query1.Name);

            //Alternatif 2
            //Bunun amacı ise isimsiz metod(delegate(pointer) yardımı ile) aynı sonucu elde ederiz.
            var query2 = Array.Find(calisanlar, delegate (Employee e)
            {
                return e.Name == "Beray";
            });
            Console.WriteLine(query2.ID + " " + query2.Name);

            //Alternatif 3
            //bu sefer lambda ifadeleri ile yukarıda yaptığımız işlemlerle aynı sonucu elde ederiz.
            //e => ifadesi bir lambda ifadesidir. Lambda ifadeleri de metotdur. return kısmı metodun gövdesidir.
            var query3 = Array.Find(calisanlar, e =>
            {
                return e.Name == "Beray";
            });
            Console.WriteLine(query3.ID + " " + query3.Name);

            //Alternatif 4
            //aynı sorgunun ters sql ile yazılması. Alttakine göre daha pratik
            var query4 = from e in calisanlar
                         where e.Name == "Beray"
                         select e;

            //Alternatif 5
            //aynı sorguyu extension metodlar ile yazdık. Extension metodlarda lambda ifadeleri kullanılıyor.
            var query5 = calisanlar.Where(e => e.Name == "Beray").Select(e => e);
        }
    }
}
