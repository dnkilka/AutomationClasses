using NUnit.Framework;
using OpenQA.Selenium;
using PetCareTests.Pages;
using PetCareTests.Selenium;
using PetCareTests.URL;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Open Landing Page
            var landingPage = URLs.OpenUrl(driver);


            //Verify text on the page
            var alltext = landingPage.AllText.Text;
            alltext.ShouldBe(landingPage.paragraphsText);


            //Verify Header text
            string header = landingPage.LandingHeader.Text;
            header.ShouldBe("Alex's Pet Business");

            //Verify images of the page
            var image1 = landingPage.CatImage.Displayed;
            var image2 = landingPage.DogImage.Displayed;
            image1.ShouldBeTrue();
            image2.ShouldBeTrue();

            driver.Quit();
            
        }


    }
}
