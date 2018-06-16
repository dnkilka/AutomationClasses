using OpenQA.Selenium;

namespace PetCareTests.Pages
{
    public class LandingPage
    {
        private IWebDriver _driver;

        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement LandingPageHeader => _driver.FindElement(By.XPath("//h1[contains(., 'Alex's Pet Business')]"));
        public IWebElement KittenHeader => _driver.FindElement(By.ClassName("logo"));
        public IWebElement Paragraph1 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p"));
        public IWebElement Paragraph2 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p[2]"));
        public IWebElement Paragraph3 => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p[3]"));
        public IWebElement ContactLink => _driver.FindElement(By.XPath("//div[@class = 'par-size']/p[3]/a"));
        public IWebElement CatImage => _driver.FindElement(By.XPath("//p/img[@src = 'images/hcat.png']"));
        public IWebElement DogImage => _driver.FindElement(By.XPath("//p/img[@src = 'images/dog.png']"));
    }
}