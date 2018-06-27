using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System;
using Bogus;
using dnk.log2html.Support;
using PetCareTests.Pages;
using PetCareTests.Selenium;
using PetCareTests.URL;
using PetCareTests.Verification;

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
	        TestWrapper.Test(driver, () =>
	        {
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
	            requestSummaryPage.IsSummaryBlockDisplayed().ShouldBeTrue("Summary Block is Displayed");

	            //Verify Header text
	            var header = requestSummaryPage.PageHeader.Text;
	            header.ShouldBe("Request Summary", "Header");

	            //Verify contact info
	            VerifyContactInformation(requestSummaryPage, customer);

		        //Verify all other information is populated correctly
	            VerifyOtherInformation(requestSummaryPage, catsNumber, otherNumber, visitsPerDay, comment);
		        string[] data = { $"{catsNumber} cat(s)", $"{otherNumber} other animal(s)", $"{visitsPerDay} visits per day are required.", comment };
		        VerifyOtherInformationAlternative(requestSummaryPage, data);
				
		        //Click Close button and verify the page was closed
				requestSummaryPage.CloseButton.Click();
	            Thread.Sleep(1000);
	            requestSummaryPage.IsSummaryBlockDisplayed().ShouldBeFalse("Summary Block is not displayed");

			});
		}

	    private static void VerifyOtherInformation(RequestSummaryPage requestSummaryPage, string catsNumber, string otherNumber,
		    string visitsPerDay, string comment)
	    {
		    var allText = requestSummaryPage.ModalContent.Text;
		    allText.Contains($"{catsNumber} cat(s)").ShouldBeTrue("Cats number");
		    allText.Contains($"{otherNumber} other animal(s)").ShouldBeTrue("Other Animals");
		    allText.Contains($"{visitsPerDay} visits per day are required.").ShouldBeTrue("Visits per day");
		    allText.Contains(comment).ShouldBeTrue("Comment");
	    }

	    private static void VerifyOtherInformationAlternative(RequestSummaryPage requestSummaryPage, string [] data)
	    {
		    var allText = requestSummaryPage.ModalContent.Text;

		    for (var i = 0; i < data.Length; i++)
		    {
				Logger.Log.Info("Checking presence of " + data[i]);
			    allText.Contains(data[i]).ShouldBeTrue("");
			}
	    }

		private static void VerifyContactInformation(RequestSummaryPage requestSummaryPage, Person person)
		{
			requestSummaryPage.GetFirstName().ShouldBe(person.FirstName, "First name");
			requestSummaryPage.GetLastName().ShouldBe(person.LastName, "Last name");
			requestSummaryPage.GetPhoneNumber().ShouldBe(person.Phone, "Phone");
			requestSummaryPage.GetEmail().ShouldBe(person.Email, "Email");
	    }
    }
}
