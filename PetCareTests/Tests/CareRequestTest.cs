using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using Shouldly;
using System;
using OpenQA.Selenium.Support.UI;

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

            var customerFirstName = "Iryna";
            var customerLastName = "Shch";
            var customerPhoneNumber = "2244225588";
            var customerEmail = "someEmail@gmail.com";
            var catsNumber = "2";
            var otherNumber = "3+";
            var visitsPerDay = "2";
            var comment = "Please be quiet, our spiders are easily scared";

            //Fill out inputs
            driver.FindElement(By.Id("firstName")).SendKeys(customerFirstName);
            driver.FindElement(By.Name("lastName")).SendKeys(customerLastName);
            driver.FindElement(By.ClassName("phoneNumber")).SendKeys(customerPhoneNumber);
            driver.FindElement(By.XPath("//div[@id='emailContainer']/input")).SendKeys(customerEmail);

            //Click Animal Type checkboxes
            driver.FindElement(By.Id("cat")).Click();
            var catQuantitySelect = new SelectElement(driver.FindElement(By.Id("catQuantity")));
            catQuantitySelect.SelectByText(catsNumber);

            driver.FindElement(By.Id("other")).Click();
            var otherQuantitySelect = new SelectElement(driver.FindElement(By.Id("otherQuantity")));
            otherQuantitySelect.SelectByText(otherNumber);

            //Visits per day
            driver.FindElement(By.Id("visitSeveralTimesPerDay")).Click();
			var visitQuantitySelect = new SelectElement(driver.FindElement(By.Id("visitsPerDay")));
            otherQuantitySelect.SelectByText(visitsPerDay);

            //Comments
            driver.FindElement(By.Id("comments")).SendKeys(comment);

            //Click Request button
            driver.FindElement(By.Id("requestButton")).Click();

            //Verify data on the Request Summary pop-up
            Assert.IsTrue(driver.FindElement(By.ClassName("summaryBlock")).Displayed);
            driver.FindElement(By.ClassName("summaryBlock")).Displayed.ShouldBeTrue();

            var header = driver.FindElement(By.Id("myModalLabel")).Text;
            Assert.AreEqual("Request Summary", header);
            header.ShouldBe("Request Summary");

            var firstName = driver.FindElement(By.XPath("//div[contains(.,'First Name:') and (contains(@class, 'summaryBlock'))]")).Text.Replace("First Name: ", "");
            Assert.AreEqual(customerFirstName, firstName);

            var lastName = driver.FindElement(By.XPath("//div[contains(.,'Last Name:') and (contains(@class, 'summaryBlock'))]")).Text.Replace("Last Name: ", "");
            Assert.AreEqual(customerLastName, lastName);

            var phoneNumber = driver.FindElement(By.XPath("//div[contains(.,'Phone') and (contains(@class, 'summaryBlock'))]")).Text.Replace("Phone #: ", "");
            Assert.AreEqual(customerPhoneNumber, phoneNumber);

            var email = driver.FindElement(By.XPath("//div[contains(.,'Email') and (contains(@class, 'summaryBlock'))]")).Text.Replace("Email: ", "");
            Assert.AreEqual(customerEmail, email);

            var allText = driver.FindElement(By.ClassName("modal-content")).Text;
            Assert.IsTrue(allText.Contains($"{catsNumber} cat(s)"));
            allText.Contains($"{catsNumber} cat(s)").ShouldBeTrue();
            Assert.IsTrue(allText.Contains($"{otherNumber} other animal(s)"));
            Assert.IsTrue(allText.Contains($"{visitsPerDay} visits per day are required."));
            Assert.IsTrue(allText.Contains(comment));

            //Click Close button
            driver.FindElement(By.XPath("//button[.='Close']")).Click();
            Thread.Sleep(1000);
            Assert.IsFalse(driver.FindElement(By.ClassName("summaryBlock")).Displayed);
            driver.FindElement(By.ClassName("summaryBlock")).Displayed.ShouldBeFalse();
            
            driver.Quit();
        }
    }
}
