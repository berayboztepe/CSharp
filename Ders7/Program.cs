using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders7
{
    class Program
    {
        static void Main(string[] args)
        {
            //görüldüğü gibi arraylistlerle işlem yapmak çok ama çok uzun sürdü! Çok ciddi performans artışı görebiliriz
            //Boxing ve Unboxing işlemi daha uzun sürmesine neden oluyor.
            metot1();
            Metot2();
            Calistirici();
        }

        //C'de yaptığımız struct örneğinin aynısı. Bir struct oluşturmak için bir class tanımladık, şablon türünde!
        public class LinkedListNode<T>
        {
            private T value;
            public LinkedListNode(T value)
            {
                this.value = value;
            }
            public T Value
            {
                get { return value; }
                set { this.value = value; }
            }
            public LinkedListNode<T> Next { get; set; }
        }

        public class LinkListe<T>
        {
            //bağlı listenin ilk elemanını, son elemanını ve temp'ini tanımladık!
            public LinkedListNode<T> Head { get; private set; }
            public LinkedListNode<T> Tail { get; private set; }
            public LinkedListNode<T> temp { get; private set; }

            public void AddFirst(LinkedListNode<T> value)
            {
                temp = Head;
                Head = value;
                Head.Next = temp;
            }

            public void Yazdir()
            {
                temp = Head;
                int i = 1;
                while (temp != null)
                {
                    
                    Console.WriteLine("{0}. değer = {1}", i, temp.Value);
                    temp = temp.Next;
                    i++;
                }
            }

        }
        public static void Calistirici()
        {
            LinkListe<int> list = new LinkListe<int>();
            LinkedListNode<int> a1 = new LinkedListNode<int>(15);
            LinkedListNode<int> a2 = new LinkedListNode<int>(20);
            LinkedListNode<int> a3 = new LinkedListNode<int>(25);
            list.AddFirst(a3);
            list.AddFirst(a2);
            list.AddFirst(a1);
            list.AddFirst(new LinkedListNode<int>(75));
            list.Yazdir();
            

        }
        private static void metot1()
        {
            Stopwatch watch = new Stopwatch();//bir kronometre oluşturuyoruz. Kod çalışırken geçen zamanı görmek için
            watch.Start(); //başlattık

            ArrayList list = new ArrayList();//bir arraylist oluşturduk

            for(int i = 0; i < 1000000; i++)
            {
                //arrayliste int atıyoruz ancak arraylist bunu obje türüne dönüştürüp alıyor!!
                //objeye dönüştürmek zaman alacağı için uzun sürebilir
                list.Add(i);
            }
            //burada ise her bir liste elemanı üzerinde gezip bu objeleri integer'a dönüştürecek
            foreach(int item in list)
            {
                int sayı = item;
            }
            watch.Stop();
            Console.WriteLine("Geçen zaman = " + watch.Elapsed.TotalMilliseconds);//geçen süreyi milisaniye yazdırıyoruz!
        }

        //burada ise aynı işlemi arraylist ile değil integer bir list ile yapıyoruz(şablon türünde bir liste). 
        //inti objeye, objeyi inte dönüştürme işlemi yok!
        private static void Metot2()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start(); 

            List<int> list = new List<int>();
            //List<object> list = new List<object>(); //yapsaydık üstteki metottan bir farkı kalmayacaktı yapılan işlemlerin
            //Ancak çalışması arraylistten bile uzun sürer!!!

            for (int i = 0; i < 1000000; i++)
            {
                
                list.Add(i);
            }

            foreach (int item in list)
            {
                int sayı = item;
            }

            watch.Stop();
            Console.WriteLine("Geçen zaman = " + watch.Elapsed.TotalMilliseconds);//geçen süreyi milisaniye yazdırıyoruz!
        }
    }
}
