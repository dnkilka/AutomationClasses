using NUnit.Framework;
using OpenQA.Selenium;
using PetCareTests.Selenium;
using PetCareTests.URL;
using System;
using dnk.log2html.Support;
using PetCareTests.Verification;


namespace PetCareTests.Tests
{
    [TestFixture]
    public class LandingPageTest
    {
        [Test]
        public void LandingPage_Test()
        {
            IWebDriver driver = DriverUtils.CreateDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
	        TestWrapper.Test(driver, () =>
	        {
				// Open Landing Page
				var landingPage = URLs.OpenUrl(driver);

	            //Verify text on the page
	            var alltext = landingPage.GetAllText();
	            alltext.ShouldBe(landingPage.paragraphsText, "Page text");


	            //Verify Header text
	            string header = landingPage.LandingHeader.Text;
	            header.ShouldBe("Alex's Pet Business", "Header text");

	            //Verify images of the page
	            landingPage.CatImage.Displayed.ShouldBeTrue("Cat img");
	            landingPage.DogImage.Displayed.ShouldBeTrue("Dog img");
			});
		}
    }
}
