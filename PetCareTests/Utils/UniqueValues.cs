using System;

namespace PetCareTests.Utils
{
	public class UniqueValues
	{
		public static readonly Random Random = new Random();

		/// <summary>
		/// Generate a unique phone number in xxxxxxxxxx format. Please provide first 4 digits, which are standard for american phones. For example (7738, 2244, etc)
		/// </summary>
		public static string UniquePhoneNumber(string firstFourDigits)
		{
			var uniqueNumber = DateTime.Now.Ticks.ToString();
			return firstFourDigits + uniqueNumber.Substring(uniqueNumber.Length - 6);
		}

		/// <summary>
		/// Generates unique email address. Please provide correct email suffix, for example "@gmail.com,  @mailinator.com"
		/// </summary>
		public static string UniqueEmailAddress(string emailSuffix)
		{
			return RandomString() + emailSuffix;
		}

		/// <summary>
		/// Generate random string for random names or emails. Min length of the string is 5, max 13. The first letter of the result is capital.
		/// </summary>
		/// <returns></returns>
		public static string RandomString()
		{
			var word = new char[Random.Next(8) + 5];
			for (var i = 0; i < word.Length; i++)
			{
				var lowerBoundary = i == 0 ? 'A' : 'a'; // capital 'A' has code 65, lowercase 'a' has code 97
				word[i] = (char)Random.Next(lowerBoundary, lowerBoundary + 26);
			}
			return new string(word);
		}

		/// <summary>
		/// Generates a random number in the given range
		/// For example if 'from' is 1, and 'to' is 100 - the generated number will be in range of [1-999]
		/// </summary>
	
		public static int RandomNumber(int from, int to)
		{
			var random = new Random();
			var number = random.Next(from, to);
			return number;
		}
	}
}
