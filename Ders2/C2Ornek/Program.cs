using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2Ornek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Merhaba Dünya");
            int sayi = 32;
            //System.Int32 sayi1 = 10; C#'da her şey bir nesne olduğu için, bir değeri böyle de tanımlayabiliriz.(Nesne kullanarak)
            //Console.WriteLine(sayi + sayi1);
            var sayi3 = 10; //var ile türünü biz belli etmesek bile sistem kendi algılıyor
            //sayi. diye baktığımızda kullanabileceğimiz nesneler görülebilir
            //const int sayi5 = 25; //(javadaki static)
            //const int sayi4; const bir değişkene değer atama direkt yapılmalıdır. Sonradan klavye ile konsol üzerinden yapılamaz!
            String s1 = "Merhaba";
            String s2 = "Dünya";
            Console.WriteLine(s1 + s2);//stringler '+' ile birleştirilebilir.
            Console.WriteLine("{0} plus {1} equals {2}", sayi, sayi3, sayi + sayi3);//böyle de yazdırılabilir(%d gibi)
            Console.ReadLine();
        }
    }
}
