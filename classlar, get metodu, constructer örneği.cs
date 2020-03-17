using System;

namespace Yenisi
{
    class Program
    {
        static void Main(string[] args)
        
        {
            Cat cat = new Cat() { _tur = "Ankara", renk = "Beyaz", speed = 40 };
            Bird bird = new Bird() { _tur = "Kartal", renk = "Altın", flyspeed = 60 };
            Console.WriteLine(cat.GetProperties());
            Console.WriteLine(bird.GetProperties());

            Console.ReadLine();
        }
    }
    public class Animals
    {
        public string _tur;
        public string renk;
        /*constructer
        Animals(string a, string b)
        {
            _tur = a;
            _cins = b;
        }*/
        //get metodu
        public string GetProperties()
        {
            return String.Format("Turu = {0}   Rengi = {1}",_tur, renk);
        }
    }
    public class Cat : Animals
    {
        public int speed;
        
        public string GetProperties()
        {
            string animalproperties = base.GetProperties();
            string catproperties = String.Format("    Speed of Cat : {0}", speed);
            return (animalproperties + catproperties);

        }
        

        }
    public class Bird : Animals
    {
       public int flyspeed;
        public string GetProperties()
        {
            //base demek ana classtaki özellikleri almak demek
            string animalproperties = base.GetProperties();
            string birdproperties = String.Format("    Flyspeed of Bird : {0}", flyspeed);
            return (animalproperties + birdproperties);
        }
    }
    }

