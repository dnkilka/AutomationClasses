using System;
using dnk.log2html.Support;
using NUnit.Framework;
using PetCareTests.Selenium;
using PetCareTests.URL;
using PetCareTests.Verification;

namespace PetCareTests.Tests
{
    [TestFixture]
    public class AboutMeTest
    {
        [Test]
        public void AboutMe_Test()
        {
            var driver = DriverUtils.CreateDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            TestWrapper.Test(driver, () =>
            {
                // Open Landing Page
                var landingPage = URLs.OpenUrl(driver);

                //Open About Me page
                var aboutMePage = landingPage.ClickAboutMeLink();

                //Verify text on the page
                var alltext = aboutMePage.AllText.Text;
                alltext.ShouldBe(aboutMePage.paragraphsText, "Paragraph Text");

                //Verify Header text
                var header = aboutMePage.AboutMeHeader.Text;
                header.ShouldBe("About Me", "About Me header");
            });
        }
    }
}