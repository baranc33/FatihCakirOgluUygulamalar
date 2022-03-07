/*
 Startnew metoduda Run metodu gibi çalışır Rundan farkı Runda Bir obje gönderemiyoruz
 startnew ile bir obje gönderebiliriz içerde işlemler yapktıktan sonra bu objeyi alabiliyoruz
 
 */

internal class Program
{
    private async static Task Main(string[] args)
    {
        Console.WriteLine("Ana Thread : {0}", Thread.CurrentThread.ManagedThreadId);

        // aynı run gibi kullanıp bunu bir değişkene atıyoruz
        Task myTask = Task.Factory.StartNew((Obj) =>
          {
              // içerde ihtiyacımız doğrultusunda işlemler yapıp proplarını değiştirebiliriz.
              Console.WriteLine("MyTask çalıştı");
              // gelen objenin status nesnemize denk olduğunu 2. verdiğimiz parametreden bildiğimiz
              // için as operatörüyle cast ediyoruz
              // as in diğer bi özelliği cast edilmezse null döneceği
              var status = Obj as Status;
              status.threadId = Thread.CurrentThread.ManagedThreadId;


          },  // starnew metodunun 2. parametresini unutmuyoruz burda bir obje istiyor
              // biz objemizi startnew içersinde kullanılacak ve startnewden önce burası çalışacağından
              // içeriye dolu bir şekilde gidiyor
         new Status(){date = DateTime.Now});


        await myTask;

        Status s = myTask.AsyncState as Status;
        Console.WriteLine(s.date);
        Console.WriteLine("Starnew Thread : {0}", s.threadId);
    }
}

