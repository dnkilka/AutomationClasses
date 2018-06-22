using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PetCareTests.Pages
{
    public class ContactPage
    {
        private IWebDriver _driver;
        
        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ContactHeader => _driver.FindElement(By.TagName("h1"));
        public IWebElement ContactEntireContent => _driver.FindElement(By.XPath("//div[@class='contact']"));
        public IWebElement CareRequestLink => _driver.FindElement(By.XPath("//div[@class='contact']//a[@href='careRequest.html']"));
        public IWebElement EmailLink => _driver.FindElement(By.XPath("//div[@class='contact']//a[@href='mailto:vova64@gmail.com']"));
        public IWebElement EnvelopeImage => _driver.FindElement(By.XPath("//img[@src='images/mail.png']"));


        public string GetHeaderTitle()
        {
            return ContactHeader.Text;
        }

        public string GetEntireContent()
        {
            return ContactEntireContent.Text;
        }

        public string GetCareRequestLink()
        {
            return CareRequestLink.GetAttribute("href");
        }

        public string GetEmailLink()
        {
            return EmailLink.GetAttribute("href");
        }

        public string GetEnvelopeImage()
        {
            return EnvelopeImage.GetAttribute("src");
        }
    }
}
