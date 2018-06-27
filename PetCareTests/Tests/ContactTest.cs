using NUnit.Framework;
using OpenQA.Selenium;
using System;
using dnk.log2html.Support;
using PetCareTests.Configuration;
using PetCareTests.Selenium;
using PetCareTests.URL;
using PetCareTests.Verification;

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
	        TestWrapper.Test(driver, () =>
	        {
				// Open Landing Page
				var landingPage = URLs.OpenUrl(driver);
           
				//Open Contact page
	            var contactPage = landingPage.ClickContactMeLink();
	                       
	            //Verify Header text
	            var header = contactPage.ContactHeader.Text;
	            header.ShouldBe("Contact Me", "Contact Me header");

	            //Verify Care Request link
	            var careRequestLink = contactPage.GetCareRequestLink();
	            careRequestLink.ShouldBe(Config.GetURL("AlexsPetsURL") + "careRequest.html", "URL");

	            //Verify Email link
	            var emailLink = contactPage.GetEmailLink();
	            emailLink.ShouldBe("mailto:vova64@gmail.com", "Email");

	            //Verify Envelope image
	            var envelopeImage = contactPage.GetEnvelopeImage();
	            envelopeImage.ShouldBe(Config.GetURL("AlexsPetsURL") + "images/mail.png", "Envelope");

			});
		}
    }
}
