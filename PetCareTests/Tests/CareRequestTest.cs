using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Shouldly;
using System;
using PetCareTests.Pages;

namespace PetCareTests.Tests
{
    [TestFixture]
    class CareRequestTest
    {
        [Test]
        public void CareRequest_Test()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://nitro.duckdns.org/Pets/careRequest.html");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var careRequestPage = new CareRequestPage(driver);

            var customerFirstName = "Iryna";
            var customerLastName = "Shch";
            var customerPhoneNumber = "2244225588";
            var customerEmail = "someEmail@gmail.com";
            var catsNumber = "2";
            var otherNumber = "3+";
            var visitsPerDay = "2";
            var comment = "Please be quiet, our spiders are easily scared";

            //Fill out inputs
            careRequestPage.FillOutContactInformation(customerFirstName, customerLastName, customerPhoneNumber, customerEmail);

            //Click Animal Type checkboxes
            careRequestPage.RequestCatCare(catsNumber);
            careRequestPage.RequestOtherCare(otherNumber);

            //Visits per day
            careRequestPage.SetVisitsPerDay(visitsPerDay);

            //Comments
            careRequestPage.FillOutComments(comment);

            //Click Request button
            careRequestPage.ClickRequestButton();

            //Verify data on the Request Summary pop-up
            var requestSummaryPage = new RequestSummaryPage(driver);

            //Verify Page opened by checking page element is visible
            Assert.IsTrue(requestSummaryPage.SummaryBlock.Displayed);
            requestSummaryPage.SummaryBlock.Displayed.ShouldBeTrue();

            //Verify Header text
            var header = requestSummaryPage.PageHeader.Text;
            Assert.AreEqual("Request Summary", header);
            header.ShouldBe("Request Summary");

            //Verify contact info
            var firstName = requestSummaryPage.FirstNameRecord.Text.Replace("First Name: ", "");
            Assert.AreEqual(customerFirstName, firstName);
            var lastName = requestSummaryPage.LastNameRecord.Text.Replace("Last Name: ", "");
            Assert.AreEqual(customerLastName, lastName);
            var phoneNumber = requestSummaryPage.PhoneNumberRecord.Text.Replace("Phone #: ", "");
            Assert.AreEqual(customerPhoneNumber, phoneNumber);
             var email = requestSummaryPage.EmailRecord.Text.Replace("Email: ", "");
            Assert.AreEqual(customerEmail, email);

            //Verify all other information is populated correctly
            var allText = requestSummaryPage.ModalContent.Text;
            Assert.IsTrue(allText.Contains($"{catsNumber} cat(s)"));
            allText.Contains($"{catsNumber} cat(s)").ShouldBeTrue();
            Assert.IsTrue(allText.Contains($"{otherNumber} other animal(s)"));
            Assert.IsTrue(allText.Contains($"{visitsPerDay} visits per day are required."));
            Assert.IsTrue(allText.Contains(comment));

            //Click Close button and verify the page was closed
            requestSummaryPage.CloseButton.Click();
            Thread.Sleep(1000);
            Assert.IsFalse(requestSummaryPage.SummaryBlock.Displayed);
            requestSummaryPage.SummaryBlock.Displayed.ShouldBeFalse();
            
            driver.Quit();
        }
    }
}
