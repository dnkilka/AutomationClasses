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
    class CareRequestTest
    {
        [Test]
        public void CareRequest_Test()
        {
            IWebDriver driver = DriverUtils.CreateDriver();
	        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

			// Open Landing Page
			var landingPage = URLs.OpenUrl(driver);
           
			//Open Care Request page
            var careRequestPage = landingPage.ClickCareRequestLink();

            var customer = new Person();
            var catsNumber = "2";
            var otherNumber = "3+";
            var visitsPerDay = "2";
            var comment = "Please be quiet, our spiders are easily scared";

            //Fill out inputs
            careRequestPage.FillOutContactInformation(customer);

            //Click Animal Type checkboxes
            careRequestPage.RequestCatCare(catsNumber);
            careRequestPage.RequestOtherCare(otherNumber);

            //Visits per day
            careRequestPage.SetVisitsPerDay(visitsPerDay);

            //Comments
            careRequestPage.FillOutComments(comment);

			//Open Request summary page
	        RequestSummaryPage requestSummaryPage = careRequestPage.ClickRequestButton();

            //Verify Page opened by checking page element is visible
            Assert.IsTrue(requestSummaryPage.IsSummaryBlockDisplayed());
            requestSummaryPage.IsSummaryBlockDisplayed().ShouldBeTrue();

            //Verify Header text
            var header = requestSummaryPage.PageHeader.Text;
            Assert.AreEqual("Request Summary", header);
            header.ShouldBe("Request Summary");

            //Verify contact info
            VerifyContactInformation(requestSummaryPage, customer);

	        //Verify all other information is populated correctly
            VerifyOtherInformation(requestSummaryPage, catsNumber, otherNumber, visitsPerDay, comment);
	        string[] data = { $"{catsNumber} cat(s)", $"{otherNumber} other animal(s)", $"{visitsPerDay} visits per day are required.", comment };
	        VerifyOtherInformationAlternative(requestSummaryPage, data);
			
	        //Click Close button and verify the page was closed
			requestSummaryPage.CloseButton.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(requestSummaryPage.IsSummaryBlockDisplayed());
            requestSummaryPage.IsSummaryBlockDisplayed().ShouldBeFalse();
            
            driver.Quit();
        }

	    private static void VerifyOtherInformation(RequestSummaryPage requestSummaryPage, string catsNumber, string otherNumber,
		    string visitsPerDay, string comment)
	    {
		    var allText = requestSummaryPage.ModalContent.Text;
		    Assert.IsTrue(allText.Contains($"{catsNumber} cat(s)"));
		    allText.Contains($"{catsNumber} cat(s)").ShouldBeTrue();
		    Assert.IsTrue(allText.Contains($"{otherNumber} other animal(s)"));
		    Assert.IsTrue(allText.Contains($"{visitsPerDay} visits per day are required."));
		    Assert.IsTrue(allText.Contains(comment));
	    }

	    private static void VerifyOtherInformationAlternative(RequestSummaryPage requestSummaryPage, string [] data)
	    {
		    var allText = requestSummaryPage.ModalContent.Text;

		    for (var i = 0; i < data.Length; i++)
		    {
				Console.WriteLine("Checking presence of " + data[i]);
			    allText.Contains(data[i]).ShouldBeTrue();
			}
	    }

		private static void VerifyContactInformation(RequestSummaryPage requestSummaryPage, Person person)
		{
		    Assert.AreEqual(person.FirstName, requestSummaryPage.GetFirstName());
		    Assert.AreEqual(person.LastName, requestSummaryPage.GetLastName());
		    Assert.AreEqual(person.Phone, requestSummaryPage.GetPhoneNumber());
		    Assert.AreEqual(person.Email, requestSummaryPage.GetEmail());
	    }
    }
}
