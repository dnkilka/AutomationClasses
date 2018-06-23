using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using PetCareTests.Configuration;

namespace PetCareTests.Selenium
{
	public class DriverUtils
	{
		public static IWebDriver CreateDriver()
		{
			var browser = Config.GetBrowser().ToUpper();
			if (browser == "CHROME")
			{
				return new ChromeDriver();
			}
			if (browser == "IE")
			{
				var options = new InternetExplorerOptions
				{
					IgnoreZoomLevel = true,
				};
				return new InternetExplorerDriver(options);
			}
			if (browser == "FF")
			{
				return new FirefoxDriver();
			}
			throw new NotImplementedException($"The browser {browser} is not supported");
		}
	}
}
