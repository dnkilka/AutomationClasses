using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace PetCareTests.Tutorial
{
    [TestFixture]
    internal class HashSetExample
    {
        [Test]
        public void Sets()
        {
            var myFirstSet = new HashSet<int>();
            myFirstSet.Add(1);
            myFirstSet.Add(3);
            myFirstSet.Add(1);
            myFirstSet.Add(int.MaxValue);
            myFirstSet.Add(int.MinValue);
            Console.WriteLine(myFirstSet.Count);
            foreach (var setItem in myFirstSet)
            {
                Console.WriteLine(setItem);
            }
            myFirstSet.Count.ShouldBe(4);
        }
    }
}