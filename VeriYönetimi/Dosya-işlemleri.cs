using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            
            foreach(DriveInfo cd in DriveInfo.GetDrives())
            {
                //sistemdeki driverları gösteren program
                Console.WriteLine("{0} ({1})", cd.Name, cd.DriveType);
            }
            Console.WriteLine("\n\n************************************\n\n");


            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("Klasörler");
            Console.WriteLine("*****************");
            foreach(DirectoryInfo dirInfo in dir.GetDirectories())
            {
                //Windows klasöründeki dizinleri yazar
                Console.WriteLine(dirInfo.Name);
            }
            Console.WriteLine("\nDosyalar");
            Console.WriteLine("*************");
            foreach(FileInfo fi in dir.GetFiles())
            {
                //Windows dizinindeki dosyaları yazar
                Console.WriteLine(fi.Name);
            }

            //Klasör oluşturmak için. Eğer bu dosya varsa hata mesajı döndürecek
            DirectoryInfo direc = new DirectoryInfo(@"C:\deneme");
            if (direc.Exists)
            {
                Console.WriteLine("Bu dosya zaten var!");
            }
            else
            {
                direc.Create();
            }
            
            //Dosya işlemleri
            File.CreateText("deneme.txt");
            //File.Copy("deneme.txt", "deneme1.txt"); dosyayı kopyalamak için
            //File.Move("deneme1.txt", "gecici.txt"); dosyayı taşımak için 

            Console.WriteLine("\n\n************************************\n\n");

            //Metin dosyalarını okuma ve yazma
            TextReader tr = File.OpenText(@"C:\\Windows\\win.ini");//win.ini dosyalarını okumamızı sağlar
            Console.WriteLine(tr.ReadToEnd());
            tr.Close();

            //Bunu yapmanın diğer yolu=Streamreader fonksiyonunun yardımı ile
            StreamReader sr = new StreamReader(@"C:\\Windows\\win.ini");
            string input;
            while((input=sr.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }


            Console.WriteLine("\n\n************************************\n\n");

            //Binary dosyalarını okuma ve yazma işlemi için
            //Yazma
            FileStream fs = new FileStream("data.bin", FileMode.Create);//dosya oluşturuluyor
            BinaryWriter w = new BinaryWriter(fs);//binarywriter, filestream sınıfını kullanıyor. binary yazmaya yardımcı olur. 
            for(int i = 0; i < 11; i++)
            {
                w.Write((int)i);
            }
            w.Close();
            fs.Close();

            //Okuma
            FileStream fs1 = new FileStream("data.bin", FileMode.Open, FileAccess.Read);
            BinaryReader r = new BinaryReader(fs1);
            for(int i = 0; i < 11; i++)
            {
                Console.WriteLine(r.ReadInt32());
            }
            r.Close();
            fs1.Close();
            
            //String okuma ve String yazma
            //String Yazma
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            sw.Write("Merhaba");
            sw.Write("Dünya");
            sw.Close();

            //String Okuma
            StringBuilder sb1 = new StringBuilder();
            StringReader sr1 = new StringReader(sb1.ToString());
            sr1.Close();
            


            //Stream bir byte dizisidir. Ben bu byte dizisini belleğe yazabilirim, networkten gönderirim, dosyaylaa yazabilirim.
            //Bir stream üzerinden dosya içerisine dökmek istediğimiz stringi yazıyoruz.
            MemoryStream ms = new MemoryStream();
            StreamWriter sw1 = new StreamWriter(ms);
            sw1.WriteLine("Merhaba");
            sw1.Flush();
            ms.WriteTo(File.Create("memory.txt"));
            sw1.Close();
            ms.Close();

            //Sıkıştırma algoritmalarını kullanmak için gerekli bir sınıf var: gzipstream. mesela dosyayı zip dosyası haline getireceğiz.
            //Dosyayı sıkıştırarak alandan tasarruf edebiliriz.
            //zip dosyası oluşturmak için
            GZipStream gzout = new GZipStream(File.Create("data.zip"), CompressionMode.Compress);
            StreamWriter sw2 = new StreamWriter(gzout);
            for(int i = 0; i < 1000; i++)
            {
                sw2.WriteLine("Merhaba");
            }
            sw2.Close();
            gzout.Close();

            //zip dosyasını açıp yazmak için
            GZipStream gzin = new GZipStream(File.OpenRead("data.zip"), CompressionMode.Decompress);
            StreamReader sr2 = new StreamReader(gzin);
            Console.WriteLine(sr2.ReadToEnd());
            sr2.Close();
            gzin.Close();

            Console.ReadLine();

        }
    }
}
