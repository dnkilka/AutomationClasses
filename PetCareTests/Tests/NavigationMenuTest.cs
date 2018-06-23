using NUnit.Framework;
using OpenQA.Selenium;
using PetCareTest.Pages;
using PetCareTests.Selenium;
using PetCareTests.URL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;


namespace PetCareTests.Tests
{
    [TestFixture]
    class NavigationMenuTest
    {
        [Test]
        public void NavigationMenu_Test()
        {
            IWebDriver driver = DriverUtils.CreateDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Open Landing Page
            URLs.OpenUrl(driver);

            var navigationMenu = new Navigation_Menu(driver);

            var aboutMePage = navigationMenu.ClickAboutMeLink();
            aboutMePage.GetHeaderText().ShouldBe("About Me");

            var contactsPage = navigationMenu.ClickContactMeLink();
            contactsPage.GetHeaderText().ShouldBe("Contact Me");

            var picturesPage = navigationMenu.ClickPicturesLink();
            picturesPage.GetHeaderText().ShouldBe("Pictures");

            var pricesPage = navigationMenu.ClickPricesLink();
            pricesPage.GetHeaderTitle().ShouldBe("Prices");

            var careRequestPage = navigationMenu.ClickCareRequestLink();
            careRequestPage.GetHeaderText().ShouldBe("Care Request");

            driver.Quit();
        }
    }
}
