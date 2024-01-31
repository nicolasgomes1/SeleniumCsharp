using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BrowserSetup
{
    public class TestSetup
    {
        private IWebDriver driver;

        public IWebDriver Driver { get => driver; set => driver = value; }

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Setting up for each test - Opening Chrome");

            ChromeOptions options = new();
            options.AddArgument("--start-maximized"); // Maximize the Chrome window

            Driver = new ChromeDriver(options);

            // Set an implicit wait timeout
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Tearing down for each test - Closing Chrome");
            Driver.Quit();
            Driver.Dispose();            
        }

        public void NavigateAndAssertUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
            // Assert that the current URL is as expected
            Assert.That(Driver.Url, Is.EqualTo(url));
        }

        public void AssertUrl(string url)
        {
            // Assert that the current URL is as expected
            Assert.That(Driver.Url, Is.EqualTo(url));
        }

        // Helper method for clicking an element by ID
        public void ClickElementById(string elementId)
        {
            IWebElement element = Driver.FindElement(By.Id(elementId));
            element.Click();
        }

        // Helper method to check if an element with a specific ID is visible
        public bool IsElementVisibleById(string elementId)
        {
            try
            {
                IWebElement element = Driver.FindElement(By.Id(elementId));
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickOnProductInNavigation(string productName)
        {
            // Click on an <a> element with the specified text within the <ol> with class "s-navigation"
            IWebElement element = Driver.FindElement(By.XPath($"//ol[@class='s-navigation']//a[contains(text(), '{productName}')]"));
            element.Click();
        }


        public void Sleep(int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
        }

        public void AcceptCookies()
        {
            if (IsElementVisibleById("onetrust-banner-sdk"))
            {
                // If visible, click on the element with ID "onetrust-accept-btn-handler"
                ClickElementById("onetrust-accept-btn-handler");
            }
        }
        public void DropDownOptions(string partialText)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            // Wait for the element with ID "products-popover" to be clickable
            IWebElement popoverElement = wait.Until(driver => driver.FindElement(By.Id("products-popover")));

            // Click on the element with partial text within the "products-popover" element
            wait.Until(driver =>
            {
                IWebElement specificTextElement = popoverElement.FindElement(By.XPath($".//*[contains(text(), '{partialText}')]"));
                specificTextElement.Click();
                return true;
            });
        }
    }
}


