using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PetCareTests.Pages
{
    public class ContactMePage
    {
        private IWebDriver _driver;
        
        public ContactMePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ContactHeader => _driver.FindElement(By.TagName("h1"));
        private IWebElement ContactEntireContent => _driver.FindElement(By.XPath("//div[@class='contact']"));
        private IWebElement CareRequestLink => _driver.FindElement(By.XPath("//div[@class='contact']//a[@href='careRequest.html']"));
        private IWebElement EmailLink => _driver.FindElement(By.XPath("//div[@class='contact']//a[@href='mailto:vova64@gmail.com']"));
        private IWebElement EnvelopeImage => _driver.FindElement(By.XPath("//img[@src='images/mail.png']"));

        public string GetHeaderText()
        {
            return ContactHeader.Text;
        }
    }
}
