using System;

namespace YoutubeEgitim2
{
    class Program
    {
        static void Main(string[] args)
        {
            //int sayi1 = 10;                                            // value type
            //int sayi2 = 20;
            //sayi1 = sayi2;                   
            //sayi2 = 100;

            //Console.WriteLine(sayi1);

            //int[] sayilar1 = new[] { 1, 2, 3 };                       // reference type
            //int[] sayilar2 = new[] { 10, 20, 30 };
            //sayilar1= sayilar2;
            //sayilar2[0]=1000;


            //Console.WriteLine( sayilar1[0] );

            CreditManager creditManager = new CreditManager();          // class da bir referans tiptir.            
            creditManager.Calculate();
            creditManager.Calculate();
            creditManager.Save();


            Customer customer1 = new Customer();                         // nesne yönelimli programlamanın temeli için küçük bir örnek
            customer1.Id = 1;                                            // burada oluşturduğumuz nesneyi aşağıda kullanıyoruz birden fazla yerde . 
            customer1.FirstName = "yasin";                               // aşağıdaki kullandığımız yerleri farklı ekranlar olarak düşünebiliriz. 100 lerce olabilir.
            customer1.LastName = "gokce";                                // yarın öbür gün nesnemizde değişiklik olduğunda sadece buradan gelip  nesneyi değiştirmemiz yeticek              
            customer1.NationalIdentity = "123456";                       // 100 lerce ekranı değiştirmemiz gerekmeyecek.
            customer1.City = "istanbul";

            Customer customer2 = new Customer();     // kullanmıyorum 


            CustomerManager customerManager = new CustomerManager(customer1);
            customerManager.Save();
            customerManager.Delete();


            Console.ReadLine();

        }
    }


    class CreditManager
    {
        public void Calculate() { Console.WriteLine("Hesaplandi"); }

        public void Save() { Console.WriteLine("Kredi verildi"); }

    }

    class Customer
    {

        public Customer()                                                         // basit constructor kullanımı  
        {                                                                         // new operasyonu yaptığımızda heap te hemen çalışır , çünkü new yaparken zaten hemen constructor'u  çağırıyoruz dikkat edersen .
            Console.WriteLine("musteri nesnesi baslatildi");
        }
        public int Id { get; set; }                  // public int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
        public string City { get; set; }



    }



    // Katmanlı mimariler temeli budur her bir işlem farklı classta farklı nesnelerde ,  aynı zamanda solidin bir ilkesi .
    class CustomerManager
    {
        private Customer _customer ;                                        // 
        public CustomerManager( Customer customer )                           // farklı bir yapıcı (constructor) kullanımı , 
        {                                                                   // 
            _customer = customer;                                           // operasyolara customer'ı direk göndermektense customer'ı önce blok için özelleştirip öyle operasyonlara gönderiliyor        
        }

        public void Save() { Console.WriteLine("Musteri kaydedildi " + _customer.FirstName ); }
        public void Delete() { Console.WriteLine("Musteri silindi " + _customer.FirstName); }
    }
}
