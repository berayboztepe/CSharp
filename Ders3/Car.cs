using System;
using System.Collections.Generic;
using System.Text;

namespace Ders3
{
    public abstract class Car : ICar
    {
        //eğer public diye erişimini belirtmezsek, aynı ana sınıfta bile olsalar, diğer sınıftan erişemeyiz. yani mainden Car classına erişiriz
        //ama marka, model vs. çıkmaz. Private olarak tanımlanır.
        private string marka = " ";
        //private string model = " ";
        //private int beygir;
        //private string renk = " ";

        

        //private dosyalara bizim yerimize erişmeyi sağlar. Get,Set metodları!! Bunlara property denir.
        //Bunu daha pratik yoldan oluşturmak için prop yazıp 2 kere taba bas
        //public string marka { get; set; } bir marka değişkeni oluştur. Get set yardımı ile priv olan değişkeni kullanmamızı sağlar
        //ya da aşağıdaki gibi yapılır
        public string Marka
        {
            set
            {
                this.marka = value;
            }
            get
            {
                return this.marka;
            }
        }

        public string model { get; set; }
        public int beygir { get; set; }
        public string renk { get; set; }

        //parametreyi diğer classta eklemek için buradan boş ctor oluşturuyoruz.
        public Car()
        {
            
        }

        //bunlara kolay ulaşılması için bir constructor tanımlıyoruz. ctor yazıp 2 kere taba bas
        public Car(string marka, string model, string renk, int beygir)
        {
            this.marka = marka;
            this.model = model;
            this.renk = renk;
            this.beygir = beygir;
        }

        public virtual void Calistir()
        {
            Console.WriteLine("Arac Calistirildi");
        }
        public virtual void Hizlan()
        {
            Console.WriteLine("Arac Hizlaniyor");
        }

        public virtual void Yavasla()
        {
            Console.WriteLine("Arac Yavaslıyor");
        }
        //Abstract bir metod tanımlamak için mutlaka sınıfın da abstract olması gerekir ve abtract metod virtual olamaz
        //Abstract metodun gövdesi olmaz(yani içinde kod parçacığı bulunmaz)
        //Eğer bir abstract metod tanımlarsak, bu class'ı miras alan tüm classlara aynı isimli fonksiyonu yazmam gerek(implement etmem gerek)
        //gövdeli bir şekilde**
        public abstract void Dur();

        //destructor tanımlamak için ~ kullanırız. Nesne çağrılırken önce constructorlar çağrılır, etki alanı bittiğinde ise distructorlar çağrılır!
        ~Car()
        {
            Console.WriteLine("Aracın Yıkıcısı Çağrıldı...");
        }
    }
}
