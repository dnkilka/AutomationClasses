using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Shouldly;
using System;
using PetCareTest.Pages;
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

	        try
	        {
				// Open Landing Page
				var landingPage = URLs.OpenUrl(driver);

				//Open Care Request page
		        var navigationMenu = new Navigation_Menu(driver);
		        var careRequestPage = navigationMenu.ClickCareRequestLink();

				var customer = new Customer();
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
				var requestSummaryPage = careRequestPage.ClickRequestButton();

				//Verify Page opened by checking page element is visible
				requestSummaryPage.IsSummaryBlockDisplayed().ShouldBeTrue();

				//Verify Header text
				var header = requestSummaryPage.PageHeader.Text;
				header.ShouldBe("Request Summary");

				//Verify contact info
				VerifyContactInformation(requestSummaryPage, customer);

				//Verify all other information is populated correctly
				string[] data = { $"{catsNumber} cat(s)", $"{otherNumber} other animal(s)", $"{visitsPerDay} visits per day are required.", comment };
				VerifyOtherInformation(requestSummaryPage, data);

				//Click Close button and verify the page was closed
				requestSummaryPage.CloseButton.Click();
				Thread.Sleep(1000);
				Assert.IsFalse(requestSummaryPage.IsSummaryBlockDisplayed());
				requestSummaryPage.IsSummaryBlockDisplayed().ShouldBeFalse();
			}
	        catch (Exception e)
	        {
				Console.WriteLine(e);
		        throw;
	        }
	        finally
	        {
		        driver.Quit();
			}
        }

	    private static void VerifyOtherInformation(RequestSummaryPage requestSummaryPage, string [] data)
	    {
		    var allText = requestSummaryPage.ModalContent.Text;

		    for (var i = 0; i < data.Length; i++)
		    {
				Console.WriteLine("Checking presence of " + data[i]);
			    allText.Contains(data[i]).ShouldBeTrue();
			}
	    }

		private static void VerifyContactInformation(RequestSummaryPage requestSummaryPage, Customer customer)
	    {
		    Assert.AreEqual(customer.FirstName, requestSummaryPage.GetFirstName());
		    Assert.AreEqual(customer.LastName, requestSummaryPage.GetLastName());
		    Assert.AreEqual(customer.PhoneNumber, requestSummaryPage.GetPhoneNumber());
		    Assert.AreEqual(customer.Email, requestSummaryPage.GetEmail());
	    }
    }
}
