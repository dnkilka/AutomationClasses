using OpenQA.Selenium;
using PetCareTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCareTest.Pages
{
    public class Navigation_Menu
    {
        private IWebDriver _driver;
        public Navigation_Menu(IWebDriver driver)
        {
            _driver = driver;

        }

        public IWebElement AboutMe => _driver.FindElement(By.LinkText("About Me"));
        public IWebElement Contact => _driver.FindElement(By.LinkText("Contact"));
        public IWebElement Pictures => _driver.FindElement(By.LinkText("Pictures"));
        public IWebElement Prices => _driver.FindElement(By.LinkText("Prices"));
        public IWebElement CareRequestLink => _driver.FindElement(By.LinkText("Care Request"));

        public PicturesPage ClickPicturesLink()
        {
            Pictures.Click();
            return new PicturesPage(_driver);
        }

        public ContactMePage ClickContactMeLink()
        {
            Contact.Click();
            return new ContactMePage(_driver);
        }

        public AboutMePage ClickAboutMeLink()
        {
            AboutMe.Click();
            return new AboutMePage(_driver);
        }

        public PricesPage ClickPricesLink()
        {
            Prices.Click();
            return new PricesPage(_driver);
        }

        public CareRequestPage ClickCareRequestLink()
        {
            CareRequestLink.Click();
            return new CareRequestPage(_driver);
        }
    }
}
