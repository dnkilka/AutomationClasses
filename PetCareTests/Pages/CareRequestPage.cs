using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PetCareTests.Pages
{
    public class CareRequestPage
    {
        private IWebDriver _driver;

        // Bad approach (a), because the code will try to find the elements every time when the page is created.
        // This is bad, because 
        // - sometimes elements appear when you perform some actions on the page
        // - you might not need all page elements
        //private IWebElement FirstName_Input;

        public CareRequestPage(IWebDriver driver)
        {
            _driver = driver;

            // (a) continue:
            //FirstName_Input = _driver.FindElement(By.Id("firstName"));
        }

//	    public void SetDriver(IWebDriver newValue)
//	    {
//		    _driver = newValue;
//	    }

        // Good approach, but difficult syntax
        /*private IWebElement FirstNameInput
         { get
            {
                return _driver.FindElement(By.Id("firstName"));
            }
        }*/

        // Good approach with good syntax
        private IWebElement FirstNameInput => _driver.FindElement(By.Id("firstName"));
        private IWebElement LastNameInput => _driver.FindElement(By.Name("lastName"));
        private IWebElement PhoneNumberInput => _driver.FindElement(By.ClassName("phoneNumber"));
        private IWebElement EmailInput => _driver.FindElement(By.XPath("//div[@id='emailContainer']/input"));
        private IWebElement CatCheckbox => _driver.FindElement(By.Id("cat"));
        private SelectElement CatQuantityDropdown => new SelectElement(_driver.FindElement(By.Id("catQuantity")));
        private IWebElement OtherCheckbox => _driver.FindElement(By.Id("other"));
        private SelectElement OtherQuantityDropdown => new SelectElement(_driver.FindElement(By.Id("otherQuantity")));
        private IWebElement OneVisitPerDayRadio => _driver.FindElement(By.Id("visitOneTimePerDay"));
        private IWebElement SeveralVisitsPerDayRadio => _driver.FindElement(By.Id("visitSeveralTimesPerDay"));
        private SelectElement VisitsPerDayDropdown => new SelectElement(_driver.FindElement(By.Id("visitsPerDay")));
        private IWebElement CommentsTextArea => _driver.FindElement(By.Id("comments"));
        private IWebElement SendRequestButton => _driver.FindElement(By.Id("requestButton"));

	
        public void FillOutContactInformation(string firstName, string lastName, string phone, string email)
        {
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            PhoneNumberInput.SendKeys(phone);
            EmailInput.SendKeys(email);
        }

        public void RequestCatCare(string numberOfCats)
        {
            CatCheckbox.Click();
            CatQuantityDropdown.SelectByText(numberOfCats);
        }

        public void RequestOtherCare(string numberOfOthers)
        {
            OtherCheckbox.Click();
            OtherQuantityDropdown.SelectByText(numberOfOthers);
        }

        public void SetVisitsPerDay(string numberOfVisits)
        {
            if(numberOfVisits == "1")
            {
                OneVisitPerDayRadio.Click();
            }
            else
            {
                SeveralVisitsPerDayRadio.Click();
                VisitsPerDayDropdown.SelectByText(numberOfVisits);
            }
        }

        public void FillOutComments(string comment)
        {
            CommentsTextArea.SendKeys(comment);
        }

        public RequestSummaryPage ClickRequestButton()
        {
            SendRequestButton.Click();
	        return new RequestSummaryPage(_driver);
        }
    }
}
