using NUnit.Framework;
using OpenQA.Selenium;
using PetCareTest.Pages;
using PetCareTests.Selenium;
using PetCareTests.URL;
using System;
using System.Collections.Generic;
using dnk.log2html.Support;
using PetCareTests.Verification;

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
	        TestWrapper.Test(driver, () =>
	        {
				// Open Landing Page
				URLs.OpenUrl(driver);

	            var navigationMenu = new Navigation_Menu(driver);
	            var picturesPage = navigationMenu.ClickPicturesLink();

	            picturesPage.GetHeaderText().ShouldBe("Pictures", "Pictures");
	            picturesPage.GetFirstParagraphText().ShouldBe("These are all of the pets I can take care of for you!", "Paragrap text");

	            var collectedSources = picturesPage.GetImagesSources();
				collectedSources.RemoveAt(0);

	            var expectedSources = new List<string>()
	            {
	                "images/kitten.gif",
	                "images/dogp.png",
	                "images/hamster.png",
	                "images/rat.png",
	                "images/parrot.png",
	                "images/guinea-pig.png",
	                "images/bunnyFail.png",
	                "images/fish.png",
	                "images/snake.png",
	                "images/lizard.png"
	            };

	            collectedSources.ShouldBeEqual(expectedSources, "List of src");
			});
		}
    }
}
