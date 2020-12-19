using System;
using System.Collections.Generic;

namespace Ders9
{
    /*listeler, kuyruklar, yığınlar, hashler vb. Veri yapıları örneklerini içerir.
    2 türlüdür. Object türünde, şablon türünde sınıfları kullanan koleksiyonlar
    tüm koleksiyonlar, üzerinde foreach döngüsü ile gezilebilen yapılardır.
    arraylistin normal koleksiyon hali arraylist iken şablon hali arraylist<T> değil, list<T>! diğerilerinden tek farklı olan
    
     
     */
    class Collections
    {
        static void Main(string[] args)
        {
            //Listeler ve listeye eleman ekleme
            List<int> intList = new List<int>();
            Ekle(intList);
            //Console.WriteLine("{0}", intList[1]);

            //bu şekilde range ile de birden fazla sayı ekleyebiliriz.
            //Addrange sadece IEnumerable nesneleri kabul edebilir(yani üzerinde dönülebilecek nesneler (dizinin üzerinde dönülebilir)
            intList.AddRange(new int[]{3, 4, 5, 6, 7});

            //elemanların üzerinde foreach ile dönmek istersek
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }

            //Belli bir konuma eleman eklemek istersek. 2. indekse 10'u ekliyor.
            intList.Insert(2, 10);

            Console.WriteLine("\n\n");
            //Elemanları yazdırmak için
            for(int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine(intList[i]);
            }

            //Eleman silmek için. 3 numaralı indeksteki elemanı sil
            intList.RemoveAt(3);

            Console.WriteLine("\n\n");

            for (int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine(intList[i]);
            }

            Console.WriteLine("\n\n");
            //Belli bir aralığı silmek istersek. 3'ten başla 2 tane sil(3'ü ve ardından geleni)
            int indextostart = 3;
            int count = 2;
            intList.RemoveRange(indextostart, count);

            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            //Arama işlemleri. Indeksi ya da kendisi elde edilir.
            //Değer varsa onun indeksini, yoksa -1 döndürür.
            Console.WriteLine(intList.IndexOf(77));
            Console.WriteLine("\n\n");
            //Sort ile sıralama yapabiliriz.
            intList.Sort();
            foreach (int item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");

            //Kuyruklar
            //Queue ve Queue<T> olmak üzere iki çeşittir. FIFO(first in first out) prensibine göre çalışır.
            //Enqueue() ile kuyruğun sonuna eleman ekleme, Dequeue() ise kuyruktan eleman çıkarmak ve okumak için kullanılır.

            Queue<string> que = new Queue<string>();
            que.Enqueue("emre");
            que.Enqueue("beray");
            que.Enqueue("boztepe");
            foreach (string item in que)
            {
                Console.WriteLine(item);
            }
            que.Dequeue();
            Console.WriteLine("\n\n");
            foreach (string item in que)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            //Yığınlar
            //LIFO(last in first out) veya FILO(first in last out) ile çalışır.
            //Push() ile en üstüne eleman eklenir. Pop() ile en üstteki itemi döndürür ve çıkarır.
            //Count() ile eleman sayılır. Peek() ile elemanları okuruz ama çıkarmayız. Kuyruklarda da bu iki metot kullanılır!

            Stack<char> st = new Stack<char>();
            st.Push('a');
            st.Push('b');
            st.Push('c');
            foreach (char item in st)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
            st.Pop();
            foreach (char item in st)
            {
                Console.WriteLine(item);
            }

            //İkili Bağlı Listeler
            //hem sonraki hem de önceki elemanların adreslerini tutar.

            //Sıralı Listeler
            //Anahtar değerine göre koleksiyondaki elemanları sıralar
            Console.WriteLine("\n\n");
            SortedList<string, string> sl = new SortedList<string, string>();
            sl.Add("türkiye", "ankara");
            sl.Add("italya", "roma");
            sl["ukrayna"] = "kiev";

            //Baş harfi alfabede daha önce olan daha önce yazdırılır.
            //KeyValuePair yerine var da yazılabilir.
            foreach (KeyValuePair<string, string> item in sl)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }

            Console.WriteLine("\n\n");

            //Sözlükler
            //hash table veya maps olarak bilinir. Hızlı şekilde arama yapılabilir.
            //Key verip Value elde ediyoruz. En çok kullanılanı Dictionary<TKey, TValue>. Yapısı SortedListe benziyor.
        }
        static List<int> Ekle(List<int> intList)
        {
            intList.Add(1);
            intList.Add(2);
            return intList;
        }
    }
}
