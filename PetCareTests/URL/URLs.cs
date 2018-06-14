using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PetCareTests.Configuration;

namespace PetCareTests.URL
{
	class URLs
	{
		public static void OpenUrl(IWebDriver driver)
		{
			driver.Navigate().GoToUrl(Config.GetURL("AlexsPetsURL"));
		}
	}
}
