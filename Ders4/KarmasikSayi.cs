using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders4
{
    class KarmasikSayi
    {
        private double mgercek;
        private double msanal;

        public double Gercek
        {
            get { return mgercek; }
            set { mgercek = value; }
        }

        public double Sanal
        {
            get { return msanal; }
            set { msanal = value; }
        }

        public KarmasikSayi(double x, double y)
        {
            mgercek = x;
            msanal = y;
        }

        public KarmasikSayi()
        {
            mgercek = 0;
            msanal = 0;
        }

        //operatör tanımladığımız zaman, bu iki karmaşık sayının toplanmasını sağlayabiliriz.
        //Gerçek sayıların birbiri arasında, sanal sayıların da birbiri arasında toplanmasını sağlarız
        //bunu static olarak kullanırız, bir nesne olarak değil. Bu da aslında kendi başına bir metod.
        //Geriye döndürdüğü şey, object türünden olmalı.
        public static KarmasikSayi operator +(KarmasikSayi a, KarmasikSayi b)
        {
            double gt = a.Gercek + b.Gercek;
            double st = a.Sanal + b.Sanal;
            return new KarmasikSayi(gt, st);
        }

        //Ancak bir karmaşık sayı ile normal bir sayıyı toplayamayız. Bunun için başka bir operatör oluşturuyoruz.
        //Burada bir karmaşık sayı ile gerçek sayıyı topluyoruz.
        public static KarmasikSayi operator +(KarmasikSayi a, double x)
        {
            double gt = a.Gercek + x;
            return new KarmasikSayi(gt, a.Sanal);
        }
        //Burada ise bir sayı ile karmaşık sayıyı topluyoruz.
        public static KarmasikSayi operator +(double x, KarmasikSayi a)
        {
            return a + x;
        }
        //Karmaşık sayılarda çarpma işlemi
        public static KarmasikSayi operator *(KarmasikSayi a,
                                                             KarmasikSayi b)
        {
            double sanal1 = a.Gercek * b.Sanal;
            double sanal2 = a.Sanal * b.Gercek;
            double sc = sanal1 + sanal2;

            double gercek1 = a.Gercek * b.Gercek;
            double gercek2 = a.Sanal * b.Sanal;
            double gc = gercek1 - gercek2;
            return new KarmasikSayi(gc, sc);
        }
        //Karmaşık sayılarda bölme işlemi
        public static KarmasikSayi operator /(KarmasikSayi a,
                                                    KarmasikSayi b)
        {
            KarmasikSayi beslenik = new KarmasikSayi(b.Gercek, -
            b.Sanal);
            KarmasikSayi pay = a * beslenik;
            double payda = b.Gercek * b.Gercek + b.Sanal * b.Sanal;

            double bolumGercek = pay.Gercek / payda;
            double bolumSanal = pay.Sanal / payda;
            return new KarmasikSayi(bolumGercek, bolumSanal);
        }



        public KarmasikSayi(KarmasikSayi k)
        {
            mgercek = k.mgercek;
            msanal = k.msanal;
        }

        //İLİŞKİSEL OPERATÖRLER
        //== operatörü
        public static bool operator ==(KarmasikSayi a,
                                                    KarmasikSayi b)
        {
            if (a.Sanal == b.Sanal && a.Gercek == b.Gercek)
                return true;
            else return false;
        }
        //!= operatörü
        //== varsa != olmak zorundadır(zıt operatörler aynı anda olmalı)
        public static bool operator !=(KarmasikSayi a,
        KarmasikSayi b)
        {
            return !(a == b);
        }

        //True-False Operatörleri
        public static bool operator true(KarmasikSayi a)
        {
            if (a.Sanal != 0 || a.Gercek != 0)
                return true;
            else return false;
        }
        public static bool operator false(KarmasikSayi a)
        {
            if (a.Sanal == 0 || a.Gercek == 0)
                return true;
            else return false;
        }

        //Mantıksal Operatörler
        //İkili mantıksal operatörlerin olması için, true ve false operatörleri ve tekli mantıksal operatörler bulunmalı!!!!
        //| operatörü
        public static bool operator |(KarmasikSayi
                                                    a, KarmasikSayi b)
        {
            if ((a.Sanal != 0 || a.Gercek != 0) | (b.Sanal != 0
            || b.Gercek != 0))
                return true;
            else return false;
        }
        //& operatörü
        public static bool operator &(KarmasikSayi
        a, KarmasikSayi b)
        {
            if ((a.Sanal == 0 || a.Gercek == 0) & (b.Sanal == 0
            || b.Gercek == 0))
                return false;
            else return true;
        }
        //! operatörü
        public static bool operator !(KarmasikSayi a)
        {
            if ((a.Gercek != 0) | (a.Sanal != 0))
                return false;
            else return true;
        }
        //Dönüşüm Operatörleri
        //biçimli
        public static implicit operator int(KarmasikSayi b)
        {
            return (int)b.Gercek;
        }
        //veya biçimsiz
        /*public static explicit operator int(KarmasikSayi b)
        {
            return b.Gercek;
        }   */



        public void yaz()
        {
            if (msanal > 0)
            {
                Console.WriteLine("{0} + {1}i", mgercek, msanal);
            }
            else
            {
                Console.WriteLine("{0} - {1}i", mgercek, -msanal);
            }
        }
    }
}
