using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PetCareTests.Tutorial
{
	[TestFixture]
	class Strings
	{
		[Test]
		public void StringsExample()
		{
			string firstName = "IrYnKa";
			string lastName = "Shcherbyna";

			//String Interpolation
			string greeting = $"Good afternoon, {firstName} {lastName}, how are you doing {{}} <- curly bracket";
			Console.WriteLine(greeting);

			//String format
			greeting = string.Format("Good afternoon, {0} {1}, how are you doing {{}} <- curly bracket", firstName, lastName);
			Console.WriteLine(greeting);

			//Length
			Console.WriteLine("string literal".Length);
			Console.WriteLine(firstName.Length);
			Console.WriteLine(greeting.IndexOf("abra kadabra")); // returns -1
			Console.WriteLine(greeting.Substring(greeting.IndexOf(firstName), firstName.Length));

			//Contains
			Console.WriteLine("Contains:");
			Console.WriteLine(greeting.Contains("Vlad"));
			Console.WriteLine(greeting.Contains("{}"));

			//Equals
			Console.WriteLine("Equals:");
			Console.WriteLine(firstName.ToUpper().Equals("irynka".ToUpper()));
			Console.WriteLine(firstName.Equals("Irynka"));
			Console.WriteLine("ToUpper:");
			Console.WriteLine(firstName.ToUpper());
		}
	}
}
