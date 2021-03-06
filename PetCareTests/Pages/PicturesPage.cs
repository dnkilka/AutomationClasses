﻿using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using PetCareTests;
using PetCareTests.Configuration;

namespace PetCareTest.Pages
{
    public class PicturesPage
    {
        private IWebDriver _driver;
        public PicturesPage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement PicturesHeader => _driver.FindElement(By.XPath("//h1[contains(., 'Pictures')]"));
        public IWebElement FirstParagraph => _driver.FindElement(By.XPath("//div[contains(@class, 'pictures-par')]//p")); // By.XPath("//p[contains(.,'I can take care')]")
        public List<IWebElement> AllImagesList => _driver.FindElements(By.TagName("img")).ToList();
        
        public string GetHeaderText()
        {
            return PicturesHeader.Text;
        }

        public string GetFirstParagraphText()
        {
	        var text = FirstParagraph.Text;
	        Logger.Log.Info($"The first paragraph text was: '{text}'");
			return text;
        }

        public List<string> GetImagesSources()
        {
            var imagesSources = new List<string>();
            var imagesList = AllImagesList;
            for (int i = 0; i < imagesList.Count; i++)
            {
                var webElement = imagesList[i];
                var source = webElement.GetAttribute("src").Replace(Config.GetURL("AlexsPetsURL"), string.Empty);
                imagesSources.Add(source);
            }

            return imagesSources;
        }
    }
}