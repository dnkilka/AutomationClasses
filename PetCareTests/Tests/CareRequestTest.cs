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
        public void Test()
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

            //Comments
            driver.FindElement(By.Id("comments")).SendKeys(comment);

            //Click Request button
            driver.FindElement(By.Id("requestButton")).Click();

            driver.Quit();
        }
    }
}
