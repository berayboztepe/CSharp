using System;

namespace Ders3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car arac1 = new Car("Ford", "Fiesta", "Yesil", 150);//yeni arac oluşturduk
            //Car arac2 = new Car();//boş constructordan yardım aldık

            Ford arac = new Ford("Ford", "Fiesta", "Kırmızı", 175, "Fransa");
            Car arac1 = new Ford("Ford", "Fiesta", "Beyaz", 150, "Polonya");//ford aynı zamanda bir car olduğu için böyle de tanımlanabilir. Ancak 2 aynı isimli fonksiyon varsa
            //hem Ford'da hem de Car'da, Car'da bulunan fonksiyon çalışır.
            //Eğer ben hem böyle yapıp hem de araca özel fonksiyonları çalıştırmak istersem
            //Car'daki fonksiyona virtual, araçlardaki fonksiyona override eklerim

            //ICar arac3 = new ICar();
            //yaparsak hata verir. interfacelerin içinde bir implementasyon(gövdeli fonksiyonlar) olmadığı için 
            //interfacelerden nesne oluşturamayız

            ICar arac3 = new Ford("Ford", "A3", "Siyah", 120, "Almanya");
            //Ancak her ford aynı zamanda bir ICAR olduğu için böyle bir tanımlama yapabiliriz


            //Car arac2 = new Car();
            //Ancak böyle bir tanımlama yapamayız. Çünkü Car sınıfı abstract bir sınıf olduğu ve içinde implement edilmeyen bir fonksiyon olduğu için
            //direkt kendisini kullanamayız ancak onu miras alan diğer sınıfları kullanabiliriz.
                arac.Calistir();
            
            
                arac1.Calistir();
            
            
                arac3.Dur();

            Console.ReadLine();
        }
    }
}
