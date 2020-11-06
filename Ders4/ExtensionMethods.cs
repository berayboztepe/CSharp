using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ders4
{
    class ExtensionMethods
    {
        /*
        static void Main(string[] args)
        {
            //var i; yapamayız. bir değer vermemiz gerekir
            //var k, j= 0 yapamayız. Yalnızca bir değer atayabiliriz.
            //var n = null; yapamayız. Null değişkeni varla ifade edilmez.

            //bu şekilde isimsiz class tanımlayabiliriz. Özellikleri var ancak parametre olarak gönderilemez ve geri dönüş değeri olarak kullanılamaz.
            var employee = new
            {
                Name = "Beray",
                Department = "Engineering"
            };

       
            Console.WriteLine("{0}:{1}", employee.Name, employee.Department);


            

        }
        */
        //Kısmi metod oluşturmak istersek:
        public partial class Account
        {
            public Account()
            {
                OnCreated();
            }
            partial void OnCreated();
        }
        public partial class Account
        {
            partial void OnCreated()
            {
                Console.WriteLine("Account Created");
            }

        }

    }
}
