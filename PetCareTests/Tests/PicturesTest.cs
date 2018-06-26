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

            var collectedSources = picturesPage.GetImagesSources();

            var expectedSources = new List<string>()
            {
                "http://nitro.duckdns.org/Pets/images/catwalk.gif",
                "http://nitro.duckdns.org/Pets/images/kitten.gif",
                "http://nitro.duckdns.org/Pets/images/dogp.png",
                "http://nitro.duckdns.org/Pets/images/hamster.png",
                "http://nitro.duckdns.org/Pets/images/rat.png",
                "http://nitro.duckdns.org/Pets/images/parrot.png",
                "http://nitro.duckdns.org/Pets/images/guinea-pig.png",
                "http://nitro.duckdns.org/Pets/images/bunnyFail.png",
                "http://nitro.duckdns.org/Pets/images/fish.png",
                "http://nitro.duckdns.org/Pets/images/snake.png",
                "http://nitro.duckdns.org/Pets/images/lizard.png"
                /*"images/kitten.gif",
                "images/dogp.png",
                "images/hamster.png",
                "images/rat.png",
                "images/parrot.png",
                "images/guinea-pig.png",
                "images/bunnyFail.png",
                "images/fish.png",
                "images/snake.png",
                "images/lizard.png"*/
            };

            collectedSources.ShouldBe(expectedSources);

            driver.Quit();
        }
    }
}
