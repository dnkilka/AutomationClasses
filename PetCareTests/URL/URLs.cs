using OpenQA.Selenium;
using PetCareTests.Configuration;
using PetCareTests.Pages;

namespace PetCareTests.URL
{
	class URLs
	{
		public static LandingPage OpenUrl(IWebDriver driver)
		{
			var url = Config.GetURL("AlexsPetsURL") + "index.html";
			Logger.Log.Info("Openning URL " + url);
			driver.Navigate().GoToUrl(url);
			return new LandingPage(driver);	
		}
	}
}
