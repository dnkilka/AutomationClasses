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

            //Fill out inputs
            driver.FindElement(By.Id("firstName")).SendKeys("Iryna");
            driver.FindElement(By.Name("lastName")).SendKeys("Xxx");
            driver.FindElement(By.ClassName("phoneNumber")).SendKeys("2244225588");
            driver.FindElement(By.XPath("//label[.='Email']/parent::div[1]/following-sibling::div[1]//input")).SendKeys("someEmail.com");

            //Click Animal Type checkboxes
            driver.FindElement(By.Id("cat")).Click();
            var catQuantitySelect = new SelectElement(driver.FindElement(By.Id("catQuantity")));
            catQuantitySelect.SelectByText("2");

            driver.FindElement(By.Id("other")).Click();
            var otherQuantitySelect = new SelectElement(driver.FindElement(By.Id("otherQuantity")));
            otherQuantitySelect.SelectByText("3+");

            //Visits per day
            driver.FindElement(By.Id("visitSeveralTimesPerDay")).Click();

            //Comments
            driver.FindElement(By.Id("comments")).SendKeys("Please be quiet, our spiders are easily scared");

            //Click Request button
            driver.FindElement(By.Id("requestButton")).Click();

            driver.Quit();
        }
    }
}
