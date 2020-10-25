using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ilk Sayiyi Girin: ");
            var sayi1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ikinci Sayiyi Girin: ");
            var sayi2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Iki Sayının Toplami = "+ DortIslem.MatematikselIslemler.Topla(sayi1, sayi2));
            //Diğer classta Topla sınıfı static olduğu için burada, static main'de o sınıfı çalıştırmak için nesne oluşturmadan bu yöntemle
            //çalıştırabiliriz!!!
            DortIslem.MatematikselIslemler cikarma = new DortIslem.MatematikselIslemler();
            //Ancak Cikar sınıfı static olmadığı için, çalıştırmak için nesne oluşturmamız gerekir!!!!
            Console.WriteLine("Iki Sayının Farkı = "+cikarma.Cikar(sayi1, sayi2));

            Console.ReadLine();
        }
    }
}
