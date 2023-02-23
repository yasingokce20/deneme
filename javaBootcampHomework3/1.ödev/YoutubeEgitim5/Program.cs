using System;

namespace YoutubeEgitim5
{
    class Program
    {
        static void Main(string[] args)
        {

            CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager());                          // istersern asker kredisini ver
            customerManager.GiveCredit();                                                                                                // 

            Console.ReadLine();

        }
    }











    class CreditManager
    {
        public void Calculate(int creditType)
        {

            if (creditType == 1)
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

    abstract class BaseCreditManager                                                        // abstract classlar genelde tamamlanmı ve tamamlanmamış operasyonlsrı yönetmede kullanılır
    {                                                                                       // aslında bazı farklarla beraber miras almaya benziyor , zaten bir sınıf bir abstract sınıfı inhererit edebilir. absrtact sınıflarda sınıf grubunda kabul edbilir .
                                                                                            // abstract sınıflarda interface lerde new lenemez => bu özelliği daha bilmiyorum anlamadım.
        public abstract void Calculate();


        //   public void Save()                                                                  // save hepsinde aynı olduğu için save operasyonunu artık bi daha yazmıyacağım . 
        //   {
        //       Console.WriteLine("kaydedildi");                                              
        //   }


        public virtual void Save()                                                                 
        {
            Console.WriteLine("kaydedildi");                                                // egerki save operasyonunuda bazen değiştireceksem virtual yapmak lazım .
        }



    }

    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()                                                    // override üzerine yazmak demek
        {
            Console.WriteLine("Öğretmen kredisi hesaplandi");               
        }

       
    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Asker kredisi hesaplandi");
        }

        public override void Save()
        {
            // ekstra eklemek istediğimiz kodlar                                              
            base.Save();                                                                     // virtaual yaptık bundaki save operasyonuna eklemler yaptım
            // ekstra eklemk istediğimiz kodlar 
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
