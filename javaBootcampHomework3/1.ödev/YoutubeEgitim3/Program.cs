using System;

namespace YoutubeEgitim3
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

            //int[] sayilar1 = new[] { 1, 2, 3 };                       // reference 
            //int[] sayilar2 = new[] { 10, 20, 30 };
            //sayilar1= sayilar2;
            //sayilar2[0]=1000;


            //Console.WriteLine( sayilar1[0] );

            CreditManager creditManager = new CreditManager();          // class da bir referans tiptir.            
            creditManager.Calculate();
            creditManager.Calculate();
            creditManager.Save();


            Customer customer1 = new Customer();                         // nesne yönelimli programlamanın temeli için küçük bir örnek
            customer1.Id = 1;                                            // burada oluşturduğumuz nesneyi aşağıda kullanıyoruz birden fazla yerde .                                                       // bu üç alan artık sadece  person alanı ollduğu için kullanılamıyor.
          //  customer1.FirstName = "yasin";                               // aşağıdaki kullandığımız yerleri farklı ekranlar olarak düşünebiliriz. 100 lerce olabilir.
          //  customer1.LastName = "gokce";                                // yarın öbür gün nesnemizde değişiklik olduğunda sadece buradan gelip  nesneyi değiştirmemiz yeticek              
          //  customer1.NationalIdentity = "123456";                       // 100 lerce ekranı değiştirmemiz gerekmeyecek.
            customer1.City = "istanbul";

            Customer customer2 = new Customer();                         // 2. müşteriyi kullanmıyorum 


            Company company = new Company();
            company.CompanyName = "";
            company.TaxNumber = "12345";


            Person person = new Person();
            person.FirstName = "";
            person.LastName = "";
            person.NationalIdentity = "";
            person.Id = 1;
            person.City = "";

            CustomerManager customerManager2 = new CustomerManager(new Person());    // alttaki özellik sayesinde customer istenen alana person verebiliyoruz . yani müşteri istenen alana farklı tip müşterileri verebiliyoruz ve hepsinide ayrı nesnelerde tutarak bunu yapıyoruz.  
            customerManager2.Save();
            customerManager2.Delete();

            Customer c1 = new Customer();                               // 
            Customer c2 = new Person();                                 //    temel sınıf oluşan referans numarasını tutabiilyor . Çünkü person , company temel sınıfı barındırıyor.
            Customer c3 = new Company();                                //    

            //CustomerManager customerManager = new CustomerManager(customer1);
            //customerManager.Save();
            //customerManager.Delete();


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
       
      
        public string City { get; set; }



    }

    class Person : Customer
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

    class Company : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }



    // Katmanlı mimariler temeli budur her bir işlem farklı classta farklı nesnelerde ,  aynı zamanda solidin bir ilkesi .
    class CustomerManager
    {
        private Customer _customer;                                        // 
        public CustomerManager(Customer customer)                           // farklı bir yapıcı (constructor) kullanımı , 
        {                                                                   // 
            _customer = customer;                                           // operasyolara customer'ı direk göndermektense customer'ı önce blok için özelleştirip öyle operasyonlara gönderiliyor        
        }

        public void Save() { Console.WriteLine("Musteri kaydedildi " + _customer.Id); }
        public void Delete() { Console.WriteLine("Musteri silindi " + _customer.Id); }
    }
}
