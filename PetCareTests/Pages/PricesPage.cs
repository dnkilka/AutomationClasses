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

        public IWebElement PricesHeader => _driver.FindElement(By.XPath("//h1[contains (.,'Prices')]")); 
        public IWebElement PricesParagraph => _driver.FindElement(By.XPath("//div[@class='par-size']/ul/p")); 
        public IWebElement PricesList => _driver.FindElement(By.XPath("//div[@class='par-size']/ul/li"));


        public string GetHeaderTitle()
        {
            return PricesHeader.Text;
        }


        public string GetFirstParagraph()
        {
            return PricesParagraph.Text;
        }


        public string GetPricesList()
        {
            return PricesList.Text;
        }          
    }
}
