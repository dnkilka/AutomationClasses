using System.Collections.Generic;
using System.Linq;
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
        public List<IWebElement> PricesList
        {
            get
            {
                return _driver.FindElements(By.XPath("//div[@class='par-size']/ul/li")).ToList();
            }
        }

        public List<string> GetPricesTexts()
        {
            var prices = new List<string>();
            var pricesList = PricesList;
            for (int i = 0; i < pricesList.Count; i++)
            {
                var webElement = pricesList[i];
                var price = webElement.Text;
                prices.Add(price);
            }

            return prices;
        }

        public string GetHeaderTitle()
        {
            return PricesHeader.Text;
        }


        public string GetFirstParagraph()
        {
            return PricesParagraph.Text;
        }


        //public string GetPricesList()
        //{
        //    return PricesList.Text;
        //}          
    }
}
