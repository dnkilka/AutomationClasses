﻿using System;
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
        List<string> iLike = new List<string>
        {
            "string",
            "interpolation",
            "length",
            "method",
            "call",
            "class",
            "constructor",
            "TO READ HOMEWORK THEORY"
        };

        
        [Test]
        //Practical task #1
        public void DivideByFourAsc()
        {
            for (int i = 0; i < 100; i++)
            {
                if ((i % 4) == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Practical task #2
        [Test]
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
            //var item = iLike[1];
            iLike.Contains("string").ShouldBeTrue();
            iLike.Contains("constructor").ShouldBeTrue();

        }

        //Practical task #4
        [Test]
        public void YearOfBirth()
        {
            var random = new Random();
            int yearOfBirth = random.Next(1940, 2006);
            Console.WriteLine(yearOfBirth);
            yearOfBirth = random.Next(1940, 2006);
            Console.WriteLine(yearOfBirth);
        }

        //Practical task #6
        [Test]
        public void FamilyMembers()
        {
            string[] familyMembers = {"Andriy", "Tanya", "Liliya", "Maksym", "Picachu", "Lady"};
            for (var i = 0; i < familyMembers.Length; i++)
            {
                Console.Write($"{familyMembers[i]} Viytyk");
            }
        }

        //Practical task #7
        [Test]
        public void PartOfDay()
        {
            string currentDateAndTime = DateTime.Now.ToString();
            if (currentDateAndTime.Contains("AM"))
            {
                Console.Write("Good Morning");
            }

            if (currentDateAndTime.Contains("PM"))
            {
                int i = 123;
                Console.Write("Good night");
            }
        }


        //Practical task #8 ???
        [Test]
        public void ComparisonTest()
        {
            Comparison("Hi", "Yo").ShouldBeTrue();
            Comparison(iLike[0], iLike[1]).ShouldBeTrue();
        }

        public bool Comparison(string name1, string name2)
        {
            //how to use iLike[2]?
            return name1 == name2;
        }

        //Create a list of elements
        [Test]
        public List<string> ListOfWords()
        {
            List<string> words = new List<string> {
                "Elodin",
                "Simmon",
                "Kvothe",
                "The Cthaeh",
                "Auri",
                "Elxa Dal",
                "Cinder",
                "Kilvin",
                "Encanis",
                "Laurian",
                "Erlus"
            };
            for (int i = 0; i < words.Count; i++)
            {
                var firstLetter = words[i].First();
                if (firstLetter.Equals("E"))
                {
                    words.RemoveAt(i);
                }
                else if (firstLetter.Equals("A"))
                    {
                    words.RemoveAt(i);
                    };
            }
            return words;
        }

        //Total price of all list elements
        public int TotalPrice()
        {
            List<string> pricesString = new List<string> { "$1", "$5", "$10", "$20", "$100" };
            var pricesInteger = new List<int>;
            for (int i = 0; i < pricesString.Count; i++)
            {
                var webElement = pricesString[i];
                var price = webElement.Substring(0, 1).Convert.ToInt32();//How to convert int to string?
                pricesInteger.Add(price);
            }
            int totalprice = pricesInteger.Sum();
            return totalprice;
        }


        //Collection of unique random names
        public List<string> UniqueNamesList()
        {
            List<string> uniqueNames = new List<string>();
                        
            if (uniqueNames.Count < 10)
            {
                var faker = new Faker();
                uniqueNames.Add(faker.Name.FirstName);//???
            }
            return uniqueNames;
        }
        
    }
}
