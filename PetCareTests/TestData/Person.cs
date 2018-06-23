using Bogus;

namespace PetCareTests.TestData
{
    class Person
    {
        //Constructor
        public Person()
        {
            var faker = new Faker();
            FirstName = faker.Name.FirstName();
            LastName = faker.Name.LastName();
            PhoneNumber = faker.Phone.PhoneNumber("(###) ###-####");
            Email = faker.Internet.Email();
        }
    
        // Fields
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Email;

        // Method
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
