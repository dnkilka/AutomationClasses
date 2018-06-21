﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<IWebElement> AllImages => _driver.FindElements(By.TagName("img")).ToList();

        public string GetHeaderText()
        {
            return PicturesHeader.Text;
        }

        public string GetFirstParagraphText()
        {
            return FirstParagraph.Text;
        }
    }
}