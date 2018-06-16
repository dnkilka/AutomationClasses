using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PetCareTests.Pages
{
    public class PricesPage
    {
        private IWebDriver _driver;
               
        public PricesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement PricesHeader => _driver.FindElement(By.XPath("//h1[contains (.,'Prices')]")); 
        private IWebElement PricesParagraph => _driver.FindElement(By.XPath("//div[@class='par-size']/ul/p")); 
        private IWebElement PricesList => _driver.FindElement(By.XPath("//div[@class='par-size']/ul/li")); 
        
    }
}
