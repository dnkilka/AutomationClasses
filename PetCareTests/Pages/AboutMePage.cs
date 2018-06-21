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

        public IWebElement AboutMeHeader => _driver.FindElement(By.XPath("//h1[contains(., 'About Me')]"));
        public IWebElement AllText => _driver.FindElement(By.XPath("//div[@class = 'par-size']"));
        public IWebElement Paragraph1 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p"));
        public IWebElement Paragraph2 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p[2]"));

        public string paragraphsText = "Hey! My name is Alex and I am 12 years old. I absolutely LOVE animals! I have a lot of experience with pets. " +
            "I have 2 cats that I feed and take care of daily. I have had a hamster and fish in addition to my 2 cats. I also had 14 caterpillars!" +
            "When my family friends go out of town, they trust me with their pets.I have created this website to have a chance to take care of your pet." +
            "I am really looking forward to hearing from you!";
    }
}

