using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Shouldly;
using System;
using Bogus;
using PetCareTests.Pages;
using PetCareTests.Selenium;
using PetCareTests.URL;
using PetCareTests.Utils;

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

			// Open Landing Page
			var landingPage = URLs.OpenUrl(driver);
           
			//Open Prices page
            var pricesPage = landingPage.ClickPricesLink();
                       
            //Verify Header text
            var header = pricesPage.PricesHeader.Text;
            header.ShouldBe("Prices");

            //Verify paragraph text
            var paragraph = pricesPage.PricesParagraph.Text;
            paragraph.ShouldBe("These are my prices for different pets.");

            //Verify prices list text
            var list = pricesPage.PricesList.Text;
            list.ShouldBe("Dogs $10 per day");
            
            driver.Quit();
        }
    }
}
