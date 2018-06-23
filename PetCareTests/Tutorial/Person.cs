using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareTests.Tutorial
{
    class Person
    {
        //Constructor
        public Person()
        {
            var faker = new Faker();
            var FirstName = faker.Name.FirstName();
            var LastName = faker.Name.LastName();
            var PhoneNumber = faker.Phone.PhoneNumber("(###) ###-####");
            var Email = faker.Internet.Email();
        }
    
        // Fields
        public string FirstName;
        public string LastName;
        public string PhoneNumber;
        public string Email;

        // Method
        public string GetFullName()
        {
            return ($"{FirstName}{LastName}");
        }
    }
}
