using System;
using System.Threading;

namespace Ders10
{
    /*Yönetilebilir Kod
      .NET platformuna hedef alan kod parçacıklarına ifade eder ve sanal makinenin özelliklerinden faydalanmaya yönetilebilir kod denir. C#, C++ vb.
    C gibi .NET ile uyumluluğu olmayan diller ise yönetilemeyen kod olarak geçer.*/
    class Program
    {
        static void Main(string[] args)
        {
            //main kısmı foreground threaddir.
            string state = "Gelen ifade: Merhaba Bilgisayar Mühendisliği";
            ThreadPool.QueueUserWorkItem(ThreadProc, state);//aynı zamanda bir ifade gönderip thread çalışırken yazdırmamız mümkün
            //birden çok threadin eş zamanlı çalışmasını istersek birden fazla QueueUserWorkItem çalıştırmamız gerekir.
            //Aynı anda işlemci başına maksimum 250 çalışan thread bulunabilir.
            Console.WriteLine("Ana thread işlem yapıyor. Ardından uyumakta");
            if (Thread.CurrentThread.IsBackground == false) Console.WriteLine("Önplan True");
            Thread.Sleep(5000);//5 saniye uyutuyoruz threadi
            Console.WriteLine("Ana threadden çıkılıyor");
        }
        //bu kısım ise background threaddir.
        public static void ThreadProc(object stateinfo)
        {
            //Console.WriteLine("Thread Çalışıyor");
            Console.WriteLine(stateinfo.ToString());
            if (Thread.CurrentThread.IsBackground) Console.WriteLine("Arkaplan True");//bu threadin background thread olup olmadığını test ediyoruz
        }
    }
}
