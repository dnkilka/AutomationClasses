using OpenQA.Selenium;

namespace PetCareTests.Pages
{
    public class RequestSummaryPage
    {
        private IWebDriver _driver;

        public RequestSummaryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement ModalContent => _driver.FindElement(By.ClassName("modal-content"));
        public IWebElement PageHeader => _driver.FindElement(By.Id("myModalLabel"));
        public IWebElement SummaryBlock => _driver.FindElement(By.ClassName("summaryBlock"));
        public IWebElement FirstNameRecord => _driver.FindElement(By.XPath("//div[contains(.,'First Name:') and (contains(@class, 'summaryBlock'))]"));
        public IWebElement LastNameRecord => _driver.FindElement(By.XPath("//div[contains(.,'Last Name:') and (contains(@class, 'summaryBlock'))]"));
        public IWebElement PhoneNumberRecord => _driver.FindElement(By.XPath("//div[contains(.,'Phone') and (contains(@class, 'summaryBlock'))]"));
        public IWebElement EmailRecord => _driver.FindElement(By.XPath("//div[contains(.,'Email') and (contains(@class, 'summaryBlock'))]"));
        public IWebElement CloseButton => _driver.FindElement(By.XPath("//button[.='Close']"));

	    public string GetFirstName()
	    {
		    return FirstNameRecord.Text.Replace("First Name: ", "");
		}

	    public string GetLastName()
	    {
		    return LastNameRecord.Text.Replace("Last Name: ", "");
	    }

	    public string GetPhoneNumber()
	    {
		    return PhoneNumberRecord.Text.Replace("Phone #: ", "");

	    }

	    public string GetEmail()
	    {
		    return EmailRecord.Text.Replace("Email: ", "");
		}

	    public bool IsSummaryBlockDisplayed()
	    {
		    return SummaryBlock.Displayed;
	    }
	}
}
