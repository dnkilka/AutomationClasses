using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using dnk.log2html.Support;
using PetCareTests.Selenium;
using PetCareTests.URL;
using PetCareTests.Verification;

namespace PetCareTests.Tests
{
	[TestFixture]
	class PricesTest
	{
		[Test]
		public void Prices_Test()
		{
			IWebDriver driver = DriverUtils.CreateDriver();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			TestWrapper.Test(driver, () =>
			{
				// Open Landing Page
				var landingPage = URLs.OpenUrl(driver);
           
				//Open Prices page
				var pricesPage = landingPage.ClickPricesLink();
                       
				//Verify Header text
				var header = pricesPage.PricesHeader.Text;
				header.ShouldBe("Prices", "Prices");

				//Verify paragraph text
				var paragraph = pricesPage.PricesParagraph.Text;
				paragraph.ShouldBe("These are my prices for different pets.", "Paragraph text");

				//Verify prices list text
				//var list = pricesPage.PricesList.Text;
				//list.ShouldBe("Dogs $10 per day");
				var collectedPrices = pricesPage.GetPricesTexts();

				var expectedPrices = new List<string>()
				{
					"Dogs $10 per day",
					"Cats $10 per day",
					"Bunnies/Rabits $10 per day",
					"Hamster $8 per day",
					"Rat/Mice $8 per day",
					"Guinea Pig $8 per day",
					"Parott/Bird $8 per day",
					"Fish $8 per day",
					"Snake $8 per day",
					"Lizard $8 per day"
				};

				collectedPrices.ShouldBeEqual(expectedPrices, "Prices list");
			});
		}
    }
}
