using System;

namespace YoutubeEgitim4
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager(new Customer() , new TeacherCreditManager());                          // istersern asker kredisini ver
            customerManager.GiveCredit();                                                                                                // 

            Console.ReadLine();

        }
    }









  

    class CreditManager
    {
        public void Calculate(int creditType) {

            if (creditType ==1)
            {

            }

            if (creditType == 2)
            {

            }
        
        }                  

        public void Save() { Console.WriteLine("Kredi verildi"); }

    }




    /// <summary>
    /// 
    /// görüldüğü üzere altta ve üstte iki credi yönetimi bloklarımız var ,
    /// ikisi de bir tasarım
    /// 
    /// 
    // intrerface temel amacı yazılımdaki bağımlılıkları engellemek if() lerden kurtulmak
    // interface dayıdır. bir kişi birden fazla dayısının fonksiyonun kendisi çzelleştirerek kulanabilir.
    /// 
    /// </summary>





    interface ICreditManager
    {
       void Calculate();
       void Save();


    }

    class TeacherCreditManager : ICreditManager
    {
        public void Calculate()
        {
            Console.WriteLine("Öğretmen kredisi hesaplandi");                 // burada hesaplamalar yapılıyor
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    class MilitaryCreditManager : ICreditManager
    {
        public void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandi");
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
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
















  
    class CustomerManager
    {
        private Customer _customer;
        private ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)                                // constructura aynı zamanda interface sayesinde müşşteri ile birlikte hangi kerdiye talipse onuda göndermiş oluyoruz      
        {                                                                                                      // çünkü interface de referans tip .
            _customer = customer;                                                                       
            _creditManager = creditManager;
        }

        

        public void Save() { Console.WriteLine("Musteri kaydedildi " + _customer.Id); }
        public void Delete() { Console.WriteLine("Musteri silindi " + _customer.Id); }

        public void GiveCredit()
        {
            _creditManager.Calculate();                                                                      // gelen interface hesaplayıp kredisini veriyoruz . // imza ile çalıştırıyoruz . 
            Console.WriteLine("Kredi verildi .");

        }

    }
}



