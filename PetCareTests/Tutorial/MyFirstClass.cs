using System;
using NUnit.Framework;

namespace PetCareTests.Tutorial
{
	class MyFirstClass
	{
		//Constructor
		public MyFirstClass(int initialValue)
		{
			MyFirstField = initialValue;
		}
		// Field
		public int MyFirstField;

		//Property
		public int MyFirstProperty
		{
			get { return MyFirstField; }
		}

		// Method returns int
		public int MyFirstMethod()
		{
			Console.WriteLine("My first method body");
			return MyFirstProperty;
		}

		//Method does not return anything
		public void MyVoidMethod()
		{
			Console.WriteLine("My void method body");
		}

		//Method
		public string CreateGreeting(string name, int mood)
		{
			Console.WriteLine(name);
			if (mood == 1000)
			{
				return $"Hello, {name}";
			}
			else
			{
				return $"Good bye, {name}";
			}
		}

		//Method
		public int SquareRoot(int x)
		{
			return x * x;
		}

		[Test]
		public void NewInstanceExample()
		{
			var myObject = new MyFirstClass(555);
			string greetingSubject = "Tanya";
			string returnedGreeting = myObject.CreateGreeting(greetingSubject, 1000);
			Console.WriteLine(returnedGreeting);
		}
	}
}
