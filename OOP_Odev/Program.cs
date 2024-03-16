namespace OOP_Odev
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//CreditManager creditManager = new CreditManager();
			//creditManager.Calculate();
			//creditManager.Save();

			//Customer customer = new Customer(); //Örneğini oluşturmak, instance oluşturmak, instance creation
			//customer.Id = 1;
			//customer.City = "Adana";
			//customer.FirstName = "Dila";
			//customer.LastName = "Yılmaz";
			//customer.NationalIdentity = "4869746123";

			//CustomerManager customerManager = new CustomerManager(customer);
			//customerManager.Save();
			//customerManager.Delete();
			//customerManager.Save(1, "Dila", "Yılmaz", "4864513"); //Save fonksiyonu parametre olarak nesne almadığında müşteriye yeni bir bilgi örneğin şehir bilgisi eklediğimizde programdaki bütün hataları değiştirmemiz gerekir. (Encapsulation)
			//customerManager.Save(1, "Dila", "Yılmaz", "4864513");
			//customerManager.Save(1, "Dila", "Yılmaz", "4864513");

			//Company company = new Company();
			//company.TaxNumber = "7896";
			//company.Company_Name = "Arçelik";
			//company.Id = 2;

			//CustomerManager customerManager2 = new CustomerManager(new Person());

			//Customer c1 = new Customer();
			//Customer c2 = new Person();
			//Customer c3 = new Company();

			CustomerManager customerManager = new CustomerManager(new Customer(), new TeacherCreditManager());

		}
	}
	class CreditManager
	{
		public void Calculate()
		{
			Console.WriteLine("Hesaplandı");
		}
		public void Save() 
		{
			Console.WriteLine("Kredi verildi");
		}

	}

	interface ICreditManager
	{
		void Calculate(); // Calculate metodunu farklı amaçlarla kullanabilmek için interface içinde imzasını oluşturduk. Her bir kredi durumunda farklı işlemler yaptırmak isteyebiliriz. Esnaf kredisi için farklı tanım, ev kredisi için farklı tanım gibi.
		void Save();
	}

	abstract class BaseCreditManager : ICreditManager
	{
		public abstract void Calculate(); // Classların aksine tamamlanmamış operasyonlar da yazılır.
		public void Save()
		{
            Console.WriteLine("Kaydedildi"); //Aynı metodu defalarca kullanacağımız zaman abstract class oluşturuyoruz.
        }
	}
	class TeacherCreditManager : BaseCreditManager, ICreditManager
	{
		public override void Calculate() // calculate operasyonu her classta farklı olduğu için override ettik.
		{
            Console.WriteLine("Öğretmen kredisi hesaplandı.");
        }

	class MilitaryCreditManager : BaseCreditManager, ICreditManager
	{
		public override void Calculate()
		{
			Console.WriteLine("Asker kredisi hesaplandı.");
		}

	}

	class Customer
	{
        public Customer()
        {
			Console.WriteLine("Müşteri nesnesi başlatıldı");
        }
        public int Id { get; set; }
        public string City { get; set; }


    }

	class Person : Customer
	{
		public string NationalIdentity { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
	class Company : Customer
	{
		public string Company_Name { get; set; }
		public string TaxNumber { get; set; }
    }

	class CustomerManager //Encapsulation!! Fonksiyona id, firstname, lastname teker teker parametre olarak girersek ileride city ekleyince bütün Save işlemlerini güncellememiz gerekirdi.
	{
		private Customer _customer;
		private ICreditManager _creditManager;
		public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
			_creditManager = creditManager;
        }
        public void Save()
		{
			Console.WriteLine("Müşteri kaydedildi : " + _customer.FirstName);
		}
		public void Delete()
		{
			Console.WriteLine("Müşteri silindi : " + _customer.FirstName);
		}
		public void GiveCredit()
		{
			_creditManager.Calculate();
			Console.WriteLine("Kredi verildi");
		}
	}
}
