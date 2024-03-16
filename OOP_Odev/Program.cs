namespace OOP_Odev
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CreditManager creditManager = new CreditManager();
			creditManager.Calculate();
			creditManager.Save();

			Customer customer = new Customer(); //Örneğini oluşturmak, instance oluşturmak, instance creation
			customer.Id = 1;
			customer.FirstName = "Dila";
			customer.LastName = "Yılmaz";
			customer.NationalIdentity = "4869746123";

			CustomerManager customerManager = new CustomerManager(customer);
			customerManager.Save();
			customerManager.Delete();
			//customerManager.Save(1, "Dila", "Yılmaz", "4864513"); //Save fonksiyonu parametre olarak nesne almadığında müşteriye yeni bir bilgi örneğin şehir bilgisi eklediğimizde programdaki bütün hataları değiştirmemiz gerekir. (Encapsulation)
			//customerManager.Save(1, "Dila", "Yılmaz", "4864513");
			//customerManager.Save(1, "Dila", "Yılmaz", "4864513");


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

	class Customer
	{
        public Customer()
        {
			Console.WriteLine("Müşteri nesnesi başlatıldı");
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

	class Company : Customer
	{
        public int TaxNumber { get; set; }
    }

	class CustomerManager //Encapsulation!! Fonksiyona id, firstname, lastname teker teker parametre olarak girersek ileride city ekleyince bütün Save işlemlerini güncellememiz gerekirdi.
	{
		private Customer _customer;
		public CustomerManager(Customer customer)
        {
            _customer = customer;
        }
        public void Save()
		{
			Console.WriteLine("Müşteri kaydedildi : " + _customer.FirstName);
		}
		public void Delete()
		{
			Console.WriteLine("Müşteri silindi : " + _customer.FirstName);
		}
	}
}
