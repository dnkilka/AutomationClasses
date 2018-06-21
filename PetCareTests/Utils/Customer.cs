using Bogus;

namespace PetCareTests.Utils
{
	public class Customer
	{
		public string FirstName;
		public string LastName;
		public string Email;
		public string PhoneNumber;

		public Customer()
		{
			var faker = new Faker();
			FirstName = faker.Name.FirstName();
			LastName = faker.Name.LastName();
			PhoneNumber = faker.Phone.PhoneNumber("##########");
			Email = faker.Internet.Email();
		}

		public string FullName()
		{
			return FirstName + " " + LastName;
		}
	}
}
