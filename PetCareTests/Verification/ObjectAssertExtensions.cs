using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnk.log2html;
using Shouldly;

namespace PetCareTests.Verification
{
	public static class ShouldBeStringTestExtensions
	{
		public static void ShouldBe(this string actual, string expected, string message)
		{
			if (actual != expected)
			{
				throw new ShouldAssertException($"{message}. Expected: \"{expected}\", but was \"{actual}\".");
			}
			Logger.Log.Pass($"{message}; expected: '{expected ?? "null"}', actual: '{actual ?? "null"}'");
		}

		public static void ShouldBeIgnoreCase(this string actual, string expected, string message)
		{
			ShouldBe(actual.ToLower(), expected.ToLower(), message);
		}

		
		public static void ShouldContain(this string actual, string expected, string message, Case caseSensitivity = Case.Sensitive)
		{
			Shouldly.ShouldBeStringTestExtensions.ShouldContain(actual, expected, message, caseSensitivity);
		    Logger.Log.Pass($"{message}; expected: '{expected ?? "null"}', actual: '{actual ?? "null"}'");
		}
	}

	public static class ShouldBeBooleanExtensions
	{
		public static void ShouldBeFalse(this bool actual, string message)
		{
			Shouldly.ShouldBeBooleanExtensions.ShouldBeFalse(actual, message);
		    Logger.Log.Pass($"{message} - False");
		}

		public static void ShouldBeTrue(this bool actual, string message)
		{
			Shouldly.ShouldBeBooleanExtensions.ShouldBeTrue(actual, message);
		    Logger.Log.Pass($"{message} - True");
		}
	}

	public static class ShouldBeListExtension
	{
		public static void ShouldBeEqual(this List<string> list, List<string> listForComparing, string message)
		{
			var cleanList = list.FindAll(x => !string.IsNullOrWhiteSpace(x));
			var cleanListFromComparing = listForComparing.FindAll(x => !string.IsNullOrWhiteSpace(x));
			cleanList.Sort();
			cleanListFromComparing.Sort();
			ShouldBeEnumerableTestExtensions.ShouldBe(cleanList, cleanListFromComparing, Case.Insensitive, message);
		    Logger.Log.Pass($"{message} Contains All Values - True");
		    Logger.Log.Info($"Verified values: <br/> {string.Join("<br/>", listForComparing.ToArray())}");
		}

		/// <summary>
		/// Method compares two lists, and verifies one of them (let's name if 'largerList') has all items of another one ('smaller lists').
		/// </summary>
		/// <param name="largerList">list which is supposed to contain all items of another list</param>
		/// <param name="smallerList">"etalon list". We take all items of the list and verify another list contains all of them</param>
		/// <param name="message">custom message</param>
		public static void ShouldContain(this List<string> largerList, List<string> smallerList, string message)
		{
			var listOfMatchingItems = new List<string>();
			var listOfNotMatchingItems = new List<string>();
			foreach (var item in smallerList)
			{
				if (!largerList.Contains(item))
				{
					listOfNotMatchingItems.Add(item);
				}
				else
				{
					listOfMatchingItems.Add(item);
				}
			}
			if (listOfMatchingItems.Any())
			{
				var sb = new StringBuilder();
				foreach (var listElement in listOfMatchingItems)
				{
					sb.AppendLine(listElement + "<br/>");
				}
			    Logger.Log.Pass(message + ". Both lists contain these records: <br/>" + string.Join("<br/>", listOfMatchingItems));
			}
			if (listOfNotMatchingItems.Any())
			{
			    Logger.Log.Fail(message + ". The larger list does not contain these expected records: <br/>" + string.Join("<br/>", listOfNotMatchingItems));
			}
		}
	}
}
