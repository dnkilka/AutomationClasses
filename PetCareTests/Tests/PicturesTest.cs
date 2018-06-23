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
    class PicturesTest
    {
        [Test]
        public void Pictures_Test()
        {
            IWebDriver driver = DriverUtils.CreateDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Open Landing Page
            URLs.OpenUrl(driver);

            var navigationMenu = new Navigation_Menu(driver);
            var picturesPage = navigationMenu.ClickPicturesLink();

            picturesPage.GetHeaderText().ShouldBe("Pictures");
            picturesPage.GetFirstParagraphText().ShouldBe("These are all of the pets I can take care of for you!");

            driver.Quit();
        }
    }
}
