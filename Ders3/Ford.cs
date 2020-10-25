using System;
using System.Collections.Generic;
using System.Text;

namespace Ders3
{
    //Birçok interface miras alınabilir ancak birden fazla sınıf miras alınamaz.(tek bir sınıf)
    public class Ford : Car
    {

        //Araca özel ekstra değişken tanımlayıp eklemek istersek, bu class'a özel constructor oluşturuyoruz
        //Bu constructor'u, bu sınıfın miras aldığı sınıfın da görmesi gerek olduğu için aşağıdaki gibi oluşmasını sağlarız.
        //Miras alınan sınıfa yönlendirildiği için base() anahtar sözcüğünü kullandık
        //Eğer başka bir sınıfa yönlendirmek istersek(mesela ana sınıfı miras alan başka sınıfa) this() anahtar sözcüğünü kullanacaktık.
        public string uretim_yeri { get; set; }
        public Ford(string marka, string model, string renk, int beygir, string uretim_yeri) : base(marka, model, renk, beygir)
        {
            this.uretim_yeri = uretim_yeri;
        }
        //Aracların yapabilecekleri ile ilgili birkac class tanımladık.
        public override void Calistir()
        {
            Console.WriteLine("Ford Aracı Calistirildi");
        }
        public override void Hizlan()
        {
            Console.WriteLine("Ford Aracı Hizlaniyor");
        }

        public override void Yavasla()
        {
            Console.WriteLine("Ford Aracı Yavaslıyor");
        }
        public override void Dur()
        {
            Console.WriteLine("Ford Aracı Durdu");
        }
    }
}
