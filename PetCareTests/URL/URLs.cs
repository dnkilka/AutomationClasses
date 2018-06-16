using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PetCareTests.Configuration;
using PetCareTests.Pages;

namespace PetCareTests.URL
{
	class URLs
	{
		public static LandingPage OpenUrl(IWebDriver driver)
		{
			driver.Navigate().GoToUrl(Config.GetURL("AlexsPetsURL"));
			return new LandingPage(driver);	
		}
	}
}
