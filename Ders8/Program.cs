using System;
using System.Collections.Generic;

namespace Ders8
{
    public interface IDocument
    {
        string Title { get; set; }
        string Content { get; set; }
    }

    //kısıtlama vermeye ön hazırlık olarak şunu yapıyoruz. Bu sınıf, içerisinde title ve content içeren bir interface miras alacak!
    //Bu sayede biz her T'nin içerisinde title ve content olacağının garantisini veriyoruz
    public class Document : IDocument
    {
        //Bir dokümanımız var. 2 tane yapıcımız var
        //Bu sınıf şablon türde değil ama document manager şablon türde
        public Document()
        {

        }
        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
        public string Title { get; set; }
        public string Content { get; set; }
    }
    //Elimizdeki dokümanı manage edecek ayrı bir sınıfımız daha var!
    //interface ekledikten sonra biz şu ifade ile where T : IDocument, her T dediğimiz şeye bir kısıt vermiş oluruz.
    //yani T dediğimiz şeyin title'ı ve content'i olmak zorunda!! Her şey IDocument türünde olacak.
    //Yani artık Title'ın altı çizili değil çünkü title olmasını garanti hale getirdik
    //Peki biz sadece interface ile mi kısıtlama yapabiliriz? hayır, her T'nin bir değer tipinde olmasını söyleyebiliriz. Referans tipinde olmasını söyleyebiliriz.
    //Struct olabilir, class olabilir, default constructor olmasını sağlayabiliriz(new() ile) bunun için classta boş bir yapıcı olmalıdır! ya da hiç yapıcı olmamalıdır(kendi defaultunu kullanır)
    //başka bir şablon türünden olabilir (T:T2) vb.
    //şablon türünden bir interfaceyi implement eden bir class illa <T> diye belirtmesine gerek yok <Person> vb. şeklinde somut bir tanımlama yapılabilir
    //where ile bir interface koyuyorsak bu classta document sınıfından bir özellik kullanılacağı için bu document sınıfının mutlaka aynı interfaceyi implement etmesi gerekir.
    public class DocumentManager<T> where T : IDocument
    {
        //Burada bir kuyruğumuz var. Bu kuyruk system.collections.generic'in altında bulunur!
        private readonly Queue<T> documentQueue = new Queue<T>();
        //Burada gelen doküman kuyruğa ekleniyor(Enqueue ile)
        public void AddDocument(T doc)
        {
            documentQueue.Enqueue(doc);
        }
        //Kuyrukta eleman var mı yok mu? onu sorguluyoruz.
        public bool isDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }
        //Burada eklenen elemanı kuyruktan çıkarıp geriye döndürüyoruz
        public T GetDocument()
        {
            T doc = default(T);
            doc = documentQueue.Dequeue();
            return doc;
        }
        //Ardından kuyruktaki dokümanları yazdırıyoruz.
        public void DisplayAllDocuments()
        {
            //buradaki title'ın altı çizili yani bir hata var!
            //Burada bizim t türünde bir dokümanımız var. Ama T türünde sadece dökümanlarımız olmayabilir(world document, pdf document olabilir)
            //yani bunların uzantısının doc.Title olup olmayacağı kesin değil, garantisi yok!
            //Bizim burada T'ye bir kısıt vermemiz gerek.
            //Her T dediğimiz şeyin içerisinde mutlaka Title olacak diye garanti vermemiz gerek. Bunu da kısıtları kullanarak yaparız
            foreach(T doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
            //eğer kısıtlama yapmasaydık kodu şu şekilde yazardık
            //yalnız bu halde bile hata verir. T'nin title'ı var mı yok mu garantisi yok!
            /*foreach(Document doc in documentQueue)
            {
                Console.WriteLine(((Document)(doc)).Title);
            }*/
        }
    }
  
    public class StaticDeneme<T>
    {
        public static int x;
    }
    //C#'ta ref anahtar sözcüğü ile parametre gönderilebilir. Bu işlem C'deki pointer mantığına karşılık gelir. Call by referance


    class Program
    { 
        static void Main(string[] args)
        {
            //şablon türündeki document managerdan document türünden bir nesne oluşturduk. Biz doküman pdf olabilir, bize özgü olabilir.
            //Ardından yeni dokümanları ekleyip listeledik.
            DocumentManager<Document> dm = new DocumentManager<Document>();
            dm.AddDocument(new Document("Title A", "Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));
            dm.DisplayAllDocuments();
            /*if (dm.isDocumentAvailable)
            {
                Document d = dm.GetDocument();
                Console.WriteLine(d.Content);
            }*/

            //static değerleri de şablon olarak kullanıp, farklı türde değişkenler atayabiliriz.
            StaticDeneme<string>.x = 4;
            StaticDeneme<int>.x = 5;
            Console.WriteLine("String x = " + StaticDeneme<string>.x);
            Console.WriteLine("Int x = " + StaticDeneme<int>.x);


            Console.ReadLine();
        }
    }
}
