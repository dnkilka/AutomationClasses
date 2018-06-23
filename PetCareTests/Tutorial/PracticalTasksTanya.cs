using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Shouldly;
using Bogus;
using PetCareTests.Pages;
using PetCareTests.Selenium;
using PetCareTests.URL;
using PetCareTests.Utils;


namespace PetCareTests.Tutorial
{
    [TestFixture]
    public class PracticalTasksTanya
    {
        [Test]
        //Practical task #1
        public void DivideByFourAsc()
        { for (int i = 0; i < 100; i++)
            {
                if ((i % 4) == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Practical task #2
        public void DivideByFourDesc()
        {
            for (int i = 100; i > 0; i--)
            {
                if ((i % 4) == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Practical task #3 - !!!
        [Test]
        public void StringList()
        {
            List<string> iLike = new List<string> { "string", "interpolation", "length", "method", "call", "class", "constructor", "TO READ HOMEWORK THEORY" };
            var item = iLike[1];
            iLike.Contains("string").ShouldBeTrue();
            iLike.Contains("constructor").ShouldBeTrue();
        }

        //Practical task #4
        public void YearOfBirth()
        {
            var random = new Random();
            int yearOfBirth = random.Next(1940, 2006);
        }
        
        //Practical task #6
        public void FamilyMembers()
        {
            string[] familyMembers = { "Andriy", "Tanya", "Liliya", "Maksym", "Picachu", "Lady" };
            for (var i = 0; i < familyMembers.Length; i++)
            {
                Console.Write($"{familyMembers[i]} Viytyk");
                Console.Read();
            }
        }

        //Practical task #7
        public void PartOfDay()
        {
            string currentDateAndTime = DateTime.Now.ToString();
            if (currentDateAndTime.Contains("AM"))
                {
                    Console.Write("Good Morning");
                }
            if (currentDateAndTime.Contains("PM"))
                {
                    Console.Write("Good night");
                }
        }
        
    
        //Practical task #8 ???
        public bool Comparison(string name1, string name2)
            {
                //how to use iLike[2]?
               return (name1.Length > name2.Length);
            }

    }
}
