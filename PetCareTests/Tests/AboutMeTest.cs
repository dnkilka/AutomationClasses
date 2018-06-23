using NUnit.Framework;
using OpenQA.Selenium;
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
    public class AboutMeTest
    {
        [Test]
        public void AboutMe_Test()
        {
            IWebDriver driver = DriverUtils.CreateDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Open Landing Page
            var landingPage = URLs.OpenUrl(driver);

            //Open About Me page
            var aboutMePage = landingPage.ClickAboutMeLink();

            //Verify text on the page
            var alltext = aboutMePage.AllText.Text;
            alltext.ShouldBe(aboutMePage.paragraphsText);

            //Verify Header text
            string header = aboutMePage.AboutMeHeader.Text;
            header.ShouldBe("About Me");

            driver.Quit();
        }
    }
}
