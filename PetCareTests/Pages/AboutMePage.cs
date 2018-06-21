using OpenQA.Selenium;
using System;

namespace PetCareTests.Pages
{
    public class AboutMePage
    {
        private IWebDriver _driver;

        public AboutMePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AboutMePageHeader => _driver.FindElement(By.XPath("//h1[contains(., 'About Me')]"));
        public IWebElement Paragraph1 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p"));
        public IWebElement Paragraph2 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p[2]"));

        public string GetHeaderText()
        {
            return AboutMePageHeader.Text;
        }
    }
}

