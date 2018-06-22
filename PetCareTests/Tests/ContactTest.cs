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
    class ContactTest
    {
        [Test]
        public void Contact_Test()
        {
            IWebDriver driver = DriverUtils.CreateDriver();
	        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			// Open Landing Page
			var landingPage = URLs.OpenUrl(driver);
           
			//Open Contact page
            var contactPage = landingPage.ClickContactMeLink();
                       
            //Verify Header text
            var header = contactPage.ContactHeader.Text;
            header.ShouldBe("Contact Me");

            //Verify Care Request link
            var careRequestLink = contactPage.GetCareRequestLink();
            careRequestLink.ShouldBe("http://nitro.duckdns.org/Pets.QA/careRequest.html");

            //Verify Email link
            var emailLink = contactPage.GetEmailLink();
            emailLink.ShouldBe("mailto:vova64@gmail.com");

            //Verify Envelope image
            var envelopeImage = contactPage.GetEnvelopeImage();
            envelopeImage.ShouldBe("http://nitro.duckdns.org/Pets.QA/images/mail.png");
            
            driver.Quit();
        }
    }
}
